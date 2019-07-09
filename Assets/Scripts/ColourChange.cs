using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    public float elapsedTime = .0f;
    public float speed = .5f;
    public float fillStartPosition = 0f;
    public float fillEndPosition = .5f;

    public bool isNowOrrange;
    public GameObject previousObject;
    

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        //StartCoroutine(Fill());
        if (this.gameObject.name == "StartEnd")
        {
            StartCoroutine(Fill());
        }
    }
    void Update()
    {
        if (this.gameObject.name != "StartEnd")
        {
            if (previousObject == null) return;
            if (previousObject.GetComponent<ColourChange>().isNowOrrange == true)
            {
                StartCoroutine(Fill());
            }
        }

    }


    IEnumerator Fill()
    {
        while (!isNowOrrange)
        {
            rend.material.SetTextureOffset("_MainTex", new Vector2(Mathf.Lerp(fillStartPosition, fillEndPosition, elapsedTime), 0));
            elapsedTime += speed * Time.deltaTime;


            {
                
                    if (elapsedTime >= 1f)
                    {
                        isNowOrrange = true;
                    }
                    else
                    {
                        
                    }
                    
                
                
                yield return isNowOrrange;

                
            }


        }

    }
}
