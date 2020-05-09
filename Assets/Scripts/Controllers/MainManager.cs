//using Buff;
using Managers;
using Models;
using DataTable;
using System.Collections.Generic;
using UIFORM;
using System;
/// <summary>
/// 这个类考虑全部使用静态方法调用Manager各类
/// </summary>
public static class MainManager {

    public static bool IsLoadGameScene;

    /// <summary>
    /// 数据初始化 
    /// </summary>
    public static void InitManager() {
        // 防止重复加载
        if (ManagerController.Instance.IsInit) {
            return;
        }

        ManagerController.Instance.Initialize();


        //CreateItem(1001,100000);
    }
    /*----------------------------------------------------------------------------*/
    // 角色相关数据的查询

    // DataManager
    /// <summary>
    /// 查询我方全员队伍中队员数据
    /// </summary>
    /// <returns>The all character.</returns>
    public static List<Character> GetAllCharacter() {
        return ManagerController.Instance.MCGetCharactersByCamp(Init.CharacterCamp.CAMP_HERO);
    }
    /// <summary>
    /// 查询我方队员的数据
    /// </summary>
    /// <returns>The hero character.</returns>
    /// <param name="uid">Uid.</param>

    public static Character GetHeroCharacter(long uid) {
        return ManagerController.Instance.MCGetCharacaterByUID(uid);
    }

    public static List<CharacterSave> MainGetAllCharacterSaves() {
        return ManagerController.Instance.MCGetAllCharacterSaves();
    }

    public static List<CharacterSave> MainGetCharacterSavesByCamp(Init.CharacterCamp characterCamp, Init.CharacterState characterState) {
        return ManagerController.Instance.MCGetAllCharacterSavesByCamp(characterCamp, characterState);
    }
    public static List<CharacterSave> MainGetCharacterSavesByCamp(CharacterSave characterSave, bool includeMySelf)
    {
        return ManagerController.Instance.MCGetCharacterSavesByCamp(characterSave, includeMySelf);
    }

    public static List<CharacterSave> MainGetCharacterSavesByCampAllEnterInThisGame(CharacterSave characterSave, bool includeMySelf) {
        return ManagerController.Instance.MCGetCharacterSavesByCampAllEnterInThisGame(characterSave, includeMySelf);
    }



    /// <summary>
    /// 根据队员的状态查询列表
    /// 英雄战队
    /// </summary>
    /// <returns>The characters by state.</returns>
    /// <param name="state">Init.CharacterState.</param>
    public static List<Character> GetCharactersByState(Init.CharacterState state) {
        return ManagerController.Instance.MCGetHeroCharactersByState(state);
    }

    /// <summary>
    /// 查询敌人战斗队伍中的全部队员
    /// </summary>
    /// <returns>The combat list.</returns>
    public static List<Character> GetEnemyList()
    {
        return ManagerController.Instance.MCGetCharactersByCamp(Init.CharacterCamp.CAMP_ENEMY);
    }
    /// <summary>
    /// 查询敌方阵营队员的数据
    /// </summary>
    /// <returns>The enemy character.</returns>
    /// <param name="uid">Uid.</param>
    public static Character GetEnemyCharacter(long uid)
    {
        return ManagerController.Instance.MCGetCharacaterByUID(uid);
    }

    public static CharacterSave MainGetPetCharacterSaveByMasterID(long characterUID) {
        return ManagerController.Instance.MCGetPetCharacterSaveByMasterID(characterUID);
    }

    /*-----------------------------------------------------------------------------------------------------------------------------*/

    /// <summary>
    /// 修改角色站位
    /// </summary>
    /// <param name="cs"></param>
    /// <param name="combatPosition"></param>
    public static Init.CombatPosition SetCharacterPosition(CharacterSave cs, Init.CombatPosition combatPosition)
    {
        return ManagerController.Instance.MCSetCharacterPosition(cs, combatPosition);
    }
    /// <summary>
    /// 修改角色站位
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="combatPosition"></param>
    public static Init.CombatPosition SetCharacterPosition(long uid, Init.CombatPosition combatPosition) {
        CharacterSave cs = GetCharacterSaveByUID(uid);
        if (cs != null) {
            return ManagerController.Instance.MCSetCharacterPosition(cs, combatPosition);
        }
        return Init.CombatPosition.NONE;
    }

    /*-----------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    /// 查询所有队伍中的队员数据
    /// </summary>
    /// <returns>The character by identifier.</returns>
    /// <param name="uid">uid.</param>
    public static Character GetCharacterById(long uid) {
        return ManagerController.Instance.MCGetCharacaterByUID(uid);
    }

    /// <summary>
    /// 查询该技能的动画类型
    /// </summary>
    /// <returns>The skill animation type.</returns>
    /// <param name="skillID">Skill identifier.</param>
    public static bfqTools.SkillAnimType GetSkillAnimationType(int skillID)
    {
        return bfqTools.SkillAnimController.GetSkillAnimationType(skillID);
    }

    /*-----------------------------------------------------------------------------------------------------------------------------*/
    // 查询数据表基础数据

    /// <summary>
    /// 根据技能ID查询 技能数据表基础数据
    /// </summary>
    /// <returns>The skill table by skill identifier.</returns>
    /// <param name="skillID">Skill identifier.</param>
    public static SkillBasicsDataTable GetSkillBasicsDataTable(int skillID) {
        return ManagerController.Instance.MDataTableManager.GetSkillBasicsDataTable(skillID);
    }

    // cjl test
    /// <summary>
    /// 查询角色当前技能等级的数据
    /// </summary>
    /// <returns>The skill level data table.</returns>
    /// <param name="CharacterUID">Character uid.</param>
    /// <param name="skillid">Skillid.</param>
    public static SkillLevelDataTable MainGetSkillLevelDataTable(long CharacterUID, int skillid) {
        CharacterSave characterSave = GetCharacterSaveByUID(CharacterUID);
        return MainGetSkillLevelDataTableByLevel(skillid, characterSave.GetSkillLevel(skillid));
    }

    public static SkillDescribeDataTable MainGetSkillDescribeDataTable(int SkillID) {
        return ManagerController.Instance.MCGetSkillDescribeDataTable(SkillID);
    }

    public static SkillLevelDataTable MainGetSkillLevelDataTableByLevel(int skillid, int lv) {
        return ManagerController.Instance.MCGetSkillLevelDataTableByLevel(skillid, lv);
    }

    /// <summary>
    /// 查询角色的一级属性
    /// </summary>
    /// <returns>The main property.</returns>
    /// <param name="CharacterUID">Character uid.</param>
    public static MainProperty MainGetMainProperty(long CharacterUID)
    {
        return ManagerController.Instance.MCGetMainProperty(CharacterUID);
    }

    /// <summary>
    /// 查询该角色的普通攻击的技能ID
    /// </summary>
    /// <returns>The character common skill.</returns>
    /// <param name="cid">Cid.</param>
    public static int GetCharacterCommonSkill(int cid)
    {
        return ManagerController.Instance.MDataTableManager.GetCharacterCommonSkill(cid);
    }
    /// <summary>
    /// 角色部位最大护甲值
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="bodyPartName"></param>
    /// <returns></returns>
    public static float MainGetCharacterBodyPartMaxEquipBlood(long uid, string bodyPartName) {
        return ManagerController.Instance.MCGetCharacterBodyPartMaxEquipBlood(uid, bodyPartName);
    }
    /// <summary>
    /// 角色部位最大血量
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="bodyPartName"></param>
    /// <returns></returns>
    public static float MainGetCharacterBodyPartMaxBlood(long uid, string bodyPartName) {
        return ManagerController.Instance.MCGetCharacterBodyPartMaxBlood(uid, bodyPartName);
    }

    /*-----------------------------------------------------------------------------------------------------------------------------*/
    //  查询角色存档相关数据

    /// <summary>
    /// 根据角色UID查询存档数据
    /// </summary>
    /// <returns>The character save by uid.</returns>
    /// <param name="CharacterUID">Character uid.</param>
    public static CharacterSave GetCharacterSaveByUID(long CharacterUID)
    {
        return ManagerController.Instance.MCGetCharacterSaveByUID(CharacterUID);
    }



    /// <summary>
    /// 根据阵营类型查询该阵营的角色UID数组
    /// </summary>
    /// <returns>The character save by camp.</returns>
    /// <param name="camp">Camp.</param>
    public static List<long> GetCharacterSaveByCamp(Init.CharacterCamp camp) {
        return ManagerController.Instance.MCGetCharacterSaveUIDsByCamp(camp);
    }

    /// <summary>
    /// 查询当前存档中的我方全部角色数据
    /// </summary>
    /// <returns>The characters.</returns>
    public static List<CharacterSave> GetHeroCharacters() {
        return ManagerController.Instance.MCGetAllCharacterSavesByCamp(Init.CharacterCamp.CAMP_HERO);
    }
    /// <summary>
    /// 查询当前存档中的 敌方全部角色数据
    /// </summary>
    /// <returns>The enemy characters.</returns>
    public static List<CharacterSave> GetEnemyCharacters()
    {
        return ManagerController.Instance.MCGetAllCharacterSavesByCamp(Init.CharacterCamp.CAMP_ENEMY);
    }

    /// <summary>
    /// 查询全部被动技能
    /// </summary>
    /// <returns>The all passive skill.</returns>
    /// <param name="uid">Uid.</param>
    public static List<SkillObject> MainGetAllPassiveSkill(long uid)
    {
        return ManagerController.Instance.MCGetAllPassiveSkill(uid);
    }

    /// <summary>
    /// 设置是否自动模式
    /// </summary>
    /// <param name="characterControlType">Character control type.</param>
    public static void SetHeroControlType(Init.CharacterControlType characterControlType)
    {
        ManagerController.Instance.MCSetHeroControlType(characterControlType);
    }
    /// <summary>
    /// 技能是否可以释放
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="skillid"></param>
    /// <returns></returns>
    public static Init.FireSkillState MainIsReady(long uid, int skillid) {
        var so = ManagerController.Instance.MCGetSkillObjectBySkillID(uid, skillid);
        return ManagerController.Instance.MCIsReady(so);
    }

    public static SkillObject MainGetSkillObjectBySkillID(long uid, int skillid) {
        return ManagerController.Instance.MCGetSkillObjectBySkillID(uid, skillid);
    }

    /*-----------------------------------------------------------------------------------------------------------------------------*/
    // buff 相关

    /// <summary>
    /// 查询该角色的全部buff or Debuff.
    /// </summary>
    /// <returns>The buff datas by uid.</returns>
    /// <param name="UID">Uid.</param>
    public static List<BuffData> GetBuffDatasByUID(long UID) {
        return ManagerController.Instance.MBuffManager.GetBuffDatasByUID(UID);
    }

    public static List<BuffData> GetBuffDataListByUID(long UID) {
        return ManagerController.Instance.MBuffManager.GetBuffDatasByUID(UID);
    }

    /// <summary>
    /// 查询buff的层数
    /// </summary>
    /// <param name="uid">角色UID</param>
    /// <param name="buffId">buffID</param>
    /// <param name="bname">身体部位，如果是全身的则传""</param>
    /// <returns></returns>
    public static int GetBuffLayer(long uid,int buffId,string bname) {
        int layer = 0;
        var r = ManagerController.Instance.MBuffManager.GetBuffDatasByBuffIDAndBodyPartName(uid,buffId,bname);
        if(r!=null && r.Count > 0){
            layer = r[0].Buffs.Count;
        }
        return layer;
    }

    /// <summary>
    /// 根据buffID 查询buff数据表基础数据
    /// </summary>
    /// <returns>The buff data table.</returns>
    /// <param name="buffID">Buff identifier.</param>
    public static BuffDataTable GetBuffDataTable(int buffID) {
        return ManagerController.Instance.MDataTableManager.GetBuffDataTableByBuffID(buffID);
    }

    /// <summary>
    /// 查询所有带血量buff的血量
    /// key 为buffID
    /// value 为BloodModel 
    /// </summary>
    /// <returns>The buff blood.</returns>
    /// <param name="uid">Uid.</param>
    public static Dictionary<int, BloodModel> GetBuffBlood(long uid)
    {
        return ManagerController.Instance.MBuffManager.GetBuffBlood(uid);
    }

    /*-----------------------------------------------------------------------------------------------------------------------------*/
    // 技能施放相关

    /// <summary>
    /// 创建宠物数据 返回宠物UID
    /// </summary>
    /// <returns>The pet.</returns>
    /// <param name="masterUID">该宠物创建者</param>
    /// <param name="petCID">Pet cid.</param>
    public static long MainCreatePet(long masterUID, int level, int petCID) {
        return ManagerController.Instance.MCCreatePet(masterUID, level, petCID);
    }

    public static long MainCreatePirson(long masterUID, int pirsonID, int level, Init.CombatPosition combatPosition) {
        return ManagerController.Instance.MCCreatePirson(masterUID, pirsonID, level, combatPosition);
    }

    /// <summary>
    /// 技能施放   技能施放技能施放技能施放技能施放技能施放技能施放技能施放技能施放技能施放技能施放技能施放技能施放技能施放技能施放技能施放技能施放技能施放技能施放技能施放
    /// </summary>
    /// <returns>The skill to target.</returns>
    /// <param name="CharacterUID">Character uid.</param>
    /// <param name="SkillID">Skill identifier.</param>
    /// <param name="TargetList">Target list.</param>
    /// <param name="split">第几段攻击 从0开始，0代表第一段</param>
    public static FinalResult FireSkillToTarget(long CharacterUID, int SkillID, List<SkillFireModel> TargetList, int split) {
        var r = ManagerController.Instance.MCFireSkillToTarget(CharacterUID, SkillID, TargetList, split);
        return r;
    }
    /// <summary>
    /// 每回合结束前的最后一次操作 用于获取自身的被动和buff等对本身数值的修改
    /// </summary>
    /// <returns>The round end.</returns>
    /// <param name="characterUID">Character uid.</param>
    public static List<EffectResultBackModel> GetRoundEnd(long characterUID, Init.AIBehaviorState aIBehaviorState = Init.AIBehaviorState.AI_None) {
        TraitTick(characterUID, Init.TickTraitKind.RoundEnd);
        return ManagerController.Instance.GetRoundEnd(characterUID, aIBehaviorState);
    }

    /// <summary>
    /// 目标拥有圣临等类似可以复活的buff时，当伤害目标数据中CharacterSkillHurtResult.Resurgence为true时，调用该函数
    /// 并在UI中播放复活动画
    /// </summary>
    /// <returns>The resurgence.</returns>
    /// <param name="characterUID">Character uid.</param>
    public static bool MMResurgence(long characterUID)
    {
        return ManagerController.Instance.MCCharacterResurgence(characterUID);
    }

    /// <summary>
    /// 反击 适用于当目标 触发 格挡反击/盾牌反击 后，前端调用该函数 并将返回值显示
    /// </summary>
    public static SkillHurtResult BeatBack(long attackManUID, long targetManUID) {
        return ManagerController.Instance.BeatBack(attackManUID, targetManUID);
    }

    /// <summary>
    /// 委托挂载 游戏物体回合数到期 需要从UI中移除！
    /// </summary>
    /// <param name="sendFunc">Send func.</param>
    public static void SendGamePropManagerHandler(SendGamePropStopHandler sendFunc)
    {
        ManagerController.Instance.MCSetGamePropStopHandler(sendFunc);
    }
    /// <summary>
    /// 委托挂载 吟唱被打断的委托
    /// </summary>
    /// <param name="handler"></param>
    public static void MainAddSongSkillBreakHandler(SongSkillBreakHandler handler)
    {
        //ManagerController.Instance.MCAddSongSkillBreakHandler(handler);
    }


    /// <summary>
    /// 游戏内物体的伤害
    /// 例如 尖刺陷阱 伤害到角色时调用该函数
    /// </summary>
    /// <returns>The property hurt.</returns>
    /// <param name="characterUID">Character uid.</param>
    /// <param name="gamePropUID">Game property cid.</param>
    /// <param name="CharacterEnemyUID">Character enemy uid.</param>
    public static CharacterSkillHurtResult GamePropHurt(long characterUID, long gamePropUID, long CharacterEnemyUID) {
        return ManagerController.Instance.MCGamePropHurt(characterUID, gamePropUID, CharacterEnemyUID);
    }
    /// <summary>
    /// 炸弹伤害函数，
    /// </summary>
    /// <returns>The bomb hurt.</returns>
    /// <param name="characterUID">炸弹的UID</param>
    /// <param name="CharacterEnemyUID">目标UID</param>
    public static CharacterSkillHurtResult GameBombHurt(long characterUID, long CharacterEnemyUID)
    {
        return ManagerController.Instance.MCGameBombHurt(characterUID, CharacterEnemyUID);
    }

    /// <summary>
    /// 该角色回合开始时 的准备函数
    /// </summary>
    /// <returns>The for battle.</returns>
    /// <param name="uid">Uid.</param>
    public static ReadyBattleModel ReadyForBattle(long uid) {
        return ManagerController.Instance.ReadyForBattle(uid);
    }
    /// <summary>
    /// 关闭持续技能 或者回收宠物
    /// 当为回收宠物时返回宠物UID
    /// </summary>
    /// <returns>The skill.</returns>
    /// <param name="uid">Uid.</param>
    /// <param name="skillID">Skill identifier.</param>
    public static List<SkillTargetBuffBack> MainStopSkill(long uid, int skillID) {
        return ManagerController.Instance.MCStopSkill(uid, skillID);
    }

    /// <summary>
    /// 查询是否有 只能进行非移动类活动的buff
    /// </summary>
    /// <returns>The behavior limit do not move.</returns>
    /// <param name="uid">Uid.</param>
    public static bool MMBuffGetCharacterCanMove(long uid) {
        return ManagerController.Instance.MBuffManager.BuffGetCharacterCanMove(uid);
    }

    /// <summary>
    /// 进入战斗界面后面，开始战斗前的请求
    /// </summary>
    /// <returns>The be battle.</returns>
    public static BeBattleModel MainToBeBattle() {

        return ManagerController.Instance.ManagerToBeBattle();
    }
    /// <summary>
    /// 战斗结束后调用的函数
    /// </summary>
    public static BattleEndModel MainBattleEnd() {
        BattleEndModel bem = ManagerController.Instance.MCBattleEnd();
        SaveArchive();
        return bem;
    }

    /// <summary>
    /// 根据选中的目标，查看该技能实际攻击到的站位
    /// </summary>
    /// <param name="skillID"></param>
    /// <param name="targets"></param>
    /// <returns></returns>
    public static List<Init.CombatPosition> MainCheckSkillReallyPositionForTargets(int skillID, List<SkillFireModel> targets) {
        return ManagerController.Instance.MCCheckSkillReallyPositionForTargets(skillID, targets);
    }

    /// <summary>
    /// 查询 分裂后的两个史莱姆的uid
    /// </summary>
    /// <returns></returns>
    public static List<long> MainGetReliveSlime(long uid) {
        return ManagerController.Instance.MCGetReliveSlime(uid);
    }

    public static List<Init.CombatPosition> MainAddSomePositionForPosition(List<Init.CombatPosition> combatPositions, int c) {
        return ManagerController.Instance.MCAddSomePositionForPosition(combatPositions, c);
    }


    /*-----------------------------------------------------------------------------------------------------------------------------*/



    public static void BehaviorTest() {
        //ManagerController.Instance.MBehaviorManager.BehaviorTest();
    }

    /// <summary>
    /// 获得入场编队中所有有MP值的角色
    /// </summary>
    /// <returns></returns>
    public static List<Character> GetEnterTeamHaveMp()
    {
        List<Character> results = new List<Character>();
        List<Character> characters = GetCharactersByState(Init.CharacterState.ENTER);
        for (int i = 0; i < characters.Count; i++)
        {
            Character CT = characters[i];
            if (CT.IsHaveMp())
            {
                results.Add(CT);
            }
        }
        return results;
    }

    /// <summary>
    /// 获得掉落的道具和饰品列表
    /// </summary>
    /// <returns></returns>
    public static Dictionary<Init.ItemOrAccessory, List<int>> GetBattleEndRollDrop()
    {
        return null;
    }

    /// <summary>
    /// 创建道具
    /// </summary>
    /// <param name="ItemCid">道具CID</param>
    /// <param name="Count">道具数量</param>
    public static Item CreateItem(int ItemCid, int Count,bool IsTemp = false)
    {
        return ManagerController.Instance.MWarehouseManager.CreateItem(ItemCid, Count, IsTemp);
    }
    /// <summary>
    /// 得到全部的道具
    /// </summary>
    /// <returns></returns>
    public static List<Item> AllWarehouseItem
    {
        get { return ManagerController.Instance.MWarehouseManager.AllWarehouseItem; }
    }
    /// <summary>
    /// 获得所有角色碎片
    /// </summary>
    /// <returns></returns>
    public static List<Item> AllChips
    {
        get
        {
            return ManagerController.Instance.MWarehouseManager.GetAllItemByKind(Init.ItemKind.Item_RoleChips);
        }
    }
    /// <summary>
    /// 通过道具ID移除道具(返回0失败，成功返回移除的道具CID)
    /// </summary>
    /// <param name="ItemCID"></param>
    /// <param name="ItemUID"></param>
    /// <param name="IsRemove">是否直接移除该道具</param>
    /// <returns></returns>
    public static int RemoveItemByID(int ItemCID, int ItemUID, bool IsRemove = false)
    {
        return ManagerController.Instance.MWarehouseManager.RemoveWarehouseItemById(ItemCID, ItemUID, IsRemove);
    }
    /// <summary>
    /// 通过道具CID查询道具是否可叠加
    /// </summary>
    /// <param name="ItemCID"></param>
    /// <returns></returns>
    public static bool IsItemCanOverlying(int ItemCID)
    {
        return ManagerController.Instance.MWarehouseManager.IsItemCanOverlying(ItemCID);
    }
    /// <summary>
    /// 魔晶石的数量
    /// </summary>
    /// <returns></returns>
    public static int MagicStoneCount
    {
        get
        {
            return ManagerController.Instance.MWarehouseManager.GetMagicStoneCount();
        }
    }
    /// <summary>
    /// 得到仓库中的全部的消耗品
    /// </summary>
    /// <returns></returns>
    public static List<Item> AllConsumableItem
    {
        get
        {
            return ManagerController.Instance.MWarehouseManager.GetAllItemByKind(Init.ItemKind.Item_Consumables);
        }
    }
    /// <summary>
    /// 通过UID获得仓库中的某个道具
    /// </summary>
    /// <param name="UID"></param>
    /// <returns></returns>
    public static Item GetItemByUID(int UID)
    {
        return ManagerController.Instance.MWarehouseManager.GetItemByUID(UID);
    }

    /// <summary>
    /// 通过UID获得仓库中的某个道具的存档数据
    /// </summary>
    /// <param name="UID"></param>
    /// <returns></returns>
    public static ItemSave GetItemSaveByID(int CID, int UID)
    {
        return ManagerController.Instance.MWarehouseManager.GetItemSaveByID(CID, UID);
    }



    /// <summary>
    /// 通过UID移除出售的饰品
    /// </summary>
    /// <param name="UID"></param>
    /// <returns></returns>
    public static bool RemoveAccessoryByUID(int UID)
    {
        return ManagerController.Instance.MWarehouseManager.RemoveWarehouseAccessoryByUID(UID);
    }


    /// <summary>
    /// 增加一条出售信息
    /// </summary>
    public static void AddSellInfo(int CID, int UID, int Count, bool IsAccessory = false)
    {
        SellItemData sellItemData = new SellItemData(CID, UID, Count, IsAccessory);
        ManagerController.Instance.MGameTradeManager.AddSellItemInfo(sellItemData);
    }
    /// <summary>
    /// 移除一条出售信息
    /// </summary>
    /// <param name="UID"></param>
    /// <returns></returns>
    public static bool RemoveSellInfo(int UID)
    {
        return ManagerController.Instance.MGameTradeManager.RemoveSellItemInfo(UID);
    }
    /// <summary>
    /// 查找道具出售的数量
    /// </summary>
    /// <param name="UID"></param>
    /// <returns></returns>
    public static int GetSellCountByUID(int UID)
    {
        return ManagerController.Instance.MGameTradeManager.GetSellCountByUID(UID);
    }
    /// <summary>
    /// 获得出售的价格
    /// </summary>
    /// <returns></returns>
    public static List<int> GetSellPrices()
    {
        return ManagerController.Instance.MGameTradeManager.UpdataSellPriceList();
    }
    /// <summary>
    /// 出售所有道具
    /// </summary>
    /// <returns></returns>
    public static List<int> SellAllItem()
    {
        return ManagerController.Instance.MGameTradeManager.SellAllItemInfo();
    }
    /// <summary>
    /// 购买东西的结果
    /// </summary>
    /// <param name="tradeKind"></param>
    /// <param name="Info"></param>
    /// <returns></returns>
    public static Init.TradeResultKind BuySomeThingResult(Init.TradeKind tradeKind, object Info = null)
    {
        return ManagerController.Instance.MGameTradeManager.BuySomeThing(tradeKind, Info);
    }


    /// <summary>
    /// 获得消耗品的处理结果
    /// </summary>
    /// <param name="ItemCID"></param>
    /// <param name="RoleUID"></param>
    /// <returns></returns>
    public static UseItemEffectResult DisposeConsumableEfeect(int ItemCID, long RoleUID)
    {
        return ManagerController.Instance.MItemEffectManager.DisposeItemEffect(ItemCID, RoleUID);
    }
    /// <summary>
    /// 使用消耗品并获得结果
    /// </summary>
    /// <param name="RoleUID">效果角色的UID</param>
    /// <param name="itemCID">使用的道具CID</param>
    /// <param name="itemUID">使用的道具UID</param>
    /// <param name="equipPos">角色装备的位置枚举</param>
    /// <returns></returns>
    public static UseItemEffectResult UseConsumable(long RoleUID,int itemCID, int itemUID, Init.ConsumableEquipPos equipPos)
    {
        return ManagerController.Instance.MItemEffectManager.UseConsumable(itemCID,itemUID,equipPos,RoleUID);
    }


    /// <summary>
    /// 创建数据表饰品
    /// </summary>
    /// <param name="Cid"></param>
    /// <param name="IsTemp">是否是临时的饰品</param>
    public static Accessory CreateAccessory(int Cid,bool IsTemp = false)
    {
        return ManagerController.Instance.MWarehouseManager.CreateAccessory(Cid, IsTemp);
        //ManagerController.Instance.MDataManager.CreateAccessory(Cid);
    }
    /// <summary>
    /// 创建随机饰品
    /// </summary>
    /// <param name="quality">创建的饰品品质</param>
    /// <param name="IsTemp">是否是临时的</param>
    public static Accessory CreateRandomAttAccessory(Init.Quality quality,bool IsTemp = false)
    {
        return ManagerController.Instance.MWarehouseManager.CreateRandomAccessory(quality, IsTemp);
        //ManagerController.Instance.MDataManager.CreateRandomAccessory(quality);
    }

    /// <summary>
    /// 通过道具种类获得全部道具
    /// </summary>
    /// <returns></returns>
    public static List<ItemDataTable> GetAllItemByKind(Init.ItemKind itemKind)
    {
        List<ItemDataTable> itemDataTables = new List<ItemDataTable>(ManagerController.Instance.MDataTableManager.GetAllItemByKind(itemKind));
        return itemDataTables;
    }
    /// <summary>
    /// 获得所有饰品数据
    /// </summary>
    /// <returns></returns>
    public static List<AccessoryFinalDataTable> GetAccessoryDataTables()
    {
        List<AccessoryFinalDataTable> accessoryDatas = new List<AccessoryFinalDataTable>(ManagerController.Instance.MDataTableManager.GetAllAccessoryFinalData());
        return accessoryDatas;
    }
    /// <summary>
    /// 得到全部饰品
    /// </summary>
    /// <returns></returns>
    public static List<Accessory> GetAllAccessories()
    {
        return ManagerController.Instance.MWarehouseManager.AllWarehouseAccessories;
    }
    /// <summary>
    /// 得到全部装备了的饰品
    /// </summary>
    /// <returns></returns>
    public static List<Accessory> GetAllEquipAccessories()
    {
        return ManagerController.Instance.MWarehouseManager.AllEquipAccessories;
    }
    /// <summary>
    /// 得到了全部没有装备的饰品
    /// </summary>
    /// <returns></returns>
    public static List<Accessory> GetAllNoEquipAccessories()
    {
        return ManagerController.Instance.MWarehouseManager.AllNoEquipAccessories;
    }

    /// <summary>
    /// 获得角色饰品栏
    /// </summary>
    /// <param name="RoleUID"></param>
    /// <returns></returns>
    public static List<int> GetRoleAccessoriesBox(long RoleUID)
    {
        return GetCharacterSaveByUID(RoleUID).GetAccessoriesBox();
    }

    /// <summary>
    /// 通过UID获得仓库中的某个饰品
    /// </summary>
    /// <param name="UID"></param>
    /// <returns></returns>
    public static Accessory GetAccessoryByUID(int UID)
    {
        return ManagerController.Instance.MWarehouseManager.GetAccessoryByUID(UID);
    }


    /// <summary>
    /// 通过UID获得仓库中的某个饰品的存档
    /// </summary>
    /// <param name="UID"></param>
    /// <returns></returns>
    public static AccessorySave GetAccessorySaveByUID(int UID)
    {
        return ManagerController.Instance.MWarehouseManager.GetAccessorySaveByUID(UID);
    }

    /// <summary>
    /// 获得所有出战角色中有魔法值的角色
    /// </summary>
    /// <returns></returns>
    public static List<CharacterSave> GetHaveMPCharacter()
    {
        List<CharacterSave> characterSaves = new List<CharacterSave>();

        List<Character> characters = GetAllCharacter();
        for (int i = 0;i<characters.Count;i++)
        {
            CharacterSave CS = GetCharacterSaveByUID(characters[i].UID);
            if (CS.CharacterState == Init.CharacterState.ENTER)
            {
                if (!CommonTools.Tool.FloatCompare(CS.MP,0)&&!CommonTools.Tool.FloatCompare(CS.MaxMP,0)) {
                    characterSaves.Add(CS);
                }
            }
        }
        return characterSaves;
    }

    /// <summary>
    /// 通过特质Id获得特质名称
    /// </summary>
    /// <returns></returns>
    public static string GetTraitNameById(int TraitId)
    {
        return ManagerController.Instance.MDataTableManager.GetTraitInfo_CN(TraitId)[0];
    }
    /// <summary>
    /// 通过特质Id获得特质描述
    /// </summary>
    /// <returns></returns>
    public static string GetTraitAbstractById(int TraitId)
    {
        return ManagerController.Instance.MDataTableManager.GetTraitInfo_CN(TraitId)[1];
    }
    /// <summary>
    /// 检测是否获得特质
    /// </summary>
    public static void CheckIsGetTrait()
    {
        List<RollTraitResult> rollTraitResults = ManagerController.Instance.MTraitManager.RollRoleGetTrait();
        if (rollTraitResults != null && rollTraitResults.Count>0)
        {
            SysDefine.OpenUIForm("GetTraitAnmiTipsUI");
            MessageCenter.DisposeMessage("GetTraitAnmiTipsUI",SysDefine.SYS_MSG_KIND_ShowGetTraitInfoUI, rollTraitResults);
        }
    }

    /// <summary>
    /// 抽取掉落的道具、饰品列表
    /// </summary>
    /// <param name="ItemDropCount">掉落道具的最低数量，影响获得饰品的数量</param>
    /// <returns></returns>
    public static List<DropItem> GetRollDropList(int ItemDropCount)
    {
        return ManagerController.Instance.MDataManager.GetRollDropList(ItemDropCount);
    }
    /// <summary>
    /// 获得战斗结算奖励
    /// </summary>
    /// <returns></returns>
    public static UIFORM.UIDATACLASS.TwoValue GetBattleReward()
    {
        return ManagerController.Instance.MDataManager.BossBattleRewardDrop();
    }
    /// <summary>
    /// 通过CID获得角色的数据表
    /// </summary>
    /// <param name="CID"></param>
    /// <returns></returns>
    public static CharacterDataTable GetCharacterDataTableByCID(int CID)
    {
        return ManagerController.Instance.MDataTableManager.GetCharacterTableByCID(CID);
    }
    /// <summary>
    /// 增加单货币
    /// </summary>
    /// <param name="Num">增加的数值绝对值</param>
    /// <param name="coinKind">要增加的货币的种类</param>
    /// <param name="IsTempCoin">是否时临时的 true: 临时获得不可使用 false: 加入存档可以使用</param>
    public static void AddCoin(int Num,Init.CoinKind coinKind,bool IsTempCoin = false)
    {
        ManagerController.Instance.MCoinManager.AddCoinNum(Num,coinKind,IsTempCoin);
    }
    /// <summary>
    /// 增加多货币
    /// </summary>
    /// <param name="GoldNum">增加的金币绝对值</param>
    /// <param name="SilverNum">增加的银币绝对值</param>
    /// <param name="CopperNum">增加的铜币绝对值</param>
    /// <param name="IsTempCoin">是否时临时的 true: 临时获得不可使用 false: 加入存档可以使用</param>
    public static void AddAllCoin(int GoldNum, int SilverNum, int CopperNum, bool IsTempCoin)
    {
        ManagerController.Instance.MCoinManager.AddCoinNum(GoldNum, Init.CoinKind.Coin_Gold, IsTempCoin);
        ManagerController.Instance.MCoinManager.AddCoinNum(SilverNum, Init.CoinKind.Coin_Silver, IsTempCoin);
        ManagerController.Instance.MCoinManager.AddCoinNum(CopperNum, Init.CoinKind.Coin_Copper, IsTempCoin);
    }
    /// <summary>
    /// 清空临时货币
    /// </summary>
    public static void ClearTempCoins()
    {
        ManagerController.Instance.MCoinManager.ClearAllTempCoin();
    }

    /// <summary>
    /// 判断玩家是否有足够的钱
    /// </summary>
    /// <returns></returns>
    public static bool IsHaveEnoughCoin(int CostCount)
    {
        return ManagerController.Instance.MCoinManager.CostCoinIsEnough(CostCount);
    }
    /// <summary>
    /// 消耗货币
    /// </summary>
    /// <param name="CostCount"></param>
    /// <returns>true:消耗成功，扣除对应数量 false:消耗失败，不扣除</returns>
    public static bool CostCoins(int CostCount)
    {
        return ManagerController.Instance.MCoinManager.CostCoins(CostCount);
    }

    /// <summary>
    /// 获得玩家货币数量
    /// </summary>
    /// <param name="IsTemp">是否是临时的货币</param>
    /// <returns></returns>
    public static List<int> GetCoinCount(bool IsTemp = false)
    {
        List<int> Coins = new List<int>();
        CoinSave coinSave = null;
        if (IsTemp)
        {
            coinSave = ManagerController.Instance.MCoinManager.TempCoinSave;
        }
        else
        {
            coinSave = ManagerController.Instance.MCoinManager.CoinSave;
        }
     
        Coins.Add(coinSave.Gold);
        Coins.Add(coinSave.Silver);
        Coins.Add(coinSave.Copper);
        return new List<int>(Coins);
    }

    /// <summary>
    /// 添加获得的道具信息
    /// </summary>
    /// <param name="ItemInfo"></param>
    public static TempItemInfoData AddGetItemInfo(GetItemInfo ItemInfo)
    {
        TempItemInfoData itemInfoData = null;
        if (ItemInfo.ItemKind == Init.ItemOrAccessory.Item)
        {
            Item it = CreateItem(ItemInfo.ItemCID, ItemInfo.ItemCount,true);
            itemInfoData = new TempItemInfoData(it);
        }
        else
        {
            if (ItemInfo.AccessoryCreateKind == Init.AccessoryCreateKind.DataTableCreate)
            {
                Accessory accessory = CreateAccessory(ItemInfo.ItemCID);
                itemInfoData = new TempItemInfoData(accessory);
            }
            else if (ItemInfo.AccessoryCreateKind == Init.AccessoryCreateKind.RandomCreate)
            {
                for (int i = 0;i<ItemInfo.ItemCount;i++)
                {
                    Accessory accessory = CreateRandomAttAccessory(ItemInfo.Quality);
                    itemInfoData = new TempItemInfoData(accessory);
                }
            }
        }
        return itemInfoData;
    }

    /// <summary>
    /// 查找临时背包中是否有对应CID的物品数据
    /// </summary>
    /// <param name="ItemCID"></param>
    /// <returns></returns>
    public static bool IsHaveTempItemInfo(int ItemCID)
    {
        return ManagerController.Instance.MDataManager.IsHaveTempItemInfo(ItemCID);
    }
    /// <summary>
    /// 获得临时获得的道具列表
    /// </summary>
    /// <returns></returns>
    public static List<GetItemInfo> GetTempItemInfoList()
    {
        return ManagerController.Instance.MDataManager.GetTempItemInfoList();
    }

    /// <summary>
    /// 通过事件ID获得事件描述
    /// </summary>
    /// <param name="EventId"></param>
    /// <returns></returns>
    public static string GetRandomAbstractById(int EventId,Init.EventAbstractKind abstractKind,int Index)
    {
        string Info = "";
        RandomEventAbstractDataTable abstractDataTable = ManagerController.Instance.MDataTableManager.GetRandomEventInfo_CN_ByCID(EventId);
        switch (abstractKind)
        {
            case Init.EventAbstractKind.None:
                break;
            case Init.EventAbstractKind.EventName:
                {
                    if (Index > abstractDataTable.EventNames.Count-1)
                    {
                        return Info;
                    }
                    Info = abstractDataTable.EventNames[Index];
                }
                break;
            case Init.EventAbstractKind.FirstAbstract:
                {
                    if (Index > abstractDataTable.EventAbstract_First.Count - 1)
                    {
                        return Info;
                    }
                    Info = abstractDataTable.EventAbstract_First[Index];
                }
                break;
            case Init.EventAbstractKind.SecondAbstract:
                {
                    if (Index > abstractDataTable.EventAbstract_Second.Count - 1)
                    {
                        return Info;
                    }
                    Info = abstractDataTable.EventAbstract_Second[Index];
                }
                break;
        }

        return Info;
    }
    /// <summary>
    /// 通过事件ID获得事件名
    /// </summary>
    /// <param name="EventId"></param>
    /// <returns></returns>
    public static string GetEventNameById(int EventId, int Index)
    {
        return GetRandomAbstractById(EventId,Init.EventAbstractKind.EventName,Index);
    }
    /// <summary>
    /// 通过事件ID获得事件一级描述
    /// </summary>
    /// <param name="EventId"></param>
    /// <returns></returns>
    public static string GetEventFirstAbstractId(int EventId, int Index)
    {
        return GetRandomAbstractById(EventId, Init.EventAbstractKind.FirstAbstract, Index);
    }
    /// <summary>
    /// 通过事件ID获得事件二级描述
    /// </summary>
    /// <param name="EventId"></param>
    /// <returns></returns>
    public static string GetEventSecondAbstractId(int EventId, int Index)
    {
        return GetRandomAbstractById(EventId, Init.EventAbstractKind.SecondAbstract, Index);
    }
    /// <summary>
    /// 获得事件的描述种类数量
    /// </summary>
    /// <param name="EventId"></param>
    /// <returns></returns>
    public static int GetEventAbstractCount(int EventId)
    {
        RandomEventAbstractDataTable abstractDataTable = ManagerController.Instance.MDataTableManager.GetRandomEventInfo_CN_ByCID(EventId);
        return abstractDataTable.EventNames.Count;
    }
    /// <summary>
    ///获得可以触发的特质，返回生效的特质结果数据
    /// </summary>
    /// <param name="UID">角色的UID</param>
    /// <param name="time_Battle">触发时刻</param>
    /// <param name="traitConditonData">附加条件</param>
    /// <returns></returns>
    public static List<TraitResultData> GetTriggerTrait(long UID, Init.TraitEffectTime_Battle time_Battle, TraitConditonData traitConditonData = null)
    {
        return ManagerController.Instance.GetTriggerTraitIds(UID,time_Battle,traitConditonData);
    }
    /// <summary>
    /// 刷新特质的持续条件
    /// </summary>
    /// <param name="UID">角色UID</param>
    /// <param name="TickTraitKind">要刷新的类型</param>
    public static void TraitTick(long UID, Init.TickTraitKind TickTraitKind)
    {
        ManagerController.Instance.TraitTick(UID, TickTraitKind);
    }
    /// <summary>
    /// 获得特质效果数值
    /// </summary>
    /// <param name="UID"></param>
    /// <param name="effectKind"></param>
    /// <returns></returns>
    public static float GetTraitEffectValue(long UID, Init.TraitValueEffectKind effectKind)
    {
        return ManagerController.Instance.GetTraitEffectValue(UID, effectKind);
    }
    /// <summary>
    /// 清空特质数据
    /// </summary>
    public static void ClearTraitData()
    {
        ManagerController.Instance.ClearTraitData();
    }
    /// <summary>
    /// 通过特质Id和效果Id获得战斗中的生效时刻
    /// </summary>
    /// <param name="TraitId"></param>
    /// <param name="EffectId"></param>
    /// <returns></returns>
    public static Init.TraitEffectTime_Battle GetTraitEffectTime_Battle(int TraitId, int EffectId)
    {
        return ManagerController.Instance.MDataManager.GetTraitEffectTime_Battle(TraitId, EffectId);
    }

    #region 护甲升级属性相关
    /// <summary>
    /// 获得护甲升级的属性数值效果
    /// </summary>
    /// <returns></returns>
    public static float GetEquipLvUpValue(long UID,Init.TraitValueEffectKind valueEffectKind)
    {
        float result = 0;
        result = MainManager.GetCharacterSaveByUID(UID).GetEquipEffectValue(valueEffectKind);
        return result;
    }
    /// <summary>
    /// 获得角色回合结束时的护甲产生的效果列表
    /// </summary>
    /// <returns></returns>
    public static List<EffectResultBackModel> GetEquipEffectRoundEnd(long UID)
    {
        return MainManager.GetCharacterSaveByUID(UID).GetEquipEffectRoundEnd();
    }
    /// <summary>
    /// 通过技能Id和效果种类查询护甲是否有对该技能产生的特殊效果
    /// </summary>
    /// <param name="UID"></param>
    /// <param name="EquipBuffKind"></param>
    /// <param name="SkillID"></param>
    /// <returns></returns>
    public static float GetEquipBuffEffect(long UID, Init.EquipBuffEffectKind EquipBuffKind, int SkillID,float ChangeValue)
    {
        return MainManager.GetCharacterSaveByUID(UID).GetEquipBuffEffect(EquipBuffKind,SkillID, ChangeValue);
    }
    #endregion 结束

    #region UI文本相关
    /// <summary>
    /// 通过key值获得Json加载的UI文本
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string GetUITextByJsonKey(string key)
    {
        return LauguageManager.Instance.ShowText(key);
    }
    #endregion 结束
    /// <summary>
    /// 通过CID获得角色名
    /// </summary>
    /// <param name="RoleCID"></param>
    /// <returns></returns>
    public static string GetRoleNameByCID(int RoleCID)
    {
        CommonTools.Tool.Log("查询的RoleCID:" + RoleCID);
        var r = ManagerController.Instance.GetDescribeDataTable(RoleCID);
        if (r != null) {
            return r.PropName;
        }
        return "";
    }

    /// <summary>
    /// 获得事件buff的限定条件
    /// </summary>
    /// <param name="BuffId"></param>
    /// <returns></returns>
    public static Init.LimitCondition GetEventBuffCondition(int BuffId)
    {
        return ManagerController.Instance.MDataManager.GetEventBuffLimitConditionById(BuffId);
    }

    /// <summary>
    /// 添加当前死亡角色记录
    /// </summary>
    /// <param name="UID"></param>
    public static void AddCurrentDeadRole(long UID)
    {
        ManagerController.Instance.MRandomEnevtManager.AddCurrentDeadRole(UID);
    }
    /// <summary>
    /// 清空当前死亡角色记录
    /// 总结算时、失败时进行调用
    /// </summary>
    public static void ClearCurrentDeadRole()
    {
        ManagerController.Instance.MRandomEnevtManager.ClearCurrentDeadRole();
    }

    /// <summary>
    /// 通过角色CID获得该角色品质
    /// </summary>
    /// <param name="CID"></param>
    /// <returns></returns>
    public static Init.Quality GetCharacterQualityByCID(int CID)
    {
        return ManagerController.Instance.MDataTableManager.GetCharacterTableByCID(CID).Quality;
    }
    /// <summary>
    /// 获得角色的品级价格
    /// </summary>
    /// <param name="quality"></param>
    /// <param name="characterPrice">价格的种类</param>
    /// <returns></returns>
    public static int GetCharacterQualityPrice(Init.Quality quality, Init.CharacterPrice characterPrice)
    {
        return ManagerController.Instance.MDataManager.GetCharacterQualityPrice(quality, characterPrice);
    }
    /// <summary>
    /// 获得Boss战计数
    /// </summary>
    /// <returns></returns>
    public static int GetBossBattleCount(Init.GameSceneKind gameScene)
    {
        return ManagerController.Instance.MMapMissionManager.GetBossMissionCount(gameScene);
    }
    /// <summary>
    /// 获得区域信息数据
    /// </summary>
    /// <param name="gameScene"></param>
    /// <param name="sceneLv"></param>
    /// <returns></returns>
    public static AreaInfoDataTable GetAreaInfoDataTable(Init.GameSceneKind gameScene, Init.GameSceneLv sceneLv)
    {
        return ManagerController.Instance.MDataManager.GetAreaInfoData(gameScene, sceneLv);
    }

    /// <summary>
    /// 查询该角色是否拥有某一个buff
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="buffID"></param>
    /// <param name="bodypartname"></param>
    /// <returns>true 代表有</returns>
    public static bool HaveAnyBuff(long uid, int buffID, string bodypartname = "") {
        bool have = ManagerController.Instance.MBuffManager.IsHaveAnyBuff(uid,buffID,bodypartname);
        return have;
    }
    /// <summary>
    /// 设置Boss战结果
    /// </summary>
    public static void SetBossBattleResult(bool IsWin)
    {
        ManagerController.Instance.MMissionManager.BattleResult = IsWin;
    }
    /// <summary>
    /// 检查任务结果
    /// </summary>
    public static void CheckMissionResult()
    {
        ManagerController.Instance.MMissionManager.CheckMissionCompleted();
    }
    /// <summary>
    /// 获得当前任务内容
    /// </summary>
    /// <returns></returns>
    public static Init.MissionTaskKind GetMissionTaskKind()
    {
        return ManagerController.Instance.MMissionManager.GetCurrentMission().MissionTask;
    }

    /// <summary>
    /// 获得最终Boss战计数
    /// </summary>
    /// <param name="gameScene"></param>
    /// <returns></returns>
    public static int GetShowFinalBossTick(Init.GameSceneKind gameScene)
    {
        return ManagerController.Instance.MMissionManager.GetBossMissionCount(gameScene);
    }

    /// <summary>
    /// 是否和入侵目标战斗
    /// </summary>
    /// <returns></returns>
    public static bool IsBattleWithInvadedTarget()
    {
        return ManagerController.Instance.MMissionManager.IsBattleInvadedTarget;
    }
    /// <summary>
    /// 是否战胜了Boss
    /// </summary>
    /// <returns></returns>
    public static bool IsBattleWinBoss()
    {
        if (GameSceneData.IsBossBattle && ManagerController.Instance.MMissionManager.BattleResult)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 检查赏金任务完成条件
    /// </summary>
    public static void CheckRewardMissionCondition()
    {
        ManagerController.Instance.MRewardMissionManager.CheckMissionCondition();
    }
    /// <summary>
    /// 检查赏金任务是否完成
    /// </summary>
    /// <returns></returns>
    public static bool CheckRewardMissionFinish()
    {
        return ManagerController.Instance.MRewardMissionManager.CheckMissionIsFinish();
    }


    /// <summary>
    /// 待机时请求函数
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    public static StandyModel Standy(long uid) {
        CharacterSave cs = GetCharacterSaveByUID(uid);
        cs.SetFTG(cs.FTG - 5);
        StandyModel sm = new StandyModel
        {
            FTG = 5
        };
        return sm;
    }
    /// <summary>
    /// 通过角色CID获得最大饰品数
    /// </summary>
    /// <returns></returns>
    public static int GetAccessoryCountByCID(int CID)
    {
        return ManagerController.Instance.MDataManager.GetMaxAccessoryCount(CID);
    }
    /// <summary>
    /// 通过技能Id获得技能种类
    /// </summary>
    /// <param name="SkillId"></param>
    /// <returns></returns>
    public static Init.SkillMode GetSkillModeBySkillId(int SkillId)
    {
        SkillBasicsDataTable SBDT = MainManager.GetSkillBasicsDataTable(SkillId);
        return SBDT.SkillMode;
    }

    /// <summary>
    /// 查询当前任务种类
    /// </summary>
    /// <returns></returns>
    public static Init.MissionKind GetCurrentMissionKind()
    {
        return ManagerController.Instance.MMissionManager.GetCurrentMission().MissionKind;
    }
    /// <summary>
    /// 重新计算随机饰品的附加词条的属性
    /// </summary>
    /// <param name="UID"></param>
    /// <param name="accessoryRandomAttKind"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static float RecalculateAccessoryRandomAtt(long UID, Init.AccessoryRandomAttKind accessoryRandomAttKind, float value)
    {
        return ManagerController.Instance.MAccessoryEffectManager.RecalculateAccessoryRandomAtt(UID, accessoryRandomAttKind, value);
    }


    /// <summary>
    /// 学习新技能或者升级新技能时
    /// 或者获取到修改角色MP HP等数据的道具 饰品及其它乱七八糟的劈柴货时候 刷新新角色数据
    /// 还没有的后面再加吧
    /// </summary>
    /// <param name="uid"></param>
    public static void RefreshCharacterData(long uid) {
        ManagerController.Instance.RefreshCharacterData(uid);
    }

    #region 战斗中事件buff效果
    /// <summary>
    /// 事件buff效果
    /// 重新计算事件buff修改的技能资源消耗
    /// </summary>
    /// <param name="UID"></param>
    /// <param name="CostValue"></param>
    /// <returns></returns>
    public static float ReCalculateSkillCostByBuff(long UID, float CostValue)
    {
        return ManagerController.Instance.MRandomEnevtManager.ReCalculateSkillCostByBuff(UID, CostValue);
    }

   /// <summary>
   /// 事件buff效果
   /// 角色回合结束角色查找是否有buff效果 适用疲劳值改变、MP当前值改变
   /// </summary>
   /// <param name="UID"></param>
   /// <param name="effectKind"></param>
   /// <returns></returns>
    public static float GetRoundEndBuffEffect(long UID, Init.EventBuff_GetRoundEndEffect effectKind)
    {
        return ManagerController.Instance.MRandomEnevtManager.GetRoundEndBuffEffect(UID, effectKind);
    }

    /// <summary>
    /// 事件buff效果
    /// 角色回合结束查找是否有部位效果 适用部位恢复效果和部位伤害
    /// </summary>
    /// <param name="UID"></param>
    /// <param name="effectKind"></param>
    /// <returns></returns>
    public static List<BodyPartChangeInfo> GetRoundEndBuff_BodyPartChange(long UID, Init.EventBuff_GetRoundEndEffect effectKind)
    {
        return ManagerController.Instance.MRandomEnevtManager.GetRoundEndBuff_BodyPartChange(UID, effectKind);
    }

    /// <summary>
    /// 更新战斗buff条件
    /// </summary>
    public static void UpdateBattleBuffCondition()
    {
        ManagerController.Instance.MRandomEnevtManager.TickEventBuff(Init.LimitCondition.LimitBattleNum);
    }
    /// <summary>
    /// 更新角色附加属性条件
    /// </summary>
    /// <param name="limitCondition"></param>
    public static void UpdateRoleAdditionPropertyCondition(Init.LimitCondition limitCondition)
    {
        List<Character> characters = SysDefine.GetEnterRole();
        characters.ForEach(p=> 
        {
            CharacterSave CS = GetCharacterSaveByUID(p.UID);
            CS.AdditionPropertyTable.UpdatePropertiesLimitCondition(limitCondition);
            CS.AdditionPropertyTable.ClearTempProperties();
        });
    }
    #endregion

    /// <summary>
    /// 改变竞技场挑战种类
    /// </summary>
    /// <param name="challengeKind"></param>
    public static void ChangeArenaChallenge(Init.ArenaChallengeKind challengeKind)
    {
        ManagerController.Instance.MArenaManager.ChangeArenaChallengeKind(challengeKind);
    }
    /// <summary>
    /// 获得指定位置的魔石列表
    /// </summary>
    /// <param name="combatPosition"></param>
    /// <returns></returns>
    public static List<JewelSave> GetPosJewelStones(Init.CombatPosition combatPosition)
    {
        List<JewelSave> LoadJewel = new List<JewelSave>();
        List<JewelSave> Jewels = ManagerController.Instance.MJewelEffectManager.JewelSaveList;
        for (int i = 0;i< Jewels.Count;i++)
        {
            JewelSave JS = Jewels[i];
            if (JS.CombatPosition == combatPosition)
            {
                LoadJewel.Add(JS);
            }
        }
        return LoadJewel;
    }
    /// <summary>
    /// 查询是否拥有该魔石
    /// </summary>
    /// <returns></returns>
    public static bool SelectIsHaveJewel(Init.JewelKind jewelKind)
    {
        return ManagerController.Instance.MJewelEffectManager.SelectIsHaveJewel(jewelKind);
    }

    /// <summary>
    /// 获得指定位置上的魔石
    /// </summary>
    /// <param name="combatPosition"></param>
    /// <returns></returns>
    public static Init.JewelKind GetPosJewelStone(Init.CombatPosition combatPosition)
    {
        Init.JewelKind jewelKind = Init.JewelKind.Jewel_None;
        switch (combatPosition)
        {
            case Init.CombatPosition.NONE:
                break;
            case Init.CombatPosition.FRONT:
                {
                    jewelKind = ManagerController.Instance.MJewelEffectManager.FrontStoneKind;
                }
                break;
            case Init.CombatPosition.MIDDLE:
                {
                    jewelKind = ManagerController.Instance.MJewelEffectManager.MiddleStoneKind;
                }
                break;
            case Init.CombatPosition.BACK:
                {
                    jewelKind = ManagerController.Instance.MJewelEffectManager.BackStoneKind;
                }
                break;
        }
        return jewelKind;
    }

    /// <summary>
    /// 设置魔石位置的角色UID
    /// </summary>
    public static void SetPosJewelRoleUID(Init.CombatPosition combatPosition,long RoleUID)
    {
        JewelEffectManager JewelManager = ManagerController.Instance.MJewelEffectManager;
        JewelManager.RemoveRoleJewelProperties(combatPosition,true);
        JewelManager.SetPosRoleUID(combatPosition,RoleUID);
        JewelManager.AddProperties(combatPosition);
    }
    /// <summary>
    /// 设置位置上的魔石
    /// </summary>
    /// <param name="combatPosition"></param>
    /// <param name="kind"></param>
    public static void SetPosJewel(Init.CombatPosition combatPosition,Init.JewelKind kind)
    {
        JewelEffectManager JewelManager = ManagerController.Instance.MJewelEffectManager;
        JewelManager.UpdateRoleJewelKind(combatPosition, kind);
    }
    /// <summary>
    /// 通过角色UID查询角色是否有特殊的魔石效果
    /// </summary>
    /// <param name="UID"></param>
    /// <returns></returns>
    public static List<JewelEffect> GetJewelSpEffects(long UID)
    {
        return ManagerController.Instance.MJewelEffectManager.GetJewelSpEffects(UID);
    }


    #region 图集相关方法预留
    /// <summary>
    /// 通过图集加载Sprite资源
    /// </summary>
    /// <param name="atlasType">图集枚举</param>
    /// <param name="spriteName">资源名</param>
    /// <returns></returns>
    public static UnityEngine.Sprite GetSpriteByAtlas(AtlasType atlasType, string spriteName)
    {
        if (spriteName == "10049" || spriteName == "10050")//黑骑士
        {
            spriteName = "10048";
        }
        return ManagerController.Instance.MAtlasManager.LoadSpriteByAtlas(atlasType, spriteName);
    }

    #endregion



    /// <summary>
    /// 更新角色的血量和mp数据
    /// //需要修改
    /// </summary>
    //public static void UpdateAllCharacterHpAndMp()
    //{
    //    List<Character> characters = GetAllCharacter();
    //    for (int i = 0;i<characters.Count;i++)
    //    {
    //        characters[i].UpdateHpAndMp();
    //    }
    //}

    /*-----*/

    public static List<GameArchive> LoadGameArchives() {
        //return ManagerController.Instance.MCLoadGameArchives();
        return null;
    }

    public static void StartGameByIndex(int index) {
        ManagerController.Instance.MCStartGameByIndex(index);
    }

    public static void SaveArchive() {
        ManagerController.Instance.MCSave();
    }

    /// <summary>
    /// 黑骑士 形态转换
    /// </summary>
    /// <param name="uid"></param>
    public static void MainDoChangeForm(long uid) {
        ManagerController.Instance.MCDoChangeForm(uid);
    }
    /// <summary>
    /// 判断 是否可以分裂
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    public static bool MainSlimeCanSplit(long uid) {
        return ManagerController.Instance.MCIsSlimeSplit(uid);
    }
    /// <summary>
    /// 查询角色的初始属性值 护甲值 HP,MP,LU,SP....
    /// </summary>
    /// <param name="cid"></param>
    /// <param name="att"></param>
    /// <param name="dic_BodyPart">身体部位血量 key为部位名</param>
    /// <param name="dic_equit">护甲血量 key为部位名</param>
    public static void MainGetInitialCharacter(int cid , out CharacterAttributeDataTable att ,out Dictionary<string , float> dic_BodyPart , out Dictionary<string, float> dic_equit) {
        // 角色初始属性
        att = ManagerController.Instance.MDataTableManager.GetCharacterAttributeData(cid);
        // 角色身体部位列表
        var bpds = ManagerController.Instance.MDataTableManager.GetBodyPartsByCID(cid);
        // 角色护甲列表
        var eds = ManagerController.Instance.MDataTableManager.GetEquipDataTablesByCID(cid);
        float blood = att.HP;
        dic_BodyPart = new Dictionary<string, float>();
        for (int i = 0;i < bpds.Count;i ++) {
            var item = bpds[i];
            dic_BodyPart[item.PartName] = blood * item.Probability / 100.0f;
        }
        dic_equit = new Dictionary<string, float>();
        for (int i = 0;i<eds.Count;i++) {
            var item = eds[i];
            dic_equit[item.BodyPartName] = item.MaxBlood;
        }
    }

    /// <summary>
    /// 从战斗界面返回主城界面时，要把所有变换状态的角色，返回初始状态
    /// </summary>
    public static void MainBattleToMain() {
        ManagerController.Instance.MCBattleToMain();
    }

    /// <summary>
    /// 保存消耗品对技能伤害类型的改变
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="itemEffectKind"></param>
    public static void MainConsumableChangeSkillEffect(long uid, Init.SkillEffectType itemEffectKind) {
        ManagerController.Instance.MCConsumableChangeSkillEffect(uid,itemEffectKind);
    }

    #region 掉落相关
    /// <summary>
    /// 战斗掉落数据
    /// </summary>
    /// <param name="dropType"></param>
    /// <returns></returns>
    public static DropData BattleDropData(Init.BattleDropType dropType)
    {
        return ManagerController.Instance.MDropManager.BattleDropData(dropType);
    }
    /// <summary>
    /// 任务掉落数据
    /// </summary>
    /// <returns></returns>
    public static DropData MissionDropData()
    {
        return ManagerController.Instance.MDropManager.MissionDropData();
    }
    /// <summary>
    /// 全部的临时背包中的掉落数据，包含战斗的掉落数据
    /// </summary>
    /// <returns></returns>
    public static DropData AllDropData()
    {
        return ManagerController.Instance.MDropManager.AllDropData();
    }
    /// <summary>
    /// 获得所有的临时道具，总结算所有掉落完成后调用
    /// </summary>
    public static void GetAllTempReward()
    {
        ManagerController.Instance.MDropManager.GetAllTempReward();
    }
    #endregion

    /// <summary>
    /// 从存档中还原货币
    /// </summary>
    /// <param name="Ca"></param>
    /// <param name="tempCa"></param>
    public static void LoadCoinArchToSave(CoinArchive Ca)
    {
        ManagerController.Instance.MCoinManager.LoadCoinArchToSave(Ca);
    }

    /// <summary>
    /// 从存档中还原场景
    /// </summary>
    /// <param name="Ca"></param>
    /// <param name="tempCa"></param>
    public static void LoadSceneArchToSave(SceneArchive Sa)
    {
        ManagerController.Instance.MGameSceneManager.LoadSceneArchToSave(Sa);
    }

    /// <summary>
    /// 从存档中还原地图
    /// </summary>
    /// <param name="Ca"></param>
    /// <param name="tempCa"></param>
    public static void LoadMapColumnArchToSave(List<MapColumnNodeArchive> mcna)
    {
        ManagerController.Instance.MMapNodeManager.LoadMapNodesArchToSave(mcna);
    }


    /// <summary>
    /// 订阅网络监听事件的回调方法
    /// </summary>
    public static void ScribeCallMethodToNetChangedEvent()
    {
        ManagerController.Instance.ScribeCallMethodToNetChangedEvent();
    }

    public static void OnNetChanged(NetListenManager.NetChangedEventArgs e)
    {
        ManagerController.Instance.MNetListenManager.OnNetChanged(e);

    }


    //public static NetListenManager.NetChangedEventHandler NetChanged(System.Action nce)
    //{
    //    nce.Invoke();
    //    NetListenManager.NetChangedEventHandler neh = ManagerController.Instance.MNetListenManager.netch;  
    //    return this.ManagerController.Instance.MNetListenManager= ManagerController.Instance.MNetListenManager;
    //}

    /// <summary>
    /// 检测网络状态
    /// </summary>
    public static void CheckNet()
    {
        ManagerController.Instance.CheckNet();
    }

    /// <summary>
    /// 请求网络时间
    /// </summary>
    public static void RequestNetworkTime()
    {
        ManagerController.Instance.RequestNetworkTime();
    }


    /// <summary>
    /// 得到网络时间
    /// </summary>
    /// <returns></returns>
    public static DateTime DataStandardTime()
    {
       return ManagerController.Instance.DataStandardTime();
    }

    public static void TimeCounter()
    {
        ManagerController.Instance.TimeCounter();
    }


}