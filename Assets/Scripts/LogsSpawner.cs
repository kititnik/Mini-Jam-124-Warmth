using System.Collections;
using System.Net.Mime;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LogsSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 size;
    [SerializeField] private int secondsBetweenSpawns;
    [SerializeField] private GameObject logs;
    private int _spawnedLogsCount;
    [SerializeField] private int maxLogsCount;
    [SerializeField] private Sprite[] stickSprites;
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
            var log = Instantiate(logs, pos, Quaternion.identity);
            log.GetComponent<SpriteRenderer>().sprite = stickSprites[Random.Range(0, stickSprites.Length-1)];
        }
    }
}
