using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerScriber : MonoBehaviour
{
    // 声明变量
    public Text countdown4text;
    private int totaltime4;
    //public Text countdown3text;
    private string netChanged;
    public Text countdown1text;
    public Text countdown3text;

    // 实例化网络状态监听发布器
    private static readonly NetStatusPublisher nsp = new NetStatusPublisher();

    // Start is called before the first frame update
    void Start()
    {
        // 启动订阅事件方法
        ScribeMethod();

        // 启动网络监听协程
        StartCoroutine(nsp.CheckNet());

        // 启动计时器协程
        StartCoroutine(TimerProcess());

        //InvokeRepeating("TimerProcess",1,3);
    }

    /// <summary>
    /// 订阅事件（链）
    /// </summary>
    void ScribeMethod()
    {
        nsp.NetChanged += TimerCount;
    }

    /// <summary>
    /// 订阅者接收到事件消息后进行后续操作的回调函数
    /// </summary>
    /// <param name="sender">发布者</param>
    /// <param name="e">事件内容</param>
    /// <returns></returns>
    public string TimerCount(object sender, NetStatusPublisher.NetChangedEventArgs e)
    {
        NetStatusPublisher netStatusPublisher = (NetStatusPublisher)sender;
        // 访问发布者sender中的公共字段，得到订阅者感兴趣的事件信息内容
        netChanged = e.netStatusNow;

        // 这里如果直接触发回调方法，
        // 则回调方法里的计时循环协程就会嵌套在事件发布方法里的网络监听循环协程，会导致线程阻塞
        //StartCoroutine(TimerProcess());
        return null;
    }

    /// <summary>
    /// 倒计时器协程
    /// </summary>
    /// <returns></returns>
    IEnumerator TimerProcess()
    {
        while (true)
        {
            //nsp.NetChanged -= TimerCount;

            // 访问sender中的公共字段
            Debug.Log("timerLoop, 网络状态：" + netChanged);

            //启动网络倒计时UI协程
            if (netChanged == "DownToUp")
            {
                StopCoroutine("LocalTimeControlIE"); // 注意协程参数用方法名称，string类型
                Debug.Log(" netstatus from Down to Up，关闭本地时间计时协程，开始获取网络时间");
                yield return StartCoroutine("NetworkTimeControlIE");

            }
            // 启动网络倒计时协程
            else if (netChanged == "UpToDown")
            {
                StopCoroutine("NetworkTimeControlIE");
                Debug.Log("netstatus from Up to Down，关闭网络时间计时协程，开始获取本地时间");
                yield return StartCoroutine("LocalTimeControlIE");
            }
            else
            {
                Debug.Log("nothing happened");
            }

        }
    }

    // 获取本地操作系统的时间来倒计时
    /// <summary>
    /// 计时携程
    /// </summary>
    /// <returns></returns>
    public IEnumerator LocalTimeControlIE()
    {
        while (true)
        {
            if (netChanged == "DownToUp")
            {
                break;
            }
            int H = (int)(23 - System.DateTime.Now.Hour);
            int M = (int)(60 - System.DateTime.Now.Minute);
            int S = (int)(60 - System.DateTime.Now.Second);
            countdown4text.text = "本地时间倒计时\n" + string.Format("{0:00}:{1:00}:{2:00}", H, M, S);
            yield return new WaitForSeconds(1.0f);
        }
        
    }

    // 网络倒计时器
    private DateTime theNetTime;
    //private int totaltime4;
    //private Text countdown4text;

    /// <summary>
    /// 获取网络时间来倒计时
    /// </summary>
    /// <returns></returns>
    public IEnumerator NetworkTimeControlIE()
    {
        Debug.Log("开始网络倒计时协程");

        int nH = 00;
        int nM = 00;
        int nS = 00;


        Debug.Log("开始请求网络时间");
        //yield return StartCoroutine(RequestNetworkTime());
        GetNetStandardTime netServerTime= new GetNetStandardTime();
        netServerTime.RequestNetworkTime();

        Debug.Log(" 获取时间");
        netServerTime.DataStandardTime();
        nH = (int)netServerTime.netTime.Hour;
        nM = (int)netServerTime.netTime.Minute;
        nS = (int)netServerTime.netTime.Second;
        totaltime4 = 86400 - ((nH * 60 * 60) + (nM * 60) + nS);

        while (totaltime4 >= 1)
        {
            if (netChanged == "UpToDown")
            {
                break;
            }
            Debug.Log("开始倒计时");
            int H = (int)totaltime4 / 60 / 60;
            int M = (int)totaltime4 / 60 % 60;
            int S = (int)totaltime4 % 60;
            countdown4text.text = "网络时间倒计时\n" + string.Format("{0:00}:{1:00}:{2:00}", H, M, S);
            yield return new WaitForSeconds(1.0f);
            // 时间减去一秒
            totaltime4--;

            // 计时器复位重新开始计时
            if (totaltime4 < 1)
            {
                totaltime4 = 86400 - ((nH * 60 * 60) + (nM * 60) + nS);
            }

        }
        
    }


    ////实现倒计时方法二：采用Update方法
    ////Update is called once per frame
    //void Update()
    //{
    //    Debug.Log("开始Update倒计时");

    //    int M = (int)(totaltime2 / 60);
    //    float S = totaltime2 % 60;
    //    if (totaltime2 > 0)
    //    {
    //        intervaletime -= Time.deltaTime;
    //        if (intervaletime <= 0)
    //        {
    //            intervaletime += 1;
    //            totaltime2--;
    //            countdown2text.text = string.Format("{0:00}:{1:00}", M, S);

    //        }
    //    }
    //    if (totaltime2 <= 0)
    //    {
    //        totaltime2 = 20;
    //    }

    //}



}


