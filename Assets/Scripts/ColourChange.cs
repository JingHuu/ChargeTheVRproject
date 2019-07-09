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

    //PLEASE do not rename the following. Otherwise they will ALL need to be linked up AGAIN in Inspector.
    public GameObject previousObject1;
    //Needed for nodes with mulitple inputs.
    public GameObject previousObject2;
    public GameObject previousObject3;
    public GameObject previousObject4;


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
            if (previousObject1.GetComponent<ColourChange>().isNowOrrange == true 
                && previousObject2.GetComponent<ColourChange>().isNowOrrange == true 
                && previousObject3.GetComponent<ColourChange>().isNowOrrange == true 
                && previousObject4.GetComponent<ColourChange>().isNowOrrange == true)
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
