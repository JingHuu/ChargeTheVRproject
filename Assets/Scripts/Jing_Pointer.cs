using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jing_Pointer : MonoBehaviour
{

    public float m_Distance = 10.0f;
    public LineRenderer m_LineRenderer = null; //save it for visual effects 
    public LayerMask m_EverythingMask = 0;
    public LayerMask m_InteractableMask = 0;
    public UnityAction<Vector3, GameObject> OnPointerUpdate = null;

    private Transform m_CurrentOrigin = null;
    private GameObject m_CurrentObject = null;

    private void Awake()
    {
        Jing_PlayerEvents.OnControllerSource += UpdateOrigin;
        Jing_PlayerEvents.OnTouchpadDown += ProcessTouchpadDown;
    }

    private void Start()
    {

    }

    private void OnDestroy()
    {
        Jing_PlayerEvents.OnControllerSource -= UpdateOrigin;
        Jing_PlayerEvents.OnTouchpadDown -= ProcessTouchpadDown;
    }

    private void Update()
    {
        Vector3 hitpoint = UpdateLine();

        m_CurrentObject = UpdatePointerStatus();

        if (OnPointerUpdate != null)
            OnPointerUpdate(hitpoint, m_CurrentObject);
    }

    private Vector3 UpdateLine()
    {
        //create ray
        RaycastHit hit = CreateRaycast(m_EverythingMask);

        //default end
        Vector3 endPosition = m_CurrentOrigin.position + (m_CurrentOrigin.forward * m_Distance);

        //check hit
        if (hit.collider != null)
            endPosition = hit.point;

        //set position
        m_LineRenderer.SetPosition(0, m_CurrentOrigin.position);
        m_LineRenderer.SetPosition(1, endPosition);

        return endPosition;
    }

    private void UpdateOrigin(OVRInput.Controller controller, GameObject controllerObject)
    {
        //set origin of pointer
        m_CurrentOrigin = controllerObject.transform;

        //is the laser visible? don't show if using gaze control
        if(controller == OVRInput.Controller.Touchpad)
        {
            m_LineRenderer.enabled = false;
        }
        else
        {
            m_LineRenderer.enabled = true;
        }

    }

    private RaycastHit CreateRaycast(int layer)
    {
        RaycastHit hit;
        Ray ray = new Ray(m_CurrentOrigin.position, m_CurrentOrigin.forward);
        Physics.Raycast(ray, out hit, m_Distance, layer);

        return hit;
    }

    private GameObject UpdatePointerStatus()
    {
        //create ray
        RaycastHit hit = CreateRaycast(m_InteractableMask);

        //check hit
        if (hit.collider)
            return hit.collider.gameObject;

        //return
        return null;

    }

    private void SetLineColor()
    {
        if (!m_LineRenderer)
            return;
        Color endColor = Color.white;
        endColor.a = 0.0f;

        m_LineRenderer.endColor = endColor;
    }

    private void ProcessTouchpadDown()
    {
        if (!m_CurrentObject)
            return;

        Interactable interactable = m_CurrentObject.GetComponent<Interactable>();
        interactable.RotateNode();
    }

}
