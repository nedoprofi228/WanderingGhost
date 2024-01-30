using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SceletonController;

public class CreateSceleton : MonoBehaviour
{
    
    public static bool isClicked = false;
    public void Click()
    {
        isClicked = true;
        skeletonSpawned = true;

    }
}
