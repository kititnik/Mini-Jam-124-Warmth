using System;
using UnityEngine;
using TMPro;

public class LogsHandler : MonoBehaviour
{
    public static int LogsCount { get; private set; }
    [SerializeField] private TMP_Text logsCountTxt;
    
    private void Awake()
    {
        LogsCount = 0;
    }
    
    public void ChangeLogsCount(int value)
    {
        if (value < 0) throw new ArgumentException("Not enought logs");
        LogsCount = value;
        UpdateLogsCountText();
    }

    private void UpdateLogsCountText()
    {
        logsCountTxt.text = LogsCount.ToString();
    }
}
