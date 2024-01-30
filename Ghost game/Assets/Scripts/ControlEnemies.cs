using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Attack;

public class ControlEnemies : MonoBehaviour
{

    public float speed;
    private int direction = 0;
    private bool walkRight;
    private bool afk;

    private Rigidbody2D rb;
    private AudioSource walk;
    private Animator anim;

    GameObject skeleton;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        walk = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }
    public void FixedUpdate()
    {
        skeleton = GameObject.FindGameObjectWithTag("skeleton");
        if (skeleton != null)
        {
            direction = gameObject.transform.position.x < skeleton.transform.position.x ? 1 : -1;
        }
        Move();
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
        

    }
    public void Update()
    {
        
    }
    void Move()
    {
        if (skeleton == null || afk)
        {
            if (skeleton == null)
                Debug.Log("skeleton not founded");
            anim.SetBool("startWalk", false);
            direction = 0;
            afk = false;
            return;
        }
        
        if (Math.Abs(gameObject.transform.position.x) > Math.Abs(skeleton.transform.position.x))
        {
            afk = Math.Abs(gameObject.transform.position.x) - Math.Abs(skeleton.transform.position.x) < 0.013f;
        }
        else
        {
            afk = Math.Abs(skeleton.transform.position.x) - Math.Abs(gameObject.transform.position.x) < 0.013f;
        }
        
        if ((direction < 0 && walkRight) || (direction > 0 && !walkRight))
        {
            walkRight = !walkRight;
            transform.localScale *= new Vector2(-1, 1);
        }
        if(direction != 0)
        {
            walk.Play();
            anim.SetBool("startWalk", true);
        }
    }
    void Attack()
    {
        anim.SetTrigger("AttackTrigger");
        anim.SetBool("startWalk", false);
        direction = 0;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "skeleton")
        {
            Attack();
        }
    }

}
