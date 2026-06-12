using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5f; // Speed of the player movement
    private Vector3 targetPosition;
    void Start()
    {
            targetPosition = transform.position; // Initialize target position to the current position
       
    }

    // Update is called once per frame
    void Update()
    {
        move();

    }

    public void MoveTowards(Vector3 target)
    {
        targetPosition = target;
    }

    public void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
