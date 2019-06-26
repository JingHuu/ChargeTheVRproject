using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
   
    // Update is called once per frame
	void Update ()
    {
		
	}

    //Click left mouse button to rotate target
    private void OnMouseDown()
    {
        transform.Rotate(45, 0, 0);
    }

    
}
