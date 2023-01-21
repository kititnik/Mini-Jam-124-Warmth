using System;
using UnityEngine;

public class CollectLogs : MonoBehaviour
{
    public static int LogsCount { get; private set; }
    [SerializeField] private string logsTag;
    [SerializeField] private LogsSpawner logsSpawner;
    [SerializeField] private Bonfire bonfire;

    private void Awake()
    {
        LogsCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag(logsTag)) return;
        LogsCount++;
        Destroy(col.gameObject);
        logsSpawner.StartLogsSpawn();
    }

    public static void ChangeLogsCount(int value)
    {
        if (value < 0) throw new ArgumentException("Not enought logs");
        LogsCount = value;
    }
}
