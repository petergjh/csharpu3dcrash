using System.Collections;
using System.Collections.Generic;
using UIFrame;
using UnityEngine;
using UnityEngine.UI;

namespace DemoProject
{
    public class PropDetailUIForm : BaseUIForm
    {
        public Text TxtName;  // 窗体名称
        private void Awake()
        {
            // 窗体的性质
            CurrentUIType.UIForms_Type = UIFormType.PopUp;
            CurrentUIType.UIForms_ShowMode = UIFormShowMode.ReverseChange;
            CurrentUIType.UIForms_LucencyType = UIFormLucenyType.Translucence;

            // 按钮的注册
            // BtnClose关闭按钮
            RegisterButtonObjectEvent("BtnClose",
                p =>
                {
                    CloseUIForm();
                }
                );
        }

            // 接受消息
            //           MessageCenter.AddMsgListener("Props",
            //              p =>
            //             {
            //                Debug.Log("接受消息." );
            //                   if (p.Key.Equals("ticket"))
            //                   {
            //                   if (TxtName)
            //                  {
            //                     TxtName.text = p.Values.ToString();

            //                   }
            //
            //                    else if (p.Key.Equals("shoes"))
            //                    {
            //                        if (TxtName)
            //                        {
            //                            TxtName.text = p.Values.ToString();
            //                        }
            //                    }
            //
            //                    else if (p.Key.Equals("cloth"))
            //                    {
            //                        if (TxtName)
            //                        {
            //                            TxtName.text = p.Values.ToString();
            //                        }
            //                    }
            //            });


            //ReceiveMessage("Props", 
            //    p =>
            //    {
            //        if (TxtName)
            //        {
            //            // TxtName.text = p.Values.ToString();
            //            string[] strArray = p.Values as string[];
            //            TxtName.text = strArray[0];
            //            print("测试传递消息的值可以是不同的类型对象： " + strArray);
            //        }
            //        Debug.Log("监听并接收消息：" + p.Key + p.Values);
            //    });

        protected override void ReceiveMsg(KeyValuesUpdate KV)
        {
            switch (KV.Key)
            {
                case "DeleteYes":
                    {
                       // ShowSaves();
                        Debug.Log("监听并接收消息：" + KV.Key + KV.Value);
                        Debug.Log("确认删档，刷新重载UI");

                    }
                    break;

                case "Props":
                    {
                        string[] strArray = KV.Value as string[];
                        TxtName.text = strArray[0];
                        print("测试传递消息的值可以是不同的类型对象： " + strArray);

                    }
                    break;
                
            }
        }



    } // Awake_end

}
    






