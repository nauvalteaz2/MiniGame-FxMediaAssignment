using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]private GameObject[] CollectiblePrefabs;
    [SerializeField]private GameObject[] ObstaclePrefabs;
    [SerializeField] private LayerMask SpawnBlockLayer;
    [SerializeField] private float CheckRadius = 0.5f;
    private int attempts = 20;
    private SpriteRenderer spriteRenderer;
    private int Amount = 15;
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
            Vector3 spawnPos;
            do
            {
                spawnPos = new Vector3(
                    Random.Range(bounds.min.x + 0.5f, bounds.max.x - 0.5f),
                    Random.Range(bounds.min.y + 0.5f, bounds.max.y - 0.5f),
                    0f
                );

                attempts--;
            }
            while (
            IsPositionOccupied(spawnPos) &&
            attempts > 0
            );

            GameObject collectible = CollectiblePrefabs[Random.Range(0, CollectiblePrefabs.Length)];
            Instantiate(collectible, spawnPos, Quaternion.identity);
        }

    }

    public void ObstacleSpawner()
    {
        Bounds bounds = spriteRenderer.bounds;
        Vector3 spawnPos = new Vector3(
           Random.Range(bounds.min.x + 0.5f, bounds.max.x - 0.5f),
           Random.Range(bounds.min.y + 0.5f, bounds.max.y - 0.5f),
           0f);
        GameObject obstacle = ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)];
        Instantiate(obstacle, spawnPos, Quaternion.identity);
    }
    bool IsPositionOccupied(Vector2 position)
    {
        return Physics2D.OverlapCircle(
            position,
            CheckRadius,
            SpawnBlockLayer
        );
    }
}
