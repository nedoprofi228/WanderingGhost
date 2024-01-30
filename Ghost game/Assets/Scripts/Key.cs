using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyDoor
{
    public class Key : MonoBehaviour
    {
        public static bool haveKey;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "skeleton")
            {
                Destroy(gameObject);
                haveKey = true;
            }
        }
    }
}