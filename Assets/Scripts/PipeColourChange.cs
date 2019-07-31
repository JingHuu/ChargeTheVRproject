using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeColourChange : MonoBehaviour
{
    public float elapsedTime = .0f;
    public float speed;
    public float fillStartPosition = 0f;
    public float fillEndPosition = .5f;

    public bool isPipeNowOrange;

    //PLEASE do not rename the following. Otherwise they will ALL need to be linked up AGAIN in Inspector.
    public GameObject previousObject1;
    public GameObject previousObject2;
    private NodeColourChange _node1;
    private NodeColourChange _node2;

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        speed = .05f;
        StartCoroutine(Setup());
        
    }
    bool b = false;
    void Update()
    {
        
        if (previousObject2 != null)
        {
            if (_node1.isNowOrrange || _node2.isNowOrrange)
            {
                b = true;
            }
        }
        else
        {
            if (_node1.isNowOrrange)
            {
                b = true;
            }
        }
        
        if (b)
        {
            if (AudioManager.audioProgression > 20f)
            {
                speed = .5f;
            }
            else
            {
                speed = .05f;
            }

            StartCoroutine(Fill());
        }
        /*
        if (previousObject1.GetComponent<NodeColourChange>().isNowOrrange == false)
        {
            StartCoroutine(Empty());
        }
        */
    }

    IEnumerator Setup()
    {
        _node1 = previousObject1.GetComponent<NodeColourChange>();
        
        if (previousObject2 != null) _node2 = previousObject2.GetComponent<NodeColourChange>();
        
        yield return null;
    }

    IEnumerator Fill()
    {
        while (!isPipeNowOrange)
        {
            rend.material.SetTextureOffset("_MainTex", new Vector2(Mathf.Lerp(fillStartPosition, fillEndPosition, elapsedTime), 0));
            //Vector1_776A8DBC
            //rend.material.SetFloat("_Lerp", Mathf.Lerp(0, 1, elapsedTime));
            elapsedTime += speed * Time.deltaTime;

            {
                if (elapsedTime >= 1f)
                {
                    isPipeNowOrange = true;
                    elapsedTime = 0f;
                }
                else
                {

                }
                yield return isPipeNowOrange;
            }
        }
    }
    /*
    IEnumerator Empty()
    {
        while (isPipeNowOrange)
        {
            //Start at fill end, move to fill start

            rend.material.SetTextureOffset("_MainTex", new Vector2(Mathf.Lerp(-fillEndPosition, 0f, elapsedTime), 0));
            //rend.material.SetFloat("_Lerp", Mathf.Lerp(1, 0, elapsedTime));
            elapsedTime += speed * Time.deltaTime;

            {
                if (elapsedTime >= 1f)
                {
                    isPipeNowOrange = false;
                    elapsedTime = 0f;
                }
                else
                {

                }

            }
            yield return !isPipeNowOrange;
        }
    }
    */
}
