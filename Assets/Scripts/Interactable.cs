using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{


    public void RotateNode()
    {
        transform.Rotate(45, 0, 0);

        /*OVRInput.Controller activeController = OVRInput.GetActiveController();
        float indexTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        if (indexTrigger != 0.0f)
        {
            transform.Rotate(45, 0, 0);
        }*/
    }


}
