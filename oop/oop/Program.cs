using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    class Program
    {
        static void Main(string[] args)
        {
            // 非静态类须实例化后调用
            Person p = new Person();

            p.age = 20;              
            // 就近原则，这里的age赋值为基类中的60，不会取20

            p.Speak();

            Person p2 = new Person();
            p2.Speak();  // 实例化对象时会为类的字段赋初值

            Student stu = new Student();
            // 类中的字段name不是public权限，所以会取不到
            stu.age = 10;
            stu.Introduce(); // 通过类的Introduce方法接口取到了隐藏的name字段 
            Console.ReadKey();  // 暂停输出界面，防闪退

        }
    }
}
