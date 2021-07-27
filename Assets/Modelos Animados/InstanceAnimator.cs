using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceAnimator : MonoBehaviour
{
    private GameObject instance;
    private Animator anim;


    void FindObject()
    {
        instance = GameObject.Find("SillaEscritorio");
        anim = instance.GetComponent<Animator>();
    }

    public void PlayRotar()
    {
        FindObject();
        anim.Play("Rotar", -1, 0f);
    }
    
    public void PlayElevar()
    {
        FindObject();
        anim.Play("Elevar", -1, 0f);
    }
    
    public void PlayInclinar()
    {
        FindObject();
        anim.Play("Inclinar", -1, 0f);
    }
}
