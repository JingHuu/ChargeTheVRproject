using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColourChange : MonoBehaviour
{
    [SerializeField]
    private float lerpTime = 10f;
    private float time;
    private float previousAudioProgression;

    Renderer rend;

    private Vector4 _blue;
    private Vector4 _yellow;
    private Vector4 _brightorange;
    private Vector4 _darkorange;
    private float speed1;
    private float speed2;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        time = 0f;

        _blue = new Vector3(.3f, .7f, 1.5f);
        _yellow = new Vector3(.6f, .3f, 0);
        _darkorange = new Vector3(1f, .2f, 0f);
        _brightorange = new Vector3(2.5f, .7f, 0);
        speed1 = 0f;
        speed2 = 0.02f;

        rend.material.SetVector("_ColourIntensity", _blue); // initial emissive
        rend.material.SetFloat("_Speed1", speed1); //initial speed
        rend.material.SetFloat("_Speed2", speed2);
    }

    // Update is called once per frame
    void Update()
    {
        SphereEmmissiveChange();

        if (AudioManager.audioProgression != previousAudioProgression)
        {
            time = 0;
        }

        previousAudioProgression = AudioManager.audioProgression;
    }

    private void SphereEmmissiveChange()
    {
        time += Time.deltaTime;
        float t = time / lerpTime;

        Vector3 c = rend.material.GetVector("_ColourIntensity");
        float f1 = rend.material.GetFloat("_Speed1");
        float f2 = rend.material.GetFloat("_Speed2");

        if (AudioManager.audioProgression < 30f)
        {
            // blue yellow
            rend.material.SetVector("_ColourIntensity", Vector3.Lerp(c, _yellow, t));
            //rend.material.SetFloat("_Speed1", Mathf.Lerp(f1, 0.02f, t));
            //rend.material.SetFloat("_Speed2", Mathf.Lerp(f2, 0.05f, t));
            rend.material.SetFloat("_Speed1", 0.02f);
            rend.material.SetFloat("_Speed2", 0.05f);
        }
        else if (AudioManager.audioProgression < 60f)
        {
            // yellow darkO
            rend.material.SetVector("_ColourIntensity", Vector3.Lerp(c, _darkorange, t));
            //rend.material.SetFloat("_Speed1", Mathf.Lerp(f1, 0.05f, t));
            //rend.material.SetFloat("_Speed2", Mathf.Lerp(f2, 0.08f, t));
            rend.material.SetFloat("_Speed1", 0.05f);
            rend.material.SetFloat("_Speed2", 0.08f);
        }
        else if (AudioManager.audioProgression >= 60f)
        {
            // darkO brightO
            rend.material.SetVector("_ColourIntensity", Vector3.Lerp(c, _brightorange, t));
            //rend.material.SetFloat("_Speed1", Mathf.Lerp(f1, 0.08f, t));
            //rend.material.SetFloat("_Speed2", Mathf.Lerp(f2, 0.08f, t));
            rend.material.SetFloat("_Speed1", 0.08f);
            rend.material.SetFloat("_Speed2", 0.08f);
        }
        else
        {
            rend.material.SetVector("_ColourIntensity", _blue);
        }
        
    }
}
