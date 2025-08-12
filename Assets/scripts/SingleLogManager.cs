using UnityEngine;

public class SingleLogManager : MonoBehaviour
{
    [SerializeField] TreesSpawnerManager treesSpawnerManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            treesSpawnerManager.OnLogCut(this.gameObject);
        }
    }
}
