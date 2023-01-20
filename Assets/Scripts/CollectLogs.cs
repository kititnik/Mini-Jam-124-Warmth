using UnityEngine;

public class CollectLogs : MonoBehaviour
{
    public int logsCount;
    [SerializeField] private string logsTag;
    [SerializeField] private LogsSpawner logsSpawner;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag(logsTag)) return;
        logsCount++;
        Destroy(col.gameObject);
        logsSpawner.StartLogsSpawn();
    }
}
