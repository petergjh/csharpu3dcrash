using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 1. 访问修饰符
/// 2. 非静态类的实例化调用
/// 3. 静态类的直接调用
/// 4. 调用继承类中的protected方法
/// 5. 通过公共属性的逻辑判断来合法访问私有字段
/// 6. 构造方法
/// 7. 静态方法
/// 8. 单例模式
/// 
/// 
/// </summary>
namespace oop
{
    class Program
    {
        private static string School;

        static void Main(string[] args)
        {
            // 非静态类须实例化后调用
            Person p = new Person();
            p.age = 20;
            Console.WriteLine(" 就近原则，这里的age赋值为基类中的60，不会取这里的20");
            Console.WriteLine("调用基类的方法");
            p.Speak();

            // 静态字段可直接访问： 类名.字段 ,无须创建类实例化对象
            // 静态方法只能访问静态成员，不能访问非静态成员
            // 静态类所有成员都必须是静态的，不能声明非静态成员。
            // 静态类不能实例化，可直接调用类的所有成员
            School = Student.schoolName;
            Console.WriteLine("学校名：{0}\n", School);

            // 静态构造方法只会执行一次
            Student std = new Student();
            Student std2 = new Student(); // 不会执行

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

            Person2 p4 = new Person2();
            p4.ContactSomeOne();

            //索引器
            Person3 s = new Person3();
            s[1] = "王二";
            s[2] = "男";
            s[3] = "5521221";
            s.Say();




            Console.ReadKey();  // 暂停输出界面，防闪退

        }
    }
}
