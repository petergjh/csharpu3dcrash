using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggerLog : MonoBehaviour {


    public struct LogInfo
    {
        public LogType type;
        public string desc;

        public LogInfo(LogType type, string desc)
        {
            this.type = type;
            this.desc = desc;
        }
    }

    //错误详情
    public List<LogInfo> m_logEntries = new List<LogInfo>();
    public List<LogInfo> m_logLog = new List<LogInfo>();
    public List<LogInfo> m_logWarning = new List<LogInfo>();
    public List<LogInfo> m_logError = new List<LogInfo>();
    public List<LogInfo> curLog = new List<LogInfo>();
    //是否显示错误窗口
    private bool m_IsVisible = false;
    //窗口显示区域
    private Rect m_WindowRect = new Rect(0, 0, Screen.width, Screen.height);
    //窗口滚动区域
    private Vector2 m_scrollPositionText = Vector2.zero;
    //字体大小
    private int fontSize = 30;

    public List<string> s1 = new List<string>();

    GUISkin skin;

    private void Start()
    {
        skin = Resources.Load<GUISkin>("GUISkin");
        curLog = m_logEntries;
        ////监听错误
        Application.logMessageReceivedThreaded += (condition, stackTrace, type) =>
        {
            if (!m_IsVisible)
            {
                m_IsVisible = true;
            }
            switch (type)
            {
                case LogType.Warning:
                    m_logWarning.Add(new LogInfo(type, string.Format("{0}\n{1}", condition, stackTrace)));
                    break;
                case LogType.Log:
                    m_logLog.Add(new LogInfo(type, string.Format("{0}\n{1}", condition, stackTrace)));
                    break;
                case LogType.Error:
                case LogType.Exception:
                    m_logError.Add(new LogInfo(type, string.Format("{0}\n{1}", condition, stackTrace)));
                    break;
            }
            m_logEntries.Add(new LogInfo(type, string.Format("{0}\n{1}", condition, stackTrace)));
            s1.Add(stackTrace);
        };

        for (int i = 0; i < 10; i++)
        {
            Debug.LogError("错误啊！！");
            Debug.LogWarning("警告啊！！");
            print("正常输出");
        }
        int[] a = null;
        a[1] = 100;
    }

    void OnGUI()
    {
        if (m_IsVisible)
        {
            m_WindowRect = GUILayout.Window(0, m_WindowRect, ConsoleWindow, "Console");
        }
    }

    //日志窗口
    void ConsoleWindow(int windowID)
    {
        GUILayout.BeginHorizontal();
        skin.button.fontSize = fontSize;
        skin.textArea.fontSize = fontSize;
        if (GUILayout.Button("Clear", skin.button, GUILayout.MaxWidth(200), GUILayout.MaxHeight(100)))
        {
            m_logEntries.Clear();
        }
        if (GUILayout.Button("Close", skin.button, GUILayout.MaxWidth(200), GUILayout.MaxHeight(100)))
        {
            m_IsVisible = false;
        }
        if (GUILayout.Button("AddFontSize", skin.button, GUILayout.MaxWidth(200), GUILayout.MaxHeight(100)))
        {
            fontSize++;
        }
        if (GUILayout.Button("ReduceFontSize", skin.button, GUILayout.MaxWidth(200), GUILayout.MaxHeight(100)))
        {
            fontSize--;
        }
        if (GUILayout.Button("Log", skin.button, GUILayout.MaxWidth(200), GUILayout.MaxHeight(100)))
        {
            if (curLog == m_logLog)
                curLog = m_logEntries;
            else
                curLog = m_logLog;
        }
        if (GUILayout.Button("Warning", skin.button, GUILayout.MaxWidth(200), GUILayout.MaxHeight(100)))
        {
            if (curLog == m_logWarning)
                curLog = m_logEntries;
            else
                curLog = m_logWarning;
        }
        if (GUILayout.Button("Error", skin.button, GUILayout.MaxWidth(200), GUILayout.MaxHeight(100)))
        {
            if (curLog == m_logError)
                curLog = m_logEntries;
            else
                curLog = m_logError;
        }
        GUILayout.EndHorizontal();
        m_scrollPositionText = GUILayout.BeginScrollView(m_scrollPositionText, skin.horizontalScrollbar, skin.verticalScrollbar);
        foreach (var entry in curLog)
        {
            Color currentColor = GUI.contentColor;
            switch (entry.type)
            {
                case LogType.Warning:
                    GUI.contentColor = Color.white;
                    break;
                case LogType.Assert:
                    GUI.contentColor = Color.black;
                    break;
                case LogType.Log:
                    GUI.contentColor = Color.green;
                    break;
                case LogType.Error:
                case LogType.Exception:
                    GUI.contentColor = Color.red;
                    break;
            }
            GUILayout.Label(entry.desc, skin.textArea);
            GUI.contentColor = currentColor;
        }
        GUILayout.EndScrollView();
    }

}