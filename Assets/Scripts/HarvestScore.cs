using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HarvestScore : MonoBehaviour
{
    private int score = 0;
    public int ScorePerWheat = 5;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Update()
    {
        PlayerPrefs.SetInt("HarvestScore", score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wheat"))
        {
            score += ScorePerWheat;
            scoreText.text = "Harvest Yield: " + score;
        }
    }
}
