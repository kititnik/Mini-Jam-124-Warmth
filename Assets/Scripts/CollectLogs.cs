using System;
using UnityEngine;

public class CollectLogs : MonoBehaviour
{
    
    [SerializeField] private string logsTag;
    [SerializeField] private LogsSpawner logsSpawner;
    private LogsHandler _logsHandler;
    private AudioSource _audioSource;

    private void Awake()
    {
        _logsHandler = FindObjectOfType<LogsHandler>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag(logsTag)) return;
        _logsHandler.ChangeLogsCount(LogsHandler.LogsCount + 1);
        _audioSource.Play();
        Destroy(col.gameObject);
        logsSpawner.StartLogsSpawn();
    }
}
