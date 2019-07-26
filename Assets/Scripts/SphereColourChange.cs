using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColourChange : MonoBehaviour
{
    [SerializeField]
    private float lerpTime = 20f;
    private float time;

    Renderer rend;

    public Color blue;
    public Color yellow;
    public Color orange;
    public Color red;
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float t = time / lerpTime;

        if (AudioManager.audioProgression == 10f)
        {
            rend.material.SetColor("_Colour", Color.Lerp(blue, yellow, t));
        }
        else if(AudioManager.audioProgression == 50f)
        {
            rend.material.SetColor("_Colour", Color.Lerp(yellow, orange, t));
        }
        else if(AudioManager.audioProgression == 90f)
        {
            rend.material.SetColor("_Colour", Color.Lerp(orange, red, t));
        }
    }
}
