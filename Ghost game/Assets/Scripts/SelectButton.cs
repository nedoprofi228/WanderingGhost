using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    private bool stopGame = false;
    public Canvas stopMenu;
    public void StopGame()
    {
        if (!stopGame)
        {
            stopGame = true;
            Time.timeScale = 0f;
            stopMenu.gameObject.SetActive(true);
        }
        else
        {
            stopGame = false;
            Time.timeScale = 1f;
            stopMenu.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            StopGame();
    }
}
