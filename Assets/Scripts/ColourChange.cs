using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    public float elapsedTime = .0f;
    public float speed = .5f;
    public float fillStartPosition = 0f;
    public float fillEndPosition = .25f;

    public int isNowOrrange;

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(Fill());
    }
    void Update()
    {
                
    }

    
    IEnumerator Fill()
    {
        while (isNowOrrange != 1)
        {
            rend.material.SetTextureOffset("_MainTex", new Vector2(Mathf.Lerp(fillStartPosition, fillEndPosition, elapsedTime), 0));
            elapsedTime += speed * Time.deltaTime;

            if (elapsedTime >= 1f)
            {
                isNowOrrange = 1;
            }
            else
            {
                isNowOrrange = 0;
            }
            yield return isNowOrrange;
        }
           
            
    }
    
}
