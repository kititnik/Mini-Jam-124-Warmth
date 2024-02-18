using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private TimeToWin timeToWin;
    [SerializeField] private GameObject events;
    [SerializeField] private Bonfire bonfire;
    [SerializeField] private ResourceSpawner resourceSpawner;
    [SerializeField] private GameObject[] resources;
    [SerializeField] private Vector2 spawnArea;
    [SerializeField] private int maxResourcesCount;
    [SerializeField] private int spawnDelay;

    void Awake()
    {
        Timer timerToWin = new Timer(this);
        Timer timerToCheckChance = new Timer(this);
        Timer timerForEvent = new Timer(this);
        Timer timerToSpawn = new Timer(this);
        EventManager eventManager = new EventManager();
        eventManager.Initialize(timerToCheckChance, timerForEvent, events);
        timeToWin.Initialize(timerToWin, 120, eventManager);
        bonfire.Initialize(eventManager, null);
        resourceSpawner.Initialize(resources, timerToSpawn, spawnArea, maxResourcesCount, spawnDelay);
    }
}
