using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogsHandler : MonoBehaviour
{
    public static int LogsCount { get; private set; }
    
    private void Awake()
    {
        LogsCount = 0;
    }
    
    public static void ChangeLogsCount(int value)
    {
        if (value < 0) throw new ArgumentException("Not enought logs");
        LogsCount = value;
    }
}
