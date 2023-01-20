using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLogs : MonoBehaviour
{
    public int logsCount;
    [SerializeField] private string logsTag;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag(logsTag)) return;
        logsCount++;
        Destroy(col.gameObject);
    }
}
