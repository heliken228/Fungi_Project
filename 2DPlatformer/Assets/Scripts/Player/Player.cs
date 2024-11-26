using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _jumpForce = 5f;
        private bool _groundCheck;
        private bool _DoubleJump = false;
        
        private SpriteRenderer _sprite;
        private Rigidbody2D _rb2D;
        [SerializeField] private LayerMask _mask;
        
        [SerializeField] private float _groundCheckRadius = 0.8f;
        private float _horizontalInput;
        public static Player Instance;

        private void OnEnable()
        {
            InputController.horizontalInputAction += Move;
            InputController.verticalInputAction += Jump;
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _rb2D = GetComponent<Rigidbody2D>();
            _sprite = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            if (IsGrounded())
            {
                _DoubleJump = true;
            }
        }

        private void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position, Vector2.down * _groundCheckRadius, Color.blue);
        }

        internal void Move()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            _rb2D.linearVelocity = new Vector2(horizontalInput * _speed, _rb2D.linearVelocityY);
            
            if (horizontalInput > 0)
            {
                _sprite.flipX = false;
            }
            else if (horizontalInput < 0)
            {
                _sprite.flipX = true;
            }
            
        }

        internal void Jump()
        {
            if (IsGrounded())
            {
                _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, _jumpForce);
            }
            else if (_DoubleJump)
            {
                _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, _jumpForce);
                _DoubleJump = false;
            }
            
        }

       public bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckRadius, _mask);
            return hit.collider;
        }

        private void OnDisable()
        {
            InputController.horizontalInputAction -= Move;
            InputController.verticalInputAction -= Jump;
        }
    }
