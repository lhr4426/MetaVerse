using CodeShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CodeShooter
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed;
        private Rigidbody2D rigidBody;
        public float BulletSpeed { get { return bulletSpeed; } set { bulletSpeed = value; } }

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Vector3 velo = rigidBody.velocity;
            velo.y = bulletSpeed;
            rigidBody.velocity = velo;
            // Debug.Log($"{rigidBody.velocity.y}");
        }        
    }

}
