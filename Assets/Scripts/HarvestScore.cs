using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HarvestScore : MonoBehaviour
{
    public int score = 0;
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
            score += 5;
            scoreText.text = "Harvested Wheat: " + score;
        }
    }
}
