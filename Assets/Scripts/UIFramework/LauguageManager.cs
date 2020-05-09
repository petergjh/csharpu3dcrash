using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
/***
 * 语言管理器
 * 预计4-5月份完成
 * **/
namespace UIFrame
{
    public class LauguageManager
    {
        /// <summary>
        /// 当前显示的语言类型
        /// </summary>
        public LanguageType _CurretLanguageType { private set; get; } = LanguageType.English;
        /// <summary>
        /// 语言管理器的单例
        /// </summary>
        public static LauguageManager _Instance;
        /// <summary>
        /// 获得单例
        /// </summary>
        /// <returns></returns>
        public static LauguageManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LauguageManager();
                }
                return _Instance;
            }
        }
        /// <summary>
        /// 语言文件数据路径缓存集合
        /// </summary>
        private Dictionary<string, string> _DicLauguagePathCache;
        /// <summary>
        /// 描述数据的缓冲池
        /// </summary>
        private Dictionary<string, Dictionary<string, string>> _DicAbstractDataCache;

        private LauguageManager()
        {
            _DicLauguagePathCache = new Dictionary<string, string>();
            _DicAbstractDataCache = new Dictionary<string, Dictionary<string, string>>();
            //初始化语言缓存集合
            InitLauguageCache();
        }

        /// <summary>
        /// 释放指定的描述数据缓存
        /// </summary>
        /// <param name="dataType"></param>
        public void ReleaseAbstractDataCache(AbstractType dataType)
        {
            //获得描述文件种类
            string abstractType = GetLoadLanguageType(dataType);
            if (_DicAbstractDataCache.ContainsKey(abstractType))
            {
                _DicAbstractDataCache.Remove(abstractType);
            }
        }
        /// <summary>
        /// 释放全部数据数据缓存
        /// </summary>
        public void ReleaseAllAbstractDataCache()
        {
            _DicAbstractDataCache.Clear();
            _DicAbstractDataCache = new Dictionary<string, Dictionary<string, string>>();
        }

        /// <summary>
        /// 获得描述
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetAbstract(AbstractType dataType,string key)
        {
            Dictionary<string, string> dic_AbstractData = LoadAbstractDataByType(dataType);
            string Abstract = "";

            if (dic_AbstractData.IsNotNull())
            {
                Debug.Log("是否存在该key值:"+dic_AbstractData.ContainsKey(key));
                dic_AbstractData.ForEach((k,value)=> 
                {
                    Debug.Log("语言数据key:" + k);
                    Debug.Log("语言数据value:" + value);
                });



                dic_AbstractData.TryGetValue(key, out Abstract);
            }
            else
            {
                Debug.Log("读取的数据文件为null！");
            }
            return Abstract;
        }

        /// <summary>
        /// 通过指定类型加载描述数据
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        private Dictionary<string, string> LoadAbstractDataByType(AbstractType dataType)
        {
            Dictionary<string, string> dic_Abstracts = null;
            //获得描述文件种类
            string abstractType = GetLoadLanguageType(dataType);

            Debug.Log("描述文件种类:"+ abstractType);

            //先判断缓冲池中是否有该类型的描述数据
            if (_DicAbstractDataCache.ContainsKey(abstractType))
            {
                _DicAbstractDataCache.TryGetValue(abstractType, out dic_Abstracts);
            }
            //如果缓冲池中没有该类型的数据，则查找新的数据添加到缓冲池中
            else
            {
                string DataPath = "";
                _DicLauguagePathCache.TryGetValue(abstractType, out DataPath);
                //从数据表管理器中加载获得对应的描述数据
                //dic_Abstracts = ManagerController.Instance.MDataTableManager.LoadAbstractInfoData(DataPath);
                //将获得的描述数据添加到缓冲池中
                _DicAbstractDataCache.Add(abstractType, dic_Abstracts);
            }
            return dic_Abstracts;
        }
        /// <summary>
        /// 获得要加载的语言类型
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        private string GetLoadLanguageType(AbstractType dataType)
        {
            string LanguageKind = dataType.ToString();
            switch (_CurretLanguageType)
            {
                case LanguageType.English:
                    {
                        LanguageKind += "_EN";
                    }
                    break;
                case LanguageType.Simplified_Chinese:
                    {
                        LanguageKind += "_CN";
                    }
                    break;
            }
            return LanguageKind;
        }

        /// <summary>
        /// 得到显示文本信息
        /// </summary>
        /// <param name="LID">ID</param>
        /// <returns></returns>
        public string ShowText(string LID)
        {
            //查询结果
            string strQueryResult = string.Empty;
            //参数检查
            if (string.IsNullOrEmpty(LID))
            {
                return null;
            }
            //查询处理
            if (_DicLauguagePathCache != null && _DicLauguagePathCache.Count>=1)
            {
                _DicLauguagePathCache.TryGetValue(LID, out strQueryResult);
                if (!string.IsNullOrEmpty(strQueryResult))
                {
                    return strQueryResult;
                }
            }
            Debug.Log(GetType() + "/ShowText() Error/ LID:"+LID);
            return null;
        }

        /// <summary>
        /// 初始化语言缓存集合
        /// </summary>
        private void InitLauguageCache()
        {
            IConfigManager config = new ConfigManagerByJson(SysDefine.SYS_PATH_LAUGUAGE_CN);
            if (config != null)
            {
                _DicLauguagePathCache = config.AppSetting;
            }
        }
    }

    /// <summary>
    /// 语言类型
    /// </summary>
    public enum LanguageType
    {
        /// <summary>
        /// 英语
        /// </summary>
        English,
        /// <summary>
        /// 简体中文
        /// </summary>
        Simplified_Chinese
    }

    /// <summary>
    /// 描述信息数据种类
    /// </summary>
    public enum AbstractType
    {
        /// <summary>
        /// 小游戏描述数据
        /// </summary>
        Abstract_MiniGame,
        /// <summary>
        /// 角色信息
        /// </summary>
        Abstract_CharacterInfo,
        /// <summary>
        /// UI描述
        /// </summary>
        Abstract_UI

    }
}
