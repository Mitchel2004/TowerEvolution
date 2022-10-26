using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitioning : MonoBehaviour
{
    private Animator cameraTransitioning;
    public bool isIn3D = true;

    void Start()
    {
        cameraTransitioning = Camera.main.GetComponent<Animator>();
    }

    public void TransitionCamera()
    {
        if (isIn3D)
        {
            cameraTransitioning.SetTrigger("to2D");
            isIn3D = false;
        }
        else
        {
            cameraTransitioning.SetTrigger("to3D");
            isIn3D = true;
        }
    }
}