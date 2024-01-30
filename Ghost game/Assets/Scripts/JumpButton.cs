using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SceletonController;


public class JumpButton : MonoBehaviour
{
    public static bool useJump = false;
    
    public void Jump()
    {
        if (onGround)
        {
            useJump = true;
        }
        
    }
}
