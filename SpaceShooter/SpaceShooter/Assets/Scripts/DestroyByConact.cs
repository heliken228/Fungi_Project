using System;
using UnityEngine;

public class DestroyByConact : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _playerExplosion;
    [SerializeField] private int _scoreValue;
    [SerializeField] private GameManager _gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (_explosion != null && other.CompareTag("Bolt"))
        {
            Instantiate(_explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            return;
        }
        
        if (_playerExplosion != null && other.CompareTag("Player"))
        {
            Instantiate(_playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            return;
        }
        if (_gameManager != null)
        {
            _gameManager.AddScore(_scoreValue);
        }
    }
}
