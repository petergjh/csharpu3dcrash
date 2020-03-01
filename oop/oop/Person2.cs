using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 类属性的访问控制
/// 通过公有属性保护私有字段的合法访问
/// </summary>
namespace oop
{
    class Person2
    {
        private string name;
        private int id;
        private int phone;
        private int age=30; // 受保护的私有字段
        private char sex;
        
        public string Name
        {
            get;
            set;
        }

        public int ID
        {
            get
            { return id; }
            set
            { id = value; }
        }
       
        // lambda表达式来把字段自动封装成属性 
        public int Phone { get => phone; set => value; }
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
            Console.WriteLine("大家好，我今年{0}岁\n", Age);
            Console.WriteLine("大家好，本人性别是{0}\n", sex);
        }
    }
}
