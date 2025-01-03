using System;
using UnityEngine;

public class BoltMoveEnemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _speed = -1f;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.linearVelocity = transform.up * _speed;
    }
    
}
