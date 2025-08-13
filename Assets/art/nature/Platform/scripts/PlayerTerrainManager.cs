using UnityEngine;

public class PlayerTerrainManager : MonoBehaviour
{
    [SerializeField] GameObject[] platforms;
    [SerializeField] float platformsHeight;
    private int currentPlayerPlatform;
    [SerializeField] GameObject player;
    void Start()
    {
        currentPlayerPlatform = 0;
        player.transform.position = platforms[currentPlayerPlatform].transform.position + Vector3.up * platformsHeight;
    }

    // Update is called once per frame
    void moveLeft()
    {
        if (currentPlayerPlatform == 3)
        {
            currentPlayerPlatform = 0;
        }
        else
        {
            currentPlayerPlatform++;
        }
        teleport(currentPlayerPlatform);
    }
    void moveRight()
    {
        if (currentPlayerPlatform == 0)
        {
            currentPlayerPlatform = 3;
        }
        else
        {
            currentPlayerPlatform--;
        }
        teleport(currentPlayerPlatform);
    }
    void teleport(int platformNumber)
    {
        player.transform.position = platforms[platformNumber].transform.position + Vector3.up * platformsHeight;
    }
}
