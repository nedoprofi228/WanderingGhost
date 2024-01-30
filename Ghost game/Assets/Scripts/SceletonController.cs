using UnityEngine;
using static JumpButton;

public class SceletonController : MonoBehaviour
{
    public float damage;
    [Space(10)]

    public Joystick joystick;
    Rigidbody2D rb;
    Animator anim;

    private bool walkRight = false;
    public float speed;
    public float jumpPower;
    float moveInput;

    float currentTime2 = 0;
    float needTime2 = 1f;

    public static bool onGround, inAir;
    public static bool jumpIsReady = true;
    public float checkRaduis;
    public Transform trans;
    public LayerMask layer;

    public AudioSource landsrc, jumpsrc, spawn;

    public static bool skeletonSpawned = false;

    [SerializeField] private AudioSource walk;

   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        
    }
    
    void Update()
    {
        
        if (anim.GetBool("startWalk") && Time.time - currentTime2 >= needTime2 && onGround)
        {
            currentTime2 = Time.time;
            walk.Play();
        }
        
            
    }
    private void FixedUpdate()
    {
        Jump();
        moveInput = joystick.Horizontal;
        rb.velocity = new Vector2(speed * moveInput, rb.velocity.y);
        Move();
    }
    private void OnMouseOver()
    {
        Attack();
    }
    void Move()
    {
        if (moveInput != 0) 
        {
            anim.SetBool("startWalk", true);
            
            if ((moveInput > 0 && !walkRight) || (moveInput < 0 && walkRight))
            {    
                walkRight = !walkRight;
                transform.localScale *= new Vector2(-1, 1);
            }
        }
        else
        {
            anim.SetBool("startWalk", false);
        }
        
    }
    public void Jump()
    {
        CheckGround();
        if (useJump && onGround || Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpPower;
            jumpsrc.Play();
            inAir = true;
            jumpIsReady = false;
            useJump = false;
        }
    }
    void CheckGround()
    {
        onGround = Physics2D.OverlapCircle(trans.position, checkRaduis, layer);
        if (onGround && inAir)
        {
            landsrc.Play();
            inAir = false;
            jumpIsReady=true;
        }
        if (rb.velocity.y < -0.4f)
        {
            inAir = true;
        }
    }
    private void Attack()
    {
        anim.SetTrigger("AttackTrigger");
    }
}
