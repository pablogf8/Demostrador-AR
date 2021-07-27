
namespace GoogleARCore.Examples.ObjectManipulation
{
    using GoogleARCore;
    using UnityEngine;


    public class ObjectManipulator : Manipulator
    {
        public Camera FirstPersonCamera;
        public GameObject ObjectPrefab;
        public GameObject ManipulatorPrefab;
        
        public int Instances;
        private int count = 0;

        public CanvasController CanvasController;

        protected override bool CanStartManipulationForGesture(TapGesture gesture)
        {
            if (gesture.TargetObject == null)
            {
                return true;
            }

            return false;
        }


        protected override void OnEndManipulation(TapGesture gesture)
        {
            if (gesture.WasCancelled)
            {
                return;
            }

            if (gesture.TargetObject != null)
            {
                return;
            }

            TrackableHit hit;
            TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon;

            if (Frame.Raycast(gesture.StartPosition.x, gesture.StartPosition.y, raycastFilter, out hit))
            {
                if (((hit.Trackable is DetectedPlane) &&
                    Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position,
                        hit.Pose.rotation * Vector3.up) < 0) || count >= Instances)
                {
                    Debug.Log("Hit at back of the current DetectedPlane");
                }
                else
                {
                    var gameObject = Instantiate(ObjectPrefab, hit.Pose.position, hit.Pose.rotation);
                    count++;
                    CanvasController.ActivateCanvas();
                    
                    var manipulator =
                        Instantiate(ManipulatorPrefab, hit.Pose.position, hit.Pose.rotation);

                    gameObject.transform.parent = manipulator.transform;

                    var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                    manipulator.transform.parent = anchor.transform;

                    manipulator.GetComponent<Manipulator>().Select();
                }
            }
        }
    }
}
