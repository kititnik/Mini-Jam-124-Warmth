using System.Collections;
using TMPro;
using UnityEngine;

public class TimeToWin : MonoBehaviour
{
    public int timeInMinutes;
    public int timeInSeconds;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject winPan;
    private EventManager _eventManager;
    private PlayerMovement _playerMovement;
    private Bonfire _bonfire;
    private PlayerTemperature _playerTemperature;
    private Leaderboard _leaderboard;
    private long _timeInMilliseconds;

    private void Awake()
    {
        _eventManager = FindObjectOfType<EventManager>();
        _bonfire = FindObjectOfType<Bonfire>();
        _playerTemperature = FindObjectOfType<PlayerTemperature>();
        _leaderboard = FindObjectOfType<Leaderboard>();
        StartCoroutine(Time());
    }

    private IEnumerator Time()
    {
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
    }
}
