using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameRunning = false;
    public static bool gameEnds = false;
    private bool hasEnd = false;
    //public float timeLeft = 50f;

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        //timeLeft -= Time.deltaTime;
        if (isGameRunning && gameEnds)
        {
            StartCoroutine(RestartGame());
            gameEnds = false;
        }
    }

    /*public void RestartGame()
    {
        hasEnd = true;
        
        if(timeLeft < 0)
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }*/

    IEnumerator RestartGame()
    {
        hasEnd = true;
        yield return new WaitForSeconds(12);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
