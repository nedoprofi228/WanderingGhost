using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void OnButtonDown()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
