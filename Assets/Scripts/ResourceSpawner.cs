using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    private Vector2 _spawnArea;
    private int _spawnedResourcesCount;
    private int _maxResourcesCount;
    private GameObject[] _resources;
    private Timer _timerToSpawn;
    private float _spawnDelay;
    public void Initialize(
        GameObject[] resources, 
        Timer timerToSpawn, 
        Vector2 spawnArea, 
        int maxResourcesCount, 
        int spawnDelay)
    {
        _spawnDelay = spawnDelay;
        _maxResourcesCount = maxResourcesCount;
        _spawnArea = spawnArea;
        _timerToSpawn = timerToSpawn;
        _resources = resources;
        _timerToSpawn.StartTimer(_spawnDelay);
        _timerToSpawn.TimeIsOver += Spawn;
    }

    private void Spawn()
    {
        _timerToSpawn.StartTimer(_spawnDelay);
        if(_spawnedResourcesCount >= _maxResourcesCount) return;
        GameObject objToSpawn = _resources[Random.Range(0, _resources.Length-1)];
        var pos = (Vector2)transform.position + new Vector2(
                Random.Range(-_spawnArea.x / 2, _spawnArea.x / 2),
                Random.Range(-_spawnArea.y / 2, _spawnArea.y / 2));
        Instantiate(objToSpawn, pos, Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }
}
