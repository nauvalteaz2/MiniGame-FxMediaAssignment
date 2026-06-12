using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]private TMP_Text scoreText;
    private int score;
    public static ScoreManager Instance { get; private set; }
    private Dictionary<CollectibleType, int> CollectibleScoreDictionary = new()
    {
        { CollectibleType.Gold, 10 },
        { CollectibleType.Red, 50 },
        { CollectibleType.Blue, 100 },
        { CollectibleType.Silver, 200 },
    };
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of ScoreManager detected. Destroying duplicate.");
            Destroy(gameObject);
            return;
        }


        UpdateUI();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(CollectibleType type)
    {
        if (CollectibleScoreDictionary.TryGetValue(type, out int scoreToAdd))
        {
            score += scoreToAdd;
            UpdateUI();
        }
        else
        {
            Debug.LogWarning($"Collectible type {type} not found in score dictionary.");
        }
    }

    private void UpdateUI()
    {
        scoreText.text = $"Score: {score}";
        // Update your UI elements here, e.g., score text
    }
}
