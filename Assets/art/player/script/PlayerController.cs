using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TreesSpawnerManager treesSpawnerManager;
    private PlayerInputSystem playerInputSystem;
    private InputAction moveRight;
    private InputAction moveLeft;
    private InputAction cut;
    [SerializeField] PlayerTerrainManager playerTerrainManager;
    void Awake()
    {
        playerInputSystem = new();
    }
    void OnEnable()
    {
        moveRight = playerInputSystem.Player.moveRight;
        moveRight.performed += DoMoveRight;
        moveRight.Enable();
        moveLeft = playerInputSystem.Player.moveLeft;
        moveLeft.performed += DoMoveLeft;
        moveLeft.Enable();
        cut = playerInputSystem.Player.cut;
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
            GameManager.Instance.endGame();
            OnDisable();
        }
    }
}