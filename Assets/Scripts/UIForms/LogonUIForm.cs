using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFrame;

namespace DemoProject
{

    public class LogonUIForm : BaseUIForm
    {
        public void Awake()
        {
            Debug.Log("游戏登录窗体LogonUIForm开始初始化");
            // 定义本窗体的性质
            base.CurrentUIType.UIForms_Type = UIFormType.Normal;
            base.CurrentUIType.UIForms_ShowMode = UIFormShowMode.Normal;
            base.CurrentUIType.UIForms_LucencyType = UIFormLucenyType.Lucency; ;

            // 查找按钮节点
            //Transform UILogonForm = GameObject.FindGameObjectWithTag("_TestTagLogonUIForm").transform;
            //Transform traLogonSysButton = UILogonForm.Find("BG/Btn_OK");
            //Debug.Log("层级视图的节点查找暂用Unity的对象标签，后面需用帮助类重构");
            //GameObject goButton = UnityHelper.FindTheChildNode(this.gameObject, "Btn_OK").gameObject;
            //Debug.Log("已查找到子节点: "+goButton);

            //// 给按钮注册事件方法
            //if(goButton!= null)
            //{
            //    EventTriggerListener.Get(goButton.gameObject).onClick = LogonSys;
            //}

            RegisterButtonObjectEvent("Btn_OK", LogonSys);
        }

        /// <summary>
        /// 登陆方法
        /// </summary>
        public void LogonSys(GameObject go)
        {
            print("登陆方法被执行");
            // 前台或后台检查登陆账号信息
            //  如果成功，切换下一个窗体
            //UIManager.GetInstance().ShowUIForms("SelectHeroUIForm");
            //OpenUIForm("SelectHeroUIForm");
            OpenUIForm(ProjectConst.SELECT_HERO_FORM);
        }

    }

}
