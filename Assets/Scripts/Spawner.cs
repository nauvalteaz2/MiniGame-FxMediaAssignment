using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]private GameObject[] CollectiblePrefabs;
    [SerializeField]private GameObject[] ObstaclePrefabs;
    private SpriteRenderer spriteRenderer;
    private int Amount = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CollectiblesSpawner();
        ObstacleSpawner();

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void CollectiblesSpawner()
    {
        Bounds bounds = spriteRenderer.bounds;
        for (int i = 0; i < Amount; i++)
        {
            Vector3 spawnPos = new Vector3(
               Random.Range(bounds.min.x, bounds.max.x),
               Random.Range(bounds.min.y, bounds.max.y),
               0f
           );
            GameObject collectible = CollectiblePrefabs[Random.Range(0, CollectiblePrefabs.Length)];
            Instantiate(collectible, spawnPos, Quaternion.identity);
        }

    }

    public void ObstacleSpawner()
    {
        Bounds bounds = spriteRenderer.bounds;
        Vector3 spawnPos = new Vector3(
           Random.Range(bounds.min.x, bounds.max.x),
           Random.Range(bounds.min.y, bounds.max.y),
           0f);
        GameObject obstacle = ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)];
        Instantiate(obstacle, spawnPos, Quaternion.identity);
    }
}
