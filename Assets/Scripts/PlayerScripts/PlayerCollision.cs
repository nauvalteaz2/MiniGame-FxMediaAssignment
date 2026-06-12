using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Collectible"))
        {
            Collectibles collectible =
                other.GetComponent<Collectibles>();

            if (collectible != null)
            {
                ScoreManager.Instance.AddScore(
                    collectible.type
                );

                Destroy(other.gameObject);
            }
        }
    }
}
