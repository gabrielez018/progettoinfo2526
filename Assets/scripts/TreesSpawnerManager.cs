
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class TreesSpawnerManager : MonoBehaviour
{
    [SerializeField] GameObject[] logs;
    [SerializeField] float logHeight;
    [SerializeField] int logCount;
    private float nextLogToSpawnYposition;
    private List<GameObject> currentLogs = new List<GameObject>();

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
        GameObject RandomLogPrefab = logs[Random.Range(0, logs.Length)];
        Quaternion RandomYRotation = Quaternion.Euler(0,Random.Range(0,4)*90,0);
        GameObject NewLog = Instantiate(RandomLogPrefab, transform.position + Vector3.up * nextLogToSpawnYposition, RandomYRotation);
        NewLog.transform.SetParent(this.transform);
        currentLogs.Add(NewLog);
        nextLogToSpawnYposition = nextLogToSpawnYposition + logHeight;
    }
    public void OnLogCut(GameObject cuttedLog)
    {
        if(currentLogs.Contains(cuttedLog)){
            currentLogs.Remove(cuttedLog);
        }
        Destroy(cuttedLog);
        foreach (GameObject log in currentLogs)
        {
            log.transform.position -= Vector3.up * logHeight;
        }
    }
}
