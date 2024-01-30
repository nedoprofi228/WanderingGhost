using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KeyDoor;
using Unity.VisualScripting;

public class LatticeUp : MonoBehaviour
{
    [SerializeField] private float speedUp;
    private RectTransform pos;
    private AudioSource audio;
    private Rigidbody2D rb;
    private bool upLattice;
    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        pos = gameObject.GetComponent<RectTransform>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Key.haveKey && !upLattice && collision.tag == "skeleton")
        {
            audio = gameObject.GetComponent<AudioSource>();
            audio.Play();
            upLattice = true;
        }
    }
    private void UpLattice()
    {
       
        if (upLattice && gameObject.transform.position.y < 2.30f)
        {
            rb.velocity = Vector2.up * speedUp;
            Debug.Log($"{gameObject.transform.position}");
        }
        else
        {
            rb.velocity = new Vector2(0,0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpLattice();
    }
}
