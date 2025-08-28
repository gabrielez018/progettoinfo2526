using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public enum GameState
    {
        playing,
        paused,
        gameOver
    }
    private int score;
    public GameState gameState;

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
        startGame();
    }
    public void addScore()
    {
        score++;
    }
    public int setScore()
    {
        return score;
    }
    public void startGame()
    {
        gameState = GameState.playing;
    }
    public void pauseGame()
    {
        gameState = GameState.paused;
    }
    public void endGame()
    {
        gameState = GameState.gameOver;
    }
    

}
