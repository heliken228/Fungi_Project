using Unity.VisualScripting;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _asteroidPrefabs;
    [SerializeField] private GameObject _enemyPurlePrefab;
    [SerializeField] private BoxCollider _spawnZone;
    [SerializeField] private float _spawnInterval = 2f;
    private void Start()
    {
        InvokeRepeating("SpawnEnemies", 0f, _spawnInterval);
    }

    private void SpawnEnemies()
    {
        bool spawnEnemy = Random.Range(0, 10) < 2; // 20% шанс спавна вражеского корабля
        GameObject prefabToSpawn;

        if (spawnEnemy)
        {
            prefabToSpawn = _enemyPurlePrefab;
        }
        else
        {
            int randomIndex = Random.Range(0, _asteroidPrefabs.Length);
            prefabToSpawn = _asteroidPrefabs[randomIndex];
        }
        
        Vector3 spawnPosition = GetRandomPositionInBox(_spawnZone);
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        
        if (!spawnEnemy)
        {
            spawnedObject.AddComponent<AsteroidMovement>();
            spawnedObject.AddComponent<RandomRotation>();
        }
        else
        {
            spawnedObject.AddComponent<AsteroidMovement>();
            spawnedObject.AddComponent<Enemy>();
            spawnedObject.AddComponent<WeaponController>();
        }
    }
    
    private Vector3 GetRandomPositionInBox(BoxCollider boxCollider)
    {
        Vector3 extents = boxCollider.size / 2;
        Vector3 randomPoint = new Vector3(
            Random.Range(-extents.x, extents.x),
            Random.Range(-extents.y, extents.y),
            Random.Range(-extents.z, extents.z)
        );
        return boxCollider.transform.TransformPoint(randomPoint);
    }
    
}
