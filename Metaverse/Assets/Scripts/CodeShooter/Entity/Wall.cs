using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeShooter
{
    public class Wall : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}

