using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrame
{
    /// <summary>
    /// 消息（传递）中心
    /// 负责UI框架中，所有UI窗体间的数据传值
    /// </summary>
    public class MessageCenter
    {
        // 定义一个委托. 观察者模式
        public delegate void DelegateMessageDelivery(KeyValueUpdate kv);

        // 声明委托实例. 消息中心缓存集合： string: 监听的类型（ 数据大的分类）， DelegateMessageDelivery： 监听到以后要执行的委托
        public static Dictionary<string, DelegateMessageDelivery> _dicMessages = new Dictionary<string, DelegateMessageDelivery>();

        /// <summary>
        /// 增加委托指向的方法：监听消息
        /// </summary>
        /// <param name="messageType">消息分类</param>
        /// <param name="handler">消息委托</param>
        public static void AddMsgListener(string messageType, DelegateMessageDelivery handler)
        {
            if (!_dicMessages.ContainsKey(messageType))
            {
                _dicMessages.Add(messageType, null);
            }
            _dicMessages[messageType] += handler;
        }

        /// <summary>
        /// 委托指向的方法：取消消息的监听
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="handler"></param>
        public static void RemoveMsgListener(string messageType, DelegateMessageDelivery handler)
        {
            if (_dicMessages.ContainsKey(messageType))
            {
                _dicMessages[messageType] -= handler;
            }
        }


        /// <summary>
        /// 委托指向的方法：取消所有消息的监听
        /// </summary>
        public static void RemoverAllMsgListener()
        {
            if (_dicMessages != null)
            {
                _dicMessages.Clear();
            }
        }


        /// <summary>
        /// 调用（执行）委托 (发送消息）
        /// </summary>
        /// <param name="messageType">消息的分类</param>
        /// <param name="kv">键值对（对象）</param>
        public static void SendMessage(string messageType, KeyValueUpdate kv)
        {
            DelegateMessageDelivery del;   // 实例化一个委托
            if (_dicMessages.TryGetValue(messageType, out del))
            {
                if (del != null)
                {
                    // 调用执行委托
                    del(kv);
                }
            }
        }

    }


    /// <summary>
    /// 键值对更新类
    /// 功能：配合委托，实现委托数据传递
    /// </summary>
    public class KeyValueUpdate
    {
        private string _Key;
        private object _Values;
        public string Key { get { return _Key; } }
        public object Values { get { return _Values; } }

        // 构造函数初始化字段
        public KeyValueUpdate(string key, object valueObj)
        {
            _Key = key;
            _Values = valueObj;
        }
    }


}
