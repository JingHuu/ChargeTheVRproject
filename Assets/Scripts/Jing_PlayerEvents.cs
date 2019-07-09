using System.Collections;
using System.Collections.Generic;
using OVR.OpenVR;
using UnityEngine;
using UnityEngine.Events;

public class Jing_PlayerEvents : MonoBehaviour
{
    
    public delegate void TouchpadUp();
    public static event TouchpadUp OnTouchPadUp;
    
    public delegate void TouchpadDown();
    public static event TouchpadDown OnTouchPadDown;
    
    public delegate void ControllerSource(OVRInput.Controller control, GameObject obj);
    public static event ControllerSource OnControllerSource;
    
    
    public GameObject rightAnchor;
    public GameObject leftAnchor;
    public GameObject headAnchor;

    
    private Dictionary<OVRInput.Controller, GameObject> controllerSets = null;
    private OVRInput.Controller inputSource = OVRInput.Controller.None;
    private OVRInput.Controller controller= OVRInput.Controller.None;
    private bool inputActive = true;

    private void Awake()
    {
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDUnmounted += PlayerLost;

        controllerSets = CreateControllerSets();
    }

    private void OnDestroy()
    {
        OVRManager.HMDMounted -= PlayerFound;
        OVRManager.HMDUnmounted -= PlayerLost;
    }

    private void Update()
    {
        // check for active input
        if (!inputActive) return;
        
        // check for controller
        CheckForController();
        
        CheckInputSource();
        Input();
        
    }

    void CheckInputSource()
    {
        inputSource = UpdateSource(OVRInput.GetActiveController(), inputSource);
    }

    void CheckForController()
    {
        OVRInput.Controller controllerCheck = controller;

        // remote
        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            controllerCheck = OVRInput.Controller.LTrackedRemote;
        
        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
            controllerCheck = OVRInput.Controller.RTrackedRemote;
        
        if (OVRInput.IsControllerConnected(OVRInput.Controller.Touchpad)) // head
            controllerCheck = OVRInput.Controller.Touch;

        controller = UpdateSource(controllerCheck, controller);

    }
    
    void Input()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
            OnTouchPadDown?.Invoke();
        
        if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
            OnTouchPadUp?.Invoke();
       
    }

    private OVRInput.Controller UpdateSource(OVRInput.Controller check, OVRInput.Controller previous)
    {
        if (check == previous)
            return previous;

        GameObject controlObj = null;

        controllerSets.TryGetValue(check, out controlObj);

        if (controlObj == null) controlObj = headAnchor;

        OnControllerSource?.Invoke(check, controlObj);
        return check;
    }
    
    void PlayerFound()
    {
        inputActive = true;
    }

    void PlayerLost()
    {
        inputActive = false;
    }

    Dictionary<OVRInput.Controller, GameObject> CreateControllerSets()
    {
        Dictionary<OVRInput.Controller, GameObject> dict = new Dictionary<OVRInput.Controller, GameObject>()
        {
            {OVRInput.Controller.RTrackedRemote, rightAnchor },
            {OVRInput.Controller.LTrackedRemote, leftAnchor},
            {OVRInput.Controller.Touchpad, headAnchor}
        };
        
       
        return dict;
    }
}
