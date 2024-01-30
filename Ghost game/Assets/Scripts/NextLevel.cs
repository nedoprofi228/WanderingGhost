using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static selectLevel1;

public class NextLevel : MonoBehaviour
{
    public void OnButtonDown()
    {
        if (SceneIdex <countLevels)
        {
            SceneManager.LoadScene(SceneIdex + 1);
            Time.timeScale = 1.0f;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
