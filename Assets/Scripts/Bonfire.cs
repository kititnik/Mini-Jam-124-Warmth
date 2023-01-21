using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Bonfire : MonoBehaviour
{
    public static float BurningLevel { get; private set; }
    [SerializeField] private float fadingSpeed; 
    [SerializeField] private Image burningLevelScale;
    [SerializeField] private GameObject putOnLogsBtn;

    private void Start()
    {
        BurningLevel = 1;
    }

    private void Update()
    {
        if (BurningLevel > 0)
        {
            BurningLevel -= fadingSpeed * Time.deltaTime;
            burningLevelScale.fillAmount = BurningLevel;
        }
        else
        {
            print("F");
        }
    }

    public static void SetBurningLevel(float value)
    {
        if (value > 1) value = 1;
        if (value < 0) value = 0;
        BurningLevel = value;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            putOnLogsBtn.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            putOnLogsBtn.SetActive(false);
        }
    }

    public void PutOnLogs()
    {
        try
        {
            CollectLogs.ChangeLogsCount(CollectLogs.LogsCount - 1);
        }
        catch
        {
            return;
        }
        SetBurningLevel(BurningLevel + 0.2f);
    }
}
