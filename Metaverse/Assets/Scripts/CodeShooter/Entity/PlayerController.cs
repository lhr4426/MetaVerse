using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeShooter
{
    public class PlayerController : MonoBehaviour
    {
        private Camera camera;

        [Header("Shoot Settings")]
        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject projectilePivot;

        private ParticleSystem particleSystem;
        private GameManager gameManager;


        private void Awake()
        {
            camera = Camera.main;
            particleSystem = GetComponentInChildren<ParticleSystem>();
            gameManager = FindFirstObjectByType<GameManager>();
        }

        void OnMove(InputValue inputValue)
        {
            Vector2 mousePos = inputValue.Get<Vector2>(); // ���콺 ��ġ ������
            Vector2 worldPos = camera.ScreenToWorldPoint(mousePos);
            transform.position = new Vector2(worldPos.x, transform.position.y);
            // ���콺 �¿츸 �̵��ϵ���
        }

        void OnFire(InputValue inputValue)
        {
            if (inputValue.isPressed)
            {
                Vector3 position = projectilePivot.transform.position;
                GameObject go = Instantiate(bullet, position, Quaternion.identity);
                particleSystem.Play();
            }
        }
    }
}

