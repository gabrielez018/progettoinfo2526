
using System.Collections.Generic;
using UnityEngine;

public class TreesSpawnerManager : MonoBehaviour
{
    [SerializeField] GameObject[] logs;
    [SerializeField] float logHeight;
    [SerializeField] int logCount;
    private float nextLogToSpawnYposition;
    public List<GameObject> currentLogs = new List<GameObject>();

    void Start()
    {
        GenerateLogAtStart();
    }

    // Update is called once per frame
    void GenerateLogAtStart()
    {
        //make the initial y of the log spawner to 0 to make on the floor
        nextLogToSpawnYposition = 0;
        for (int i = 0; i < logCount; i++)
        {
            SpawnNewLog();
        }

    }
    void SpawnNewLog()
    {
        GameObject randomLogPrefab = null;
        if (nextLogToSpawnYposition == 0)
        {
            randomLogPrefab =  logs[0];
        }
        else
        {
            randomLogPrefab = logs[Random.Range(0, logs.Length)];
        } 
        GameObject NewLog = Instantiate(randomLogPrefab, transform.position + Vector3.up * nextLogToSpawnYposition, getRandomRotation());
        currentLogs.Add(NewLog);
        NewLog.transform.SetParent(this.transform);
        nextLogToSpawnYposition += logHeight;
    }
    public void OnLogCut(GameObject cuttedLog)
{
    if (currentLogs.Contains(cuttedLog))
    {
        currentLogs.Remove(cuttedLog);
    }

    foreach (GameObject log in currentLogs)
    {
        log.transform.position -= Vector3.up * logHeight;
    }

    
    nextLogToSpawnYposition -= logHeight;


    SpawnNewLog();

    Destroy(cuttedLog);
}
    private Quaternion getRandomRotation()
    {
        return Quaternion.Euler(0, Random.Range(0, 4) * 90, 0);
    }
}
