using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalNodeColourChange : NodeColourChange
{


    public override void Update()
    {

        //If this object is NOT the starting node AND is EITHER one of the trigger angles, do the thing.
        if (!isStartBattery && triggerAngle + 2 >= myT.eulerAngles.z && triggerAngle - 2 <= myT.eulerAngles.z)
        {
            if (_pipe1.isPipeNowOrange && _pipe2.isPipeNowOrange && _pipe3.isPipeNowOrange && _pipe4.isPipeNowOrange)
            {
                if (!hasFired)
                {
                    hasFired = true;
                    StartCoroutine(Fill());
                    AudioProgression();
                    particleLauncher.isEnding = true;
                }

            }

        }

    }
    

}
