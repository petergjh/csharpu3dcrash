using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

    //事件发送者
    public class Dog : MonoBehaviour
    {
        //1.声明事件委托类；
        public delegate void AlarmEventHandler(object sender, EventArgs e);

        //2.声明事件成员；   
        public event AlarmEventHandler Alarm;

        //3.发布事件消息；
        public void OnAlarm()
        {
            if (this.Alarm != null)
            {
                Console.WriteLine("\n狗报警: 有小偷进来了,汪汪~~~~~~~");
                // 调用事件
                this.Alarm(this, new EventArgs());   //发出警报
            }
        }
    }

    //事件订阅者
    class Host
    {

        // 4.事件（链）订阅
        public Host(Dog dog)
        {
            dog.Alarm += new Dog.AlarmEventHandler(this.HostHandleAlarm);
        }

        // 5.事件处理器。订阅者接收到消息后的后续操作。（是一个委托类型）
        void HostHandleAlarm(object sender, EventArgs e)
        {
            Console.WriteLine("主人监听到报警后抓住了小偷！");
        }
    }

    // 事件订阅者
    class Police
    {
        // 4.事件（链）订阅
        public Police(Dog dog)
        {
            dog.Alarm += new Dog.AlarmEventHandler(this.PoliceHandleAlarm);
        }

        // 5. 事件处理器。 订阅者接收到消息后进行的后续操作。
        void PoliceHandleAlarm(object sender, EventArgs e)
        {
            Console.WriteLine("警察监听到报警后跑了过来！");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Host host = new Host(dog);

            //当前时间，从2008年12月31日23:59:50开始计时
            DateTime now = new DateTime(2015, 12, 31, 23, 59, 50);
            DateTime midnight = new DateTime(2016, 1, 1, 0, 0, 0);

            //等待午夜的到来
            Console.WriteLine("时间一秒一秒地流逝... ");
            while (now < midnight)
            {
                Console.WriteLine("当前时间: " + now);
                System.Threading.Thread.Sleep(1000);    //程序暂停一秒
                now = now.AddSeconds(1);                //时间增加一秒
            }

            //午夜零点小偷到达,看门狗引发Alarm事件
            Console.WriteLine("\n月黑风高的午夜: " + now);
            Console.WriteLine("小偷悄悄地摸进了主人的屋内... ");

            //６.触发事件
            dog.OnAlarm();
            Console.ReadLine();
        }
    }
