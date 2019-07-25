using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInput : MonoBehaviour
{
    // specific available inputs
    // 
    //  - back trigger = PrimaryIndexTrigger
    //  - touchpad = PrimaryTouchpad/One
    //  - non menu button = Two
    
    // other things of note
    // this will give you the active controller:
    // OVRInput.Controller activeController = OVRInput.GetActiveController();
    //
    // controller also has access to Orientation/AngVelocity/AngAcceleration/Position/Acceleration
    // you can get any of these with specific get functions:
    // Orientation - OVRInput.GetLocalControllerRotation(activeController);
    // Angular Velocity - OVRInput.GetLocalControllerAngularVelocity(activeController);
    // Angular Acceleration - OVRInput.GetLocalControllerAngularAcceleration(activeController);
    // Position - OVRInput.GetLocalControllerPosition(activeController);
    // Acceleration - OVRInput.GetLocalControllerAcceleration(activeController);
    //
    // If you want specific x y coords for the touchpad you get them like this
    // OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
    
    
    // TO ACCESS ANY INPUT
    // you must use OVRInput.Button or OVRInput.Touch
    // variations:
    // OVRInput.Get
    // OVRInput.GetDown
    // OVRInput.GetUp
    // for Eg if you wanted the down input on the touchpad you must 
    // OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad);
    //
    // It looks like you can also get up/down/left/right inputs from dragging your finger from the centre of the
    // touchpad to the edge of the touchpad in the desired direction
    // it is done like this: (not 100% sure this will work but here's the input anyway)
    // up - OVRInput.Get(OVRInput.Button.Up);
    // down - OVRInput.Get(OVRInput.Button.Down);
    // left - OVRInput.Get(OVRInput.Button.Left);
    // right - OVRInput.Get(OVRInput.Button.Right);
    
    // OVRInput.GetControllerWasRecentered() exists and will give a true value when vr location is reset

    public GameObject controller;
    public GameObject visualDonut;

    private LineRenderer lineRend;
    private Vector3 lineStart;
    private Vector3 lineEnd;
    private RaycastHit hit;
    public float lineRendMaxDistance;

    private void Start()
    {
        lineRend = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineStart = controller.transform.position;
        lineEnd = lineStart + (controller.transform.forward * 3);
        
        lineRend.SetPosition(0, lineStart);
        lineRend.SetPosition(1, lineEnd);
        
        visualDonut.transform.position = hit.point;
        visualDonut.transform.LookAt(hit.point);

        if (Physics.Raycast(lineStart, controller.transform.forward, out hit, lineRendMaxDistance))
        {
            float alphaTime = Vector3.Distance(controller.transform.position, hit.point) / lineRendMaxDistance;
            
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.blue, alphaTime) },
                new[] { new GradientAlphaKey(0.8f, 0), new GradientAlphaKey(0, alphaTime) }
            );
            
            lineRend.colorGradient = gradient;
            lineEnd = hit.point;
            lineRend.SetPosition(1, lineEnd);
            visualDonut.SetActive(true);
        }
        else
        {
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 1) },
                new[] { new GradientAlphaKey(0.8f, 0), new GradientAlphaKey(0, 1) }
            );

            lineRend.colorGradient = gradient;
            visualDonut.SetActive(false);
        }

        if (hit.point == Vector3.zero) return;
        
        RotateOnClick rotateScript = hit.collider.gameObject.GetComponentInParent<RotateOnClick>();
        if (rotateScript != null && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            rotateScript.OnMouseDown();
        }
    }

}
