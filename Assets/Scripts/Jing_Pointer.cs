using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jing_Pointer : MonoBehaviour
{

    public float rayDistance = 1000;
    private LineRenderer lineRend;
    public LayerMask everythingMask = 0;
    public LayerMask interactableMask = 0;

    private Transform currentOrigin = null;
    
    private void Awake()
    {
        lineRend = GetComponent<LineRenderer>();
        
        Jing_PlayerEvents.OnControllerSource += UpdatePointerOrigin;
        Jing_PlayerEvents.OnTouchPadDown += ProcessTouchPadDown;
    }

    private void OnDestroy()
    {
        Jing_PlayerEvents.OnControllerSource -= UpdatePointerOrigin;
        Jing_PlayerEvents.OnTouchPadDown -= ProcessTouchPadDown;
    }

    private void Start()
    {
        SetLineColour();
    }

    private void Update()
    {
        Vector3 hitPoint = UpdateLine();
    }

    private Vector3 UpdateLine()
    {
        RaycastHit hit = CreateRaycast(everythingMask);

        Vector3 endPos = currentOrigin.position + (currentOrigin.forward * rayDistance);

        if (hit.collider != null)
            endPos = hit.point;
        
        lineRend.SetPosition(0, currentOrigin.position);
        lineRend.SetPosition(1, endPos);
        
        return endPos;
    }
    
    RaycastHit CreateRaycast(int layer)
    {
        RaycastHit hit;
        Ray ray = new Ray(currentOrigin.position, currentOrigin.forward);
        Physics.Raycast(ray, out hit, rayDistance, layer);
        
        return hit;
    }

    void SetLineColour()
    {
        if (!lineRend) return;
        
        Color endColour = Color.white;
        endColour.a = 0;

        lineRend.endColor = endColour;
    }
    
    void UpdatePointerOrigin(OVRInput.Controller control, GameObject obj)
    {
        currentOrigin = obj.transform;

        if (control == OVRInput.Controller.Touchpad)
            lineRend.enabled = false;
        else
            lineRend.enabled = true;
        
    }

    void ProcessTouchPadDown()
    {
        
    }
    
}
