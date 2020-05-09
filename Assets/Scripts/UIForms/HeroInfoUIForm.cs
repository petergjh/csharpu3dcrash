using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFrame;

namespace DemoProject
{

    /// <summary>
    /// 英雄信息显示
    /// </summary>
    public class HeroInfoUIForm : BaseUIForm
    {
        private void Awake()
        {
            Debug.Log("英雄头像窗体HeroInfoUIForm开始初始化");

            // 定义窗体性质 
            CurrentUIType.UIForms_Type = UIFormType.Fixed;  // 把此窗体挂到相应unity的父节点上显示

            // 事件注册：返回
            //RigisterButtonObjectEvent("BtnBack",
             //   p => CloseUIForm()
              //  );

            
        }

    }

}
