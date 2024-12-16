using System;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidMovement : MonoBehaviour
{
    [Range(1, 5)]
    [SerializeField] float _speed;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _speed = Random.Range(1f, 5f);
        
        _rigidbody.linearVelocity = Vector3.up * -_speed;
    }
}
