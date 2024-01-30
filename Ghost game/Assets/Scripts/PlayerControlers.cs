using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlers : MonoBehaviour
{
    private Joystick joystick;
    private Rigidbody2D rb;

    private CapsuleCollider2D cpcoll;

    private float moveInputX;
    private float moveInputY;
    public float moveSpeed;

    private Animator anim;
    
    void Start()
    {
        cpcoll = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GameObject.Find("ghost").GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
    }

    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Walk();
        Animations();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "platforma" || collision.tag == "door")
        {
            cpcoll.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "platforma" || collision.tag == "door")
        {
            cpcoll.enabled = true;
        }
    }
    void Walk()
    {
        moveInputY = joystick.Vertical;
        moveInputX = joystick.Horizontal;
        Vector2 MoveInputJoystick = new Vector2(joystick.Horizontal, joystick.Vertical);
        rb.AddForce(MoveInputJoystick * moveSpeed);
        if (moveInputX < 0)
        {
            anim.SetBool("WalkLeft", true);
        }
        else if (moveInputX > 0)
        {
            anim.SetBool("WalkLeft", false);
        }
    }
    void Animations()
    {
        if (moveInputX == 0)
        {
            anim.SetBool("StartWalk", false);
        }

        else
        {
            anim.SetBool("StartWalk", true);
        }
            
    }

}
