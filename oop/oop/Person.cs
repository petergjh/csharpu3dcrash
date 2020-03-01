using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    // 默认是internal类
    // 非static静态类无法被其它类直接调用
    // 须实例化后调用
    class Person:Student
    {
        public int age;
        public void Speak()
        {
             int age = 60;
            Console.WriteLine("Hello, I`m {0} years old.", age);
            // Console.ReadKey();

            base.SpeakEnglish(); 
            // 调用类中家权限的方法，注意跟类实例化的方法调用区分
        }
        
        
    }
}
