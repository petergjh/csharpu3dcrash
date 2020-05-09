using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFrame;

namespace DemoProject
{
    public class StartProject : MonoBehaviour
    {
        void Start()
        {
            Log.Write(GetType() + "/Start()/");

            Debug.Log("游戏开始！Welcome to my game! Have a funtime!");
            // 加载登陆窗体
            UIManager.GetInstance().ShowUIForms("LogonUIForm");
            Debug.Log("登陆窗体 LogonUIForm 加载已完成！");

        }
    }

}
