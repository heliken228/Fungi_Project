using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject _shotPrefab;
    [SerializeField] private Transform _shotSpawn;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _initialDelay;

    private void Start()
    {
        InvokeRepeating("Fire", _initialDelay, _fireRate); //повторение выстрела (постоянно повторяед метод)
    }

    private void Fire() // гет пулобджект
    {
        Instantiate(_shotPrefab, _shotSpawn.position, _shotSpawn.rotation);
    }
}
