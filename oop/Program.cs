using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 访问修饰符与非静态类的实例化调用
/// </summary>
namespace oop
{
    class Program
    {
        static void Main(string[] args)
        {
            // 非静态类须实例化后调用
            Person p = new Person();
            p.age = 20;
            Console.WriteLine(" 就近原则，这里的age赋值为基类中的60，不会取这里的20");
            Console.WriteLine("调用基类的方法");
            p.Speak();

            Console.WriteLine("实例化对象时会为类的字段int型自动赋默认值0");
            Person2 p2 = new Person2();
            p2.Speak();

            Student stu = new Student();
            Console.WriteLine(" 类中的字段name不是public权限，所以会取不到");
            stu.age = 10;
            Console.WriteLine("通过类的Introduce方法接口取到了隐藏的name字段\n");
            stu.Introduce();

            Person2 p3 = new Person2();
            p3.Age = 40;
            p3.Speak();
            Console.WriteLine("通过公共属性来对私有字段进行输入值的合法控制");
            p3.Age = -50;
            p3.Speak();

            p3.Name = "张三";
            p3.Sex = 'a';
            p3.Sex = '男';

            p3.ID = 521;

            p3.Phone = 123456;

            p3.ContactSomeOne();






            Console.ReadKey();  // 暂停输出界面，防闪退

        }
    }
}
