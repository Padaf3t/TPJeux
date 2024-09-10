using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMasterScript : MonoBehaviour
{
    public const float xBoudaries = 10;
    public int score = 0;
    public Text scoreText;


    public void AddScore(int scoreAdded)
    {
        score += scoreAdded;
        scoreText.text = "Score : " + score.ToString();
    }
}
