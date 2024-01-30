using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOfEnemie1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != gameObject.tag && collision != null)
            collision.GetComponent<TakeDamage>().GetDamage(1f);
    }
}
