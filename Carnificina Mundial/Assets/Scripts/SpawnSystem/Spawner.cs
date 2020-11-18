using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Vector2 spawnPoint;

    public float spawnRate;

    private float nextSpawn;

    private void Update()
    {
        spawnPoint = new Vector2(Random.Range(-12f, 12f), Random.Range(-10, 6.75f));

        if (Time.time > nextSpawn) SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        nextSpawn = spawnRate + Time.time;
        Instantiate(enemy, spawnPoint, transform.rotation);
    }
}
