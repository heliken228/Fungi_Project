using System;
using UnityEngine;

public class DestroyByConact : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _playerExplosion;

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
        
       /* if (other.CompareTag("Boundary"))
        {
            return;
        }
        
        if (other.CompareTag("EnemyBolt") && CompareTag("Enemy"))
        {
            return;
        }*/
    }
}
