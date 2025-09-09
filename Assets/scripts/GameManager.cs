using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public enum GameState
    {
        playing,
        paused,
        gameOver,
        mianMenu
    }
    private int score;
    public GameState gameState;
    private TMP_Text scoreText;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        StartGame();
    }
    public void AddScore()
    {
        score++;
    }
    public int GetScore()
    {
        return score;
    }
    public void StartGame()
    {
        gameState = GameState.playing;
        score = 0;
    }
    public void PauseGame()
    {
        gameState = GameState.paused;
    }
    public void EndGame()
    {
        gameState = GameState.gameOver;
    }
    public void RegisterText(TMP_Text text)
    {
        scoreText = text;
    }
    public void UpdateScoreUi()
    {
        if (scoreText != null)
        {
            scoreText.text = GetScore().ToString();
        }
    }
    

}
