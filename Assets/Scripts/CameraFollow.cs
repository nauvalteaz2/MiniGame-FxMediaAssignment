using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
        }
    }
}
