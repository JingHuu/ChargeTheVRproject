using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    //public float x, y, z;

    //Click left mouse button to rotate target
    public void OnMouseDown()
    {
        /*
        Transform[] temp = transform.GetComponentsInChildren<Transform>();

        //for loop
        for (int i = 0; i < temp.Length -1; i++)
        {
            transform.GetChild(i).rotation *= Quaternion.AngleAxis(45, transform.forward);
        }
       
        //transform.GetChild(4).rotation *= Quaternion.AngleAxis(45, transform.forward);

        */

        transform.Rotate(0, 0, 45);

        //AudioManager.rotate = .7f;    // this line is not doing what it should
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/NodeRotate", this.gameObject);
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
