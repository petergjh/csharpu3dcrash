using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI窗体父类
/// 定义窗体的四个生命周期
/// 1. Display 显示状态
/// 2. Hiding 隐藏状态
/// 3. ReDisplay 再显示状态
/// 4. Freeze 冻结状态
/// </summary>

namespace UIFrame
{

    public class BaseUIForm : MonoBehaviour
    {
        //定义一个UI窗体类型的私有字段
        private UIType _CurrentUIType = new UIType();

        // 定义UI窗体类型的公共属性
        public UIType CurrentUIType { get => _CurrentUIType; set => _CurrentUIType = value; }

        #region 窗体的四种生命周期状态: 显示、隐藏、重新显示、冻结

        // 定义四个虚方法，设置窗体显示的四个状态
        public virtual void Display()
        {
            this.gameObject.SetActive(true);
            Debug.Log("设置窗体生命周期状态为：显示状态");
            // 设置模态窗体调用（必须是弹出窗体）
            if(_CurrentUIType.UIForms_Type==UIFormType.PopUP)
            {
                Debug.Log("设置弹出窗体的模态窗体调用。");
                UIMaskManager.GetInstance().SetMaskWindow(this.gameObject, CurrentUIType.UIForms_LucencyType);
            }
        }

        public virtual void Hiding()
        {
            this.gameObject.SetActive(false);
            Debug.Log("设置窗体生命周期状态为：隐藏状态");
            // 取消模态窗体调用
            if (_CurrentUIType.UIForms_Type == UIFormType.PopUP)
            {
                UIMaskManager.GetInstance().CancelMaskWindow();
            }
        }

        public virtual void ReDisplay()
        {
            this.gameObject.SetActive(true);
            Debug.Log("设置窗体生命周期状态为：重新显示状态");
            // 设置模态窗体调用（必须是弹出窗体）
            if (_CurrentUIType.UIForms_Type == UIFormType.PopUP)
            {
                UIMaskManager.GetInstance().SetMaskWindow(this.gameObject, CurrentUIType.UIForms_LucencyType);
            }
        }

        public virtual void Freeze()
        {
            this.gameObject.SetActive(true);
            Debug.Log("设置窗体生命周期状态为：冻结显示状态");
        }

        #endregion


        #region 封装子类常用的方法

        /// <summary>
        /// 把注册按钮事件利用委托进行封装
        /// </summary>
        /// <param name="buttonName">节点名称</param>
        /// <param name="delHandle">委托事件，需注册的方法</param>
        protected void RigisterButtonObjectEvent(string buttonName, EventTriggerListener.VoidDelegate delHandle)
        {
            Debug.LogFormat("按钮：{0}已注册监听事件：{1}" , buttonName,delHandle);
            GameObject goButton = UnityHelper.FindTheChildNode(this.gameObject, buttonName).gameObject;
            Debug.Log("已查找到子节点: " + goButton);

            // 给按钮注册事件方法
            if (goButton != null)
            {
                EventTriggerListener.Get(goButton.gameObject).onClick = delHandle;
                Debug.LogFormat("节点按钮相对应的委托事件已经成功完成。"+delHandle);
            }
        }

        /// <summary>
        /// 打开UI窗体
        /// </summary>
        /// <param name="uiFormName"></param>
        protected void OpenUIForm(string uiFormName)
        {
            UIManager.GetInstance().ShowUIForms(uiFormName);
        }


        /// <summary>
        /// 关闭"当前"UI窗体
        /// </summary>
        /// <param name="uiFormName"></param>
        //protected void CloseUIForm(string uiFormName)
        protected void CloseUIForm()
        {
            string strUIFormName = string.Empty;  // 处理后的UIForm名称
            int intPosition = -1;

            strUIFormName = GetType().ToString();
            intPosition = strUIFormName.IndexOf('.');
            if (intPosition !=-1)
            {
                // 剪切字符串中“.”之间的部分
                strUIFormName = strUIFormName.Substring(intPosition + 1);
            }

            UIManager.GetInstance().CloseUIForms(strUIFormName);
        }

        /// <summary>
        /// 发送消息的方法
        /// </summary>
        /// <param name="msgType">消息类型</param>
        /// <param name="msgName">消息名称</param>
        /// <param name="msgContent">消息内容</param>
        protected void SendMessage(string msgType,string msgName, object msgContent)
        {
            Debug.Log("正在发送消息:" + msgType+ msgName+ msgContent);
            // 消息的内容
            KeyValueUpdate kvs = new KeyValueUpdate(msgName,msgContent);

            // 发送消息的类型
            MessageCenter.SendMessage(msgType, kvs);


        }

        /// <summary>
        // 接收消息的方法也可以封装
        /// </summary>
        /// <param name="messageType">消息分类</param>
        /// <param name="handler">消息委托</param>
        public void ReceiveMessage(string messageType, MessageCenter.DelegateMessageDelivery handler)
        {
            MessageCenter.AddMsgListener(messageType, handler);
        }




        #endregion




    }


}
