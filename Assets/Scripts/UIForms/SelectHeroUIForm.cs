using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFrame;
using Managers;

namespace DemoProject
{

    public class SelectHeroUIForm: BaseUIForm
    {
        public void Awake()
        {
            Log.Write(GetType() + "/Awake()/");
            Log.Write("立即同步日志缓存");
            Log.SyncLogCatchToFile();
            Debug.Log("立即同步日志缓存");

            Debug.Log("选择英雄窗体SelectHeroUIForm开始初始化。");
            // 窗体的性质
            // CurrentUIType.UIForms_ShowMode = UIFormShowMode.HideOther;
            Debug.Log("显示当前窗体时隐藏其它窗体,减少不必要加载的性能消耗");

            // 事件注册：进入主城
            // RigisterButtonObjectEvent("BtnConfirm", EnterMainCityUIForm);
            RegisterButtonObjectEvent("BtnConfirm",
                p =>
                {
                    Debug.LogFormat("一个按钮打开多个窗体：使用Lamda表达式对同一按钮:{0}:{1}进行多个事件的委托注册响应.",this.name,p.name);
                    OpenUIForm("MainCityUIForm");
                    OpenUIForm("HeroInfoUIForm");

                }
                );

            // 事件注册: 返回上一页
            RegisterButtonObjectEvent("BtnClose", ReturnLogonUIForm);
            // 可用Lambda表达式简写 
            // RigisterButtonObjectEvent("BtnClose", m => CloseUIForm());

            // 事件注册：按钮，打开英雄详情
            RegisterButtonObjectEvent("BtnHero2",
                p => OpenUIForm("HeroDetailUIForm"));
            Debug.Log("注册BtnMarket点击事件，打开MarketUIForm窗体");



        }

        public void Start()
        {
            // 显示“UI管理器”内部的状态
            print("所有窗体集合中的数量 = " + UIManager.GetInstance().ShowAllUIFormsCount());
            print("当前窗体集合中的数量 = " + UIManager.GetInstance().ShowCurrentUIFormsCount());
            print("栈窗体集合中的数量 = " + UIManager.GetInstance().ShowCurrentStackUIFormsCount());

        }

        // public void EnterMainCityUIForm(GameObject go)
        // {
          //  print("进入主城UI窗体！");
        // }

        public void ReturnLogonUIForm(GameObject go)
        {
            //UIManager.GetInstance().CloseUIForms("SelectHeroUIForm");
            //UIManager.GetInstance().CloseUIForms(ProConst.SELECT_HERO_FORM);
            CloseUIForm();

            print("返回");
            print(GetType());  // 返回命名空间和类名
        }

    }

}
