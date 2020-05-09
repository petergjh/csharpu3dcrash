using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using Managers;
//using Models;
using UIFrame;
//using UIFrame.UIDATACLASS;
using System;
using System.IO;

public class ArchUIForm : BaseUIForm
{  
    private const string NAME = "ArchUIForm";
    // 存档ID
    // private string ArchID=null;
    private Button BtnOnArchDefault;
    private string strArrayChosen;
    public static int ArchID=1;
    private Button ShowBtnOnArch;
    private string newfilename = "";
    const string File_Directory_Name = "/GameArchive";

    protected override void Initialization()
    {
        MsgTypeName = NAME;
        // 窗体属性
        CurrentUIType.UIForms_Type = UIFormType.PopUp;
        CurrentUIType.UIForms_ShowMode = UIFormShowMode.ReverseChange;
        CurrentUIType.UIForms_LucencyType =UIFormLucenyType.ImPenetrable;

        ShowSaves();
    }


    /// <summary>
    /// 初始化按钮点击事件
    /// </summary>
    protected override void InitButtonClickEvent()
    {
        // 退出按钮
        RegisterButtonObjectEvent("BtnExit",
            p =>
            {
                //UIManager.GetIndtance().CloseUIForms("ArchUIForm");
                CloseUIForm();
                Debug.Log("存档窗体已关闭");
            }
            );

        // 选择存档一
        RegisterButtonObjectEvent("BtnOnArch1",
            p =>
            {
                // 获得存档ID
                ArchID =1;
                AniBtn("BtnOnArch1");
            }
            );

        // 选择存档二
        RegisterButtonObjectEvent("BtnOnArch2",
            p =>
            {
                // 获得存档ID
                ArchID = 2;
                AniBtn("BtnOnArch2");
            }
            );

        // 选择存档三
        RegisterButtonObjectEvent("BtnOnArch3",
            p =>
            {
                // 获得存档ID
                ArchID = 3;
                AniBtn("BtnOnArch3");
            }
            );


        // 开始游戏按钮
        RegisterButtonObjectEvent("BtnStartGame", p =>
        {
            AniBtn("BtnStartGame");
            // 加载存档
            //LoadArch(ArchID);
            MainManager.InitManager();
            Debug.Log(" 加载存档，启动游戏");

            //GameArchiveManager.LoadArchive(ArchID);
            Debug.Log("已成功加载存档：" + ArchID);
            // 关闭窗体
            CloseUIForm();

            // 跳转场景
            //SceneManager.LoadScene("lobbyScene");
            //OpenUIForm("RegisterUI");
            //Globe.LoadingSceneKind = LoadingKind.InitGame;
            //Globe.LodingScene("lobbyScene");
            //UIManager.GetIndtance().CloseUIForms("ArchUIForm");
        }
        );

                // 存档UI的增、删、改、查
        RegisterButtonObjectEvent("BtnAddArch", p=>
        {
            AniBtn("BtnAddArch");
            // 新建一个空的存档文件
            //GameArchiveManager.CreateFile(newfilename, null);
            Debug.Log("新建存档后刷新UI");
            ShowSaves();
            //OpenUIForm("ArchUIForm");
        }
        );


        // 删除存档按钮
        RegisterButtonObjectEvent("BtnDeleteArch",
            p=>
            {
                AniBtn("BtnDeleteArch");
                Debug.Log("存档ArchID=" + ArchID);
                // 打开确认弹窗
                OpenUIForm("DialogUIForm");
                Debug.Log("打开删档对话框");

                // 发送删除消息到弹窗
                string[] strArray = new string[] { "请选择要删除的存档！","是否要删除存档一", "是否要删除存档二","是否要删除存档三"};
                strArrayChosen = strArray[ArchID];

                Debug.LogFormat("发送消息：类型：DialogUIForm， 名称：Save, 内容：{0}" , strArray[ArchID]);
                SendMessage("DialogUIForm","Save",strArrayChosen);
                // ArchID = 0;

            }
            );
    }


    protected override void ReceiveMsg(KeyValuesUpdate KV)
    {
        switch (KV.Key)
        {
            case "DeleteYes":
                {
                    ShowSaves();
                    Debug.Log("监听并接收消息：" + KV.Key + KV.Value);
                    Debug.Log("确认删档，刷新重载UI");

                }
                break;
        }
    }

  
    #region 私有方法

    public static bool IsFileExists(string fileName)
    {
        return File.Exists(fileName);
    }

    public void ShowSaves()
    {
        // 显示各存档 
        for (int ArchID = 3; ArchID > 0; ArchID--)
        {
            string BtnOnArch = "BtnOnArch" + ArchID;
            ShowBtnOnArch = FindChild<Button>(gameObject, BtnOnArch);
            string path = Application.streamingAssetsPath + File_Directory_Name + "/save" + ArchID + ".json";
            if (IsFileExists(path))
            {
                // 若有此存档就显示，可启动游戏，可删、改、查此存档
                Debug.Log("已找到存档：" + ArchID);//
                // ShowBtnOnArch.image.enabled = true;
                ShowBtnOnArch.interactable = true;
            }
            else
            {
                // 若无此存档则显示为空，并提示可新建存档
                // ShowBtnOnArch.image.Disable();
                ShowBtnOnArch.interactable = false;
                Debug.Log("没找到存档：" + ArchID);
                newfilename = path;
            }
        }

        // 高亮显示第一个存档
        BtnOnArchDefault = FindChild<Button>(this.gameObject, "BtnOnArch1");
        BtnOnArchDefault.Select();
        Debug.Log("设置默认选择存档一");
    }

    /// <summary>
    /// 按钮缩放特效
    /// </summary>
    /// <param name="aniBtnName"></param>
    public void AniBtn(string aniBtnName)
    {
            BtnOnArchDefault = FindChild<Button>(this.gameObject,aniBtnName);
            BtnOnArchDefault.transform.DOPunchPosition(new Vector3(0, 2, 0), 0.3f, 6, 0.3f);
            BtnOnArchDefault.transform.DOPunchScale(new Vector3(0.1f, 0, 0), 0.3f, 6, 0.3f);
    }

    #endregion



}
