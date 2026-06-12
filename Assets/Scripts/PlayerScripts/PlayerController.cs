using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 TargetPosition;
    private PlayerMovement playerMovement;
    [SerializeField] private GameObject PausePanel;
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        TargetPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            PausePanel.SetActive(true);
        }
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                SetTarget(touch.position);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            SetTarget(Input.mousePosition);

        }
    }

        private void SetTarget(Vector2 screenPosition)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(
            new Vector3(
                screenPosition.x,
                screenPosition.y,
                -Camera.main.transform.position.z
            )
        );
        worldPos.z = transform.position.z; 
        playerMovement.MoveTowards(worldPos);
    }
}
