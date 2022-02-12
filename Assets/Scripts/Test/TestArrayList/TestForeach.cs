using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForeach : MonoBehaviour
{
    void Start()
    {
        GoTestForeach();
    }

    private void GoTestForeach()
    {
        Debug.Log("start foreach 空数组的遍历");
        var array = new List<string>();
        foreach(var item in array)
        {
            Debug.Log(item);
        }

        //foreach语句中不能修改枚举成员
        var array2 = new List<string> { "", "1", "2", "3" };
        foreach(var item in array2)
        {
            Debug.Log(item);
            array2.Remove("1");
            Debug.Log(item);
        }

    }

}
