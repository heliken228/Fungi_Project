using System;
using UnityEngine;

public class BoltMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 2f;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.linearVelocity = transform.up * _speed;
    }
    
}
