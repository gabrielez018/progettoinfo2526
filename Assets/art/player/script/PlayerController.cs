using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TreesSpawnerManager treesSpawnerManager;
    private GameObject bottomLog;
    private PlayerInputSystem playerInputSystem;
    private InputAction moveRight;
    private InputAction moveLeft;
    private InputAction cut;
    void Awake()
    {
        playerInputSystem = new();
    }
    void OnEnable()
    {
        moveRight = playerInputSystem.Player.moveRight;
        moveRight.Enable();
        moveLeft = playerInputSystem.Player.moveLeft;
        moveLeft.Enable();
        cut = playerInputSystem.Player.cut;
        cut.performed += DoCut;
        cut.Enable();
    }

    private void DoCut(InputAction.CallbackContext context)
    {
        if (treesSpawnerManager.currentLogs.Count > 0)
        {
            bottomLog = treesSpawnerManager.currentLogs[0];
        }
        if (bottomLog != null)
        {
            treesSpawnerManager.OnLogCut(bottomLog);
        }
    }

    void OnDisable()
    {
        moveRight.Disable();
        moveRight.Disable();
        cut.Disable();
    }
}