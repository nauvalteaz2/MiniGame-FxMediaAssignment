using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text TimerText;
    [SerializeField] private GameObject PausePanel;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimer()
    {
        timer = 5f;
        InvokeRepeating(nameof(UpdateTimer), 0f, 1f);
    }

    private void UpdateTimer()
    {
        if (timer > 0)
        {
            timer -= 1f;
            TimerText.text = timer.ToString("F0");
        }
        else
        {
            CancelInvoke(nameof(UpdateTimer));
            PausePanel.SetActive(true);
            Time.timeScale = 0f; 
        }
    }
}