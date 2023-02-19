using System.Collections;
using UnityEngine;
using DG.Tweening;

public class LogsSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 size;
    [SerializeField] private int secondsBetweenSpawns;
    [SerializeField] private GameObject logs;
    private int _spawnedLogsCount;
    [SerializeField] private int maxLogsCount;
    private void Start()
    {
        StartCoroutine(nameof(Spawn));
    }

    public void StartLogsSpawn()
    {
        _spawnedLogsCount--;
        StartCoroutine(nameof(Spawn));
    }

    private IEnumerator Spawn()
    {
        while (_spawnedLogsCount < maxLogsCount)
        {
            _spawnedLogsCount++;
            var pos = transform.position + new Vector3(
                Random.Range(-size.x / 2, size.x / 2),
                Random.Range(-size.y / 2, size.y / 2),
                90);
            yield return new WaitForSeconds(secondsBetweenSpawns);
            Instantiate(logs, pos, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
    }
}
