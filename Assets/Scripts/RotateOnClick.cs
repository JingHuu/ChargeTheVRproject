using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    //public float x, y, z;

    //Click left mouse button to rotate target
    private void OnMouseDown()
    {
        transform.Rotate(45, 0, 0);
    }
    
    private void WhenTriggerPulled()
    {
        OVRInput.Controller activeController = OVRInput.GetActiveController();
        float indexTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);    
        if (indexTrigger != 0.0f)
        {
            transform.Rotate(0, 0, 0);
        }
    }
}
