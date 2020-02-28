

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class ForLoop
    {
        //求：1到100的累加和
        public void Test1()
        {
            int intResult = 0;
            for (int i = 1; i <= 100; i++)
            {
                intResult = intResult + i;
            }
            Console.WriteLine("结果是：" + intResult);
        }

        public static void Main()
        {
            ForLoop obj = new Demo1();
            obj.Test1();
        }
    }
}
