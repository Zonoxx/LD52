using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    private void Start()
    {
        var gameScore = PlayerPrefs.GetInt("HarvestScore");
        var highScore = PlayerPrefs.GetInt("BestScore");
        scoreText.text = "Harvested Wheat: " + PlayerPrefs.GetInt("HarvestScore");
        if (gameScore > highScore)
        {
            PlayerPrefs.SetInt("BestScore", gameScore);
            highScoreText.text = "This is a new high score!";
        }
        else
        {
            highScoreText.text = "Your current best score: " + PlayerPrefs.GetInt("BestScore");
        }
    }
}
