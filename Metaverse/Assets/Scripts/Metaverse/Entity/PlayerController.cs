using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Metaverse
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Setting")]
        protected Rigidbody2D _rigidbody;

        [SerializeField] private SpriteRenderer characterRenderer;

        protected Vector2 movementDirection = Vector2.zero;
        public Vector2 MovementDirection { get { return movementDirection; } }


        protected Vector2 lookDirection = Vector2.zero;
        public Vector2 LookDirection { get { return lookDirection; } }

        private Camera camera;

        [Header("Player Stats")]
        [SerializeField] private float speed = 1.0f;
        public float Speed { get { return speed; } }


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            characterRenderer = GetComponentInChildren<SpriteRenderer>();
            camera = Camera.main;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Rotate(LookDirection);
        }

        private void FixedUpdate()
        {
            Movement(MovementDirection);
        }


        private void Rotate(Vector2 direction)
        {
            float xyAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bool isLeft = Mathf.Abs(xyAngle) > 90;
            characterRenderer.flipX = isLeft;
        }

        private void Movement(Vector2 direction)
        {
            direction = direction * Speed;
            _rigidbody.velocity = direction;
        }

        void OnMove(InputValue inputValue)
        {
            // Debug.Log("움직이는중");
            movementDirection = inputValue.Get<Vector2>().normalized;
        }

        void OnLook(InputValue inputValue)
        {
            Vector2 mousePosition = inputValue.Get<Vector2>();
            Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
            lookDirection = (worldPos - (Vector2)transform.position);

            if (lookDirection.magnitude < .9f)
            {
                lookDirection = Vector2.zero;
            }
            else
            {
                lookDirection = lookDirection.normalized;
            }

        }

        void OnInteraction(InputValue inputValue)
        {
            if(inputValue.isPressed)
            {
                Debug.Log("상호작용 키 입력됨");
                Debug.Log($"{LookDirection} 방향 보는 중");
                RaycastHit2D hit = Physics2D.Raycast(transform.position, LookDirection, 2f, LayerMask.GetMask("NPC"));
                if (hit.collider != null && hit.collider.CompareTag("NPC"))
                {
                    Debug.Log("NPC와 상호작용 시도");
                    BaseNPC npc = hit.collider.GetComponent<BaseNPC>();
                    npc.ShowMessage();
                }
            }
        }
    }
}

