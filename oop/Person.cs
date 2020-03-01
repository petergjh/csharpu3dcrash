using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 面向对象：类的3大特性：封装、继承、多态
/// </summary>
namespace oop
{
    // 默认是internal类
    // 非static静态类无法被其它类直接调用
    // 须实例化后调用
    class Person:Student  // 继承类
    {
        public int age;
        public void Speak()
        {
            int age = 60;
            Console.WriteLine("Hello, I`m {0} years old.", age);
            // Console.ReadKey();

            Console.WriteLine("调用继承类中的protected方法");
            base.SpeakEnglish(); 
        }
        
        
    }
}
