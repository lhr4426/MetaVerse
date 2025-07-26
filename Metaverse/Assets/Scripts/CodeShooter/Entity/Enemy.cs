using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeShooter
{
    public class Enemy : MonoBehaviour
    {
        private Animator animator;
        private SpriteRenderer spriteRenderer;

        private readonly int IsDie = Animator.StringToHash("IsDie");

        GameManager gameManager;
        public void Init(GameManager manager)
        {
            gameManager = manager;
        }
        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void SetSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            gameManager.AddScore(1);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            animator.SetBool(IsDie, true);
            Destroy(collision.gameObject);
            Destroy(gameObject, 1f);
        }
    }
}

