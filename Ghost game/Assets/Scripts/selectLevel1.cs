using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selectLevel1 : MonoBehaviour
{
    
    public Button[] buttons;
    public static int SceneIdex;
    public static int countLevels;

    private void Start()
    {
        countLevels = buttons.Length;
        int levelUnlock = PlayerPrefs.GetInt("levelUnlock", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0;i < levelUnlock; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        Time.timeScale = 1.0f;
        SceneIdex = levelIndex;
    }

}
