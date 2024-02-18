using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventManager
{
<<<<<<< Updated upstream
    [SerializeField] private GameObject[] events;
    public float eventDuration;
    public float interval;
    private Bonfire _bonfire;
=======
    private Timer _timerToCheckChance;
    private Timer _timerForEvent;
    private GameObject currentEvent;
    private GameObject _events;
    private float _chanceToSpawn;
    public event Action EventStarted;
    public event Action EventEnded;
>>>>>>> Stashed changes

    public static void A()
    {
        
    }

<<<<<<< Updated upstream
    private IEnumerator StartEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            var e = events[Random.Range(0, events.Length-1)];
            e.SetActive(true);
            var normalFadingSpeed = _bonfire.fadingSpeed;
            _bonfire.fadingSpeed *= 3f;
            yield return new WaitForSeconds(eventDuration);
            e.SetActive(false);
            _bonfire.fadingSpeed = normalFadingSpeed;
        }
=======
    public void Initialize(Timer timerToCheckChance, Timer timerForEvent, GameObject events)
    {
        _events = events;
        _timerToCheckChance = timerToCheckChance;
        _timerForEvent = timerForEvent;
        _timerToCheckChance.TimeIsOver += CheckChance;
        _timerForEvent.TimeIsOver += EndEvent;
        _timerToCheckChance.StartTimer(20);
    }

    private void CheckChance()
    {
        int i = Random.Range(1, 10);
        if(i < _chanceToSpawn) StartEvent();
    }

    private void StartEvent()
    {
        currentEvent = _events;
        currentEvent.SetActive(true);
        EventStarted?.Invoke();
        _timerForEvent.StartTimer(10);
    }

    private void EndEvent()
    {
        currentEvent.SetActive(false);
        EventEnded?.Invoke();
        _timerToCheckChance.StartTimer(20);
    }

    public void SetChance(float partOfTime)
    {
        _chanceToSpawn = 10 * partOfTime;
>>>>>>> Stashed changes
    }
}
