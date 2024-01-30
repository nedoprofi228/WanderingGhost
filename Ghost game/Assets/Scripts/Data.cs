using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static coinText;

namespace Data
{

    public class Data : MonoBehaviour
    {
        public static int money;
        public static int Level;
        public static GameObject ghost;
        public static void EndLevel()
        {
            PlayerPrefs.SetInt("money", countCoins);
            int countLevels = PlayerPrefs.GetInt("levelUnlock");
            PlayerPrefs.SetInt("levelUnlock", countLevels + 1);
            Debug.Log(countCoins);
            Debug.Log(PlayerPrefs.GetInt("money"));
        }
        public static void LevelStart()
        {
            countCoins = PlayerPrefs.GetInt("money");
        }
        public static int GetCountMoney()
        {
            return PlayerPrefs.GetInt("money");
        }
    }
}
