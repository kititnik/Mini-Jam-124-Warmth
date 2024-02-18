using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bonfire : MonoBehaviour
{
    private EventManager _eventManager;
    [SerializeField] private float startFadingSpeed;
    public static float BurningLevel { get; private set; }
    public bool isBurning;
    public float fadingSpeed;
    [SerializeField] private Image burningLevelScale;
    [SerializeField] private GameObject putOnLogsBtn;
    [SerializeField] private GameObject particles;
    [SerializeField] private Sprite bonfireOutSprite;
    private LogsHandler _logsHandler;
    private Image _image;
    private Animator _animator;
    [SerializeField] private new Light light;

    public void Initialize(EventManager eventManager, LogsHandler logsHandler)
    {
        _image = GetComponent<Image>();
        _animator = GetComponent<Animator>();
        _logsHandler = logsHandler;
        _eventManager = eventManager;
        _eventManager.EventStarted += IncreaseHeatLoss;
        _eventManager.EventEnded += RevertHeatLoss;
        BurningLevel = 1;
        isBurning = true;
        StartCoroutine(BurningBonfire());
    }

    private void IncreaseHeatLoss()
    {
        fadingSpeed *= 3f;
    }

    private void RevertHeatLoss()
    {
        fadingSpeed = startFadingSpeed;
    }

    private IEnumerator BurningBonfire()
    {
        while (BurningLevel > 0)
        {
            BurningLevel -= fadingSpeed * Time.deltaTime;
            light.range = 25 * BurningLevel;
            burningLevelScale.fillAmount = BurningLevel;
            yield return null;
        }
        Destroy(putOnLogsBtn);
        Destroy(particles);
        Destroy(_animator);
        _image.sprite = bonfireOutSprite;
        isBurning = false;
    }

    public static void SetBurningLevel(float value)
    {
        if (value > 1) value = 1;
        if (value < 0) value = 0.25f;
        BurningLevel = value;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(putOnLogsBtn == null) return;
        if (col.CompareTag("Player"))
        {
            putOnLogsBtn.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(putOnLogsBtn == null) return;
        if (col.CompareTag("Player"))
        {
            putOnLogsBtn.SetActive(false);
        }
    }

    public void PutOnLogs()
    {
        try
        {
            _logsHandler.ChangeLogsCount(LogsHandler.LogsCount - 1);
        }
        catch
        {
            return;
        }
        SetBurningLevel(BurningLevel + 0.2f);
    }
}
