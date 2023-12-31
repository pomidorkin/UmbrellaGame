using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] UmbrellaMovement umbrellaMovement;
    [SerializeField] GameResetter gameResetter;
    [SerializeField] SavingHandler savingHandler;
    private Vector2 lastPosition;
    public int score = 0;

    // UI
    [SerializeField] TMP_Text recordScoreText;
    [SerializeField] TMP_Text menuScoreText;
    [SerializeField] TMP_Text scoreText;
    // Start is called before the first frame update
    private void OnEnable()
    {
        gameResetter.OnGameReset += ResetScore;
    }

    private void OnDisable()
    {
        gameResetter.OnGameReset -= ResetScore;
    }
    void Start()
    {
        lastPosition = umbrellaMovement.transform.position;
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateHighScore()
    {
        if (savingHandler.saveManager.State.highScore < score)
        {
            savingHandler.saveManager.State.highScore = score;
            SaveManager.Instance.Save();
        }
        recordScoreText.text = "Your Record: " + savingHandler.saveManager.State.highScore;
        menuScoreText.text = "Your Score: " + score;
        Debug.Log("Record: " + savingHandler.saveManager.State.highScore + ", current score: " + score);
    }

    public void ResetScore()
    {
        UpdateHighScore();
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }
}
