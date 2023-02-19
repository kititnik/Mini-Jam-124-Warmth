using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTemperature : MonoBehaviour
{
    private State _state;
    private float _temperature;
    [SerializeField] private float minTemperature;
    [SerializeField] private float maxTemperature;
    public float fadingSpeed;
    [SerializeField] private string bonfireTag;
    [SerializeField] private Image vignette;
    [SerializeField] private GameObject losePan;
    private PlayerMovement _playerMovement;
    private Bonfire _bonfire;
    public static bool IsAlive;

    private void Awake()
    {
        IsAlive = true;
        _temperature = maxTemperature;
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _bonfire = FindObjectOfType<Bonfire>();
        StartCoroutine(TemperatureChanging());
    }

    private IEnumerator TemperatureChanging()
    {
        while (_temperature > minTemperature)
        {
            if (_state == State.Freeze)
            {
                _temperature -= fadingSpeed * Time.deltaTime;
            }
            else
            {
                if (!_bonfire.isBurning)
                {
                    _state = State.Freeze;
                }

                if (_temperature < maxTemperature)
                {
                    _temperature += fadingSpeed * Time.deltaTime;
                }
            }
            vignette.color = new Color(1, 1, 1, _temperature * -1 + 1);
            yield return null;
        }
        Lose();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(bonfireTag) && _bonfire.isBurning)
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
        IsAlive = false;
        losePan.SetActive(true);
        Destroy(gameObject);
    }

    private enum State
    {
        Freeze = 0,
        Heat = 1
    }
}