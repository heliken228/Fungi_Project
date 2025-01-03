using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private PoolObject _poolObject;
    [SerializeField] private GameObject _shotPrefab;
    [SerializeField] private Transform _shotSpawn;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _initialDelay;
    private float _nextFire;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", _initialDelay, _fireRate); //повторение выстрела (постоянно повторяед метод)
    }

    private void Fire()
    {
        _nextFire = Time.time + _fireRate;

        GameObject bullet = _poolObject.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = _shotSpawn.position;
            bullet.transform.rotation = _shotSpawn.rotation;
            bullet.SetActive(true);
            
        }
    }
}
