using System;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PoolObject : MonoBehaviour
{
   [SerializeField] private GameObject _bulletPrefab; // Префаб пули
   public int poolSize = 20; // Размер пула

   private Queue<GameObject> _bulletPool;

   void Start()
   {
      _bulletPool = new Queue<GameObject>();
      for (int i = 0; i < poolSize; i++)
      {
         GameObject bullet = Instantiate(_bulletPrefab);
         bullet.SetActive(false);
         _bulletPool.Enqueue(bullet);
      }
   }

   public GameObject GetBullet()
   {
      if (_bulletPool.Count > 0)
      {
         return _bulletPool.Dequeue();
      }
      else
      {
         GameObject bullet = Instantiate(_bulletPrefab);
         bullet.SetActive(false);
         return bullet;
      }
   }

   public void ReturnBullet(GameObject bullet)
   {
      bullet.SetActive(false);
      _bulletPool.Enqueue(bullet);
   }
}
