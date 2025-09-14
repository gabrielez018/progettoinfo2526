using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TreesSpawnerManager treesSpawnerManager;
    private InputAction moveRight;
    private InputAction moveLeft;
    private InputAction cut;
    [SerializeField] PlayerTerrainManager playerTerrainManager;
    [SerializeField] Animator animator;
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject player;
    [SerializeField] GameObject deadPlayer;
    [SerializeField] private TimeBarManager timeBarManager;
    private bool started;

    void Start()
    {
        started = false;
        timeBarManager.ResetBar();
        GameManager.Instance.UpdateScoreUi();
    }
    void OnEnable()
    {
        moveRight = GameManager.Instance.playerInputSystem.Player.moveRight;
        moveRight.performed += DoMoveRight;
        moveRight.Enable();
        moveLeft = GameManager.Instance.playerInputSystem.Player.moveLeft;
        moveLeft.performed += DoMoveLeft;
        moveLeft.Enable();
        cut = GameManager.Instance.playerInputSystem.Player.cut;
        cut.performed += DoCut;
        cut.Enable();
    }

    private void DoMoveLeft(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.gameState == GameManager.GameState.playing)
        {
            if (playerTerrainManager != null)
            {

                playerTerrainManager.moveLeft();
            }
        }
    }
    private void DoMoveRight(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.gameState == GameManager.GameState.playing)
        {
            if (playerTerrainManager != null)
            {

                playerTerrainManager.moveRight();
            }
        }

    }

    private void DoCut(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.gameState == GameManager.GameState.playing)
        {
            animator.SetTrigger("cut");
            SoundFXManager.Instance.PlaySound(SoundType.CUT);
            cameraController.SetShake();
            GameManager.Instance.AddScore();
            GameManager.Instance.UpdateScoreUi();
            timeBarManager.OnLogCut();
            started = true;

            
            if (treesSpawnerManager.currentLogs.Count > 0)
            {
                GameObject bottomLog = treesSpawnerManager.currentLogs[0];


                if (bottomLog != null)
                {
                    treesSpawnerManager.OnLogCut(bottomLog);
                }
            }
        }
        
        
    }

    void OnDisable()
    {
        moveRight.Disable();
        moveLeft.Disable();
        cut.Disable();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trunk"))
        {
            PlayerDeath();
        }
    }
    private void SwitchPlayer()
    {
        Instantiate(deadPlayer, player.transform.position, player.transform.rotation);
        Destroy(player);
    }
    public void PlayerDeath()
    {
        GameManager.Instance.EndGame();
        SoundFXManager.Instance.PlaySound(SoundType.DEATH);
        SwitchPlayer();
        cameraController.SetShakeDuration(2f);
        cameraController.SetShake();
    }
    void Update()
    {
        if (!started)
        {
            timeBarManager.ResetBar();
        }
    }
    
}