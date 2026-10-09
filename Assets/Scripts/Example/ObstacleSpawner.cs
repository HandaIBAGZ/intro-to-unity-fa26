using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject CactusPrefab;
    public Transform SpawnPoint;
    public float MinSpawnDelay = 1f;
    public float MaxSpawnDelay = 3f;

    private float _timer = 0f;
    private float _timeUntilSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _timeUntilSpawn = Random.Range(MinSpawnDelay, MaxSpawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeUntilSpawn)
        {
            Instantiate(CactusPrefab, SpawnPoint.position, Quaternion.identity);
            _timer = 0f;
            _timeUntilSpawn = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        }
    }

    public void StopSpawning()
    {
        enabled = false;
    }
}
