﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeColourChange : MonoBehaviour
{
    public float elapsedTime = .0f;
    public float speed = .005f;
    public float fillStartPosition = 0f;
    public float fillEndPosition = .5f;

    public bool isNowOrrange;
    public bool isNowEmpty;

    //PLEASE do not rename the following. Otherwise they will ALL need to be linked up AGAIN in Inspector.
    public GameObject previousObject1;
    //Needed for nodes with mulitple inputs.
    public GameObject previousObject2;
    public GameObject previousObject3;
    public GameObject previousObject4;

    public float triggerAngle1;
    public float triggerAngle2;
    public float triggerAngle3;
    public float triggerAngle4;

    public float badAngle1;
    public float badAngle2;
    public float badAngle3;
    public float badAngle4;

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

        //If this object is NOT the starting node AND is EITHER one of the trigger angles, do the thing.
        if (this.gameObject.name != "StartEnd"
            && (triggerAngle1 + 2 >= this.gameObject.transform.eulerAngles.z && triggerAngle1 - 2 <= this.gameObject.transform.eulerAngles.z)
            || (triggerAngle2 + 2 >= this.gameObject.transform.eulerAngles.z && triggerAngle2 - 2 <= this.gameObject.transform.eulerAngles.z)
            || (triggerAngle3 + 2 >= this.gameObject.transform.eulerAngles.z && triggerAngle3 - 2 <= this.gameObject.transform.eulerAngles.z)
            || (triggerAngle4 + 2 >= this.gameObject.transform.eulerAngles.z && triggerAngle4 - 2 <= this.gameObject.transform.eulerAngles.z))
        {
            if (previousObject1.GetComponent<PipeColourChange>().isNowOrrange == true
                && previousObject2.GetComponent<PipeColourChange>().isNowOrrange == true
                && previousObject3.GetComponent<PipeColourChange>().isNowOrrange == true
                && previousObject4.GetComponent<PipeColourChange>().isNowOrrange == true)
            {
                StartCoroutine(Fill());
            }
        }

        if (this.gameObject.name != "StartEnd"
            && (badAngle1 + 2 >= this.gameObject.transform.eulerAngles.z && badAngle1 - 2 <= this.gameObject.transform.eulerAngles.z)
            || (badAngle2 + 2 >= this.gameObject.transform.eulerAngles.z && badAngle2 - 2 <= this.gameObject.transform.eulerAngles.z)
            || (badAngle3 + 2 >= this.gameObject.transform.eulerAngles.z && badAngle3 - 2 <= this.gameObject.transform.eulerAngles.z)
            || (badAngle4 + 2 >= this.gameObject.transform.eulerAngles.z && badAngle4 - 2 <= this.gameObject.transform.eulerAngles.z))
        {
            if (previousObject1.GetComponent<PipeColourChange>().isNowOrrange == true
                && previousObject2.GetComponent<PipeColourChange>().isNowOrrange == true
                && previousObject3.GetComponent<PipeColourChange>().isNowOrrange == true
                && previousObject4.GetComponent<PipeColourChange>().isNowOrrange == true)
            {
                StartCoroutine(Empty());
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

    IEnumerator Empty()
    {
        while (isNowOrrange)
        {
            //Start at fill end, move to fill start
            
            rend.material.SetTextureOffset("_MainTex", new Vector2(Mathf.Lerp(fillEndPosition, fillStartPosition, elapsedTime), 0));
            elapsedTime = 0;

            {
                if (elapsedTime == 0f)
                {
                    isNowOrrange = false;
                }
                else
                {

                }
                
            }
            yield return !isNowOrrange;
        }
    }
}
