using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 框架核心参数
/// 为了规整，把一些全局性的常量统一放在这里，包括以下：
/// 1. 系统常量
/// 2. 全局方法
/// 3. 系统枚举类型
/// 4. 委托定义
/// </summary>

namespace UIFrame
{
    public interface IConfigManager
    {

        /// <summary>
        /// 只读属性：应用设置通用接口
        /// 接口功能：得到键值对集合数据
        /// </summary>
        Dictionary<string, string> AppSetting { get; }

        // 方法：得到配置文件AppSetting里的数据条目数量
        int GetAppSettingMaxNumber();

    }

    [Serializable]
    internal class KeyValuesInfo
    {

        // 配置信息（键值对集合)
        public List<KeyValueNode> ConfigInfo = null;
        
    }

    [Serializable]
    internal class KeyValueNode
    {
        // 键
        public string Key = null;
        // 值
        public string Value = null;
    }


}
