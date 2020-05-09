using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DDOLSingleton<T>:MonoBehaviour where T : DDOLSingleton<T>
{
    protected static T _instance = null;
    public static T Instance 
    {
        get
        {
            if (null == _instance)
            {
                GameObject go = GameObject.Find("DDOL");
                if (null == go)
                {
                    go = new GameObject("DDOL");
                    DontDestroyOnLoad(go);
                }

                _instance = go.GetComponent<T>();
                if(null == _instance)
                {
                    _instance = go.AddComponent<T>();
                }
            }
            return _instance;
        }
    }
    public abstract void Initialize();
}
