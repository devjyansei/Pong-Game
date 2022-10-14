using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    public static GameManager instance;
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI scoreText;
    int score;

    public int Score{get { return score; } set { score = value; }}

    RacketController racketController;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        racketController = FindObjectOfType<RacketController>();
    }
    
    public void UpdateScore()
    {
        scoreText.text = Score.ToString();
        racketController.AiSpeed += 0.5f;
    }
    public void StartGame() 
    {
        button.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        BallController.instance.OnMyStart();
    }
    public void GameOver()
    {
        button.gameObject.SetActive(true);
        BallController.instance.transform.position = Vector2.zero;
        score = 0;
        UpdateScore();
    }

}
