using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UIFrame
{

    /// <summary>
    /// 定义帮助类
    /// </summary>
    public class UnityHelper: MonoBehaviour
    {
         
        /// <summary>
        /// 递归查找子节点方法
        /// </summary>
        /// <param name="goParent"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        public static Transform FindTheChildNode(GameObject goParent,string childName)
        {
            Transform searchTrans = null;  // 查找结果
            searchTrans = goParent.transform.Find(childName);
            if (searchTrans==null)
            {
                Debug.Log("通用方法：开始递归查找子节点: "+childName);
                foreach(Transform trans in goParent.transform)
                {
                    searchTrans = FindTheChildNode(trans.gameObject, childName);
                    if(searchTrans != null)
                    {
                        return searchTrans;
                    }
                }
            }
            return searchTrans;
        }


        /// <summary>
        /// 查找并获取子节点脚本方法
        /// </summary>
        /// <typeparam name="T">泛型，这里代指unity组件</typeparam>
        /// <param name="goParent"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        public static T GetTheChildNodeComponentScripts<T>(GameObject goParent, string childName) where T:Component
        {
            Transform searchTransformNode = null;
            searchTransformNode = FindTheChildNode(goParent, childName);
            if(searchTransformNode != null)
            {
                Debug.Log(" 通用方法：查找并返回子节点脚本：" + childName);
                return searchTransformNode.gameObject.GetComponent<T>();
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 查找并给子节点添加脚本方法
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="goParent">父节点对象</param>
        /// <param name="childName">子节点名称</param>
        /// <returns></returns>
        public static T AddChildNodeComponent<T>(GameObject goParent, string childName) where T:Component
        {
            Debug.Log("通用方法：查找子节点并添加脚本。");
            Transform searchTransform = null;  // 查找特定节点结果

            //  查找特定子节点
            searchTransform = FindTheChildNode(goParent, childName);

            // 如果查找成功，比较若有同名重复脚本则删除，无测添加
            if (searchTransform != null)
            {
                // 如果已经有相同的脚本，则先删除
                T[] componentScriptsArray = searchTransform.GetComponents<T>();
                for (int i = 0; i < componentScriptsArray.Length; i++)
                {
                    if (componentScriptsArray[i] != null)
                    {
                        Destroy(componentScriptsArray[i]);
                    }
                }
                return searchTransform.gameObject.AddComponent<T>();
            }
            else
            {
                return null;
            }
            // 如果查找不成功，返回null

        }


        ///// <summary>
        ///// 给子节点添加父对象方法
        ///// </summary>
        ///// <param name="parents">父对象的方位</param>
        ///// <param name="child">子对象的方法</param>
        //public static void AddChildNodeToParentNode(Transform parents, Transform child)
        //{
        //    Debug.Log("通用方法：给子节点添加父对象");
        //    child.SetParent(parents, false);
        //    child.localPosition = Vector3.zero;
        //    child.localScale = Vector3.one;
        //    child.localEulerAngles = Vector3.zero;
        //}

        /// <summary>
        /// 给子节点添加父对象
        /// </summary>
        /// <param name="Parent"></param>
        /// <param name="child"></param>
        public static void AddParentNodeToChildNode(Transform Parent, Transform child)
        {
            child.SetParent(Parent, false);
            child.localPosition = Vector3.zero;
            child.localScale = Vector3.one;
            child.localEulerAngles = Vector3.zero;
        }


    }

}