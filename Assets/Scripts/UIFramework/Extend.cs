using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public static class Extend 
{


}
/// <summary>
/// GameObject's Util/Static This Extension
/// </summary>
public static class GameObjectExtension
{
    public static void Example()
    {
        var gameObject = new GameObject();
        var transform = gameObject.transform;
        var selfScript = gameObject.AddComponent<MonoBehaviour>();
        var boxCollider = gameObject.AddComponent<BoxCollider>();

        gameObject.Show(); // gameObject.SetActive(true)
        selfScript.Show(); // this.gameObject.SetActive(true)
        boxCollider.Show(); // boxCollider.gameObject.SetActive(true)
        gameObject.transform.Show(); // transform.gameObject.SetActive(true)

        gameObject.Hide(); // gameObject.SetActive(false)
        selfScript.Hide(); // this.gameObject.SetActive(false)
        boxCollider.Hide(); // boxCollider.gameObject.SetActive(false)
        transform.Hide(); // transform.gameObject.SetActive(false)

        selfScript.DestroyGameObj();
        boxCollider.DestroyGameObj();
        transform.DestroyGameObj();

        selfScript.DestroyGameObjGracefully();
        boxCollider.DestroyGameObjGracefully();
        transform.DestroyGameObjGracefully();

        selfScript.DestroyGameObjAfterDelay(1.0f);
        boxCollider.DestroyGameObjAfterDelay(1.0f);
        transform.DestroyGameObjAfterDelay(1.0f);

        selfScript.DestroyGameObjAfterDelayGracefully(1.0f);
        boxCollider.DestroyGameObjAfterDelayGracefully(1.0f);
        transform.DestroyGameObjAfterDelayGracefully(1.0f);

        gameObject.Layer(0);
        selfScript.Layer(0);
        boxCollider.Layer(0);
        transform.Layer(0);

        gameObject.Layer("Default");
        selfScript.Layer("Default");
        boxCollider.Layer("Default");
        transform.Layer("Default");
    }

    #region CEGO001 Show

    public static GameObject Show(this GameObject selfObj)
    {
        selfObj.SetActive(true);
        return selfObj;
    }

    public static T Show<T>(this T selfComponent) where T : Component
    {
        selfComponent.gameObject.Show();
        return selfComponent;
    }

    #endregion

    #region CEGO002 Hide

    public static GameObject Hide(this GameObject selfObj)
    {
        selfObj.SetActive(false);
        return selfObj;
    }

    public static T Hide<T>(this T selfComponent) where T : Component
    {
        selfComponent.gameObject.Hide();
        return selfComponent;
    }

    #endregion

    #region CEGO003 DestroyGameObj

    public static void DestroyGameObj<T>(this T selfBehaviour) where T : Component
    {
        selfBehaviour.gameObject.DestroySelf();
    }

    #endregion

    #region CEGO004 DestroyGameObjGracefully

    public static void DestroyGameObjGracefully<T>(this T selfBehaviour) where T : Component
    {
        if (selfBehaviour && selfBehaviour.gameObject)
        {
            selfBehaviour.gameObject.DestroySelfGracefully();
        }
    }

    #endregion

    #region CEGO005 DestroyGameObjGracefully

    public static T DestroyGameObjAfterDelay<T>(this T selfBehaviour, float delay) where T : Component
    {
        selfBehaviour.gameObject.DestroySelfAfterDelay(delay);
        return selfBehaviour;
    }

    public static T DestroyGameObjAfterDelayGracefully<T>(this T selfBehaviour, float delay) where T : Component
    {
        if (selfBehaviour && selfBehaviour.gameObject)
        {
            selfBehaviour.gameObject.DestroySelfAfterDelay(delay);
        }

        return selfBehaviour;
    }

    #endregion

    #region CEGO006 Layer

    public static GameObject Layer(this GameObject selfObj, int layer)
    {
        selfObj.layer = layer;
        return selfObj;
    }

    public static T Layer<T>(this T selfComponent, int layer) where T : Component
    {
        selfComponent.gameObject.layer = layer;
        return selfComponent;
    }

    public static GameObject Layer(this GameObject selfObj, string layerName)
    {
        selfObj.layer = LayerMask.NameToLayer(layerName);
        return selfObj;
    }

    public static T Layer<T>(this T selfComponent, string layerName) where T : Component
    {
        selfComponent.gameObject.layer = LayerMask.NameToLayer(layerName);
        return selfComponent;
    }

    #endregion

    #region CEGO007 Component

    public static T GetOrAddComponent<T>(this GameObject selfComponent) where T : Component
    {
        var comp = selfComponent.gameObject.GetComponent<T>();
        return comp ? comp : selfComponent.gameObject.AddComponent<T>();
    }

    public static Component GetOrAddComponent(this GameObject selfComponent, Type type)
    {
        var comp = selfComponent.gameObject.GetComponent(type);
        return comp ? comp : selfComponent.gameObject.AddComponent(type);
    }

    #endregion
}

public static class GraphicExtension
{
    public static void Example()
    {
        var gameObject = new GameObject();
        var image = gameObject.AddComponent<Image>();
        var rawImage = gameObject.AddComponent<RawImage>();

        // image.color = new Color(image.color.r,image.color.g,image.color.b,1.0f);
        image.ColorAlpha(1.0f);
        rawImage.ColorAlpha(1.0f);
    }

    public static T ColorAlpha<T>(this T selfGraphic, float alpha) where T : Graphic
    {
        var color = selfGraphic.color;
        color.a = alpha;
        selfGraphic.color = color;
        return selfGraphic;
    }
}

public static class ImageExtension
{
    public static void Example()
    {
        var gameObject = new GameObject();
        var image1 = gameObject.AddComponent<Image>();

        image1.FillAmount(0.0f); // image1.fillAmount = 0.0f;
    }

    public static Image FillAmount(this Image selfImage, float fillamount)
    {
        selfImage.fillAmount = fillamount;
        return selfImage;
    }
}


public static class ObjectExtension
{

    #region CEUO001 Instantiate

    public static T Instantiate<T>(this T selfObj) where T : Object
    {
        return Object.Instantiate(selfObj);
    }

    #endregion

    #region CEUO002 Instantiate

    public static T Name<T>(this T selfObj, string name) where T : Object
    {
        selfObj.name = name;
        return selfObj;
    }

    #endregion

    #region CEUO003 Destroy Self

    public static void DestroySelf<T>(this T selfObj) where T : Object
    {
        Object.Destroy(selfObj);
    }

    public static T DestroySelfGracefully<T>(this T selfObj) where T : Object
    {
        if (selfObj)
        {
            Object.Destroy(selfObj);
        }

        return selfObj;
    }

    #endregion

    #region CEUO004 Destroy Self AfterDelay 

    public static T DestroySelfAfterDelay<T>(this T selfObj, float afterDelay) where T : Object
    {
        Object.Destroy(selfObj, afterDelay);
        return selfObj;
    }

    public static T DestroySelfAfterDelayGracefully<T>(this T selfObj, float delay) where T : Object
    {
        if (selfObj)
        {
            Object.Destroy(selfObj, delay);
        }

        return selfObj;
    }

    #endregion


    #region CEUO006 DontDestroyOnLoad

    public static T DontDestroyOnLoad<T>(this T selfObj) where T : Object
    {
        Object.DontDestroyOnLoad(selfObj);
        return selfObj;
    }

    #endregion

    public static T As<T>(this Object selfObj) where T : Object
    {
        return selfObj as T;
    }


}
public static class BehaviourExtension
{
    public static T Enable<T>(this T selfBehaviour) where T : Behaviour
    {
        selfBehaviour.enabled = true;
        return selfBehaviour;
    }

    public static T Disable<T>(this T selfBehaviour) where T : Behaviour
    {
        selfBehaviour.enabled = false;
        return selfBehaviour;
    }
}
/// <summary>
/// 类扩展方法
/// </summary>
public static class ClassExtention
{
    public static bool IsNull<T>(this T selfObj) where T : class
    {
        return null == selfObj;
    }

    public static bool IsNotNull<T>(this T selfObj) where T : class
    {
        return null != selfObj;
    }

    /// <summary>
    /// 克隆一个新对象
    /// 需要在类上增加[Serializable]
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selfObj"></param>
    /// <returns></returns>
    public static T Clone<T>(this T selfObj) where T : class
    {
        using (Stream objStream = new MemoryStream())
        {
            //利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(objStream, selfObj);
            objStream.Seek(0, SeekOrigin.Begin);
            return (T)formatter.Deserialize(objStream);
        }
    }
}

/// <summary>
/// Dictionary扩展方法
/// </summary>
public static class DictionaryExtension
{
     /// <summary>
        /// 合并两个字典
        /// Merge the specified dictionary and dictionaries.
        /// </summary>
        /// <returns>The merge.</returns>
        /// <param name="dictionary">Dictionary.</param>
        /// <param name="dictionaries">Dictionaries.</param>
        /// <typeparam name="TKey">The 1st type parameter.</typeparam>
        /// <typeparam name="TValue">The 2nd type parameter.</typeparam>
     public static Dictionary<TKey, TValue> Merge<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,params Dictionary<TKey, TValue>[] dictionaries)
     {
        return dictionaries.Aggregate(dictionary,(current, dict) => current.Union(dict).ToDictionary(kv => kv.Key, kv => kv.Value));
     }

    /// <summary>
    /// 遍历
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <param name="dict"></param>
    /// <param name="action"></param>
    public static void ForEach<K, V>(this Dictionary<K, V> dict, Action<K, V> action)
    {
        var dictE = dict.GetEnumerator();
        while (dictE.MoveNext())
        {
            var current = dictE.Current;
            action(current.Key, current.Value);
        }

        dictE.Dispose();
    }
}


/// <summary>
/// List扩展方法
/// </summary>
public static class ListExtension
{

    /// <summary>
    /// 遍历列表
    /// </summary>
    /// <typeparam name="T">列表类型</typeparam>
    /// <param name="list">目标表</param>
    /// <param name="action">行为</param>
    public static void ForEach<T>(this List<T> list, Action<int, T> action)
    {
        for (var i = 0; i < list.Count; i++)
        {
            action(i, list[i]);
        }
    }

    //public static void ForEach1<T>(this List<T> list, Action<int, T> action)
    //{
    //    for (var i = 0; i < list.Count; i++)
    //    {
    //        action(i, list[i]);
    //    }
    //}

    // <summary>
    /// 通过序列化复制一个新的List对象，操作的内容改变不会影响原List的内容
    /// 需要在类上增加[Serializable]
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="List">源对象</param>
    /// <returns>复制后的对象列表</returns>
    public static List<T> List_Clone<T>(this List<T> List)
    {
        using (Stream objectStream = new MemoryStream())
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(objectStream, List);
            objectStream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(objectStream) as List<T>;
        }
    }


    /// <summary>
    /// 将List转为Array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selfList"></param>
    /// <returns></returns>
    public static T[] ToArraySavely<T>(this List<T> selfList)
    {
        var res = new T[selfList.Count];

        for (var i = 0; i < selfList.Count; i++)
        {
            res[i] = selfList[i];
        }

        return res;
    }

    /// <summary>
    /// 尝试获取，如果没有该数则返回null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selfList"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static T TryGet<T>(this List<T> selfList, int index)
    {
        return selfList.Count > index ? selfList[index] : default(T);
    }
}



