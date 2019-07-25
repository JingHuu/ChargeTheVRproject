using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // list all possible game sounds
    public static FMOD.Studio.EventInstance music;// game music loop
    public static FMOD.Studio.EventInstance NodeRotation; // node rotate sfx

    public static float NodeAngle;
    public static float audioProgression;
    /*
     *  BELOW IS A SAMPLE, CHANGE FOR CORRECT NAMES
     *  
    public static FMOD.Studio.EventInstance score1, score2, score3; // Game sounds from Score bank
    public static FMOD.Studio.EventInstance atmos1, atmos2, atmos3; // Game sounds from Atmos bank
    */
    public static FMOD.Studio.ParameterInstance StemUnlock;
    public static FMOD.Studio.ParameterInstance Rotate;

    // Keep music rolling between scenes. Will not destroy onload unless there is a double.
    static AudioManager instance = null;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        // music
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Score");
        // sfx
        NodeRotation = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/NodeRotate");
        

        // connect to sound parameters
        music.getParameter("NodeUnlock", out StemUnlock);
        NodeRotation.getParameter("Rotate", out Rotate);
    }

    void FixedUpdate()
    {
        StemUnlock.setValue(audioProgression);
        Rotate.setValue(NodeAngle);
    }


    // Below is the switch statement for all the possible sounds used in the game
    public static void Playsound(string clip)
    {
        switch (clip) { case ("music"): music.start(); break; }
        switch (clip) { case ("musicStop"): music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); break; }
        switch (clip) { case ("RotateNode"): NodeRotation.start(); break; }
    }

}
