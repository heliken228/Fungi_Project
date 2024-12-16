using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 2f;
    private Rigidbody _rigidbody;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.angularVelocity = Random.insideUnitSphere * _rotationSpeed;
    }
}
