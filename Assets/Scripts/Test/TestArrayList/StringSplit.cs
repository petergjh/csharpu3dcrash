using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringSplit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string str = "aaajbbbjccc";
        string[] sArray = str.Split('j');
        foreach (string i in sArray)
        {
            Debug.Log(i.ToString());
        }

        Debug.Log("++++++++++++++++++++++++++++++");

        string[] sArrayList = str.Split('-');
        foreach (string i in sArrayList)
        {
            Debug.Log(i.ToString());
        }

        // 输出结果：
        //aaa
        //bbb
        //ccc
        //++++++++++++++++++++++++++++++
        //aaajbbbjccc

        //注意：Split('j')是单引号


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
