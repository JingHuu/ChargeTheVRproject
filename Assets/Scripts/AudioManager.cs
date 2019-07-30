using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // list all possible game sounds
    public static FMOD.Studio.EventInstance music;// game music loop
    public static FMOD.Studio.EventInstance NodeRotation; // node rotate sfx

    public static float rotate;
    public static float audioProgression;


    public static FMOD.Studio.ParameterInstance StemUnlock;
    public static FMOD.Studio.ParameterInstance musicProgression;
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
        //music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Score");
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Score2");


        // connect to sound parameters
        //music.getParameter("NodeUnlock", out StemUnlock);
        music.getParameter("MusicProgression", out musicProgression);
        NodeRotation.getParameter("Rotate", out Rotate);

        music.start();
    }

    void FixedUpdate()
    {
        //StemUnlock.setValue(audioProgression);
        musicProgression.setValue(audioProgression);
        
        Rotate.setValue(rotate);
    }


    // Below is the switch statement for all the possible sounds used in the game
    public static void Playsound(string clip)
    {
        //switch (clip) { case ("music"): music.start(); break; }
        switch (clip) { case ("musicStop"): music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); break; }
        switch (clip) { case ("RotateNode"): NodeRotation.start(); break; }
    }

}
