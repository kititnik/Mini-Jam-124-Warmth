using System;
using UnityEngine;

public class LogsHandler : MonoBehaviour
{
    public static int LogsCount { get; private set; }
    
    private void Awake()
    {
        LogsCount = 10000;
    }
    
    public static void ChangeLogsCount(int value)
    {
        if (value < 0) throw new ArgumentException("Not enought logs");
        LogsCount = value;
    }
}
