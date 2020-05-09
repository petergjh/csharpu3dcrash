/***
 * 
 *  Title: UI框架
 * 
 *  Description:
 *          功能:定义所有UI窗体的父类
 *          定义四个生命周期
 *          
 *          1.Display显示状态
 *          2.Hiding 隐藏状态
 *          3.ReDisplay 再显示状态
 *          4.Freeze 冻结状态
 *          
 *  Date:2019
 *  Version:0.1
 *  Modify Recoder:
 * 
 * 
 * 
 */



using Managers;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UIFrame
{
    /// <summary>
    /// 基础UI窗体
    /// </summary>
    public class BaseUIForm : MonoBehaviour
    {
        /*字段*/
        private UIType _CurrentUIType = new UIType();

        /*属性*/
        public UIType CurrentUIType
        {
            get { return _CurrentUIType; }
            set { _CurrentUIType = value; }
        }
        /// <summary>
        /// 该类的消息名
        /// </summary>
        protected string MsgTypeName = "";

        /// <summary>
        /// 要加载的子窗体列表
        /// </summary>
        protected List<string> LoadChildrenUIFormList;

        /// <summary>
        /// 要额外关闭的窗口名称列表
        /// </summary>
        protected List<string> CloseUIFormList;

        private void Awake()
        {
            //初始化基础信息
            Initialization();
            //初始化UI信息
            InitUIInfo();
            //初始化UI按钮点击事件
            InitButtonClickEvent();

            if (MsgTypeName != "")
            {
                ReceiveMessage(MsgTypeName, ReceiveMsg);
            }
            //添加刷新货币的监听
            ManagerController.Instance.MCoinManager.AddRefreshCoinArea(RefreshCoinBox);
        }


        #region 窗体六种状态
        /// <summary>
        /// 显示状态
        /// </summary>
        public virtual void Display()
        {
            this.gameObject.Show();
            if (_CurrentUIType.UIForms_Type == UIFormType.PopUp)
            {
                UIMaskManager.GetInstance().SetMaskWindow(this.gameObject,_CurrentUIType.UIForms_LucencyType);
            }
        }
        /// <summary>
        /// 隐藏状态
        /// </summary>
        public virtual void Hiding()
        {
            this.gameObject.Hide();
            //取消模态窗体调用
            if (_CurrentUIType.UIForms_Type == UIFormType.PopUp)
            {
                UIMaskManager.GetInstance().CancelMaskWindow();
            }
        }
        /// <summary>
        /// 再显示状态
        /// </summary>
        public virtual void ReDisplay()
        {
            this.gameObject.Show();
            if (_CurrentUIType.UIForms_Type == UIFormType.PopUp)
            {
                UIMaskManager.GetInstance().SetMaskWindow(this.gameObject, _CurrentUIType.UIForms_LucencyType);
            }
        }
        /// <summary>
        /// 冻结状态
        /// </summary>
        public virtual void Freeze()
        {
            this.gameObject.Show();
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        protected virtual void Initialization()
        {

        }

        /// <summary>
        /// 初始化UI信息
        /// </summary>
        protected virtual void InitUIInfo()
        {

        }
        /// <summary>
        /// 初始化UI按钮点击事件
        /// </summary>
        protected virtual void InitButtonClickEvent()
        {

        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="handler"></param>
        protected virtual void ReceiveMsg(KeyValuesUpdate KV)
        {

        }
        /// <summary>
        /// 刷新货币UI
        /// </summary>
        protected virtual void RefreshCoinBox()
        {

        }
        #endregion

        #region 封装自子类常用的方法
        /// <summary>
        /// 获得描述文本
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string GetAbstract(AbstractType dataType, string key)
        {
            return LauguageManager.Instance.GetAbstract(dataType, key);
        }

        /// <summary>
        /// 加载一个Sprite资源
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        protected Sprite LoadSprite(string Path)
        {
            UnityEngine.Object obj_Sprite = Resources.Load(Path, typeof(Sprite));
            Sprite sprite = null;
            try
            {
                sprite = obj_Sprite as Sprite;
            }
            catch(System.Exception ex)
            {

            }
            return sprite;
        }

        /// <summary>
        /// 移除所有传入父节点的子节点
        /// </summary>
        /// <param name="FatherTrans">传入的父节点</param>
        protected void RemoveChildrenNode(Transform FatherTrans)
        {
            Transform[] transforms = FatherTrans.GetComponentsInChildren<Transform>();
            for (int i = 1; i < transforms.Length; ++i)
            {
                Destroy(transforms[i].gameObject);
            }
        }

        /// <summary>
        /// 查找子节点
        /// </summary>
        /// <param name="Parent"></param>
        /// <param name="ChildNam"></param>
        /// <returns></returns>
        protected Transform FindChild(GameObject Parent, string ChildName)
        {
           return UnityHelper.FindTheChildNode(Parent, ChildName);
        }

        /// <summary>
        /// 查找子节点上的某个组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Parent"></param>
        /// <param name="ChildNam"></param>
        /// <returns></returns>
        //protected T FindChild<T>(GameObject Parent, string ChildName)
        protected T FindChild<T>(GameObject Parent, string ChildName)
        {
            T t = UnityHelper.FindTheChildNode(Parent, ChildName).GetComponent<T>();
            if (t == null)
            {
                Debug.LogError("查找失败!查找类型:"+t.GetType());
            }
            return t;
        }

        /// <summary>
        /// 从图集中加载sprite资源
        /// </summary>
        /// <param name="atlasType"></param>
        /// <param name="spriteName"></param>
        /// <returns></returns>
        protected Sprite LoadSpriteByAtlas(AtlasType atlasType, string spriteName)
        {
            Sprite sprite = MainManager.GetSpriteByAtlas(atlasType, spriteName);
            if (sprite.IsNull())
            {
                Debug.Log("加载的图片不存在!图片名:"+spriteName);
            }
            return sprite;
        }

        /// <summary>
        /// Spine切换动画
        /// </summary>
        /// <param name="SpineAnmi">spine动画的Transform</param>
        /// <param name="AnmiName">切换的动画名</param>
        protected void SpineAnmiChange(Transform SpineAnmi, string AnmiName,bool IsLoop = true)
        {
            SkeletonGraphic skeletonAnimation = SpineAnmi.GetComponent<SkeletonGraphic>();
            skeletonAnimation.freeze = true;
            skeletonAnimation.Skeleton.SetToSetupPose();
            skeletonAnimation.AnimationState.ClearTracks();
            skeletonAnimation.AnimationState.SetAnimation(0, AnmiName, IsLoop);
            skeletonAnimation.startingLoop = IsLoop;
            skeletonAnimation.freeze = false;
        }
        /// <summary>
        /// Spine切换动画
        /// </summary>
        /// <param name="SpineAnmi"></param>
        /// <param name="AnmiName"></param>
        /// <param name="IsLoop"></param>
        /// <param name="Time"></param>
        protected void SpineAddNewAnmi(Transform SpineAnmi, string AnmiName, bool IsLoop = true,float Time = 0f)
        {
            SkeletonGraphic skeletonAnimation = SpineAnmi.GetComponent<SkeletonGraphic>();
            skeletonAnimation.Skeleton.SetToSetupPose();
            skeletonAnimation.AnimationState.ClearTracks();
            skeletonAnimation.AnimationState.AddAnimation(0, AnmiName, IsLoop, Time);
        }

        /// <summary>
        /// 注册按钮点击事件
        /// </summary>
        /// <param name="buttonName"></param>
        /// <param name="delHandle"></param>
        protected void RegisterButtonObjectEvent(string buttonName, EventTriggerListener.VoidDelegate delHandle)
        {
            GameObject objButton = UnityHelper.FindTheChildNode(this.gameObject, buttonName).gameObject;
            if (objButton != null)
            {
               EventTriggerListener.Get(objButton).onClick = delHandle;
            }
        }

        /// <summary>
        /// 重置层序
        /// </summary>
        public void ResetCanvasSortLayer()
        {
            if (UIManager._DicUIFormSortLayerCount.ContainsKey(name))
            {
                this.GetComponent<Canvas>().sortingOrder = UIManager._DicUIFormSortLayerCount[name];
            }
        }

        /// <summary>
        /// 打开UI窗体
        /// </summary>
        /// <param name="UIFormName"></param>
        protected void OpenUIForm(string UIFormName)
        {
            UIManager.GetIndtance().ShowUIForms(UIFormName);
        }
        /// <summary>
        /// 打开UI窗体并发送一条初始消息
        /// </summary>
        /// <param name="UIFormName"></param>
        /// <param name="msgName"></param>
        /// <param name="msgContent"></param>
        protected void OpenUIForm(string UIFormName,string msgName, object msgContent = null)
        {
            UIManager.GetIndtance().ShowUIForms(UIFormName);
            KeyValuesUpdate kvs = new KeyValuesUpdate(msgName, msgContent);
            MessageCenter.SendMessage(UIFormName, kvs);
        }
        /// <summary>
        /// 关闭UI窗体
        /// </summary>
        /// <param name="UIFormName"></param>
        protected void CloseUIForm(string UIFormName)
        {
            UIManager.GetIndtance().CloseUIForms(UIFormName);
        }

        protected void CloseUIForm()
        {
            string strUIFormName = string.Empty;
            int intPosition = -1;
            ResetCanvasSortLayer();
            strUIFormName = GetType().ToString();
            intPosition = strUIFormName.IndexOf('.');
            if (intPosition != -1)
            {
                strUIFormName = strUIFormName.Substring(intPosition + 1);
            }
            UIManager.GetIndtance().CloseUIForms(strUIFormName);
        }

        /// <summary>
        /// 发送方法
        /// </summary>
        /// <param name="msgType">消息类型</param>
        /// <param name="msgName">消息名称</param>
        /// <param name="msgContent">消息内容</param>
        protected void SendMessage(string msgType,string msgName,object msgContent = null)
        {
            KeyValuesUpdate kvs = new KeyValuesUpdate(msgName, msgContent);
            MessageCenter.SendMessage(msgType,kvs);
        }
        protected new void SendMessage(string msgType, object msgContent)
        {
            KeyValuesUpdate kvs = new KeyValuesUpdate(SysDefine.SYS_MSG_NULL, msgContent);
            MessageCenter.SendMessage(msgType, kvs);
        }
        protected new void SendMessage(string msgType)
        {
            KeyValuesUpdate kvs = new KeyValuesUpdate(SysDefine.SYS_MSG_NULL, SysDefine.SYS_MSG_NULL);
            MessageCenter.SendMessage(msgType, kvs);
        }
    

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="msgType">消息类型</param>
        /// <param name="handler">消息委托</param>
        protected void ReceiveMessage(string msgType, MessageCenter.DelMessageDelivery handler)
        {
            if (string.IsNullOrEmpty(msgType))
            {
                Debug.Log("接收的消息为空");
                return;
            }
            MessageCenter.AddMsgListener(msgType, handler);
        }

        /// <summary>
        /// 清空所有消息池中的消息
        /// </summary>
        protected void ClearAllMessage()
        {
            MessageCenter.ClearAllMsgListener();
        }

        /// <summary>
        /// 移除一个消息
        /// </summary>
        /// <param name="msgType"></param>
        /// <param name="handler"></param>
        protected void RemoveMessage(string msgType, MessageCenter.DelMessageDelivery handler)
        {
            MessageCenter.RemoveMsgListener(msgType,handler);
        }

        /// <summary>
        /// 通过消息种类清空某一类消息
        /// </summary>
        /// <param name="MsgType"></param>
        protected void ClearMsgListenerByMsgKind(string MsgType)
        {
            MessageCenter.ClearMsgListenerByMsgKind(MsgType);
        }

        /// <summary>
        /// 设置保存的预设不在跳转场景时被销毁
        /// </summary>
        /// <param name="ChildTrans"></param>
        protected void SetSavePrefabPos(Transform ChildTrans)
        {
            UIManager.GetIndtance().SetSavePrefab(ChildTrans);
        }

       /// <summary>
       /// 关闭所有退出的窗口
       /// </summary>
       /// <param name="action"></param>
        protected void CloseExitUIForm(Action action)
        {
            if (CloseUIFormList.IsNotNull() && CloseUIFormList.Count > 0)
            {
                for (int i = 0; i < CloseUIFormList.Count; i++)
                {
                    CloseUIForm(CloseUIFormList[i]);
                }
            }
            CloseUIForm();
            action.Invoke();
        }

        /// <summary>
        /// 加载子节点窗体
        /// </summary>
        /// <param name="action"></param>
        protected void LoadChildrenUIForm()
        {
            if (LoadChildrenUIFormList.IsNotNull() && LoadChildrenUIFormList.Count>0)
            {
                LoadChildrenUIFormList.ForEach(p=> 
                {
                    OpenUIForm(p, SysDefine.SYS_MSG_INITSCENE);
                });
            }
        }
        /// <summary>
        /// 关闭子节点窗体
        /// </summary>
        public void CloseChildrenUIForm()
        {
            if (LoadChildrenUIFormList.IsNotNull() && LoadChildrenUIFormList.Count > 0)
            {
                LoadChildrenUIFormList.ForEach(p =>
                {
                    CloseUIForm(p);
                });
            }
        }
        #endregion

    }//ClassEnd
}

