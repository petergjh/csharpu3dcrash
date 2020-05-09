/***
 * 
 *  Title: UI框架
 *          主题: 消息(传递)中心
 *  Description:
 *          功能: 负责UI框架中，所有UI窗体中间的数据传值
 *      
 *          
 *  Date:2019
 *  Version:0.1
 *  Modify Recoder:
 * 
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrame
{
    public class MessageCenter
    {
        /// <summary>
        /// 委托：消息传递
        /// </summary>
        public delegate void DelMessageDelivery(KeyValuesUpdate KV);
        /// <summary>
        /// 消息中心缓存集合
        /// <key:数据的分类>
        /// <value:数据执行委托>
        /// </summary>
        public static Dictionary<string, DelMessageDelivery> _dicMessages = new Dictionary<string, DelMessageDelivery>();

        /// <summary>
        /// 添加消息的监听
        /// </summary>
        /// <param name="messageType">消息分类</param>
        /// <param name="handler">消息委托</param>
        public static void AddMsgListener(string messageType, DelMessageDelivery handler)
        {
            if (!_dicMessages.ContainsKey(messageType))
            {
                _dicMessages.Add(messageType, null);
            }
            _dicMessages[messageType] += handler;
        }

        /// <summary>
        /// 取消消息的监听
        /// </summary>
        /// <param name="messageType">消息分类</param>
        /// <param name="handler">消息委托</param>
        public static void RemoveMsgListener(string messageType, DelMessageDelivery handler)
        {
            if (_dicMessages.ContainsKey(messageType))
            {
                _dicMessages[messageType] -= handler;
            }
        }

        /// <summary>
        /// 清空所有消息监听
        /// </summary>
        public static void ClearAllMsgListener()
        {
            if (_dicMessages != null)
            {
                _dicMessages.Clear();
            }
        }

        /// <summary>
        /// 通过消息种类清空某一类型的消息
        /// </summary>
        /// <param name="messagetype"></param>
        public static void ClearMsgListenerByMsgKind(string messagetype)
        {
            if (_dicMessages != null)
            {
                if (_dicMessages.ContainsKey(messagetype))
                {
                    _dicMessages.Remove(messagetype);
                }
            }
        }


        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void DisposeMessage(string messageType,string key,object value = null)
        {
            KeyValuesUpdate keyValues = new KeyValuesUpdate(key, value);
            SendMessage(messageType, keyValues);
        }
        public static void DisposeMessage(string messageType,object value)
        {
            KeyValuesUpdate keyValues = new KeyValuesUpdate(SysDefine.SYS_MSG_NULL, value);
            SendMessage(messageType, keyValues);
        }
        public static void DisposeMessage(string messageType)
        {
            KeyValuesUpdate keyValues = new KeyValuesUpdate(SysDefine.SYS_MSG_NULL, SysDefine.SYS_MSG_NULL);
            SendMessage(messageType, keyValues);
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="messageType">消息的分类</param>
        /// <param name="Kv">键值对对象</param>
        public static void SendMessage(string messageType, KeyValuesUpdate Kv)
        {
            DelMessageDelivery del;
            if (_dicMessages.TryGetValue(messageType, out del))
            {
                //调用委托
                //del?.Invoke(Kv);

                if (del != null)
                {
                    //调用委托
                    del(Kv);
                }
            }
        }
    }

    /// <summary>
    /// 键值更新对
    /// 功能：配合委托，实现委托数据传递
    /// </summary>
    public class KeyValuesUpdate
    {
        private string _Key;
        private object _Values;

        //只读Key
        public string Key { get { return _Key; } }
        //只读Value
        public object Value { get { return _Values; } }

        public KeyValuesUpdate(string key,object valueObj)
        {
            _Key = key;
            _Values = valueObj;
        }
    }
}
