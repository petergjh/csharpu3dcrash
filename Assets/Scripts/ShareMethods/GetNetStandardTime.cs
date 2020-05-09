using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

/// <summary>
/// 网络状态监听发布器
/// </summary>
public class GetNetStandardTime 
{

    private string serverTime = null;
    public DateTime netTime = default;

    // 请求网络时间
    //IEnumerator RequestNetworkTime()
    public void RequestNetworkTime()
    {//返回国际标准时间
     //只使用的TimerServer的IP地址，未使用域名
        string[,] TimerServer = new string[14, 2];
        int[] ServerTab = new int[] { 3, 2, 4, 8, 9, 6, 11, 5, 10, 0, 1, 7, 12 };

        TimerServer[0, 0] = "time-a.nist.gov";
        TimerServer[0, 1] = "129.6.15.28";
        TimerServer[1, 0] = "time-b.nist.gov";
        TimerServer[1, 1] = "129.6.15.29";
        TimerServer[2, 0] = "time-a.timefreq.bldrdoc.gov";
        TimerServer[2, 1] = "132.163.4.101";
        TimerServer[3, 0] = "time-b.timefreq.bldrdoc.gov";
        TimerServer[3, 1] = "132.163.4.102";
        TimerServer[4, 0] = "time-c.timefreq.bldrdoc.gov";
        TimerServer[4, 1] = "132.163.4.103";
        TimerServer[5, 0] = "utcnist.colorado.edu";
        TimerServer[5, 1] = "128.138.140.44";
        TimerServer[6, 0] = "time.nist.gov";
        TimerServer[6, 1] = "192.43.244.18";
        TimerServer[7, 0] = "time-nw.nist.gov";
        TimerServer[7, 1] = "131.107.1.10";
        TimerServer[8, 0] = "nist1.symmetricom.com";
        TimerServer[8, 1] = "69.25.96.13";
        TimerServer[9, 0] = "nist1-dc.glassey.com";
        TimerServer[9, 1] = "216.200.93.8";
        TimerServer[10, 0] = "nist1-ny.glassey.com";
        TimerServer[10, 1] = "208.184.49.9";
        TimerServer[11, 0] = "nist1-sj.glassey.com";
        TimerServer[11, 1] = "207.126.98.204";
        TimerServer[12, 0] = "nist1.aol-ca.truetime.com";
        TimerServer[12, 1] = "207.200.81.113";
        TimerServer[13, 0] = "nist1.aol-va.truetime.com";
        TimerServer[13, 1] = "64.236.96.53";
        int portNum = 13;
        string hostName;
        byte[] bytes = new byte[1024];
        int bytesRead = 0;
        string netString = null;

        System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
        for (int i = 0; i < 13; i++)
        {
            hostName = TimerServer[ServerTab[i], 0];

            Debug.Log("开始请求远端服务器 hostName:" + hostName);
            //try
            //{
            // 同步连接服务器
            // client.Connect(hostName, portNum);

            // 异步连接服务器
            // client.BeginConnect(hostName, Convert.ToInt32(portNum), new AsyncCallback(ConnectCallback),client);
            Debug.Log("使用BeginConnect异步方法开始连接服务器");
            var connectResult = client.BeginConnect(hostName, portNum, null, null);
            var connectOK = connectResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
            Debug.Log("连接服务器状态：" + connectOK);

            //if (client.Connected)
            if (connectOK)
            {
                System.Net.Sockets.NetworkStream ns = client.GetStream();
                Debug.Log("开始获取网络字节流：" + ns);
                //同步读取
                if (ns.CanRead)
                {
                    Debug.Log("开始同步接收远程服务器数据");
                    bytesRead = ns.Read(bytes, 0, bytes.Length);
                    client.Close();
                    ns.Close();
                    MyConnectCallback(connectResult);
                    break;
                }
                else
                {
                    client.Close();
                    ns.Close();
                    Debug.Log("网络错误！");
                    MyConnectCallback(connectResult);
                    break;
                }

                //// 异步接收读取网络数据流
                //try
                //{
                //    byte[] result = new byte[client.Available];
                //    ns.BeginRead(result, 0, result.Length, new AsyncCallback(MyReadCallback), ns);
                //    Debug.Log("开始异步接收网络数据："+ns);
                //    strResponse = Encoding.ASCII.GetString(result).Trim();
                //    Debug.Log("得到异步接收的网络数据 strResponse ntp time:" +strResponse);
                //    netString = strResponse;
                //    client.Close();
                //    break;
                //}
                //catch 
                //{ 
                //    Debug.Log("网络错误！");
                //}
            }
            else
            {
                Debug.Log("网络未连接");
                client.Close();
                MyConnectCallback(connectResult);
                //yield break;
                break;
            }
            // client.EndConnect(connectResult);
            //}
            //catch (System.Exception)
            //{
            //Debug.Log("获取错误！");
            //}
        }
        netString = System.Text.Encoding.ASCII.GetString(bytes, 0, bytesRead);
        Debug.Log("得到网络标准时间 ntp time:" + netString);
        serverTime = netString;
        //return serverTime;
    }

    // 转换得到网络标准时间
    //public static DateTime DataStandardTime()//使用时，将static 关键字删除，在其它位置方可使用
    public DateTime DataStandardTime()
    {

        if (serverTime != null)
        {
            char[] sp = new char[1];
            sp[0] = ' ';
            // string str1;
            // netString = netString.Replace("PDT", "");

            string[] s;
            //s = str1.Split(sp);
            s = serverTime.Split(sp);
            // "58961 20-04-22 07:22:32 50 0 0 900.6 UTC(NIST) *"
            netTime = System.DateTime.Parse(s[1] + " " + s[2]);//得到标准时间
            //Debug.WriteLine("get:" + dt.ToShortTimeString());
            Debug.Log("得到网络标准时间:" + netTime.ToShortTimeString());
            //dt=dt.AddHours (8);
            netTime = netTime.ToLocalTime();
            Debug.Log("转换为本地时间:" + netTime);
            return netTime;
        }
        else
        {
            netTime = System.DateTime.Parse("20200000000000");
            Debug.Log(" 获取网络时间失败，设置成默认时间0.");
            return netTime;
        }
    }

    ///// <summary>
    ///// 异步接收读取网络数据流回调函数
    ///// </summary>
    //private static void MyReadCallback(IAsyncResult iar)
    //{
    //    NetworkStream ns = (NetworkStream)iar.AsyncState;
    //    byte[] read = new byte[1024];
    //    String data = "";
    //    int recv;

    //    recv = ns.EndRead(iar);
    //    data = String.Concat(data, Encoding.ASCII.GetString(read, 0, recv));

    //    //接收到的消息长度可能大于缓冲区总大小，反复循环直到读完为止
    //    while (ns.DataAvailable)
    //    {
    //        ns.BeginRead(read, 0, read.Length, new AsyncCallback(MyReadCallback), ns);
    //    }
    //    //打印
    //    Console.WriteLine("您收到的信息是" + data);
    //    Debug.Log("您收到的信息是" + data);
    //}

    /// <summary>
    /// socket异步连接回调函数
    /// </summary>
    /// <param name="ar"></param>
    public static void MyConnectCallback(IAsyncResult ar)
    {
        TcpClient t = (TcpClient)ar.AsyncState;
        try
        {
            if (t.Connected)
            {
                Debug.Log("回调使用EndConnect异步方法结束异步连接服务器");
                t.EndConnect(ar);//函数运行到这里就说明连接成功
            }
            else
            {
            }
        }
        catch
        { }
    }

}

