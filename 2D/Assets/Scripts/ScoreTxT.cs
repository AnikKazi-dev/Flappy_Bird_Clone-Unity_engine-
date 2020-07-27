using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTxT : MonoBehaviour
{
    // Start is called before the first frame update
    Text scoreText;
    int score = 0;
    int highScore;
    public Text panelHighScore;
    public Text panelScore;
    public GameObject newImg;

    void Start()
    {
        scoreText = GetComponent<Text>();
        panelScore.text = score.ToString();
        highScore = PlayerPrefs.GetInt("HighScore");
        panelHighScore.text = highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetScore()
    {
        return score;
    }
    public void Scored()
    {
        score++;
        // Debug.Log(score);
        
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();

        if(score > highScore)
        {
            newImg.SetActive(true);
            highScore = score;
            panelHighScore.text = highScore.ToString();

            PlayerPrefs.SetInt("HighScore",highScore);
        }
    }
}
