using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    class Student
    {
        string name = "Kirk"; // 默认是private访问修饰符
        public int age;
        public void Introduce()
        {
            Console.WriteLine("My name is {0}, and {1} years old.", name, age);
        }
        protected void SpeakEnglish()
        {
            Console.WriteLine("I can speak English")
        }

    }
}
