using UnityEngine;
using UnityEngine.Serialization;

public class CollectLogs : MonoBehaviour
{
    [SerializeField] private string logsTag;
    [SerializeField] private LogsSpawner logsSpawner;
    [SerializeField] private AudioClip stickTaking;
    private LogsHandler _logsHandler;
    [SerializeField] private AudioSource stickTakingAuso;

    private void Awake()
    {
        _logsHandler = FindObjectOfType<LogsHandler>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag(logsTag)) return;
        _logsHandler.ChangeLogsCount(LogsHandler.LogsCount + 1);
        stickTakingAuso.PlayOneShot(stickTaking);
        Destroy(col.gameObject);
        logsSpawner.StartLogsSpawn();
    }
}
