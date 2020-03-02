using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 类属性的访问控制
/// 通过公有属性保护私有字段的合法访问
/// 构造方法：1.方法与类同名 2.方法名前无返回值类型声明 3.无return返回值
/// </summary>
namespace oop
{
    class Person2
    {
        public Person2()
        {
            Console.WriteLine("无参的构造方法\n");
        }

        // 多个构造方法叫做构造方法重载，一旦定义了有参，默认无参方法失效
        public Person2(string Myname, int Myage)
        {
            Console.WriteLine("有参的构造方法");
            Name = Myname;
            this.Age = Myage; 
            // 关键词this访问类内部成员属性");
        }
        private int id;
        private int phone;
        private int age=30; // 受保护的私有字段
        private char sex;
        private string name;
        public string Name
        {
            get
            { return name; }
            set
            { name = value; }
        }

        public int ID { get => id; set => id = value;}
       
        // lambda匿名函数表达式来把字段自动封装成属性 
        public int Phone { get => phone; set => phone=value; }
        public int Age  // 公有属性来控制私有字段的合法访问
        {
            get
            {
                return age;
            }
            set
            {
                Console.WriteLine("通过设置公有属性值的逻辑条件来判断私有字段的合法访问");

                if (value<0)
                {
                    Console.WriteLine("您输入的年龄小于零不合法\n");
                }
                else
                {
                    age = value;
                }
            }
        }

        public char Sex
        {
            get
            {
                return sex;
            }
            set
            {
                Console.WriteLine("通过设置公有属性值的逻辑条件来判断私有字段的合法访问");
                if(value == '男' | value=='女')
                {
                    sex = value;
                }
                else
                {
                    Console.WriteLine("性别只能是男或女\n");
                }
            }
        }

        public void Speak()
        {
            Console.WriteLine(" 未继承基类，不能调用基类方法");
            Console.WriteLine("但可以通过实例化类来访问类");
            Student stu = new Student();
            stu.Introduce();

            Console.WriteLine("关键词this访问类内部成员方法");
            this.ContactSomeOne();
        }

        public void ContactSomeOne()
        {
            Console.WriteLine(" 姓名：{0}\n 性别：{1}\n 年龄：{2}\n 身份证ID号:{3}\n 联系电话:{4}\n ", name, sex, age, id, phone);
        }
    }
}
