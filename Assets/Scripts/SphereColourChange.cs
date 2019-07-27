using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColourChange : MonoBehaviour
{
    [SerializeField]
    private float lerpTime = 10f;
    private float time;

    Renderer rend;

    private Vector4 _blue;
    private Vector4 _yellow;
    private Vector4 _brightorange;
    private Vector4 _darkorange;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        time = 0f;

        _blue = new Vector4(.3f, .7f, 1.5f, 0f);
        _yellow = new Vector4(.6f, .3f, 0, 0);
        _darkorange = new Vector4(1f, .2f, 0f, 0f);
        _brightorange = new Vector4(2.5f, .7f, 0, 0);

        // initial emmissive colour
        rend.material.SetVector("_ColourIntensity", _blue);
    }

    // Update is called once per frame
    void Update()
    {
        SphereEmmissiveChange();
        /*time += Time.deltaTime;
        float t = time / lerpTime;

        rend.material.SetVector("_ColourIntensity", new Vector4(Mathf.Lerp(_blue.x, _yellow.x, t), Mathf.Lerp(_blue.y, _yellow.y, t), Mathf.Lerp(_blue.z, _yellow.z, t), Mathf.Lerp(_blue.w, _yellow.w, t)));
        */
    }

    private void SphereEmmissiveChange()
    {
        time += Time.deltaTime;
        float t = time / lerpTime;

        if (AudioManager.audioProgression > 9f)
        {
            rend.material.SetVector("_ColourIntensity", new Vector4(Mathf.Lerp(_blue.x, _yellow.x, t), Mathf.Lerp(_blue.y, _yellow.y, t), Mathf.Lerp(_blue.z, _yellow.z, t), Mathf.Lerp(_blue.w, _yellow.w, t)));
        }
        else if (AudioManager.audioProgression > 49f)
        {
            rend.material.SetVector("_ColourIntensity", new Vector4(Mathf.Lerp(_yellow.x, _darkorange.x, t), Mathf.Lerp(_yellow.y, _darkorange.y, t), Mathf.Lerp(_yellow.z, _darkorange.z, t), Mathf.Lerp(_yellow.w, _darkorange.w, t)));
        }
        else if (AudioManager.audioProgression > 59f)
        {
            rend.material.SetVector("_ColourIntensity", new Vector4(Mathf.Lerp(_darkorange.x, _brightorange.x, t), Mathf.Lerp(_darkorange.y, _brightorange.y, t), Mathf.Lerp(_darkorange.z, _brightorange.z, t), Mathf.Lerp(_darkorange.w, _brightorange.w, t)));
        }
        
    }
}
