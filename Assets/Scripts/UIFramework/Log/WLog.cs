//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;
//
//public class WLog : MonoBehaviour
//{
//    [Header("是否保存日志")]
//    public bool _SaveLog = true;
//
//    [Header("日志保存类型")]
//    public bool _Log = true;
//    public bool _Warning = true;
//    public bool _Assert = true;
//    public bool _Exception = true;
//    public bool _Error = true;
//    [HideInInspector]
//    public string log;
//    [HideInInspector]
//    public string date;
//
//    private void Awake()
//    {
//        date = TimeToString();
//        Application.logMessageReceivedThreaded += CaptureLogThread;
//        Debug.Log("日志Log管理器初始化完成。");
//    }
//
//    private void CaptureLogThread(string condition, string stackTrace, LogType type)
//    {
//        switch (type)
//        {
//            case LogType.Error:
//                if (!_Error)
//                {
//                    return;
//                }
//                break;
//            case LogType.Assert:
//                if (!_Assert)
//                {
//                    return;
//                }
//                break;
//            case LogType.Warning:
//                if (!_Warning)
//                {
//                    return;
//                }
//                break;
//            case LogType.Log:
//                if (!_Log)
//                {
//                    return;
//                }
//                break;
//            case LogType.Exception:
//                if (!_Exception)
//                {
//                    return;
//                }
//                break;
//            default:
//                break;
//        }
//        log += type + " >> " + DateTime.Now.ToString() + "\n" + condition + "\n" + StackTraceUtility.ExtractStackTrace() + "\n";
//    }
//
//    private void OnApplicationQuit()
//    {
//        SaveLog();
//    }
//
//    void SaveLog()
//    {
//        if (_SaveLog)
//        {
//            string path = Path.Combine(Directory.GetCurrentDirectory(), "Log");
//            if (!File.Exists(path))
//            {
//                Directory.CreateDirectory(path);
//            }
//            string file = Path.Combine(path, date + ".txt");
//            Debug.Log("path: " + file);
//            StreamWriter streamReader = new StreamWriter(file);
//            streamReader.Write(log);
//            streamReader.Dispose();
//        }
//    }
//
//
//    string TimeToString()
//    {
//        string date;
//        date =
//        string.Format("[Log] {0}-{1}-{2}  {3}-{4}-{5}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, (DateTime.Now.Hour > 9 ? DateTime.Now.Hour.ToString() : "0" + DateTime.Now.Hour),
//        (DateTime.Now.Minute > 9 ? DateTime.Now.Minute.ToString() : "0" + DateTime.Now.Minute),
//        (DateTime.Now.Second > 9 ? DateTime.Now.Second.ToString() : "0" + DateTime.Now.Second));
//        return date;
//    }
//}