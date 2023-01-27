using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Bonfire : MonoBehaviour
{
    public static float BurningLevel { get; private set; }
    public bool isBurning;
    public float fadingSpeed;
    [SerializeField] private Image burningLevelScale;
    [SerializeField] private GameObject putOnLogsBtn;
    [SerializeField] private Sprite bonfireOutSprite;
    private LogsHandler _logsHandler;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    [SerializeField] private new Light light;

    private void Awake()
    {
        _logsHandler = FindObjectOfType<LogsHandler>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        BurningLevel = 1;
        isBurning = true;
        StartCoroutine(BurningBonfire());
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
        Destroy(_animator);
        _spriteRenderer.sprite = bonfireOutSprite;
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
