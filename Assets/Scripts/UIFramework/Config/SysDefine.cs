/***
 * 
 *  Title: UI框架
 *          主题:框架核心参数
 *          
 *  Description:
 *          功能:
 *          1.系统常量
 *          2.全局性方法
 *          3.系统枚举类型
 *          4.委托定义
 *          
 *  Date:2019
 *  Version:0.1
 *  Modify Recoder:
 * 
 * 
 * 
 */



using Managers;
using Models;
using System.Collections;
using System.Collections.Generic;
//using UIFORM.UIDATACLASS;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIFrame
{
    #region 系统枚举类型
    /// <summary>
    /// UI窗体(位置)类型
    /// </summary>
    public enum UIFormType
    {
        /// <summary>
        /// 普通窗体
        /// </summary>
        Normal,
        /// <summary>
        /// 固定窗体
        /// </summary>
        Fixed,
        /// <summary>
        /// 弹出窗体
        /// </summary>
        PopUp,
    }

    /// <summary>
    /// UI窗体显示类型
    /// </summary>
    public enum UIFormShowMode
    {
        /// <summary>
        /// 普通
        /// </summary>
        Normal,
        /// <summary>
        /// 反向切换
        /// </summary>
        ReverseChange,
        /// <summary>
        /// 隐藏其它
        /// </summary>
        HideOther
    }

    /// <summary>
    /// UI窗体穿透类型
    /// </summary>
    public enum UIFormLucenyType
    {
        /// <summary>
        /// 完全透明,不能穿透
        /// </summary>
        Lucency,
        /// <summary>
        /// 半透明,不能穿透
        /// </summary>
        Translucence,
        /// <summary>
        /// 低透明,不能穿透
        /// </summary>
        ImPenetrable,
        /// <summary>
        /// 可以穿透
        /// </summary>
        Pentrate,
        /// <summary>
        /// 不需要遮罩，并且不改变上层遮罩
        /// </summary>
        DnotMask
    }


    /// <summary>
    /// UI活跃状态
    /// </summary>
    public enum UIFormActiveType
    {
        /// <summary>
        /// 活跃
        /// </summary>
        Active,
        /// <summary>
        /// 不活跃
        /// </summary>
        Inactive
    }

    /// <summary>
    /// 选择提示信息框的内容种类
    /// </summary>
    public enum SelectTipsKind
    {
        /// <summary>
        /// 招募角色
        /// </summary>
        Recruit,
        /// <summary>
        /// 刷新招募角色
        /// </summary>
        RefreshRecruitRole,
        /// <summary>
        /// 出战编队空提示
        /// </summary>
        TeamCountEmptyTips,
        /// <summary>
        /// 出售道具成功提示
        /// </summary>
        SellItemSucceffTips,
        /// <summary>
        /// 提示扔骰子
        /// </summary>
        DiceTips,
        /// <summary>
        /// 提示选择节点
        /// </summary>
        ChoseNode,
        /// <summary>
        /// 数值事件结果
        /// </summary>
        ValueEventResult,
        /// <summary>
        /// 传送事件提示
        /// </summary>
        TransferTips,
        /// <summary>
        /// 金币复活角色提示
        /// </summary>
        RecoverRoleByGoldTips,
        /// <summary>
        /// 召还复活角色提示
        /// </summary>
        ReviveFullRoleGoldTips,
        /// <summary>
        /// 文本提示
        /// </summary>
        StringTips,
        /// <summary>
        /// 购买商品信息提示
        /// </summary>
        BuyShopGoodsTips,
        /// <summary>
        /// 显示任务提示
        /// </summary>
        ShowMissionTips,
        /// <summary>
        /// 检查角色是否可以继续移动
        /// </summary>
        CheckRoleTeamMove,
        /// <summary>
        /// 购买魔石
        /// </summary>
        BuyJewel,
        /// <summary>
        /// 华容道游戏胜利
        /// </summary>
        KlotskiGameWin,
        /// <summary>
        /// 组合游戏结果
        /// </summary>
        ArrayGameResult,
        /// <summary>
        /// 摇奖一银币
        /// </summary>
        RollReward_Sliver,
        /// <summary>
        /// 摇奖半金币
        /// </summary>
        RollReward_HalfGold,
        /// <summary>
        /// 摇奖金币
        /// </summary>
        RollReward_Gold

    }

    /// <summary>
    /// 显示的角色属性种类
    /// </summary>
    public enum ShowRolePropertyKind
    {
        /// <summary>
        /// 全部角色
        /// </summary>
        AllRole,
        /// <summary>
        /// 编队中的角色
        /// </summary>
        EnterTeamRole
    }

    /// <summary>
    /// 数值事件提示的种类
    /// </summary>
    public enum ValueEventTipsKind
    {
        /// <summary>
        /// 增加疲劳
        /// </summary>
        AddFTG,
        /// <summary>
        /// 恢复疲劳
        /// </summary>
        RecoverFTG,
        /// <summary>
        /// 伤害部位
        /// </summary>
        HurtBodyPart,
    }

    /// <summary>
    /// 事件随机角色的种类
    /// </summary>
    public enum EventUIChoseRoleKind
    {
        /// <summary>
        /// 随机角色
        /// </summary>
        RandomRole,
        /// <summary>
        /// 选择角色
        /// </summary>
        ChoseRole,
        /// <summary>
        /// 全部角色
        /// </summary>
        AllRole,
        /// <summary>
        /// 不需要角色，显示两个按钮
        /// </summary>
        NoRoleTwoButton,
        /// <summary>
        /// 随机1-全部角色
        /// </summary>
        RandomOneToAll,
        /// <summary>
        /// 显示双选按钮
        /// </summary>
        ShowSecondChose,
    }

    /// <summary>
    /// 编队头像的动画效果种类
    /// </summary>
    public enum TeamHeadAnimKind
    {
        /// <summary>
        /// 震动
        /// </summary>
        Shake,
    }

    /// <summary>
    /// 三选事件的种类
    /// </summary>
    public enum ThreeChoiceKind
    {
        /// <summary>
        /// 战斗
        /// </summary>
        Battle,
        /// <summary>
        /// 商店
        /// </summary>
        Shop,
        /// <summary>
        /// 休息处
        /// </summary>
        Lounge
    }

    /// <summary>
    /// 通用事件的按钮点击类型
    /// </summary>
    public enum GlobalEventRoleButtonClickKind
    {
        /// <summary>
        /// 获得技能
        /// </summary>
        GetSkill,
        /// <summary>
        /// 获得Hp上限
        /// </summary>
        GetMaxHp,

    }

    /// <summary>
    /// 迷你魔法书显示的种类
    /// </summary>
    public enum MiniMagicBookKind
    {
        GetSkill,
        SkillLvUp
    }


    public enum MaxHpResultData
    {
        /// <summary>
        /// 显示结果
        /// </summary>
        ShowResult,
        /// <summary>
        /// 选择部位
        /// </summary>
        ChoseBodyPart,
    }
    /// <summary>
    /// 随机事件提示信息种类
    /// </summary>
    public enum RandomEventTipsKind
    {
        /// <summary>
        /// 无
        /// </summary>
        None,
        /// <summary>
        /// 显示结果
        /// </summary>
        ShowResult,
        /// <summary>
        /// 选择角色
        /// </summary>
        ChoseRole,
        /// <summary>
        /// 显示按钮
        /// </summary>
        ShowButton,
        /// <summary>
        /// 显示角色部位
        /// </summary>
        ShowBodyPart,
    }
    /// <summary>
    /// 随机事件提示框显示按钮的种类
    /// </summary>
    public enum RandomEventTipsShowButtonKind
    {
        /// <summary>
        /// 不显示按钮
        /// </summary>
        NoButton,
        /// <summary>
        /// 只显示退出按钮
        /// </summary>
        ShowExitButton,
        /// <summary>
        /// 显示第一个和退出按钮
        /// </summary>
        ShowFirstAndExitButton,
        /// <summary>
        /// 显示第一个和第二个按钮
        /// </summary>
        ShowFirstAndSecondButton,
        /// <summary>
        /// 显示三个按钮，不显示退出按钮
        /// </summary>
        ShowAllButtonNoExit,
    }
    /// <summary>
    /// 选择身体部位UI结果种类
    /// </summary>
    public enum BodyPartChoseUIKind
    {
        /// <summary>
        /// 血量最大值
        /// </summary>
        MaxHp,
        /// <summary>
        /// 强化护甲
        /// </summary>
        StrengthEquip,
    }
    /// <summary>
    /// 地图队伍移动状态
    /// </summary>
    public enum MapTeamMoveState
    {
        None,
        RoleTeamMove,
        EnemyTeamMove
    }
    /// <summary>
    /// 文本颜色种类
    /// </summary>
    public enum TextColorKind
    {
        None,
        Orange,
        Red,
        Green,
        white,
        HighYellow
    }
    #endregion

    public class SysDefine:MonoBehaviour
    {
        #region 路径常量
        //配置表路径常量
        /// <summary>
        /// UI窗体的配置信息
        /// </summary>
        public const string SYS_PATH_UIFORMS = @"Config\Json\UIFormsConfigInfo";
        //public const string SYS_PATH_UIFORMS = @"\\Resources\\UIFormsConfigInfo.json";
        /// <summary>
        /// 日记配置Json路径
        /// </summary>
        public const string SYS_PATH_CONFIG_LOG = @"Config\Json\SysConfigInfo";
        /// <summary>
        /// 中文UI配置Json路径
        /// </summary>
        public const string SYS_PATH_LAUGUAGE_CN = @"Config\Json\LauguagePathJSONConfig";

        //UI预设路径常量
        /// <summary>
        /// 根UICanvas
        /// </summary>
        public const string SYS_PATH_CANVAS = @"Canvas";
        /// <summary>
        /// 角色属性窗体UI预设
        /// </summary>
        public const string SYS_PATH_ROLEPROPERTY = @"Prefabs\MZC\UIPrefab\RoleProperty\RolePropertyInfoUI";

     
        #endregion

        #region 透明度常量
        //全透明
        public const float SYS_LUCENCY_RGB = 255 / 255f;
        public const float SYS_LUCENCY_RGB_A = 0 / 255f;

        //半透明
        public const float SYS_TRANS_RGB = 220 / 255f;
        public const float SYS_TRANS_RGB_A = 50 / 255f;

        //低透明
        public const float SYS_IMPENETRABLE_RGB = 50 / 255f;
        public const float SYS_IMPENETRABLE_RGB_A = 200/ 255f;
        #endregion

        #region 标签常量
        /// <summary>
        /// UICanvas标签
        /// </summary>
        public const string SYS_TAG_CANVAS = "_TagCanvas";
        #endregion

        #region 节点常量
        // 根节点常量
        /// <summary>
        /// 普通节点，一般背景用
        /// </summary>
        public const string SYS_NORMAL_NODE = "Normal";
        /// <summary>
        /// 固定节点，一般时固定元素使用
        /// </summary>
        public const string SYS_FIXED_NODE = "Fixed";
        /// <summary>
        /// 弹出节点，一般是弹窗用
        /// </summary>
        public const string SYS_POPUP_NODE = "PopUp";
        /// <summary>
        /// 引导节点，引导操作用
        /// </summary>
        public const string SYS_GUIDE_NODE = "Guide";
        /// <summary>
        /// 脚本管理节点，放一些不需要删除的脚本
        /// </summary>
        public const string SYS_SCRIPTMANAGER_NODE = "_ScriptsMgr";
        /// <summary>
        /// 保存预设的节点
        /// </summary>
        public const string SYS_SAVEPREFAB_NODE = "SavePrefab";


        //主城按钮常量
        /// <summary>
        /// 主城修炼场
        /// </summary>
        public const string SYS_TRAININGGROUND_NODE = "TrainingGround";
        /// <summary>
        /// 主城酒馆
        /// </summary>
        public const string SYS_TAVERN_NODE ="Tavern";
        /// <summary>
        /// 主城英雄通告栏
        /// </summary>
        public const string SYS_HEROCALLBOARD_NODE = "HeroCallBoard";
        /// <summary>
        /// 主城仓库
        /// </summary>
        public const string SYS_WAREHOUSE_NODE = "Warehouse";
        /// <summary>
        /// 主城竞技场
        /// </summary>
        public const string SYS_ARENA_NODE =　"Arena";
        /// <summary>
        /// 主城赏金任务
        /// </summary>
        public const string SYS_REWARDMISSION_NODE = "RewardMission";
        /// <summary>
        /// 主城设置按钮
        /// </summary>
        public const string SYS_SETTINGBUTTON_NODE = "SettingButton";
        /// <summary>
        /// 主城祭坛
        /// </summary>
        public const string SYS_ALTAR_NODE = "Altar";

        //其它常量
        /// <summary>
        /// 资源条UI
        /// </summary>
        public const string SYS_UI_ResourcesUI_Node = "ResourceBarUI";
        /// <summary>
        /// 酒馆UI
        /// </summary>
        public const string SYS_UI_TavernUI_Node = "TavernUI";
        /// <summary>
        /// 任务信息UI
        /// </summary>
        public const string SYS_UI_MissionInfoUI_Node = "MissionInfoUI";

        //特质按钮常量
        //好特质
        /// <summary>
        /// 好特质信息按钮1
        /// </summary>
        public const string SYS_UI_GoodTraitButton_1_Node = "GoodTrait1";
        /// <summary>
        /// 好特质信息按钮2
        /// </summary>
        public const string SYS_UI_GoodTraitButton_2_Node = "GoodTrait2";
        /// <summary>
        /// 好特质信息按钮3
        /// </summary>
        public const string SYS_UI_GoodTraitButton_3_Node = "GoodTrait3";
        //怀特质
        /// <summary>
        /// 坏特质信息按钮1
        /// </summary>
        public const string SYS_UI_BadTraitButton_1_Node = "BadTrait1";
        /// <summary>
        /// 坏特质信息按钮2
        /// </summary>
        public const string SYS_UI_BadTraitButton_2_Node = "BadTrait2";
        /// <summary>
        /// 坏特质信息按钮3
        /// </summary>
        public const string SYS_UI_BadTraitButton_3_Node = "BadTrait3";

        //道具
        /// <summary>
        /// 道具信息提示UI
        /// </summary>
        public const string SYS_UI_ItemInfoTipsUI_Node = "ItemInfoTipsUI";

        //提示框常量
        /// <summary>
        /// 选择提示信息框
        /// </summary>
        public const string SYS_UI_Tips_SelectTipsUI_Node = "SelectTipsUI";

        //游戏地图图片资源名
        //======节点资源常量
        /// <summary>
        /// 随机事件的节点高亮图标
        /// </summary>
        public const string SYS_ICON_RandomEventIcon_Light = "Random_777_Light";
        /// <summary>
        /// 随机事件的节点暗色图标
        /// </summary>
        public const string SYS_ICON_RandomEventIcon_Dark = "Random_777_Dark";
        /// <summary>
        /// 底座节点高亮图标
        /// </summary>
        public const string SYS_ICON_MapSeatIcon_Light = "Random_0_Light";
        /// <summary>
        /// 底座节点暗色图标
        /// </summary>
        public const string SYS_ICON_MapSeatIcon_Dark = "Random_0_Dark";
        /// <summary>
        /// 战斗事件节点高亮图标
        /// </summary>
        public const string SYS_ICON_BattleEventIcon_Light = "Random_1_Light";
        /// <summary>
        /// 战斗事件节点暗色图标
        /// </summary>
        public const string SYS_ICON_BattleEventIcon_Dark = "Random_1_Dark";
        /// <summary>
        /// 商店事件节点高亮图标
        /// </summary>
        public const string SYS_ICON_ShopEventIcon_Light = "Random_2_Light";
        /// <summary>
        /// 商店事件节点暗色图标
        /// </summary>
        public const string SYS_ICON_ShopEventIcon_Dark = "Random_2_Dark";
        /// <summary>
        /// 休息事件节点高亮图标
        /// </summary>
        public const string SYS_ICON_LoungeEventIcon_Light = "Random_3_Light";
        /// <summary>
        /// 休息事件节点暗色图标
        /// </summary>
        public const string SYS_ICON_LoungeEventIcon_Dark = "Random_3_Dark";


        #endregion

        #region 摄像机层深的常量

        #endregion

        #region 普通常量
        public const int MaxFTGLimit = 200;
        #endregion

        #region 按钮文本常量
        /// <summary>
        /// 空值
        /// </summary>
        public const string ButtonText_Null = "ButtonText_Null";
        /// <summary>
        /// 确认
        /// </summary>
        public const string ButtonText_Confirm = "ButtonText_Confirm";
        /// <summary>
        /// 放弃
        /// </summary>
        public const string ButtonText_GiveUp = "ButtonText_GiveUp";
        /// <summary>
        /// 营救
        /// </summary>
        public const string ButtonText_Save = "ButtonText_Save";
        /// <summary>
        /// 打开
        /// </summary>
        public const string ButtonText_Open = "ButtonText_Open";
        /// <summary>
        /// 进入
        /// </summary>
        public const string ButtonText_Enter = "ButtonText_Enter";
        /// <summary>
        /// 购买
        /// </summary>
        public const string ButtonText_Buy = "ButtonText_Buy";
        /// <summary>
        /// 祈福
        /// </summary>
        public const string ButtonText_Pray = "ButtonText_Pray";
        /// <summary>
        /// 激活
        /// </summary>
        public const string ButtonText_Activation = "ButtonText_Activation";
        /// <summary>
        /// 追击
        /// </summary>
        public const string ButtonText_Pursuit = "ButtonText_Pursuit";
        /// <summary>
        /// 抽签
        /// </summary>
        public const string ButtonText_Drawlots = "ButtonText_Drawlots";

        #endregion

        #region UICanvas排序常量
        /// <summary>
        /// 根节点的排序
        /// </summary>
        public const int Canvas_SortOrder_RootCanvas = 0;

        /// <summary>
        /// 地图事件节点的排序
        /// </summary>
        public const int Canvas_SortOrder_NodeUI = 0;

        #endregion

        #region 资源常量
        //角色属性UI滑动条资源路径
        /// <summary>
        /// 黑条路径
        /// </summary>
        public const string PropertySlider_Black = "MZC/ui/RolePropertyUI/PropertyInfoUI/PropertySlider_Black";
        /// <summary>
        /// 浅灰条路径
        /// </summary>
        public const string PropertySlider_ShallowGrey = "MZC/ui/RolePropertyUI/PropertyInfoUI/PropertySlider_ShallowGrey";
        /// <summary>
        /// 深灰条路径
        /// </summary>
        public const string PropertySlider_DeepGrey = "MZC/ui/RolePropertyUI/PropertyInfoUI/PropertySlider_DeepGrey";
        /// <summary>
        /// 浅蓝条路径
        /// </summary>
        public const string PropertySlider_ShallowBlue = "MZC/ui/RolePropertyUI/PropertyInfoUI/PropertySlider_ShallowBlue";
        /// <summary>
        /// 深蓝条路径
        /// </summary>
        public const string PropertySlider_DeepBlue = "MZC/ui/RolePropertyUI/PropertyInfoUI/PropertySlider_DeepBlue";
        /// <summary>
        /// 浅红条路径
        /// </summary>
        public const string PropertySlider_ShallowRed = "MZC/ui/RolePropertyUI/PropertyInfoUI/PropertySlider_ShallowRed";
        /// <summary>
        /// 深红条路径
        /// </summary>
        public const string PropertySlider_DeepRed = "MZC/ui/RolePropertyUI/PropertyInfoUI/PropertySlider_DeepRed";
        /// <summary>
        /// 浅黄条路径
        /// </summary>
        public const string PropertySlider_ShallowYellow = "MZC/ui/RolePropertyUI/PropertyInfoUI/PropertySlider_ShallowYellow";
        /// <summary>
        /// 深黄条路径
        /// </summary>
        public const string PropertySlider_DeepYellow = "MZC/ui/RolePropertyUI/PropertyInfoUI/PropertySlider_DeepYellow";
        /// <summary>
        /// 浅绿条路径
        /// </summary>
        public const string PropertySlider_ShallowGreen = "MZC/ui/RolePropertyUI/PropertyInfoUI/PropertySlider_ShallowGreen";
        /// <summary>
        /// 深绿条路径
        /// </summary>
        public const string PropertySlider_DeepGreen = "MZC/ui/RolePropertyUI/PropertyInfoUI/PropertySlider_DeepGreen";
        /// <summary>
        /// 浅紫条路径
        /// </summary>
        public const string PropertySlider_ShallowPurple = "MZC/ui/RolePropertyUI/PropertyInfoUI/PropertySlider_ShallowPurple";
        /// <summary>
        /// 深紫条路径
        /// </summary>
        public const string PropertySlider_DeepPurple = "MZC/ui/RolePropertyUI/PropertyInfoUI/PropertySlider_DeepPurple";
        #endregion

        #region 全局性方法

        /// <summary>
        /// 获得标准的数字转换
        /// </summary>
        /// <param name="Count"></param>
        /// <returns></returns>
        public static string GetStandStringCount(int Count)
        {
            string Info = "";
            int MilionCount = Count / 1000000;
            Count = Count - MilionCount*1000000;
            //判断是否是百万级
            if (MilionCount != 0)
            {
                int TenCount = Count / 100000;
                Info += MilionCount + "." + TenCount + "M";
            }
            //判断是否是千以上
            else
            {
                int KCount = Count / 1000;
                if (KCount != 0)
                {
                    Count -= KCount * 1000;
                    int BCount = Count / 100;
                    Info += KCount + "." + BCount + "K";
                }
                //直接输出数字
                else
                {
                    Info += Count.ToString();
                }
            }
            return Info;
        }

        ///// <summary>
        ///// 获得出战角色的某项总属性
        ///// </summary>
        ///// <returns></returns>
        //public static float GetTeamProperties(Init.AdditionPropertyKind propertyKind)
        //{
        //    float Value = 0f;
        //    List<Character> characters = SysDefine.GetEnterRole();
        //    for (int i = 0;i<characters.Count;i++)
        //    {
        //        Character CT = characters[i];
        //        switch (propertyKind)
        //        {
        //            case Init.AdditionPropertyKind.Attribute_HP: { }break;
        //            case Init.AdditionPropertyKind.Attribute_MP: { }break;
        //            case Init.AdditionPropertyKind.Attribute_Speed:
        //                {
        //                    Value += CT.MProperty().Speed;
        //                }
        //                break;
        //            case Init.AdditionPropertyKind.Attribute_Luck:
        //                {
        //                    Value += CT.MProperty().Luck;
        //                }
        //                break;
        //            case Init.AdditionPropertyKind.Attribute_Resist:
        //                {
        //                    Value += CT.MProperty().Resist;
        //                }
        //                break;
        //        }
        //    }
        //    return Value;
        //}
        /// <summary>
        /// 将Sprite转成Texture
        /// </summary>
        /// <param name="sprite"></param>
        /// <returns></returns>
        public static Texture GetTextureBySprite(Sprite sprite)
        {
            var targetTex = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            var pixels = sprite.texture.GetPixels(
                (int)sprite.textureRect.x,
                (int)sprite.textureRect.y,
                (int)sprite.textureRect.width,
                (int)sprite.textureRect.height);
            targetTex.SetPixels(pixels);
            targetTex.Apply();
            return targetTex;
        } 

        ///// <summary>
        ///// 获得一个随机的出战角色
        ///// </summary>
        ///// <returns></returns>
        //public static Character GetRandomCharacterByEnter()
        //{
        //    List<Character> characters = GetEnterRole();
        //    Character CT = characters[Random.Range(0, characters.Count)];
        //    return CT;
        //}

        ///// <summary>
        ///// 获得没有该buff的一个角色UID
        ///// </summary>
        ///// <returns></returns>
        //public static long GetRandomCharacterUIDByNoBuff(int buffId)
        //{
        //    List<Character> characters = new List<Character>(GetEnterRole());
        //    for (int i = characters.Count-1; i>=0;i--)
        //    {
        //        Character CT = characters[i];
        //        if (ManagerController.Instance.MRandomEnevtManager.IsHaveBuffByBuffId(CT.UID,buffId))
        //        {
        //            characters.RemoveAt(i);
        //        }
        //    }
        //    if (characters.Count == 0)
        //    {
        //        Debug.Log("!!!buff叠加出错!!!BuffId"+ buffId);
        //    }
        //    Character ct = characters[Random.Range(0, characters.Count)];
        //    return ct.UID;
        //} 

        public static void ShowWarningTips()
        {
            //OpenUIForm("WarningTips");
            MessageCenter.DisposeMessage("WarningTips",SYS_MSG_KIND_ShowWarning);
        }

        /// <summary>
        /// 加载角色头像
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public static Sprite LoadRoleHead(int CID)
        {
            return Resources.Load<Sprite>("TestImg/" + CID);
        }

        /// <summary>
        /// 从第几个子节点开始删除
        /// </summary>
        /// <param name="FatherTrans">父节点</param>
        /// <param name="Index">开始删除的子节点</param>
        public static void RemoveChildrenGameObject(Transform FatherTrans,int Index)
        {
            Transform[] transforms = FatherTrans.GetComponentsInChildren<Transform>();
            for (int i = Index; i < transforms.Length; ++i)
            {
                Destroy(transforms[i].gameObject);
            }
        }
        /// <summary>
        /// 设置活跃状态
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="state"></param>
        public static void SetActive(GameObject obj,bool state)
        {
            if (obj == null)
            {
                return;
            }
            if (obj.activeSelf != state)
            {
                obj.SetActive(state);
            }
        }
        /// <summary>
        /// 通过物品CID加载图块
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public static Sprite LoadItemSpriteByCID(int CID)
        {
            Sprite sprite = null;
            sprite = Resources.Load<Sprite>("MZC/ItemIcon/" + CID.ToString());
            return sprite;
        }
        /// <summary>
        /// 通过事件资源名+加载事件节点的图片资源
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static Sprite LoadEventNodeByIconName(string Name)
        {
            Sprite sprite = null;
            sprite = Resources.Load<Sprite>("MZC/NodeIcon/"+Name);
            return sprite;
        }
        /// <summary>
        /// 换算角度
        /// </summary>
        /// <param name="from_"></param>
        /// <param name="to_"></param>
        /// <returns></returns>
        public static float Angle_360(Vector3 from_, Vector3 to_)
        {
            //两点的x、y值
            float x = from_.x - to_.x;
            float y = from_.y - to_.y;

            //斜边长度
            float hypotenuse = Mathf.Sqrt(Mathf.Pow(x, 2f) + Mathf.Pow(y, 2f));

            //求出弧度
            float cos = x / hypotenuse;
            float radian = Mathf.Acos(cos);

            //用弧度算出角度    
            float angle = 180 / (Mathf.PI / radian);

            if (y < 0)
            {
                angle = -angle;
            }
            else if ((y == 0) && (x < 0))
            {
                angle = 180;
            }
            return angle;
        }
        ///// <summary>
        ///// 通过当前层数和节点ID获取事件CID
        ///// </summary>
        ///// <param name="MapLayer">所在层数</param>
        ///// <param name="NodeId">节点ID</param>
        ///// <returns></returns>
        //public static int GetEventIDByNodeId(Dictionary<int, Dictionary<string, CEventNode>> dic_EventMap, int MapLayer, int NodeId)
        //{
        //    if (dic_EventMap.ContainsKey(MapLayer))
        //    {
        //        if (dic_EventMap[MapLayer].ContainsKey(NodeId.ToString()))
        //        {
        //            CEventNode node = dic_EventMap[MapLayer][NodeId.ToString()];
        //            return node.RanEventCID;
        //        }
        //    }
        //    return 0;
        //}

        ///// <summary>
        ///// 显示选择提示框
        ///// </summary>
        ///// <param name="TipsInfo"></param>
        ///// <param name="IsShowCancel"></param>
        ///// <param name="selectTipsKind"></param>
        //public static void ShowSelectTips(string TipsInfo,bool IsShowCancel,SelectTipsKind selectTipsKind,UIFormLucenyType lucenyType = UIFormLucenyType.Translucence,object additionData = null)
        //{
        //    UIManager.GetIndtance().ShowUIForms(SYS_UI_Tips_SelectTipsUI_Node);
        //    SelectTipsData selectTipsData = new SelectTipsData(TipsInfo, IsShowCancel, selectTipsKind, lucenyType,additionData);
        //    MessageCenter.DisposeMessage("SelectTipsUI",SYS_MSG_KIND_SHOWSELECTTIPS, selectTipsData);
        //}

        ///// <summary>
        ///// 显示事件提示框
        ///// </summary>
        ///// <param name="EventCID"></param>
        ///// <param name="choseRoleKind"></param>
        ///// <param name="CharacterUIDs"></param>
        //public static void ShowEventTipsUI(int EventCID, EventUIChoseRoleKind choseRoleKind,List<long> CharacterUIDs = null,bool IsSelectRole = false)
        //{
        //    UIManager.GetIndtance().ShowUIForms("ValueEventTipsUI");
        //    ShowEventUIData eventUIData = new ShowEventUIData(EventCID, choseRoleKind, CharacterUIDs, IsSelectRole);
        //    MessageCenter.DisposeMessage(SysDefine.SYS_MSG_KIND_ShowEventUIKind, eventUIData);

        //}

        ///// <summary>
        ///// 显示随机事件提示框
        ///// </summary>
        ///// <param name="EventID"></param>
        ///// <param name="EventTipsKind"></param>
        ///// <param name="ShowButtonKind"></param>
        ///// <param name="EventAbstract"></param>
        ///// <param name="ShowRoleList"></param>
        //public static void ShowRandomEventTips(int EventID, RandomEventTipsKind EventTipsKind, RandomEventTipsShowButtonKind ShowButtonKind,
        //    List<string> EventAbstracts, List<long> ShowRoleList, ButtonTextData buttonTextData,Init.EventDisposeStep StepKind = Init.EventDisposeStep.None,Init.ShowUIFormKind showEventKind = Init.ShowUIFormKind.None,object AddtionData = null)
        //{
        //    UIManager.GetIndtance().ShowUIForms("RandomEventTipsUI");
        //    EventTipsData tipsData = new EventTipsData(EventTipsKind, ShowButtonKind, EventID, EventAbstracts, ShowRoleList, buttonTextData, showEventKind, StepKind, AddtionData);
        //    MessageCenter.DisposeMessage("RandomEventTipsUI",SysDefine.SYS_MSG_KIND_ShowRandomEventTips, tipsData);
        //}

        ///// <summary>
        ///// 获得入场的角色
        ///// </summary>
        ///// <returns></returns>
        //public static List<Character> GetEnterRole()
        //{
        //    return MainManager.GetCharactersByState(Init.CharacterState.ENTER);
        //}

        ///// <summary>
        ///// 打开一个窗口
        ///// </summary>
        ///// <param name="UIName"></param>
        //public static void OpenUIForm(string UIName)
        //{
        //    UIManager.GetIndtance().ShowUIForms(UIName);
        //}

        ///// <summary>
        ///// 发送随机事件消息
        ///// </summary>
        ///// <param name="msgType"></param>
        ///// <param name="value"></param>
        ///// <param name="msgKey"></param>
        //public static void SendRandomEventMsg(string msgType, object value = null, string msgKey = SYS_MSG_NULL)
        //{
        //    if (value == null)
        //    {
        //        value = SYS_MSG_NULL;
        //    }
        //    ManagerController.Instance.MRandomEnevtManager.TriggerEventMessage(msgType, msgKey, value);
        //}
        //public static void SendRandomEventMsg(string msgType, string msgKey,object value = null)
        //{
        //    if (value == null)
        //    {
        //        value = SYS_MSG_NULL;
        //    }
        //    ManagerController.Instance.MRandomEnevtManager.TriggerEventMessage(msgType, msgKey, value);
        //}
        ///// <summary>
        ///// 显示时间奖励
        ///// </summary>
        //public static void ShowTimeGiftsUI()
        //{
        //    OpenUIForm("TimeGiftsUI");
        //    MessageCenter.DisposeMessage("TimeGiftsUI",SysDefine.SYS_MSG_KIND_ShowTimeReward);
        //}

        ///// <summary>
        ///// 通过部位名获得其它属性枚举
        ///// </summary>
        ///// <param name="bodyName"></param>
        ///// <param name="IsBlood"></param>
        ///// <returns></returns>
        //public static Init.AdditionPropertyKind GetBodyKindByName(string bodyName, bool IsBlood = false)
        //{
        //    if (IsBlood)
        //    {
        //        switch (bodyName)
        //        {
        //            case "head": { return Init.AdditionPropertyKind.Blood_Head; }
        //            case "trunk": { return Init.AdditionPropertyKind.Blood_Trunk; }
        //            case "leftArm": { return Init.AdditionPropertyKind.Blood_LeftArm; }
        //            case "rightArm": { return Init.AdditionPropertyKind.Blood_RightArm; }
        //            case "leftLeg": { return Init.AdditionPropertyKind.Blood_LeftLeg; }
        //            case "rightLeg": { return Init.AdditionPropertyKind.Blood_RightLeg; }
        //            default: { return Init.AdditionPropertyKind.ErrorKind; }
        //        }
        //    }
        //    else
        //    {
        //        switch (bodyName)
        //        {
        //            case "head": { return Init.AdditionPropertyKind.Equip_Head; }
        //            case "trunk": { return Init.AdditionPropertyKind.Equip_Trunk; }
        //            case "leftArm": { return Init.AdditionPropertyKind.Equip_LeftArm; }
        //            case "rightArm": { return Init.AdditionPropertyKind.Equip_RightArm; }
        //            case "leftLeg": { return Init.AdditionPropertyKind.Equip_LeftLeg; }
        //            case "rightLeg": { return Init.AdditionPropertyKind.Equip_RightLeg; }
        //            default: { return Init.AdditionPropertyKind.ErrorKind; }
        //        }
        //    }
        //}
        /// <summary>
        /// 换算价格
        /// </summary>
        /// <param name="Prices"></param>
        /// <returns></returns>
        public static List<int> RecalculatePrice(int Prices)
        {
            List<int> PricesList = new List<int>();
            int Gold = Prices / 10000;
            Prices -= Gold * 10000;
            int Silver = Prices / 100;
            Prices -= Silver * 100;
            int Copper = Prices;
            PricesList.Add(Gold);
            PricesList.Add(Silver);
            PricesList.Add(Copper);
            return PricesList;
        }
        /// <summary>
        /// 修改文本颜色
        /// </summary>
        /// <returns></returns>
        public static string TextChangeColor(TextColorKind colorKind,string textContent)
        {
            string NewString = "";
            switch (colorKind)
            {
                case TextColorKind.None:
                    break;
                case TextColorKind.Orange:
                    {
                        NewString = "<color=#CC991A>" + textContent + "</color>";
                    }
                    break;
                case TextColorKind.Red:
                    {
                        NewString = "<color=#CC0000>" + textContent + "</color>";
                    }
                    break;
                case TextColorKind.Green:
                    {
                        NewString = "<color=#1A991A>" + textContent + "</color>";
                    }
                    break;
                case TextColorKind.white:
                    {
                        NewString = "<color=#FFFFFF>" + textContent + "</color>";
                    }
                    break;
                case TextColorKind.HighYellow:
                    {
                        NewString = "<color=#FEDF42>" + textContent + "</color>";
                    }
                    break;
            }
            return NewString;
        }

        #endregion

        #region 委托的定义

        #endregion

        #region 消息种类常量
        //空值
        public const string SYS_MSG_NULL = "Null";
        /// <summary>
        /// 初始化场景的消息
        /// </summary>
        public const string SYS_MSG_INITSCENE = "InitScene";

        //选择提示信息框
        /// <summary>
        /// 选择提示框结果
        /// </summary>
        public const string SYS_MSG_KIND_SR = "SelectTipsResult";
        /// <summary>
        /// 显示提示框
        /// </summary>
        public const string SYS_MSG_KIND_SHOWSELECTTIPS = "ShowSelectTips";

        //资源条
        /// <summary>
        /// 是否显示资源条
        /// </summary>
        public const string SYS_MSG_KIND_SHOWRESOURCE = "IsShowResourceBar";
        /// <summary>
        /// 加载事件buffUI
        /// </summary>
        public const string SYS_MSG_KIND_LoadEventBuffUI = "LoadEventBuffUI";
        /// <summary>
        /// 显示事件buff信息
        /// </summary>
        public const string SYS_MSG_KIND_ShowEventBuffInfo = "ShowEventBuffInfo";
        /// <summary>
        /// 隐藏事件buff信息
        /// </summary>
        public const string SYS_MSG_KIND_HideEventBuffInfo = "HideEventBuffInfo";

        //显示角色属性UI
        /// <summary>
        /// 显示的角色属性UI种类
        /// </summary>
        public const string SYS_MSG_KIND_SHOWRP = "ShowRPKind";
        /// <summary>
        /// 根据索引移动到目标角色信息
        /// </summary>
        public const string SYS_MSG_KIND_MOVETOTARGET = "MoveToTargetRole";
        /// <summary>
        /// 显示附加属性信息
        /// </summary>
        public const string SYS_MSG_KIND_ShowAdditionPropertyInfo = "ShowAdditionPropertyInfo";
        /// <summary>
        /// 关闭显示附加值
        /// </summary>
        public const string SYS_MSG_KIND_CloseAdditionPropertyInfo = "CloseAdditionPropertyInfo";

        //特质
        /// <summary>
        /// 通过角色UID显示特质
        /// </summary>
        public const string SYS_MSG_KIND_SHOWTRAIT = "ShowTrait";
        /// <summary>
        /// 显示特质描述的信息框
        /// </summary>
        public const string SYS_MSG_KIND_SHOWTRAITABSTRACT = "ShowTraitAbstract";

        //消耗品
        /// <summary>
        /// 加载角色属性界面的消耗品图标
        /// </summary>
        public const string SYS_MSG_KIND_PROPERTY_CONSUMABLES_ICON = "LoadPropertyConsumableIcon";

        //技能
        /// <summary>
        /// 技能设置页面根据角色UID加载技能
        /// </summary>
        public const string SYS_MSG_KIND_LOADSKILLBYUID = "LoadSkillByRoleUID";
        /// <summary>
        /// 重置入场技能按钮边框
        /// </summary>
        public const string SYS_MSG_KIND_ResetEnterSkillBorder = "ResetEnterSkillBorder";
        /// <summary>
        /// 更新入场技能
        /// </summary>
        public const string SYS_MSG_KIND_UpdateEnterSkill = "UpdateEnterSkill";
        /// <summary>
        /// 取消技能入场
        /// </summary>
        public const string SYS_MSG_KIND_CancelEnterSkill = "CancelEnterSkill";
        /// <summary>
        /// 显示选择的技能按钮信息
        /// </summary>
        public const string SYS_MSG_KIND_ShowChoseSkillButtonInfo = "ShowChoseSkillButtonInfo";

        /// <summary>
        /// 加载训练场的信息
        /// </summary>
        public const string SYS_MSG_KIND_LoadTrainingGroundInfo = "LoadTrainingGroundInfo";
        /// <summary>
        /// 修炼场加载技能
        /// </summary>
        public const string SYS_MSG_KIND_TrainingGround_LoadSkills = "TrainingGround_LoadSkills";

        //道具
        /// <summary>
        /// 加载道具信息提示
        /// </summary>
        public const string SYS_MSG_KIND_LOADITEMINFOTIPS = "LoadItemInfoTips";
        /// <summary>
        /// 显示角色属性界面的饰品更换界面
        /// </summary>
        public const string SYS_MSG_KING_SHOWACCESSORYCHANGE = "ShowAccessoryChange";
        /// <summary>
        /// 饰品更换界面点击饰品显示饰品信息
        /// </summary>
        public const string SYS_MSG_KIND_SHOWACCESSORYINFO = "ShowAccessoryInfo";
        /// <summary>
        /// 重新加载角色属性界面的饰品信息
        /// </summary>
        public const string SYS_MSG_KIND_RELOADACCESSORYINFO = "ReLoadAccessoryInfo";

        //游戏地图
        /// <summary>
        /// 创建新地图
        /// </summary>
        public const string SYS_MSG_KIND_CREATENEWMAP = "CreateNewMap";
        /// <summary>
        /// 退出随机地图
        /// </summary>
        public const string SYS_MSG_KIND_ExitRandomMapUI = "ExitRandomMapUI";
        /// <summary>
        /// 关闭地图UI
        /// </summary>
        public const string SYS_MSG_KIND_CloseMapUI = "CloseMapUI";
        /// <summary>
        /// 显示地图UI
        /// </summary>
        public const string SYS_MSG_KIND_ShowMapUI = "ShowMapUI";
        /// <summary>
        /// 创建敌人的地图
        /// </summary>
        public const string SYS_MSG_KIND_CreateEnemyMap = "CreateEnemyMap";
        /// <summary>
        /// 隐藏敌人的队伍
        /// </summary>
        public const string SYS_MSG_KIND_HideEnemyTeam = "HideEnemyTeam";

        //地图编队
        /// <summary>
        /// 加载地图编队头像
        /// </summary>
        public const string SYS_MSG_KIND_LOADTEAMICON = "LoadTeamIcon";
        /// <summary>
        /// 显示编队角色等级提升
        /// </summary>
        public const string SYS_MSG_KIND_SHOWTEAMLVUP = "ShowTeamLvUp";
        /// <summary>
        /// 显示或者隐藏地图编队
        /// </summary>
        public const string SYS_MSG_KIND_SHOWORHIDEROLETEAM = "ShowOrHideRoleTeam";
        /// <summary>
        /// 重新显示编队信息
        /// </summary>
        public const string SYS_MSG_KIND_ReShowTeamEditInfo = "ReShowTeamEditInfo";
        /// <summary>
        /// 设置角色进入战斗编队
        /// </summary>
        public const string SYS_MSG_KIND_SetRoleEnterBattleTeam = "SetRoleEnterBattleTeam";
        /// <summary>
        /// 战斗角色下场
        /// </summary>
        public const string SYS_MSG_KIND_BattleRoleRest = "BattleRoleRest";
        /// <summary>
        /// 购买魔石
        /// </summary>
        public const string SYS_MSG_KIND_BuyJewel = "BuyJewel";


        //骰子
        /// <summary>
        /// 显示或隐藏骰子
        /// </summary>
        public const string SYS_MSG_KIND_SHOWORHIDEDICE = "ShowOrHideDice";
        /// <summary>
        /// 请求摇骰子
        /// </summary>
        public const string SYS_MSG_KIND_REQUESTROLLDICE = "RequestRollDice";
        /// <summary>
        /// 摇骰子
        /// </summary>
        public const string SYS_MSG_KIND_ROLLDICE = "RollDice";

        //玩家角色
        /// <summary>
        /// 设置玩家角色的移动步数
        /// </summary>
        public const string SYS_MSG_KIND_SETROLEMOVESTEP = "SetRoleMoveStep";
        /// <summary>
        /// 显示下一步可移动的节点
        /// </summary>
        public const string SYS_MSG_KIND_SHOWNEXTSTEP = "ShowNextStep";
        /// <summary>
        /// 角色移动
        /// </summary>
        public const string SYS_MSG_KIND_ROLEMOVE = "RoleMove";

        //事件节点
        /// <summary>
        /// 一下步的节点可被点击
        /// </summary>
        public const string SYS_MSG_KIND_NEXTSTEPNODECANCLICK = "NextStepNodeCanClick";


        //随机事件消息

        /// <summary>
        /// 获得新技能
        /// </summary>
        public const string SYS_MSG_KIND_GetNewSkillResult = "GetNewSkill";
        /// <summary>
        /// 显示事件窗口
        /// </summary>
        public const string SYS_MSG_KIND_ShowEventWindow = "ShowEventWindow";
        /// <summary>
        /// 处理事件选项
        /// </summary>
        public const string SYS_MSG_KIND_DisposeOption = "DisposeOption";
        /// <summary>
        /// 处理选择身体部位的结果
        /// </summary>
        public const string SYS_MSG_KIND_DisposeChoseBodyPart = "DisposeChoseBodyPart";
        /// <summary>
        /// 处理选择角色
        /// </summary>
        public const string SYS_MSG_KIND_DisposeChoseRole = "DisposeChoseRole";

        /// <summary>
        /// 显示随机事件提示框
        /// </summary>
        public const string SYS_MSG_KIND_ShowRandomEventTips = "ShowRandomEventTips";
        /// <summary>
        /// 处理选择角色事件
        /// </summary>
        public const string SYS_MSG_KIND_DisposeChoseRoleEvent = "DisposeChoseRoleEvent";
        /// <summary>
        /// 显示临时获得的道具的曲线移动
        /// </summary>
        public const string SYS_MSG_KIND_ShowTempItem = "ShowTempItem";
        /// <summary>
        /// 显示强化护甲的事件结果
        /// </summary>
        public const string SYS_MSG_KIND_ShowStrengthEquipResult = "ShowStrengthEquipResult";
        /// <summary>
        /// 显示获得技能描述
        /// </summary>
        public const string SYS_MSG_KIND_ShowGetSkillAbstract = "ShowGetSkillAbstract";
        /// <summary>
        /// 显示奖励信息
        /// </summary>
        public const string SYS_MSG_KIND_ShowLvUpRewardAbstract = "ShowLvUpRewardAbstract";
        /// <summary>
        /// 显示等级提升奖励的获得描述
        /// </summary>
        public const string SYS_MSG_KIND_ShowLvUpGetAbstract = "ShowLvUpGetAbstract";
        /// <summary>
        /// 添加技能升级选择的技能
        /// </summary>
        public const string SYS_MSG_KIND_AddLvUpSkill = "AddLvUpSkill";
        /// <summary>
        /// 显示等级提升奖励
        /// </summary>
        public const string SYS_MSG_KIND_ShowLvUpReward = "ShowLvUpReward";
        /// <summary>
        /// 获得新技能
        /// </summary>
        public const string SYS_MSG_KIND_GetNewSkill = "GetNewSkill";
        /// <summary>
        /// 处理获得的新技能
        /// </summary>
        public const string SYS_MSG_KING_DisposeGetNewSkill = "DisposeGetNewSkill";
        /// <summary>
        /// 处理技能升级
        /// </summary>
        public const string SYS_MSG_KIND_DisposeLvUpSkill = "DisposeLvUpSkill";
        /// <summary>
        /// 处理随机事件
        /// </summary>
        public const string SYS_MSG_KIND_DisposeEvent = "DisposeEvent";
        /// <summary>
        /// 处理路过事件
        /// </summary>
        public const string SYS_MSG_KIND_DisposePassRoadEvent = "DisposePassRoadEvent";
        /// <summary>
        /// 显示骰子和编队
        /// </summary>
        public const string SYS_MSG_KIND_ShowDiceAndRoleTeam = "ShowDiceAndRoleTeam";

        /// <summary>
        /// 显示事件UI的种类
        /// </summary>
        public const string SYS_MSG_KIND_ShowEventUIKind = "ShowEventUIKind";
        /// <summary>
        /// 处理事件结果
        /// </summary>
        public const string SYS_MSG_KIND_DisposeEventResult = "DisposeEventResult";
        /// <summary>
        /// 显示事件结果
        /// </summary>
        public const string SYS_MSG_KIND_ShowEventResult = "ShowEventResult";
        /// <summary>
        /// 显示路过事件处理结果
        /// </summary>
        public const string SYS_MSG_KIND_ShowPassRoadResult = "ShowPassRoadResult";
        /// <summary>
        /// 显示新的可移动的路
        /// </summary>
        public const string SYS_MSG_KIND_ShowNewStepRoad = "ShowNewStepRoad ";

        /// <summary>
        /// 地图获得的道具背包
        /// </summary>
        public const string SYS_MSG_KIND_ShowGetItemBox = "ShowGetItemBox";

        /// <summary>
        /// 重置自动售卖机
        /// </summary>
        public const string SYS_MSG_KIND_ResetAutoSellEvent = "ResetAutoSellEvent";
        /// <summary>
        /// 显示自动售卖的结果
        /// </summary>
        public const string SYS_MSG_KIND_ShowAutoSellResult = "ShowAutoSellResult";
        /// <summary>
        /// 自动售卖机购买道具
        /// </summary>
        public const string SYS_MSG_KIND_AutoSellBuyItem = "AutoSellBuyItem";

        /// <summary>
        /// 重置获得钱袋事件
        /// </summary>
        public const string SYS_MSG_KIND_ResetGetWalletEvent = "ResetGetWalletEvent";
        /// <summary>
        /// 显示获得钱袋事件的结果
        /// </summary>
        public const string SYS_MSG_KIND_ShowGetWalletEventResult = "ShowGetWalletEventResult";
        /// <summary>
        /// 打开获得的钱袋
        /// </summary>
        public const string SYS_MSG_KIND_OpenGetWallet = "OpenGetWallet";

        /// <summary>
        /// 救援事件
        /// </summary>
        public const string SYS_MSG_KIND_SavePersonEvent = "SavePersonEvent";

        /// <summary>
        /// 开始事件
        /// </summary>
        public const string SYS_MSG_KIND_StartEvent = "StartEvent";
        /// <summary>
        /// 双选
        /// </summary>
        public const string SYS_MSG_KIND_TwoChoiceEvent = "TwoChoiceEvent";


        /// <summary>
        /// 符文事件
        /// </summary>
        public const string SYS_MSG_KIND_RuneEvent = "RuneEvent";
        /// <summary>
        /// 随机扣除、增加某个部位的血量最大值
        /// </summary>
        public const string SYS_MSG_KIND_RandomBodyPartMaxHpEvent = "RandomBodyPartMaxHpEvent";
        /// <summary>
        /// 选择部位扣除、增加血量最大值
        /// </summary>
        public const string SYS_MSG_KIND_ChoseBodyPartMaxHpEvent = "ChoseBodyPartMaxHpEvent";

        /// <summary>
        /// 重置魔法阵事件
        /// </summary>
        public const string SYS_MSG_KIND_ResetMagicCircleEvent = "ResetMagicCircleEvent";
        /// <summary>
        /// 显示魔法阵事件的结果
        /// </summary>
        public const string SYS_MSG_KIND_ShowMagicCircleEventResult = "ShowMagicCircleEventResult";
        /// <summary>
        /// 激活魔法阵
        /// </summary>
        public const string SYS_MSG_KIND_ActiveMagicCircle = "ActiveMagicCircle";

        /// <summary>
        /// 重置通用事件提示框
        /// </summary>
        public const string SYS_MSG_KIND_ResetGlobalEventTipsUI = "ResetGlobalEventTipsUI";

        /// <summary>
        /// 传送事件
        /// </summary>
        public const string SYS_MSG_KIND_TransferEvent = "TransferEvent";

        /// <summary>
        /// 处理随机事件获得技能
        /// </summary>
        public const string SYS_MSG_KIND_DisposeRandomGetSkill = "DisposeRandomGetSkill";
        /// <summary>
        /// 获得技能的结果
        /// </summary>
        public const string SYS_MSG_KIND_GetSkillResult = "GetSkillResult";
        /// <summary>
        /// 获得通用结果
        /// </summary>
        public const string SYS_MSG_KIND_GetGlobalResult = "GetGlobalResult";
        /// <summary>
        /// 显示迷你魔法书
        /// </summary>
        public const string SYS_MSG_KIND_ShowMiniMagicTips = "ShowMiniMagicTips";
        /// <summary>
        /// 重置选择身体提示UI
        /// </summary>
        public const string SYS_MSG_KIND_ResetChoseBodyTipsUI = "ResetChoseBodyTipsUI";
        /// <summary>
        /// 重置选择护甲提示UI
        /// </summary>
        public const string SYS_MSG_KIND_ResetChoseEquipTipsUI = "ResetChoseEquipTipsUI";
        /// <summary>
        /// 处理Hp最大值选择角色结果
        /// </summary>
        public const string SYS_MSG_KIND_DisposeMaxHpChoseRoleResult = "DisposeMaxHpChoseRoleResult";
        /// <summary>
        /// 处理Hp最大值选择部位的结果
        /// </summary>
        public const string SYS_MSG_KIND_DisposeMaxHpChoseBodyPartResult = "DisposeMaxHpChoseBodyPartResult";
        /// <summary>
        /// 处理Hp最大值结果
        /// </summary>
        public const string SYS_MSG_KIND_DisposeMaxHpResult = "DisposeMaxHpResult";
        /// <summary>
        /// 跳转游戏地图场景
        /// </summary>
        public const string SYS_MSG_KIND_GotoGameMapScene = "GotoGameMapScene";
        /// <summary>
        /// 显示时间奖励
        /// </summary>
        public const string SYS_MSG_KIND_ShowTimeReward = "ShowTimeReward";
        /// <summary>
        /// 设置道具标签页的可点击状态
        /// </summary>
        public const string SYS_MSG_KIND_SetItemToggleEnable = "SetItemToggleEnable";
        /// <summary>
        /// 更新出售的价格
        /// </summary>
        public const string SYS_MSG_KIND_UpdateSellPrices = "UpdateSellPrices";
        /// <summary>
        /// 刷新技能信息
        /// </summary>
        public const string SYS_MSG_KIND_TraingGround_RefreshSkillInfo = "TraingGround_RefreshSkillInfo";
        /// <summary>
        /// 修炼场初始化技能信息
        /// </summary>
        public const string SYS_MSG_KIND_TrainingGround_InitSkillBoxInfo = "TrainingGround_InitSkillBoxInfo ";
        /// <summary>
        /// 加载商店商品
        /// </summary>
        public const string SYS_MSG_KIND_LoadShopGoods = "LoadShopGoods";
        /// <summary>
        /// 显示商店商品信息
        /// </summary>
        public const string SYS_MSG_KIND_ShowShopGoodInfo = "ShowShopGoodInfo";
        /// <summary>
        /// 更新商店的商品
        /// </summary>
        public const string SYS_MSG_KIND_UpdateShopGoods = "UpdateShopGoods";
        /// <summary>
        /// 设置商店道具是否可以点击
        /// </summary>
        public const string SYS_MSG_KIND_SetShopGoodCanClick = "SetShopGoodCanClick";

        /// <summary>
        /// 出售可叠加的道具Id
        /// </summary>
        public const string SYS_MSG_KIND_SellOverLayerItemId = "SellOverLayerItemId";
        /// <summary>
        /// 重新刷新仓库的道具数据
        /// </summary>
        public const string SYS_MSG_KIND_ReFreshWarehouse = "ReFreshWarehouse";

        /// <summary>
        /// 酒馆重新加载碎片
        /// </summary>
        public const string SYS_MSG_KIND_ReLoadRoleChips = "ReLoadRoleChips";
        /// <summary>
        /// 酒馆重新加载角色
        /// </summary>
        public const string SYS_MSG_KIND_ReLoadRole = "ReLoadRole";
        /// <summary>
        /// 刷新可招募的角色
        /// </summary>
        public const string SYS_MSG_KIND_RefreshRecruitRole = "RefreshRecruitRole";
        /// <summary>
        /// 祭坛加载死亡角色
        /// </summary>
        public const string SYS_MSG_KIND_LoadDeadRole = "LoadDeadRole";
        /// <summary>
        /// 改变死亡角色的UI
        /// </summary>
        public const string SYS_MSG_KIND_ChangeDeadRoleUI = "ChangeDeadRoleUI";
        /// <summary>
        /// 定位目标UI
        /// </summary>
        public const string SYS_MSG_KIND_TargetDeadRoleUI = "TargetDeadRoleUI";
        /// <summary>
        /// 更新死亡角色的UI
        /// </summary>
        public const string SYS_MSG_KIND_UpdateDeadRoleUI = "UpdateDeadRoleUI";
        /// <summary>
        /// 隐藏复活按钮
        /// </summary>
        public const string SYS_MSG_KIND_HideRecoverButton = "HideRecoverButton";
        /// <summary>
        /// 花费金币复活角色
        /// </summary>
        public const string SYS_MSG_KIND_RecoverRoleByGold = "RecoverRoleByGold";
        /// <summary>
        /// 花费金币召回角色
        /// </summary>
        public const string SYS_MSG_KIND_ReviveFullRoleByGold = "ReviveFullRoleByGold";
        /// <summary>
        /// 设置其它死亡角色UI不能点击
        /// </summary>
        public const string SYS_MSG_KIND_SetOtherDeadRoleUnEnable = "SetOtherDeadRoleUnEnable";
        /// <summary>
        /// 初始化出征界面
        /// </summary>
        public const string SYS_MSG_KIND_InitGameAdventure = "InitGameAdventure";
        /// <summary>
        /// 初始化区域信息
        /// </summary>
        public const string SYS_MSG_KIND_InitAreaInfo = "InitAreaInfo";
        /// <summary>
        /// 从可招募列表中移除已经拥有的角色
        /// </summary>
        public const string SYS_MSG_KIND_RemoveHaveRole = "RemoveHaveRole";
        /// <summary>
        /// 更新事件选择的角色UID
        /// </summary>
        public const string SYS_MSG_KIND_UpdateNewChoseUID = "UpdateNewChoseUID";
        /// <summary>
        /// 刷新任务
        /// </summary>
        public const string SYS_MSG_KIND_RefreshMission = "RefreshMission";
        /// <summary>
        /// 处理任务
        /// </summary>
        public const string SYS_MSG_KIND_DisposeMission = "DisposeMission ";
        /// <summary>
        /// 显示任务内容
        /// </summary>
        public const string SYS_MSG_KIND_ShowMissionTask = "ShowMissionTask";
        /// <summary>
        /// 显示任务提示
        /// </summary>
        public const string SYS_MSG_KIND_ShowMissionTips = "ShowMissionTips";
        /// <summary>
        /// 显示最终奖励结算
        /// </summary>
        public const string SYS_MSG_KIND_ShowFinalReward = "ShowFinalReward";
        /// <summary>
        /// 显示警告条
        /// </summary>
        public const string SYS_MSG_KIND_ShowWarning = "ShowWarning";
        /// <summary>
        /// 显示获得特质信息UI
        /// </summary>
        public const string SYS_MSG_KIND_ShowGetTraitInfoUI = "ShowGetTraitInfoUI";
        /// <summary>
        /// 显示属性信息提示
        /// </summary>
        public const string SYS_MSG_KIND_ShowPropertyInfoTips = "ShowPropertyInfoTips";
        /// <summary>
        /// 隐藏属性信息提示
        /// </summary>
        public const string SYS_MSG_KIND_HidePropertyInfoTips = "HidePropertyInfoTips";

        /// <summary>
        /// 刷新角色消耗品UI
        /// </summary>
        public const string SYS_MSG_KIND_RefreshRoleConsumableBoxUI = "RefreshRolePropertyInfo";

        /// <summary>
        /// 重置角色消耗品边框UI
        /// </summary>
        public const string SYS_MSG_KIND_ReSetRoleConsumableBoxUI = "ReSetRoleConsumableBoxUI";

        /// <summary>
        /// 重置所有角色消耗栏边框UI
        /// </summary>
        public const string SYS_MSG_KIND_ReSetAllRoleConsumableBoxUI = "ReSetAllRoleConsumableBoxUI";

        /// <summary>
        /// 重置角色饰品边框UI
        /// </summary>
        public const string SYS_MSG_KIND_ReSetRoleAccessoryBoxUI = "ReSetRoleAccessoryBoxUI";

        /// <summary>
        /// 重置所有角色饰品栏边框UI
        /// </summary>
        public const string SYS_MSG_KIND_ReSetAllRoleAccessoryBoxUI = "ReSetAllRoleAccessoryBoxUI";

        /// <summary>
        /// 重置所有技能
        /// </summary>
        public const string SYS_MSG_KIND_ResetAllSkills = "ResetAllSkills";
        /// <summary>
        /// 重置技能并获得新技能
        /// </summary>
        public const string SYS_MSG_KIND_ResetSkillGetNewSkills = "ResetSkillGetNewSkills";
        /// <summary>
        /// 加载临时奖励的道具
        /// </summary>
        public const string SYS_MSG_KIND_LoadTempRewardItem = "LoadTempRewardItem";

        /// <summary>
        /// 加载改变消耗品的仓库
        /// </summary>
        public const string SYS_MSG_KIND_LoadChangeConsumableBox = "LoadChangeConsumableBox";
        /// <summary>
        /// 加载改变饰品的仓库
        /// </summary>
        public const string SYS_MSG_KIND_LoadChangeAccessoryBox = "LoadChangeAccessoryBox";
        /// <summary>
        /// 加载竞技场
        /// </summary>
        public const string SYS_MSG_KIND_LoadArena = "LoadArena";


        //小游戏相关消息
        /// <summary>
        /// 创建华容道游戏
        /// </summary>
        public const string SYS_MSG_KlotskiGame_Create = "KlotskiGame_Create";

        /// <summary>
        /// 创建画线游戏
        /// </summary>
        public const string SYS_MSG_DrawLine_Create = "DrawLine_Create";
        /// <summary>
        /// 重新加载
        /// </summary>
        public const string SYS_MSG_DrawLine_ReLoad = "DrawLine_ReLoad";

        /// <summary>
        /// 创建组合游戏
        /// </summary>
        public const string SYS_MSG_ArrayGame_Create = "ArrayGame_Create";

        /// <summary>
        /// 创建转轮游戏
        /// </summary>
        public const string SYS_MSG_TurnplateGame_Create = "TurnplateGame_Create";
        #endregion

        #region 消息传值的Key值常量
        //选择提示信息框Key值
        /// <summary>
        /// 招募角色结果
        /// </summary>
        public const string SYS_MSG_KEY_RECRUIT = "RecruitResult";


        //资源条Key值
        /// <summary>
        /// 出征按钮
        /// </summary>
        public const string SYS_MSG_KEY_ADVBUTTON = "AdvButton";
        /// <summary>
        /// 资源条
        /// </summary>
        public const string SYS_MSG_KEY_RESOURCEBAR = "ResourceBar";
        /// <summary>
        /// 酒馆的角色
        /// </summary>
        public const string SYS_MSG_KEY_TAVERNROLE = "TavernRole";

        /// <summary>
        /// 获得技能的key
        /// </summary>
        public const string SYS_MSG_KEY_GlobalGetSkill = "GlobalGetSkill";

        /// <summary>
        /// 获得货币的key
        /// </summary>
        public const string SYS_MSG_KEY_GlobalGetCoin = "GlobalGetCoin";

        /// <summary>
        /// Hp最大值事件的key
        /// </summary>
        public const string SYS_MSG_KIND_GetGlobalMaxHpEvent = "SYS_MSG_KIND_GetGlobalMaxHpEvent";
        #endregion

        #region 全局静态变量
        /// <summary>
        /// 当前显示的角色属性窗口索引
        /// </summary>
        public static int STA_ShowRolePropertyIndex = 0;
        /// <summary>
        /// 角色属性窗口最大的索引值
        /// </summary>
        public static int STA_MaxRolePropertyIndex = 0;
        /// <summary>
        /// 当前要显示的角色的属性的编队种类
        /// </summary>
        public static ShowRolePropertyKind STA_RolePropertyKind = ShowRolePropertyKind.AllRole;

        /// <summary>
        /// ========测试用事件ID========
        /// 当该值不为0时，必定触发该事件
        /// </summary>
        public static int TriggerEventId = 0;

        #endregion

    }

    public static class Globe
    {
        /// <summary>
        /// 下一个场景名
        /// </summary>
        public static string nextSceneName;
        /// <summary>
        /// 加载的场景种类
        /// </summary>
        //public static LoadingKind LoadingSceneKind;
        /// <summary>
        /// 是否显示任务
        /// </summary>
        public static bool IsShowMission;
        /// <summary>
        /// UI根节点
        /// </summary>
        public static GameObject RootCanvas;
        /// <summary>
        /// 普通UI节点
        /// </summary>
        public static GameObject NormalRoot;
        /// <summary>
        /// 固定UI节点
        /// </summary>
        public static GameObject FixedRoot;
        /// <summary>
        /// 弹窗UI节点
        /// </summary>
        public static GameObject PopUpRoot;

        public static void SetRootCanvas()
        {
            if (RootCanvas == null)
            {
                RootCanvas = GameObject.FindGameObjectWithTag(SysDefine.SYS_TAG_CANVAS);
                NormalRoot = UnityHelper.FindTheChildNode(RootCanvas, "Normal").gameObject;
                FixedRoot = UnityHelper.FindTheChildNode(RootCanvas, "Fixed").gameObject;
                PopUpRoot = UnityHelper.FindTheChildNode(RootCanvas, "PopUp").gameObject;
            }
        }
        /// <summary>
        /// 只显示弹窗UI
        /// </summary>
        public static void OnlyShowPopUpRoot()
        {
            if (RootCanvas != null)
            {
                RootCanvas.SetActive(true);
                NormalRoot.SetActive(false);
                FixedRoot.SetActive(false);
            }
        }
        /// <summary>
        /// 显示全部UI
        /// </summary>
        public static void ShowAllUI()
        {
            if (RootCanvas != null)
            {
                RootCanvas.SetActive(true);
                NormalRoot.SetActive(true);
                FixedRoot.SetActive(true);
                PopUpRoot.SetActive(true);
            }
        }
        /// <summary>
        /// 异步加载场景
        /// </summary>
        /// <param name="sceneName">场景名字</param>
        /// <param name="isAsync">是否使用异步加载</param>
        public static void LodingScene(string sceneName, bool isAsync = true)
        {
            //清理Unity垃圾
            Resources.UnloadUnusedAssets();
            //清理GC垃圾
            System.GC.Collect();
            //是否使用异步加载
            if (isAsync)
            {
                //赋值加载场景名称
                nextSceneName = sceneName;
                //跳转到LoadingScene场景
                SceneManager.LoadScene("LoadingScene");
            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        /// <summary>
        /// 异步加载场景
        /// </summary>
        /// <param name="sceneName">场景名字</param>
        /// <param name="isAsync">是否使用异步加载</param>
        public static void LodingAsyncSceneShowInfo(string sceneName)
        {
            //清理Unity垃圾
            Resources.UnloadUnusedAssets();
            //清理GC垃圾
            System.GC.Collect();
            //赋值加载场景名称
            nextSceneName = sceneName;
            //跳转到LoadingScene场景
            SceneManager.LoadScene("LoadingScene");

        }
    }
}

#region 关卡数据
/// <summary>
/// 关卡场景数据
/// </summary>
public static class GameSceneData
{
    /// <summary>
    /// 获得游戏场景管理器
    /// </summary>
    //public static GameSceneManager m_GameSceneManager { get { return ManagerController.Instance.MGameSceneManager; } }

    ///// <summary>
    ///// 普通战斗获得的经验
    ///// </summary>
    //public static int NormalExp { get { return GameSceneManager.NormalExp; } }
    ///// <summary>
    ///// 困难战斗获得的经验
    ///// </summary>
    //public static int HardExp{ get { return GameSceneManager.HardExp; } }
    ///// <summary>
    ///// 出现Boss的最大计数上限
    ///// </summary>
    //public static int ShowBossBattleCount { get { return GameSceneManager.ShowBossBattleCount; } }

    ///// <summary>
    ///// 是否是第一次摇骰子
    ///// </summary>
    //public static bool IsFirstRollDice
    //{
    //    set { m_GameSceneManager.UpdateIsFirstRollDice(value); }
    //    get { return m_GameSceneManager.IsFirstRollDice; }
    //}
    ///// <summary>
    ///// 是否开始了冒险
    ///// </summary>
    //public static bool IsStartAdventure
    //{
    //    set { m_GameSceneManager.UpdateIsStartAdventure(value); }
    //    get { return m_GameSceneManager.IsStartAdventure; }
    //}
    ///// <summary>
    ///// 是否加载了游戏存档
    ///// </summary>
    //public static bool IsLoadedGameArchives
    //{
    //    set { m_GameSceneManager.UpdateIsLoadedGameArchives(value); }
    //    get { return m_GameSceneManager.IsLoadedGameArchives; }
    //}
    ///// <summary>
    ///// 是否是Boss战
    ///// </summary>
    //public static bool IsBossBattle
    //{
    //    set { m_GameSceneManager.UpdateIsBossBattle(value); }
    //    get { return m_GameSceneManager.IsBossBattle; }
    //}
    ///// <summary>
    ///// 是否最终Boss战
    ///// </summary>
    //public static bool IsBattleFinalBoss
    //{
    //    set { m_GameSceneManager.UpdateIsBattleFinalBoss(value); }
    //    get { return m_GameSceneManager.IsBattleFinalBoss; }
    //}
    ///// <summary>
    ///// 是否是赏金任务目标
    ///// </summary>
    //public static bool IsRewardMissionTarget
    //{
    //    set { m_GameSceneManager.UpdateIsRewardMissionTarget(value); }
    //    get { return m_GameSceneManager.IsRewardMissionTarget; }
    //}
    ///// <summary>
    ///// 是否开始战斗
    ///// </summary>
    //public static bool IsStartBattle
    //{
    //    set { m_GameSceneManager.UpdateIsStartBattle(value); }
    //    get { return m_GameSceneManager.IsStartBattle; }
    //}
    ///// <summary>
    ///// 当前任务的种类
    ///// </summary>
    //public static Init.MissionKind CurrentMissionKind
    //{
    //    set { m_GameSceneManager.UpdateCurrentMissionKind(value); }
    //    get { return m_GameSceneManager.CurrentMissionKind; }
    //}
    ///// <summary>
    ///// 玩家选择的游戏关卡
    ///// </summary>
    //public static Init.GameSceneKind GameSceneKind
    //{
    //    set { m_GameSceneManager.SetGameSceneKind(value); }
    //    get { return m_GameSceneManager.GameScene; }
    //}
    ///// <summary>
    ///// 玩家选择的难度
    ///// </summary>
    //public static Init.GameSceneLv SceneLv
    //{
    //    set { m_GameSceneManager.SetGameSceneLv(value); }
    //    get { return m_GameSceneManager.SceneLv; }
    //}
    ///// <summary>
    ///// 随机事件战斗角色对象种类
    ///// </summary>
    //public static Init.EnemyStrengthKind StrengthKind
    //{
    //    set { m_GameSceneManager.SetEnemyStrengthKind(value); }
    //    get { return m_GameSceneManager.StrengthKind; }
    //}
    ///// <summary>
    ///// 战斗状态种类（区分通常战斗与竞技场）
    ///// </summary>
    //public static Init.BattleStateKind BattleStateKind
    //{
    //    set { m_GameSceneManager.UpdateBattleStateKind(value); }
    //    get { return m_GameSceneManager.BattleStateKind; }
    //}
    ///// <summary>
    ///// 遇到的敌人ID列表
    ///// </summary>
    //public static List<int> MeetEnemyIdList
    //{
    //    get { return m_GameSceneManager.MeetEnemyIdList; }
    //}
    ///// <summary>
    ///// 全部角色的CID列表
    ///// </summary>
    //public static List<int> AllRoleCIDList
    //{
    //    get { return m_GameSceneManager.AllRoleCIDList; }
    //}
    ///// <summary>
    ///// 可招募的角色列表
    ///// </summary>
    //public static List<int> RecruitRoleList
    //{
    //    get { return m_GameSceneManager.RecruitRoleList; }
    //}
    ///// <summary>
    ///// 添加已经遇到的敌人
    ///// </summary>
    ///// <returns></returns>
    //public static void AddHaveMeetEnemy(int CID)
    //{
    //    m_GameSceneManager.AddHaveMeetEnemy(CID);
    //}
    ///// <summary>
    ///// 是否已经遇到过该敌人
    ///// </summary>
    ///// <param name="CID"></param>
    ///// <returns></returns>
    //public static bool IsHaveMeetEnemy(int CID)
    //{
    //    return m_GameSceneManager.IsHaveMeetEnemy(CID);
    //}
    ///// <summary>
    ///// 是否可以进入地图场景
    ///// </summary>
    ///// <param name="sceneType"></param>
    ///// <returns></returns>
    //public static bool IsCanEnterMapScene(Init.MapSceneType sceneType)
    //{
    //    return m_GameSceneManager.IsCanEnterMapScene(sceneType);
    //}
    ///// <summary>
    ///// 尝试激活新的地图场景
    ///// </summary>
    //public static void ActiveNewMapScene(Init.MapSceneType sceneType)
    //{
    //    m_GameSceneManager.ActiveNewMapScene(sceneType);
    //}

    ///// <summary>
    ///// 获得地图场景种类
    ///// </summary>
    ///// <param name="sceneKind"></param>
    ///// <param name="sceneLv"></param>
    ///// <returns></returns>
    //public static Init.MapSceneType GetMapSceneType(Init.GameSceneKind sceneKind,Init.GameSceneLv sceneLv)
    //{
    //    Init.MapSceneType mapSceneType = Init.MapSceneType.None;
    //    switch (sceneKind)
    //    {
    //        case Init.GameSceneKind.All:
    //            break;
    //        case Init.GameSceneKind.ForestEdge:
    //            {
    //                if (sceneLv == Init.GameSceneLv.GameSceneLv_Normal || sceneLv == Init.GameSceneLv.GameSceneLv_NormalBoss)
    //                {
    //                    mapSceneType = Init.MapSceneType.ForestEdge_Normal;
    //                }
    //                else if(sceneLv == Init.GameSceneLv.GameSceneLv_Hard || sceneLv == Init.GameSceneLv.GameSceneLv_HardBoss)
    //                {
    //                    mapSceneType = Init.MapSceneType.ForestEdge_Hard;
    //                }
    //            }
    //            break;
    //        case Init.GameSceneKind.DeepForest:
    //            {
    //                if (sceneLv == Init.GameSceneLv.GameSceneLv_Normal || sceneLv == Init.GameSceneLv.GameSceneLv_NormalBoss)
    //                {
    //                    mapSceneType = Init.MapSceneType.DeepForest_Normal;
    //                }
    //                else if (sceneLv == Init.GameSceneLv.GameSceneLv_Hard || sceneLv == Init.GameSceneLv.GameSceneLv_HardBoss)
    //                {
    //                    mapSceneType = Init.MapSceneType.DeepForest_Hard;
    //                }
    //            }
    //            break;
    //        case Init.GameSceneKind.TheLostRuins:
    //            {
    //                if (sceneLv == Init.GameSceneLv.GameSceneLv_Normal || sceneLv == Init.GameSceneLv.GameSceneLv_NormalBoss)
    //                {
    //                    mapSceneType = Init.MapSceneType.TheLostRuins_Normal;
    //                }
    //                else if (sceneLv == Init.GameSceneLv.GameSceneLv_Hard || sceneLv == Init.GameSceneLv.GameSceneLv_HardBoss)
    //                {
    //                    mapSceneType = Init.MapSceneType.TheLostRuins_Hard;
    //                }
    //            }
    //            break;
    //        case Init.GameSceneKind.Nerersun:
    //            {
    //                if (sceneLv == Init.GameSceneLv.GameSceneLv_Normal || sceneLv == Init.GameSceneLv.GameSceneLv_NormalBoss)
    //                {
    //                    mapSceneType = Init.MapSceneType.Nerersun_Normal;
    //                }
    //                else if (sceneLv == Init.GameSceneLv.GameSceneLv_Hard || sceneLv == Init.GameSceneLv.GameSceneLv_HardBoss)
    //                {
    //                    mapSceneType = Init.MapSceneType.Nerersun_Hard;
    //                }
    //            }
    //            break;
    //    }
    //    return mapSceneType;
    //}
}
#endregion