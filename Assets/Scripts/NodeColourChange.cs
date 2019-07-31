using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeColourChange : MonoBehaviour
{
    public float elapsedTime = .0f;
    public float speed = .5f;
    public float fillStartPosition = 0f;
    public float fillEndPosition = .5f;

    public bool isNowOrrange;
    public bool isStartBattery;

    //PLEASE do not rename the following. Otherwise they will ALL need to be linked up AGAIN in Inspector.
    public GameObject previousObject1;
    //Needed for nodes with mulitple inputs.
    public GameObject previousObject2;
    public GameObject previousObject3;
    public GameObject previousObject4;

    private PipeColourChange _pipe1;
    private PipeColourChange _pipe2;
    private PipeColourChange _pipe3;
    private PipeColourChange _pipe4;

    public float triggerAngle;

    /*
    float badAngle1 = 10;
    float badAngle2 = 10;
    float badAngle3 = 10;
    float badAngle4 = 10;
    */

    Renderer rend;

    public bool hasFired = false;
    public bool isBattery = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        AudioManager.audioProgression = 0f;

        StartCoroutine(Setup());
        
        if (isStartBattery == true)
        {          
            StartCoroutine(Fill());
        }

        myT = transform;
    }

    private Transform myT;
    
    void Update()
    {

        //If this object is NOT the starting node AND is EITHER one of the trigger angles, do the thing.
        if (isStartBattery == false && triggerAngle + 2 >= myT.eulerAngles.z && triggerAngle - 2 <= myT.eulerAngles.z)
        {
            if (_pipe1.isPipeNowOrange || _pipe2.isPipeNowOrange || _pipe3.isPipeNowOrange || _pipe4.isPipeNowOrange)
            {
                if (!hasFired)
                {
                    hasFired = true;
                    StartCoroutine(Fill());
                    AudioProgression();
                }
                
            }

        }

    }

    IEnumerator Setup()
    {
        _pipe1 = previousObject1.GetComponent<PipeColourChange>();
        _pipe2 = previousObject2.GetComponent<PipeColourChange>();
        _pipe3 = previousObject3.GetComponent<PipeColourChange>();
        _pipe4 = previousObject4.GetComponent<PipeColourChange>();
        
        yield return null;
    }
    

    IEnumerator Fill()
    {
        while (!isNowOrrange)
        {
            //rend.material.SetTextureOffset("_MainTex", new Vector2(Mathf.Lerp(fillStartPosition, fillEndPosition, elapsedTime), 0));
            //Vector1_776A8DBC
            rend.material.SetFloat("_Lerp", Mathf.Lerp(0, 1, elapsedTime));
            elapsedTime += speed * Time.deltaTime;

            {
                if (elapsedTime >= 1f)
                {
                    isNowOrrange = true;
                    elapsedTime = 0f;
                }

                yield return isNowOrrange;
            }
        }
    }

    public bool Check()
    {
        if (_pipe1.isPipeNowOrange && _pipe2.isPipeNowOrange && _pipe3.isPipeNowOrange && _pipe4.isPipeNowOrange)
        {
            return false;
        }
        
        return true;
    }
    
    /*
    IEnumerator Empty()
    {
        while (isNowOrrange)
        {
            //Start at fill end, move to fill start

            //rend.material.SetTextureOffset("_MainTex", new Vector2(Mathf.Lerp(0f, -fillEndPosition, elapsedTime), 0));
            rend.material.SetFloat("_Lerp", Mathf.Lerp(1, 0, elapsedTime));
            elapsedTime += speed * Time.deltaTime;

            {
                if (elapsedTime >= 1f)
                {
                    isNowOrrange = false;
                    elapsedTime = 0f;
                }
                else
                {

                }
                
            }
            yield return !isNowOrrange;
        }
    }
    */

    private void AudioProgression()
    {
        if(isBattery) AudioManager.audioProgression += 10f; // this will activate one stem in the audio everytime a battery turns on
    }
}
