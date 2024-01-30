using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Data;

public class coinText : MonoBehaviour
{
    public static int countCoins= 0;
    public TMP_Text coinsText;
  
    private void Start()
    {
        Data.Data.LevelStart();
    }
    private void Update()
    {
        coinsText.text = $"{countCoins}";
    }
}
