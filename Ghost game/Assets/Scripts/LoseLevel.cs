using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLevel : MonoBehaviour
{
    GameObject[] skeletons;
    GameObject[] skelets;

    public GameObject LossMenu;

    private bool levelLose = false;
    void Update()
    {
        CheckLose();
    }
    private void CheckLose()
    {
        skeletons = GameObject.FindGameObjectsWithTag("skeleton");
        skelets = GameObject.FindGameObjectsWithTag("skelets");
        if (skelets.Length <=0 && skeletons.Length <= 0 && !levelLose)
        {
            Time.timeScale = 0.2f;
            levelLose = true;
            LossMenu.SetActive(true);
            Debug.Log("u loss level");
        }
    }
}
