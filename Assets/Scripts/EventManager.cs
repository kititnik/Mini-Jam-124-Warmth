using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject[] events;
    public float eventDuration;
    public float interval;
    private Bonfire _bonfire;

    private void Start()
    {
        _bonfire = FindObjectOfType<Bonfire>();
        StartCoroutine(StartEvent());
    }

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
    }
}
