using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI highScoreText;

    private void Start()
    {
        var gameScore = PlayerPrefs.GetInt("HarvestScore");
        var highScore = PlayerPrefs.GetInt("BestScore");
        scoreText.text = "Harvest Yield: " + PlayerPrefs.GetInt("HarvestScore");
        if (gameScore > highScore)
        {
            PlayerPrefs.SetInt("BestScore", gameScore);
            highScoreText.text = "This is a new personal best!";
        }
        else
        {
            highScoreText.text = "Your highest yield was: " + PlayerPrefs.GetInt("BestScore");
        }
    }
}
