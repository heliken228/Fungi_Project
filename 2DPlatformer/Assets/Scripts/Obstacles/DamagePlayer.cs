using System;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public static Action OnTakeDamage;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponentInChildren<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _audioSource.Play();
            Debug.Log("Damage Player");
            OnTakeDamage?.Invoke();
        }
    }
}
