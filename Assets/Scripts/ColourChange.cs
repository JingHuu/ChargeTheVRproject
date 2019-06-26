using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    // Scroll main texture based on time

    public float scrollSpeed;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offset, 0);
        
    }

    IEnumerator Fill()
    {
        //make new float = 0
        //while float < 1
            //fill towards 1
            //offset texture
            yield return null;
    }
}
