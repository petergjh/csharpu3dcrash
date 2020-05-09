using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFrame;

namespace DemoProject
{

    public class HeroDetailUIForm : BaseUIForm
    {
        private void Awake()
        {
            Debug.Log("英雄详情窗体HeroDetailUIForm开始初始化");
            // 窗体类型
            CurrentUIType.UIForms_ShowMode = UIFormShowMode.ReverseChange;
            CurrentUIType.UIForms_Type = UIFormType.PopUp;
            CurrentUIType.UIForms_LucencyType = UIFormLucenyType.Lucency;

            // 事件注册
            RegisterButtonObjectEvent("Btn_Close", 
                p=> CloseUIForm()
                );
        }
    }
}
