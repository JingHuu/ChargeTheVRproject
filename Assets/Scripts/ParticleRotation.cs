using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParticleRotation : MonoBehaviour
{

    public float speed = 10;
    public Transform myT;
    private Vector3 rotation;

    private void Start()
    {
        myT = transform;
        speed = 0.01f;
        rotation = new Vector3(0, 0, speed);
    }

    void Update()
    {
        myT.Rotate(rotation);
    }
}
