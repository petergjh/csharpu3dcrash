using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFrame;

namespace DemoProject
{

    public class MainCityUIForm : BaseUIForm
    {
        
        private void Awake()
        {
            Debug.Log("主城窗体MainCityUIForm开始初始化");
            // 窗体性质使用默认值
            //CurrentUIType.UIForms_ShowMode = UIFormShowMode.HideOther;

            // 事件注册：按钮，打开游戏商城
            RegisterButtonObjectEvent("BtnMarket",
                p => OpenUIForm("MarketUIForm"));
            Debug.Log("注册BtnMarket点击事件，监听MarketUIForm窗体的打开");


            // 事件注册：按钮，返回前一页
            // RigisterButtonObjectEvent("BtnBack",
            //    p => CloseUIForm()
            //   );

            // 事件注册：按钮，关闭当前画面的两个窗体
            RegisterButtonObjectEvent("BtnBack",
            p=>
            {
                // 关闭当前窗体
                CloseUIForm();
                
                // 关闭同画面HeroInfoUIForm窗体
                UIManager.GetInstance().CloseUIForms("HeroInfoUIForm");
            }
            );

        }

    }

}
