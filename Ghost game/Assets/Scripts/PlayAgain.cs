using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static selectLevel1;

public class PlayAgain : MonoBehaviour
{
    public void OnButtonDown()
    {
        SceneManager.LoadScene(SceneIdex);
        Time.timeScale = 1.0f;
    }
}
