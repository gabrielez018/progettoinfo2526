using UnityEngine;
using UnityEngine.UI;

public class TimeBarManager : MonoBehaviour
{
    [Header("Bar Settings")]
    public Image timeBarFill;
    public float maxTime = 5f;
    private float currentTime;

    [Header("Difficulty")]
    public float decreaseRate = 1f;
    public float increasePerLog = 0.2f;
    private bool isRunning = true;
    [SerializeField] private float maxDecreaseRate;
    [SerializeField] private float cuttingAdditionTime = 0f;
    [SerializeField] PlayerController playerController;
    private void Start()
    {
        currentTime = maxTime;
    }

    private void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.playing)
        {
            if (!isRunning) return;

            currentTime -= Time.deltaTime * decreaseRate;

            if (currentTime <= 0)
            {
                currentTime = 0;
                playerController.PlayerDeath();
                isRunning = false;
            }

            UpdateBarUI();
        }

    }

    private void UpdateBarUI()
    {
        if (timeBarFill != null)
        {
            timeBarFill.fillAmount = currentTime / maxTime;
        }
    }

    public void OnLogCut()
    {
        currentTime = Mathf.Min(currentTime + cuttingAdditionTime, maxTime);

        if (decreaseRate < maxDecreaseRate)
        {
            decreaseRate += increasePerLog;
        }
    }

    public void ResetBar()
    {
        currentTime = maxTime;
        decreaseRate = 1f;
        isRunning = true;
    }
}
