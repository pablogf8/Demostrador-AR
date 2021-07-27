namespace GoogleARCore.Examples.Common
{
    using System.Collections.Generic;
    using GoogleARCore;
    using UnityEngine;


    public class DetectedPlaneGenerator : MonoBehaviour
    {
        public GameObject DetectedPlanePrefab;

        private List<DetectedPlane> _newPlanes = new List<DetectedPlane>();

        public Material transparent; 
        public Material grid;

        bool search = true;


        public void OnTogglePlanes(bool toggle)
        {
            search = toggle;

            foreach (GameObject plane in GameObject.FindGameObjectsWithTag("plane"))
            {
                if (toggle)
                {
                    plane.GetComponent<MeshRenderer>().material = grid;
                }
                else
                {
                    plane.GetComponent<MeshRenderer>().material = transparent;
                }
            }
        }

        public void Update()
        {
            if (Session.Status != SessionStatus.Tracking)
            {
                return;
            }

            if (search) 
            {
                Session.GetTrackables<DetectedPlane>(_newPlanes, TrackableQueryFilter.New);
                for (int i = 0; i < _newPlanes.Count; i++)
                {
                    GameObject planeObject =
                        Instantiate(DetectedPlanePrefab, Vector3.zero, Quaternion.identity, transform);
                    planeObject.GetComponent<DetectedPlaneVisualizer>().Initialize(_newPlanes[i]);
                }
            }
        }
    }
}
