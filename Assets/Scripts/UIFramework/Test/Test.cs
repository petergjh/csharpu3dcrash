using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrame
{

    public class Test : MonoBehaviour
    {
        //Dictionary<string, string> _dicTest = new Dictionary<string, string>();
        private Stack<string> _StaArray = new Stack<string>();

        private void Start()
        {
            Test2();

        }

        // 测试Dictionary中的 TryGetValue方法
        private void Test1()
        {
//            string strResult = string.Empty; // 输出内容
//
//            _dicTest.Add("zhangsan", "张三");
//            _dicTest.Add("lisi", "李四");
//
//            //查询
//            _dicTest.TryGetValue("zhangsan", out strResult);
//            print("查询结果 strResult=" + strResult);
        }

        // 测试Stack<>类的属性和方法
        private void Test2()
        {
            // 压栈
            _StaArray.Push("zhangsan");
            _StaArray.Push("lisi");
            _StaArray.Push("wangwu");

            Debug.Log("// 查询栈顶元素");
            print(_StaArray.Peek());
            print(_StaArray.Peek());
            print(_StaArray.Peek());

            // 出栈操作,再返回结果
//            print(_StaArray.Pop());
//            print(_StaArray.Pop());
//            print(_StaArray.Pop());
//            print(_StaArray.Pop());  // 栈空报错

            // 使用迭代器输出所有内容
            IEnumerator<string> ie= _StaArray.GetEnumerator();
            while (ie.MoveNext())
            {
                Debug.LogFormat("使用迭代器输出栈元素{0}", ie.Current);
                print(ie.Current);
            }
        }
    }


}
