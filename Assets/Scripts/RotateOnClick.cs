using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    //public float x, y, z;
    private NodeColourChange nodeChange;

    private void Start()
    {
        nodeChange = GetComponentInChildren<NodeColourChange>();
    }
    //Click left mouse button to rotate target
    public void OnMouseDown()
    {
        
        if(!nodeChange.hasFired)
        {
            transform.Rotate(0, 0, 45);
        }
        

        AudioManager.rotate = .2f;    // this line is not doing what it should
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
