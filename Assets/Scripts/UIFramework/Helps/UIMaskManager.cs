/***
 * 
 *    Title: "SUIFW"UI框架项目
 *           主题： UI遮罩管理 
 *    Description: 
 *           功能： 实现对于任何对象的监听处理。
 *    Date: 2019
 *    Version: 0.1版本
 *    Modify Recoder: 
 *    
 *   
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


namespace UIFrame
{
    public class UIMaskManager : MonoBehaviour
    {
        /*字段*/
        //单例
        private static UIMaskManager _Instance = null;

        /// <summary>
        /// UI根节点对象
        /// </summary>
        private GameObject _objCanvasRoot = null;
        /// <summary>
        /// UI脚本节点对象
        /// </summary>
        private Transform _TraUIScriptsNode = null;
        /// <summary>
        /// 顶层面板
        /// </summary>
        private GameObject _objTopPanel = null;
        /// <summary>
        /// 遮罩面板
        /// </summary>
        private GameObject _objMaskPanel = null;
        /// <summary>
        /// UI相机
        /// </summary>
        private Camera _UICamera = null;
        /// <summary>
        /// UI相机原始的层深
        /// </summary>
        /// <returns></returns>
        private float _OriginalUICameraDepth = 0;

        /// <summary>
        /// 得到实例
        /// </summary>
        /// <returns></returns>
        public static UIMaskManager GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new GameObject("_UIMaskManager").AddComponent<UIMaskManager>();
            }
            return _Instance;
        }

        private void Awake()
        {
            //得到UI根节点对象、脚本节点对象
            _objCanvasRoot = GameObject.FindGameObjectWithTag(SysDefine.SYS_TAG_CANVAS);
            _TraUIScriptsNode = UnityHelper.FindTheChildNode(_objCanvasRoot, SysDefine.SYS_SCRIPTMANAGER_NODE);
            //把本脚本实例作为，作为脚本节点的子对象
            UnityHelper.AddParentNodeToChildNode(_TraUIScriptsNode, this.gameObject.transform);
            //得到“顶层面板”、“遮罩面板”
            _objTopPanel = _objCanvasRoot;
            _objMaskPanel = UnityHelper.FindTheChildNode(_objCanvasRoot, "_UIMaskPanel").gameObject;
            //得到UI摄像机原始的“层深”
            _UICamera = GameObject.FindGameObjectWithTag("_UICamera").GetComponent<Camera>();
            if (_UICamera != null)
            {
                //得到原始的层深
                _OriginalUICameraDepth = _UICamera.depth;
            }
            else
            {
                Debug.Log(GetType() + "/Start()/UI_Camera Is Null!");
            }
        }

        /// <summary>
        /// 设置遮罩状态
        /// </summary>
        /// <param name="objDisplay">需要显示的UI窗体</param>
        /// <param name="LucenyType"></param>
        public void SetMaskWindow(GameObject objDisplay,UIFormLucenyType LucenyType = UIFormLucenyType.Lucency)
        {
            if (LucenyType == UIFormLucenyType.DnotMask)
            {
                //显示窗体下移
                objDisplay.transform.SetAsLastSibling();
                //增加当前UI摄像机的层深（保证当前相机为最前显示）
                if (_UICamera != null)
                {
                    _UICamera.depth = _UICamera.depth + 100;
                }
                return;
            }
            Canvas _MaskCanvas = _objMaskPanel.GetOrAddComponent<Canvas>();
            _objMaskPanel.GetOrAddComponent<GraphicRaycaster>();
            //顶层窗体下移
            _objTopPanel.transform.SetAsLastSibling();

            if (UIManager._DicUIFormSortLayerCount.ContainsKey(objDisplay.name))
            {
                objDisplay.GetComponent<Canvas>().sortingOrder = UIManager._DicUIFormSortLayerCount[objDisplay.name]+2;
                _MaskCanvas = _objMaskPanel.GetComponent<Canvas>();
                _MaskCanvas.overrideSorting = true;
                _MaskCanvas.enabled = true;
                _MaskCanvas.sortingOrder = objDisplay.GetComponent<Canvas>().sortingOrder - 1;
            }
            else
            {
                if (_MaskCanvas != null)
                {
                    Destroy(_objMaskPanel.GetComponent<GraphicRaycaster>());
                    Destroy(_MaskCanvas);
                }
            }
            //启动遮罩窗体以及设置透明度
            switch (LucenyType)
            {
                case UIFormLucenyType.Lucency:
                    {
                        _objMaskPanel.SetActive(true);
                        Color newColor = new Color(
                            SysDefine.SYS_LUCENCY_RGB, 
                            SysDefine.SYS_LUCENCY_RGB, 
                            SysDefine.SYS_LUCENCY_RGB, 
                            SysDefine.SYS_LUCENCY_RGB_A
                            );
                        _objMaskPanel.GetComponent<Image>().color = newColor;
                    }
                    break;
                case UIFormLucenyType.Translucence:
                    {
                        _objMaskPanel.SetActive(true);
                        Color newColor = new Color(
                            SysDefine.SYS_TRANS_RGB,
                            SysDefine.SYS_TRANS_RGB, 
                            SysDefine.SYS_TRANS_RGB, 
                            SysDefine.SYS_TRANS_RGB_A
                            );
                        _objMaskPanel.GetComponent<Image>().color = newColor;
                    }
                    break;
                case UIFormLucenyType.ImPenetrable:
                    {
                        _objMaskPanel.SetActive(true);
                        Color newColor = new Color(
                            SysDefine.SYS_IMPENETRABLE_RGB,
                            SysDefine.SYS_IMPENETRABLE_RGB,
                            SysDefine.SYS_IMPENETRABLE_RGB, 
                            SysDefine.SYS_IMPENETRABLE_RGB_A
                            );
                        _objMaskPanel.GetComponent<Image>().color = newColor;
                    }
                    break;
                case UIFormLucenyType.Pentrate:
                    {
                        print("允许穿透");
                        if (_objMaskPanel.activeInHierarchy)
                        {
                            _objMaskPanel.SetActive(false);
                            _objMaskPanel.GetComponent<Canvas>().enabled = false;
                        }
                    }
                    break;
            }
            //遮罩窗体下移
            _objMaskPanel.transform.SetAsLastSibling();
            //显示窗体下移
            objDisplay.transform.SetAsLastSibling();
    
            //增加当前UI摄像机的层深（保证当前相机为最前显示）
            if (_UICamera != null)
            {
                _UICamera.depth = _UICamera.depth + 100;
            }
        }

        /// <summary>
        /// 取消遮罩状态
        /// </summary>
        public void CancelMaskWindow()
        {
            //顶层窗体上移
            _objTopPanel.transform.SetAsFirstSibling();
            //禁用遮罩体
            if(_objMaskPanel.activeInHierarchy)
            {
                //隐藏
                _objMaskPanel.SetActive(false);
            }

            //恢复层深
            if (_UICamera != null)
            {
                _UICamera.depth = _OriginalUICameraDepth;
            }
        }

    }
}

