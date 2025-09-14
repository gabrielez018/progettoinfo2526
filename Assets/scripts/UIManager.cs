using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("scenes settings")]
    [SerializeField] String gameSceneName;
    [SerializeField] String menuSceneName;

    [Header("gameOverBar settings")]
    [SerializeField] private float slideDuration;
    [SerializeField] private float slideYVelocity;
    private InputAction pressPause;
    private GameObject pauseMenu;
    private bool isShowingPauseMenu;
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
    void Start()
    {
        pressPause = GameManager.Instance.playerInputSystem.UI.pause;
    }
    void OnEnable()
    {
        if (pressPause == null)
        {
            pressPause = GameManager.Instance.playerInputSystem.UI.pause;
        }
        pressPause.performed += DoPause;
        pressPause.Enable();
    }
    void OnDisable()
    {
        if (pressPause == null)
        {
            pressPause = GameManager.Instance.playerInputSystem.UI.pause;
        }
        pressPause.Disable();
    }








    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
        SoundFXManager.Instance.PlaySound(SoundType.UI);
        MusicManager.Instance.PlaySound(MusicType.PLAY);
        LockCursor();
        isShowingPauseMenu = false;
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneName);
        SoundFXManager.Instance.PlaySound(SoundType.UI);
        MusicManager.Instance.PlaySound(MusicType.MAINMENU);
        UnlockCursor();
        UnRegisterPausePanel();
    }
    IEnumerator SlideUpGameOverBar()
    {
        float timer = 0f;
        while (timer < slideDuration)
        {
            timer += Time.deltaTime;

            yield return null;
        }
    }
    public void DoPause(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.gameState == GameManager.GameState.playing || GameManager.Instance.gameState == GameManager.GameState.paused)
        {
            if (!isShowingPauseMenu)
            {
                SoundFXManager.Instance.PlaySound(SoundType.UI);
                isShowingPauseMenu = true;
                Time.timeScale = 0;
                GameManager.Instance.gameState = GameManager.GameState.paused;
                UnlockCursor();
            }
            else
            {
                SoundFXManager.Instance.PlaySound(SoundType.UI);
                isShowingPauseMenu = false;
                Time.timeScale = 1;
                GameManager.Instance.gameState = GameManager.GameState.playing;
                LockCursor();
            }
            pauseMenu.SetActive(isShowingPauseMenu);
        }
    }
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RegisterPausePanel(GameObject pausePanel)
    {
        pauseMenu = pausePanel;
    }
    public void UnRegisterPausePanel()
    {
        pauseMenu = null;
    }
    
}
