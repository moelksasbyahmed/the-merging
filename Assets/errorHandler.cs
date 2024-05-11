using System;
using System.IO;
using UnityEngine;

public class errorHandler : MonoBehaviour
{
    void Start()
    {
        Application.logMessageReceived += OnLogMessageReceived;
    }

    void OnLogMessageReceived(string condition, string stackTrace, LogType type)
    {
        if (type == LogType.Exception)
        {
            Debug.LogError("Exception occurred: " + stackTrace);
            DateTime now = DateTime.Now;
            string timestamp = now.ToString("yyyy-MM-dd HH:mm:ss"); 

            File.AppendAllText(Path.Combine(Application.dataPath, "Resources/" + "log.txt"), $"\n [{timestamp}]     {condition}       {stackTrace}     \n");

        }
    }
}