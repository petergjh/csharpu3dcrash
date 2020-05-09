using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DebugLog
{
    public enum OutputModule
    {
        eNone,
        ePve = 1,
        eWonderland = 2,
        eTrial = 3,
        eMainScene = 4,
        eUI = 5,
        eOther = 6,
        ePveBase = 7,
        eMiniGame = 8,
        eGM = 9,
        eProxy = 10,
        eLoader = 11,
        eBattle = 12,
        eResLoad = 13,
        eNetWork = 14,
        eStory = 15,
        ePlatform = 16,
    }

    public enum OutputTarget
    {
        eNone,
        eConsole = 1,
        eUI = 2,
        eFile = 3,
    }

    public enum OutputLevel
    {
        eNone,
        eLog = 1,
        eLogWaning = 2,
        eLogError = 3,
    }

    //全局控制是否开启日志
    public static bool isOpenLog;
    //控制输出的模块
    private static int outputModule;
    //控制输出的目标
    private static int outputTarget;
    //控制输出的等级
    private static int outputLevel;
    //文件路径
    private static string filePath;
    //ui显示最大缓存的日志数量
    private const int MAX_LOG_NUM = 1000;
    private static List<string> logList = new List<string>();
    //ui组件，实现循环滚动
    private static YYUIWarpContent wrapContent;

    public static void Init(YYUIWarpContent uiContent)
    {
        Application.logMessageReceived += LogCallback;

        //获取文件路径
        filePath = GetPath("LJSLogFile.txt");
        //删除已存在的文件
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        //获取ui组件
        wrapContent = uiContent;
        //是否要输出日志
        isOpenLog = true;

        //指定要输出哪些模块
        SwitchModule(OutputModule.ePve, true);
        SwitchModule(OutputModule.eWonderland, true);
        SwitchModule(OutputModule.eTrial, true);
        SwitchModule(OutputModule.eMainScene, true);
        SwitchModule(OutputModule.eUI, true);
        SwitchModule(OutputModule.eOther, true);
        SwitchModule(OutputModule.ePveBase, true);
        SwitchModule(OutputModule.eMiniGame, true);
        SwitchModule(OutputModule.eGM, true);
        SwitchModule(OutputModule.eProxy, true);
        SwitchModule(OutputModule.eLoader, true);
        SwitchModule(OutputModule.eBattle, true);
        SwitchModule(OutputModule.eResLoad, true);
        SwitchModule(OutputModule.eNetWork, true);
        SwitchModule(OutputModule.eStory, true);
        SwitchModule(OutputModule.ePlatform, true);

        //指定要输出的目标
        SwitchTarget(OutputTarget.eConsole, true);
        SwitchTarget(OutputTarget.eUI,false);
        //SwitchTarget(OutputTarget.eFile, true);

        //指定输出的级别
        SwitchLevel(OutputLevel.eLog, true);
        SwitchLevel(OutputLevel.eLogWaning, true);
        SwitchLevel(OutputLevel.eLogError, true);

    }

    public static void LogCallback(string condition, string stackTrace, LogType type)
    {
        string result = "";
        if (type == LogType.Error || type == LogType.Log || type == LogType.Warning)
        {
            result = condition;
        }
        else
        {
            result = string.Format("{0}\n{1}", condition, stackTrace);
        }

        OutputUI(result);
        OutputFile(result);
    }

    public static void Log(OutputModule type, string message)
    {
        if (!IsOuputLog(type, OutputLevel.eLog))
        {
            return;
        }

        message = ModifyLog(message, 0);
        OutputConsole(message, 0);
    }

    public static void LogWarning(OutputModule type, string message)
    {
        if (!IsOuputLog(type, OutputLevel.eLogWaning))
        {
            return;
        }

        message = ModifyLog(message, 1);
        OutputConsole(message, 1);
    }

    public static void LogError(OutputModule type, string message)
    {
        if (!IsOuputLog(type, OutputLevel.eLogError))
        {
            return;
        }

        message = ModifyLog(message, 2);
        OutputConsole(message, 2);
    }

    private static void OutputConsole(string message, int type)
    {
        if (!IsOutputTarget(OutputTarget.eConsole))
        {
            return;
        }

        if (type == 0)
        {
            Debug.Log(message);
        }
        else if (type == 1)
        {
            Debug.LogWarning(message);
        }
        else if (type == 2)
        {
            Debug.LogError(message);
        }
    }

    private static void OutputFile(string message)
    {
        if (!IsOutputTarget(OutputTarget.eFile))
        {
            return;
        }

        FileStream fs = File.Open(filePath, FileMode.Append, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(message);
        sw.Close();
        fs.Close();
    }

    private static void OutputUI(string message)
    {
        if (!IsOutputTarget(OutputTarget.eUI))
        {
            return;
        }

        if (logList.Count >= MAX_LOG_NUM)
        {
            logList.Clear();
        }
        logList.Add(message);
        wrapContent.Init(logList.Count, (obj, index) =>
        {
            Text text = obj.GetComponent<Text>();
            text.text = logList[index];
        }, null, false);
    }

    private static bool IsOuputLog(OutputModule type, OutputLevel level)
    {
        bool result = false;
        bool rule1 = (outputModule & (1 << (int)type)) > 0 ? true : false;
        bool rule2 = isOpenLog;
        bool rule3 = (outputLevel & (1 << (int)level)) > 0 ? true : false;
        if (rule1 && rule2 && rule3)
        {
            result = true;
        }

        return result;
    }

    private static bool IsOutputTarget(OutputTarget target)
    {
        bool result = false;
        result = (outputTarget & (1 << (int)target)) > 0 ? true : false;
        return result;
    }

    private static string ModifyLog(string message, int type)
    {
        string result = "";
        switch (type)
        {
            case 0:
                {
                    result += "common : ";
                }
                break;
            case 1:
                {
                    result += "warning : ";
                }
                break;
            case 2:
                {
                    result += "error : ";
                }
                break;
        }
        result += message;
        return result;
    }

    private static string GetPath(string name)
    {
        string path = "";
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
                {
                    path = Application.persistentDataPath + "/" + name;
                }
                break;
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:
                {
                    path = Application.dataPath + "/../" + name;
                }
                break;
        }

        return path;
    }

    public static void SwitchModule(OutputModule module, bool isOpen)
    {
        if (isOpen)
        {
            outputModule = outputModule | (1 << (int)module);
        }
        else
        {
            outputModule = outputModule & (~(1 << (int)module));
        }
    }

    public static void SwitchTarget(OutputTarget target, bool isOpen)
    {
        if (isOpen)
        {
            outputTarget = outputTarget | (1 << (int)target);
        }
        else
        {
            outputTarget = outputTarget & (~(1 << (int)target));
        }
    }

    public static void SwitchLevel(OutputLevel level, bool isOpen)
    {
        if (isOpen)
        {
            outputLevel = outputLevel | (1 << (int)level);
        }
        else
        {
            outputLevel = outputLevel & (~(1 << (int)level));
        }
    }
}

