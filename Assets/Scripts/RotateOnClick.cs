using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    private NodeColourChange nodeChange;

    private void Start()
    {
        nodeChange = GetComponentInChildren<NodeColourChange>();
    }
    //Click left mouse button to rotate target
    public void OnMouseDown()
    {
        if(nodeChange.Check())
        {
            transform.Rotate(0, 0, 45);
        }
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
