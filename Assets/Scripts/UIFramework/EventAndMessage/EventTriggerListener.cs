/***
 * 
 *    Title: "SUIFW"UI框架项目
 *           主题： 事件触发监听      
 *    Description: 
 *           功能： 实现对于任何对象的监听处理。
 *    Date: 2017
 *    Version: 0.1版本
 *    Modify Recoder: 
 *    
 *   
 */
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIFrame
{
    public class EventTriggerListener :UnityEngine.EventSystems.EventTrigger 
    {
        public delegate void VoidDelegate(GameObject go);
        public VoidDelegate onClick;
        public VoidDelegate onDown;
        public VoidDelegate onEnter;
        public VoidDelegate onExit;
        public VoidDelegate onUp;
        public VoidDelegate onSelect;
        public VoidDelegate onUpdateSelect;




        /// <summary>
        /// 得到“监听器”组件
        /// </summary>
        /// <param name="go">监听的游戏对象</param>
        /// <returns>
        /// 监听器
        /// </returns>
        public static EventTriggerListener Get(GameObject go)
        {
            EventTriggerListener lister = go.GetComponent<EventTriggerListener>();
            if (lister==null)
            {
                lister = go.AddComponent<EventTriggerListener>();                
            }
            Debug.LogFormat("游戏对象{0}完成监听事件的注册。" , go);
            return lister;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if(onClick!=null)
            {
                Debug.Log("事件操作：onClick"  );
                onClick(gameObject);
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (onDown != null)
            {
                Debug.Log("事件操作：onDown"  );
                onDown(gameObject);
            }
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (onEnter != null)
            {
                Debug.Log("事件操作：onEnter"  );
                onEnter(gameObject);
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if (onExit != null)
            {
                Debug.Log("事件操作：onExit"  );
                onExit(gameObject);
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (onUp != null)
            {
                Debug.Log("事件操作：onUp"  );
                onUp(gameObject);
            }
        }
    
        public override void OnSelect(BaseEventData eventBaseData)
        {
            if (onSelect != null)
            {
                Debug.Log("事件操作：onSelect"  );
                onSelect(gameObject);
            }
        }

        public override void OnUpdateSelected(BaseEventData eventBaseData)
        {
            if (onUpdateSelect != null)
            {
                Debug.Log("事件操作：onUpdateSelect"  );
                onUpdateSelect(gameObject);
            }
        }
	
    }//Class_end
}
