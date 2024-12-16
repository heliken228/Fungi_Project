using Unity.VisualScripting;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _asteroidPrefabs;
    [SerializeField] private BoxCollider _spawnZone;
    [SerializeField] private float _spawnInterval = 2f;
    private void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0f, _spawnInterval);
    }
    private void SpawnAsteroid()
    {
        int randomIndex = Random.Range(0, _asteroidPrefabs.Length);
        GameObject asteroidPrefab = _asteroidPrefabs[randomIndex];

        Vector3 spawnPosition = GetRandomPositionInBox(_spawnZone);
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        
        asteroid.AddComponent<AsteroidMovement>();
        asteroid.AddComponent<RandomRotation>();
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
