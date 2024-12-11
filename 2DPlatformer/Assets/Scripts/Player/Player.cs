using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _jumpForce = 5f;
        private bool _doubleJump;
        private bool _isFalling;
        
        private float _groundCheckRadius = 0.7f;
        
        private Animator _animator;
        private SpriteRenderer _sprite;
        private Rigidbody2D _rb2D;
        [SerializeField] private LayerMask _mask;
        
        [SerializeField] private UIManager heartManager;
                
        public static Player Instance;
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _rb2D = GetComponent<Rigidbody2D>();
            _sprite = GetComponentInChildren<SpriteRenderer>();
            _animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            if (IsGrounded())
            {
                _doubleJump = true;
            }
            VerticalSpeed();
        }

        private void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position, Vector2.down * _groundCheckRadius, Color.blue);
        }

        internal void Move(float value)
        {
            _rb2D.linearVelocity = new Vector2(value * _speed, _rb2D.linearVelocityY);
            _animator.SetBool("IsRun", Mathf.Abs(_rb2D.linearVelocity.x) >= 0.01f);
            
           if (value > 0)
            {
                _sprite.flipX = false;
            }
            else if (value < 0)
            {
                _sprite.flipX = true;
            }
        }
        
        public bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckRadius, _mask);
            if (hit.collider != null) 
            {
                _isFalling = false;
                return true;
            }
            return false;

        }

        internal void Jump()
        {
            if (IsGrounded())
            {
                    _animator.SetTrigger("Jump");
                    _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, _jumpForce);
            }
            else if (_doubleJump)
            {
                    _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, _jumpForce);
                    _doubleJump = false;
            }
        }
        private void VerticalSpeed()
        {
            _animator.SetBool("IsFall", _isFalling);
            if (_rb2D.linearVelocity.y < 0)
            {
                _isFalling = true;
            }
        }

        internal void Attack()
        {
            int randomAttack = Random.Range(0, 4);  
            switch (randomAttack)
            {
                case 1:
                    _animator.SetTrigger("Attack1");
                    break;
                case 2:
                    _animator.SetTrigger("Attack2");
                    break;
                case 3:
                    _animator.SetTrigger("Attack3");
                    break;
            }
        }
        internal void StartBlock()
        {
            _animator.SetBool("Block", true);
        }
        internal void StopBlock()
        {
            _animator.SetBool("Block", false);
        }

        internal void Death()
        {
            _animator.SetTrigger("Death");
            Debug.Log("DEATH");
        }
    }
