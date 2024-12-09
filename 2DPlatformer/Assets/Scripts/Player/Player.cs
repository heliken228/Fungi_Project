using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _jumpForce = 5f;
        private bool _doubleJump;
        private bool _isFalling;
        
        private float _groundCheckRadius = 0.2f;
        
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
            _sprite = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (_rb2D.linearVelocity.y < 0 && !IsGrounded()) 
            {
                _animator.SetBool("IsFall", true);
            }
            else
            {
                _animator.SetBool("IsFall", false);
            }
            if (IsGrounded())
            { 