using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace FlappyPlane
{
    public class Player : MonoBehaviour
    {

        Animator animator;
        Rigidbody2D _rigidbody;

        public float flapForce = 6f;
        public float forwardSpeed = 3f;
        public bool isDead = false;
        float deathCooldown = 0f;

        bool isFlap = false;

        GameManager gameManager;

        // Start is called before the first frame update
        void Start()
        {
            gameManager = GameManager.instance;

            animator = GetComponentInChildren<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();

            if (animator == null)
                Debug.LogError("Not Founded Animator");

            if (_rigidbody == null)
                Debug.LogError("Not Founded RigidBody");
        }

        private void Update()
        {
            if (isDead && deathCooldown > 0f) deathCooldown -= Time.deltaTime;
        }


        private void FixedUpdate()
        {
            if (isDead) return;

            Vector3 velocity = _rigidbody.velocity;
            velocity.x = forwardSpeed;

            if (isFlap)
            {
                velocity.y += flapForce;
                isFlap = false;
            }

            _rigidbody.velocity = velocity;

            float angle = Mathf.Clamp((_rigidbody.velocity.y * 10), -90, 90);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (isDead) return;

            isDead = true;
            deathCooldown = 1f;

            animator.SetInteger("IsDie", 1);
            gameManager.GameOver();
        }

        void OnFlap(InputValue inputValue)
        {
            if (isDead && deathCooldown <= 0 && inputValue.isPressed) 
                gameManager.RestartGame();
            
            else
            {
                if (inputValue.isPressed)
                {
                    isFlap = true;
                }
            }
        }
    }
}

