using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeToWin : MonoBehaviour
{
    public int timeInMinutes;
    public int timeInSeconds;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject winPan;
    private EventManager _eventManager;

    private void Awake()
    {
        _eventManager = FindObjectOfType<EventManager>();
        StartCoroutine(Time());
    }

    private IEnumerator Time()
    {
        while (((timeInMinutes * 60) + timeInSeconds) > 0)
        {
            yield return new WaitForSeconds(1f);
            timeInSeconds--;
            if (timeInSeconds <= 0)
            {
                timeInMinutes--;
                timeInSeconds = 59;
            }
            if(timeInSeconds >= 10)
                timerText.text = $"{timeInMinutes}:{timeInSeconds}";
            else timerText.text = $"{timeInMinutes}:0{timeInSeconds}";
            switch (timeInMinutes)
            {
                case 4:
                    _eventManager.SetInterval(30, 60);
                    break;
                case 2:
                    _eventManager.SetInterval(20, 30);
                    break;
                case 1:
                    _eventManager.SetInterval(10, 15);
                    break;
            }
        }
        timerText.text = $"00:00";
        winPan.SetActive(true); 
        Destroy(gameObject);
    }
}
