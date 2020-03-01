using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 访问修饰符
/// public公共类 > protected internal > internal族内项目内> protected家内子类 > private私有
/// </summary>
namespace oop
{
    class Student  // 默认internal族类（项目内）, 改为public后其它命名空间可引用并使用其方法
    {
        string name = "Kirk"; // 默认是private私有类访问修饰符
        public int age;
        public void Introduce()
        {
            Console.WriteLine("My name is {0}, and {1} years old.", name, age);
        }

        protected void SpeakEnglish()  // protected家类,可子类通过base.调用方法。
        {
            Console.WriteLine("Hello !");
        }

        protected void SpeakChinese()
        {
            Console.WriteLine("你好啊！");
        }

    }
}
