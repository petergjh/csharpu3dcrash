using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIFrame
{
    /// <summary>
    /// UI遮罩管理器
    /// </summary>
    public class UIMaskManager:MonoBehaviour
    {
        // 本脚本私有单例
        private static UIMaskManager _Instance = null;

        // UI 根节点对象
        private GameObject _GoCanvasRoot = null;
        // UI脚本节点对象
        private Transform _TraUIScriptsNode = null;
        // 顶层面板
        private GameObject _GoTopPanel;
        // 遮罩面板
        private GameObject _GoMaskPanel;
        // UI摄像机
        private Camera _UICamera;
        // UI摄像机原始的“层深”
        private float _OriginalUICameralDepth;

            

        // 得到实例 
        public static UIMaskManager GetInstance()
        {
            if (_Instance==null)
            {
                _Instance = new GameObject("_UIMaskManager").AddComponent<UIMaskManager>();
            }
            Debug.Log("已得到一个遮罩管理器： _UIMaskManager");

            return _Instance;
        }

        private void Awake()
        {
            Debug.Log("遮罩管理器UIMaskManager开始初始化。");
            // 得到UI根节点对象、脚本节点对象
            _GoCanvasRoot = GameObject.FindGameObjectWithTag(SysDefine.SYS_TAG_CANVAS);
            _TraUIScriptsNode = UnityHelper.FindTheChildNode(_GoCanvasRoot, SysDefine.SYS_SCRIPTMANAGER_NODE);
            Debug.LogFormat("获取UI根节点_CanvasRoot对象{0}、脚本节点对象{1}", _GoCanvasRoot, _TraUIScriptsNode);

            // 把本脚本实例，作为“脚本节点对象”的子节点
            UnityHelper.AddChildNodeToParentNode(_TraUIScriptsNode, this.gameObject.transform);
            Debug.LogFormat("把遮罩管理器脚本挂到unity脚本节点上");

            // 得到顶层面板
            _GoTopPanel = _GoCanvasRoot;  // 确保 Canvas在unity左侧层级结构的最下方
            Debug.LogFormat("已获取到顶层面板："+_GoTopPanel);

            // 得到遮罩面板
            _GoMaskPanel = UnityHelper.FindTheChildNode(_GoCanvasRoot, "_UIMaskPanel").gameObject;
            Debug.LogFormat("已获取到遮罩面板："+_GoMaskPanel);

            // 得到UI摄像机原始的层深
            _UICamera = GameObject.FindGameObjectWithTag("_TagUICamera").GetComponent<Camera>();
            if (_UICamera != null)
            {
                _OriginalUICameralDepth = _UICamera.depth;
                Debug.Log("得到UI摄像机原始层深值为："+ _OriginalUICameralDepth);
            }
            else
            { Debug.Log(GetType() + "/Start()/UI_Camera is Null !, 请检查！"); }

        }

        /// <summary>
        /// 设置遮罩状态
        /// </summary>
        /// <param name="goDisplayUIForms">需要显示的UI窗体</param>
        /// <param name="lucencyType">显示透明度属性</param>
        public void SetMaskWindow(GameObject goDisplayUIForms, UIFormLucencyType lucencyType=UIFormLucencyType.Lucency)
        {
            // 顶层窗体下移
            _GoTopPanel.transform.SetAsLastSibling();
            Debug.LogFormat("顶层窗体：{0}已完成下移",_GoTopPanel);

            // 启用遮罩窗体，并根据窗体的透明度类型分别设置透明度
            switch(lucencyType)
            {
                // 完全透明，不能穿透
                case UIFormLucencyType.Lucency:
                    Debug.Log("设置遮罩窗体为活动状态。");
                    _GoMaskPanel.SetActive(true);

                    Debug.LogFormat("启用遮罩，遮罩窗体类型为：{0}，设置透明度为：完全透明",lucencyType);
                    Color newColor1 = new Color(SysDefine.SYS_UIMASK_LUCENCY_COLOR_RGB, SysDefine.SYS_UIMASK_LUCENCY_COLOR_RGB, SysDefine.SYS_UIMASK_LUCENCY_COLOR_RGB, SysDefine.SYS_UIMASK_LUCENCY_COLOR_RGB_A);
                    Debug.LogFormat("设置颜色和透明度： "+ newColor1);

                    _GoMaskPanel.GetComponent<Image>().color = newColor1;
                    Debug.LogFormat(" 修改遮罩窗体图片组件的颜色和透明度: "+ newColor1);

                    break;

                // 半透明，不能穿透
                case UIFormLucencyType.Translucence:
                    Debug.LogFormat("启用遮罩，遮罩窗体类型为：{0}，设置透明度为：半透明度",lucencyType);
                    _GoMaskPanel.SetActive(true);
                    Color newColor2 = new Color(SysDefine.SYS_UIMASK_TRANS_LUCENCY_COLOR_RGB , SysDefine.SYS_UIMASK_TRANS_LUCENCY_COLOR_RGB, SysDefine.SYS_UIMASK_TRANS_LUCENCY_COLOR_RGB, SysDefine.SYS_UIMASK_TRANS_LUCENCY_COLOR_RGB_A);
                    _GoMaskPanel.GetComponent<Image>().color = newColor2;
                    break;

                // 低透明，不能穿透
                case UIFormLucencyType.ImPenetrable:
                    Debug.LogFormat("启用遮罩，遮罩窗体类型为：{0}，设置透明度为：低透明度",lucencyType);
                    _GoMaskPanel.SetActive(true);
                    Color newColor3 = new Color(SysDefine.SYS_UIMASK_IMPENETRABLE_COLOR_RGB, SysDefine.SYS_UIMASK_IMPENETRABLE_COLOR_RGB, SysDefine.SYS_UIMASK_IMPENETRABLE_COLOR_RGB, SysDefine.SYS_UIMASK_IMPENTRABLE_COLOR_RGB_A);
                    _GoMaskPanel.GetComponent<Image>().color = newColor3;
                    break;

                // 可以穿透
                case UIFormLucencyType.Pentrate:
                    Debug.Log("遮罩窗体允许穿透");
                    if(_GoMaskPanel.activeInHierarchy)
                    {
                        _GoMaskPanel.SetActive(false);
                    }
                    break;

                default:
                    break;

            }

            // 遮罩窗体下移
            // Debug.LogFormat("遮罩窗体：{0}已完成下移}",_GoMaskPanel);
            _GoMaskPanel.transform.SetAsLastSibling();
            Debug.LogFormat ("遮罩窗体:{0}已完成下移", _GoMaskPanel.ToString());

            // 显示窗体的下移
            goDisplayUIForms.transform.SetAsLastSibling();
            Debug.LogFormat("显示窗体：{0}已完成下移", goDisplayUIForms.name);

            // 增加当前UI摄像机的层深（保证当前摄像机为最前显示）
            if(_UICamera != null)
            {
                _UICamera.depth = _UICamera.depth + 100;
                Debug.LogFormat("当前UI摄像机的层深值已经由原来的：{0} 增加到了：{1}", _OriginalUICameralDepth, _UICamera.depth);
            }
        }

        // 取消遮罩状态
        public void CancelMaskWindow()
        {
            // 顶层窗体上移
            _GoTopPanel.transform.SetAsFirstSibling();

            // 禁用遮罩窗体
            if(_GoMaskPanel.activeInHierarchy)
            {
                // 隐藏
                _GoMaskPanel.SetActive(false);
                Debug.LogFormat("遮罩窗体：{0}已完成隐藏",_GoMaskPanel);
            }

            // 恢复当前UI摄像机的层深
            if (_UICamera != null)
            {
                _UICamera.depth = _OriginalUICameralDepth;  // 恢复层深
                Debug.LogFormat("当前UI摄像机的层深值已恢复到原来的{0}", _OriginalUICameralDepth);
            }
        }
    }


}
