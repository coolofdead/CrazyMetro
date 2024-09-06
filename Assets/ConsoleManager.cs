using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConsoleManager : MonoBehaviour
{
    public static ConsoleManager Instance;

    public TMP_Text logPrefab;
    public Transform logsAnchor;

    private void Awake()
    {
        Instance = this;
    }

    public void PrintLog(string message)
    {
        var newLog = Instantiate(logPrefab, logsAnchor);
        newLog.text = message;
    }
}
