
using System.Collections.Generic;
using UnityEngine;

public class TreesSpawnerManager : MonoBehaviour
{
    [SerializeField] GameObject[] Logs;
    [SerializeField] float LogHeight;
    [SerializeField] int LogCount;
    private float NextLogToSpawnYPosition;
    private List<GameObject> CurrentLogs = new List<GameObject>();

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
        NextLogToSpawnYPosition = 0;
        for (int i = 0; i < LogCount; i++)
        {
            SpawnNewLog();
        }

    }
    void SpawnNewLog()
    {
        GameObject RandomLogPrefab = Logs[Random.Range(0, Logs.Length)];
        GameObject NewLog = Instantiate(RandomLogPrefab, transform.position + Vector3.up * NextLogToSpawnYPosition, Quaternion.identity);
        NewLog.transform.SetParent(this.transform);
        CurrentLogs.Add(NewLog);
        NextLogToSpawnYPosition = NextLogToSpawnYPosition + LogHeight;
    }
}
