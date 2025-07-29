using UnityEngine;

public class TreesSpawnerManager : MonoBehaviour
{
    [SerializeField] GameObject[] Logs;
    [SerializeField] float LogHeight;
    [SerializeField] int LogCount;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void GenerateLogAtStart()
    {
        //make the initial y of the log spawner to 0 to make on the floor
        float NextLogToSpawnPosition = 0;
        for (int i = 0; i < LogCount; i++)
        {
            SpawnNewLog();
        }

    }
    void SpawnNewLog()
    {
        GameObject RandomLogPrefab = Logs[Random.Range(0, Logs.Length)];
        
    }
}
