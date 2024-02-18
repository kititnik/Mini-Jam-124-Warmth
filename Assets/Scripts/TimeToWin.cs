<<<<<<< Updated upstream
using System.Collections;
=======
using System;
>>>>>>> Stashed changes
using TMPro;
using UnityEngine;

public class TimeToWin : MonoBehaviour
{
    private float _startTime;
    private Timer _timer;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject winPan;
    private EventManager _eventManager;
<<<<<<< Updated upstream
    private PlayerMovement _playerMovement;
    private Bonfire _bonfire;
    private PlayerTemperature _playerTemperature;
    private Leaderboard _leaderboard;
    private long _timeInMilliseconds;
=======
    public event Action TimeIsOver;
>>>>>>> Stashed changes

    public void Initialize(Timer timer, float startTime, EventManager eventManager)
    {
<<<<<<< Updated upstream
        _eventManager = FindObjectOfType<EventManager>();
        _bonfire = FindObjectOfType<Bonfire>();
        _playerTemperature = FindObjectOfType<PlayerTemperature>();
        _leaderboard = FindObjectOfType<Leaderboard>();
        StartCoroutine(Time());
=======
        _eventManager = eventManager;
        _timer = timer;
        _startTime = startTime;
        _timer.StartTimer(startTime);
        _timer.HasBeenUpdated += OnValueChanged;
        _timer.TimeIsOver += Win;
        _timer.TimeIsOver += TimeIsOver;
>>>>>>> Stashed changes
    }

    private void OnValueChanged(float time)
    {
<<<<<<< Updated upstream
        while (PlayerTemperature.IsAlive)
        {
            yield return new WaitForSeconds(1f);
            timeInSeconds++;
            _timeInMilliseconds += 1000;
            _leaderboard.UpdateLeaderBoard(_timeInMilliseconds);
            if (timeInSeconds >= 59)
            {
                timeInMinutes++;
                timeInSeconds = 0;
            }
            timerText.text = timeInSeconds < 10 ? $"{timeInMinutes}:0{timeInSeconds}" : $"{timeInMinutes}:{timeInSeconds}";
            WorsenConditions(ref _bonfire.fadingSpeed, ref _playerTemperature.fadingSpeed, ref _eventManager.interval, ref _eventManager.eventDuration);
        }
    }

    private void WorsenConditions(ref float bonfireDecreaserSpeed, ref float playersTemperatureDecreaserSpeed, ref float timeBetweenEvents, ref float eventsDuration)
    {
        //We have: bonfire decreaser speed(0 - 1), player's temperature decreaser speed(0 - 1), time between events, events duration
        bonfireDecreaserSpeed += bonfireDecreaserSpeed / 100 * 0.5f;
        playersTemperatureDecreaserSpeed += playersTemperatureDecreaserSpeed / 100 * 0.5f;
        timeBetweenEvents -= timeBetweenEvents / 100 * 0.5f;
        eventsDuration += eventsDuration / 100 * 0.5f;
=======
        timerText.text = $"{Math.Floor(time)}";
        float part = time/_startTime;
        _eventManager.SetChance(part);
    }

    private void Win()
    {
        TimeIsOver?.Invoke();
        timerText.text = $"0";
        winPan.SetActive(true); 
        Destroy(gameObject);
>>>>>>> Stashed changes
    }
}
