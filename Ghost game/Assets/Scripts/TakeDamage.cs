using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SkeletsTrigger;

public class TakeDamage : MonoBehaviour
{
    UnityEngine.Object explotion;

    private float hp = 100;
    public Slider healthBar;

    private float currentTime = -10;

    private void Start()
    {
        explotion = Resources.Load("explotion");
        healthBar.gameObject.SetActive(false);
    }
    private void Update()
    {
        HealthBarVisible();
    }

    public void GetDamage(float damage)
    {
        Debug.Log($"{gameObject.name} get Damage!");
        if (hp > 0)
        {
            currentTime = Time.time;
            hp -= damage;
            healthBar.value = hp;
            if (hp % 25 == 0)
                Debug.Log(gameObject.name + " => Hp: " + hp + " | Dmg: " + damage);
        }
        else
            Die();
    }

    public void Die()
    {
        Debug.Log($"{gameObject} Die!");
        GameObject expl = (GameObject)Instantiate(explotion);
        expl.transform.position = gameObject.transform.position;
        if (gameObject.tag == "skeleton")
        {
            _ghost.transform.position = gameObject.transform.position;
            _ghost.gameObject.SetActive(true);
        }
        Destroy(gameObject);
        Destroy(expl, 1);
    }
    void HealthBarVisible()
    {
        if (Time.time - currentTime < 3)
        {
            healthBar.gameObject.SetActive(true);
        }
        else
        {
            healthBar.gameObject.SetActive(false);
        }
    }
}
