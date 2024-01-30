using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Animator animator;
    AudioSource coinUpsrc;
    Collider2D col;
    public float needTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "skeleton")
        {
            col = gameObject.GetComponent<Collider2D>();
            col.enabled = false;
            coinUpsrc = GetComponent<AudioSource>();
            coinUpsrc.Play();
            coinText.countCoins++;
            animator = GetComponent<Animator>();
            animator.SetBool("pickUp", true);
            Destroy(gameObject, needTime);
        }
    }
}
