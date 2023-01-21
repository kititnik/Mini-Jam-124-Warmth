using System;
using UnityEngine;

public class CollectLogs : MonoBehaviour
{
    
    [SerializeField] private string logsTag;
    [SerializeField] private LogsSpawner logsSpawner;
    [SerializeField] private Bonfire bonfire;

    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag(logsTag)) return;
        LogsHandler.ChangeLogsCount(LogsHandler.LogsCount + 1);
        Destroy(col.gameObject);
        logsSpawner.StartLogsSpawn();
    }
}
