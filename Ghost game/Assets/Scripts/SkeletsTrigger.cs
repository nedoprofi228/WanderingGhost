using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static CreateSceleton;

public class SkeletsTrigger : MonoBehaviour
{
    Animator anim;
    public AudioSource skeletonmusic;
    public AudioSource createSkeleton;

    public Button button;

    public GameObject skeleton;
    private Animator ghostAnim;
    private float destaroyTime;
    public float needTime;
    private bool inTriger = false;

    public static Collider2D _ghost;
    private void Start()
    {
        anim = GetComponent<Animator>();
        button.gameObject.SetActive(false);
    }
    private void Update()
    {
       

        if (inTriger || anim.GetBool("UseMake"))
        {
            TriggerMotion();
        } 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTriger = true;
        if (collision.tag == "ghost")
        {
            button.gameObject.SetActive(true);
            _ghost = collision;
            ghostAnim = _ghost.transform.Find("ghost").GetComponent<Animator>();
        }
            

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inTriger = false;
        button.gameObject.SetActive(false);
    }
    void TriggerMotion()
    {
        if (isClicked)
        {
            anim.SetBool("UseMake", true);
            destaroyTime = Time.time;
            ghostAnim.SetBool("Delete", true);
            createSkeleton.Play();
            skeletonmusic.PlayScheduled(needTime-0.2f);
            Debug.Log("isClicked");
            isClicked = false;
            button.gameObject.SetActive(false);
        }
        if (anim.GetBool("UseMake") && Time.time - destaroyTime >= needTime)
        {
            _ghost.gameObject.SetActive(false);
            GameObject Skeleton = Instantiate(skeleton, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            anim.SetBool("UseMake", false);
        }
    }
}
