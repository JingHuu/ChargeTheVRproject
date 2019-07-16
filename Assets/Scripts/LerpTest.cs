using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{

    public Color empty, full;
    Color currentColor;
    MeshRenderer myRenderer;

    private void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = empty;
        currentColor = empty; 
    }

    void Update()
    {
        myRenderer.material.color= Color.Lerp(empty, full, Mathf.PingPong(Time.time, 1));
    }
}
