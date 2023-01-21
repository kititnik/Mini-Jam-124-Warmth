using System;
using UnityEngine;

public class PlayerTemperature : MonoBehaviour
{
    private State _state;
    private float _temperature;
    [SerializeField] private float minTemperature;
    [SerializeField] private float maxTemperature;
    [SerializeField] private float fadingSpeed;
    [SerializeField] private string bonfireTag;
    [SerializeField] private Bonfire bonfire;

    private void Awake()
    {
        _temperature = maxTemperature;
    }

    private void Update()
    {
        if (_state == State.Freeze)
        {
            if (_temperature > minTemperature)
            {
                _temperature -= fadingSpeed * Time.deltaTime;
            }
            else
            {
                Lose();
            }
        }
        else
        {
            if (!bonfire.isBurning)
            {
                _state = State.Freeze;
            }

            if (_temperature < maxTemperature)
            {
                _temperature += fadingSpeed * Time.deltaTime;
            }
        }

        Debug.Log(_temperature);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(bonfireTag) && bonfire.isBurning)
        {
            _state = State.Heat;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag(bonfireTag))
        {
            _state = State.Freeze;
        }
    }

    private void Lose()
    {
        print("F");
    }

    private enum State
    {
        Freeze = 0,
        Heat = 1
    }
}