using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Data;


namespace KeyDoor
{
    public class Door : MonoBehaviour
    {
        public GameObject winMenu;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "skeleton")
            {
                if (Key.haveKey)
                {
                    Data.Data.EndLevel();
                    winMenu.SetActive(true);
                    Time.timeScale = 0;
                    Key.haveKey = false;
                }
            }
        }
    }
}