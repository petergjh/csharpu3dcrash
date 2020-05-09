using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace BoilerEventAppl
{

    // boiler 类
    class Boiler
    {
        private int temp;
        private int pressure;
        public Boiler(int t, int p)
        {
            temp = t;
            pressure = p;
        }

        public int getTemp()
        {
            return temp;
        }
        public int getPressure()
        {
            return pressure;
        }
    }


    // 事件发布者
    class DelegateBoilerEventPublisher
    {
        // 1. 声明事件委托类
        public delegate void BoilerLogHandler(string status);

        // 2. 声明事件成员
        public event BoilerLogHandler BoilerEventLog;

        // 3. 发布事件，一旦温度和压力超出设定的阀值就广播发布需要进行记录日志的告警信息
        public void LogProcess()
        {
            string remarks = "O. K";
            Boiler b = new Boiler(100, 12);
            int t = b.getTemp();
            int p = b.getPressure();
            if (t > 150 || t < 80 || p < 12 || p > 15)
            {
                remarks = "警报：Need Maintenance";
            }
            OnBoilerEventLog("Logging Info:\n");
            OnBoilerEventLog("Temparature " + t + "\nPressure: " + p);
            OnBoilerEventLog("\nMessage: " + remarks);
        }

        // 调用事件
        // protected void OnBoilerEventLog(string message)
        // 虚方法可以供继承类重写，以便拒绝不需要的监听
        protected virtual void OnBoilerEventLog(string message)
        {
            if (BoilerEventLog != null) // 如果有对象注册
            {
                BoilerEventLog(message); // 则发布事件消息，调用所有订阅者的方法，引发订阅者收到事件消息后进行后续操作
            }
        }
    }




    // 事件订阅者
    public class RecordBoilerInfoScriber
    {
        static void Main(string[] args)
        {
            BoilerInfoLogger filelog = new BoilerInfoLogger("e:\\boiler.txt");
            DelegateBoilerEventPublisher boilerEventPublisher = new DelegateBoilerEventPublisher();

            // 4.订阅事件
            boilerEventPublisher.BoilerEventLog += new // 注册锅炉日志事件的处理程序
            DelegateBoilerEventPublisher.BoilerLogHandler(Logger); // 

            boilerEventPublisher.BoilerEventLog += new
            DelegateBoilerEventPublisher.BoilerLogHandler(filelog.Logger);


            // 6.触发事件 
            boilerEventPublisher.LogProcess();
            Console.ReadLine();
            filelog.Close();
        }//end of main

        // 5. 事件处理器。 订阅者收到消息后的后续操作
        static void Logger(string info)
        {
            Console.WriteLine(info);  // 控制台显示日志内容
        }//end of Logger

       

    }//end of RecordBoilerInfo

    //  5. 事件处理器。该类把日志内容写入日志文件
    class BoilerInfoLogger
    {
        FileStream fs;
        StreamWriter sw;
        public BoilerInfoLogger(string filename)
        {
            fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
        }
        public void Logger(string info)
        {
            sw.WriteLine(info);
        }
        public void Close()
        {
            sw.Close();
            fs.Close();
        }
    }

}
