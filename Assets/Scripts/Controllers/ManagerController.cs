using System.Collections.Generic;
//using Models;
//using DataTable;
using UnityEngine;
//using CommonTools;
//using wxb;
using System;

namespace Managers
{

    public class ManagerController : DDOLSingleton<ManagerController>
    {
        public bool IsInit { get; set; }

        //public event SongSkillBreakHandler MSongSkillBreakHandler = null;

        //        // 不好改的
        //        public DataManager MDataManager { get; private set; }
        //        public BuffManager MBuffManager { get; private set; }
        //        public GameSceneConfigManager MGameSceneConfigManager { get; private set; }
        //        public RaceStrongPointManager MRaceStrongPointManager { get; set; }
        //        public DataTableManager MDataTableManager { get; } = new DataTableManager();


        //        // 改完的
        //        //private CombatManager MCombatManager { get; set; }
        //        private BehaviorManager MBehaviorManager { get; set; }
        private GameArchiveManager MGameArchiveManager { get; set; }
        //        private SkillManager MSkillManager { get; set; }
        //        private GamePropManager MGamePropManager { get; set; }
        //        //private SaveManager MSaveManager;

        //        // 新建的
        //        private CharacterManager MCharacterManager { get; set; }
        //        private CharacterSystem MCharacterSystem { get; set; }
        //        private CreateSystem MCreateSystem { get; set; }

        //        // private WarehouseManager MItemSystem { get; set; }
        //        // private WarehouseManager MAccessorySystem { get; set; }

        //        private PositionSystem MPositionSystem { get; set; }

        //        private AttributeSystem MAttributeSystem { get; set; }

        //        private LifeSystem MLifeSystem { get; set; }


        //        //private BattleSystem MBattleSystem { get; set; }

        //        // 准备改的 下面这几个Class 短期内用不到
        //        public NetManager MNetManager { get; } = new NetManager();
        //        //public NetWorkManager MNetWorkManager { get; } = new NetWorkManager();
        //        public ProtocolManager MProtocolManager { get; } = new ProtocolManager();

        //        //-------------------------------------------------------


        //        public TraitManager MTraitManager { get; } = new TraitManager();

        //        public GameTradeManager MGameTradeManager { get; } = new GameTradeManager();
        //        public ItemEffectManager MItemEffectManager { get; } = new ItemEffectManager();
        //        public MapMissionManager MMapMissionManager { get; } = new MapMissionManager();
        //        public MissionManager MMissionManager { get; } = new MissionManager();
        //        public RewardMissionManager MRewardMissionManager { get; } = new RewardMissionManager();
        //        public MapNodeManager MMapNodeManager { get; } = new MapNodeManager();
        //        public AccessoryEffectManager MAccessoryEffectManager { get; } = new AccessoryEffectManager();
        //        public RandomEventFinalManager MRandomEnevtManager { get; } = new RandomEventFinalManager();
        //        public JewelEffectManager MJewelEffectManager { get; } = new JewelEffectManager();
        //        public PriceManager MPriceManager { get; } = new PriceManager();

        //        public WarehouseManager MWarehouseManager { get; } = new WarehouseManager();

        //        public ArenaManager MArenaManager { get; } = new ArenaManager();
        /// <summary>
        /// 图集管理器，新增
        /// </summary>
        public AtlasManager MAtlasManager { get; } = new AtlasManager();
        //        /// <summary>
        //        /// 新的货币管理器
        //        /// 增加内存加密
        //        /// </summary>
        //        public CoinManager MCoinManager { get; } = new CoinManager();
        //        /// <summary>
        //        /// 新的场景数据管理器
        //        /// </summary>
        //        public GameSceneManager MGameSceneManager { get; } = new GameSceneManager();
        //        /// <summary>
        //        /// 掉落管理器
        //        /// </summary>
        //        public DropManager MDropManager { get; } = new DropManager();

        //        /// <summary>
        //        /// 网络状态监听管理器
        //        /// </summary>
        //        public NetListenManager MNetListenManager { get; set; } = new NetListenManager();
        //        public NetListenManager.NetChangedEventArgs MNetChangedEventArgs { get; set; }

        //        /// <summary>
        //        /// 获取服务器网络时间管理器
        //        /// </summary>
        //        public ServerTimeManager MServerTimeManager { get; set; } 
        //        /// <summary>
        //        /// 倒计时管理器
        //        /// </summary>
        //        public CountTimeManager MCountTimeManager { get; set; }

        //        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        //        /// <summary>
        //        /// 分裂后的史莱姆的数据
        //        /// </summary>
        //        //public List<long> List_Relive_Slime;

        //        public Dictionary<long, List<long>> DIC_Relive_Slime = new Dictionary<long, List<long>>();


        //        //保存由消耗品改变的技能伤害类型
        //        private Dictionary<long, Init.SkillEffectType> _DicConsumablekillEffectType = new Dictionary<long, Init.SkillEffectType>();
        //        /// <summary>
        //        /// 保存消耗品对技能伤害类型的改变
        //        /// </summary>
        //        /// <param name="uid"></param>
        //        /// <param name="itemEffectKind"></param>
        //        public void MCConsumableChangeSkillEffect(long uid, Init.SkillEffectType itemEffectKind) {
        //            _DicConsumablekillEffectType.Add(uid, itemEffectKind);
        //        }


        //        public List<int> List_Invincible = new List<int>();

        //        public void SetInvincible(int cid) {
        //            List_Invincible.Add(cid);
        //        }

        //        public bool GetInvincibleByCID(int cid) {
        //            bool yes = false;
        //            List_Invincible.ForEach(item => {
        //                if (item == cid) {
        //                    yes = true;
        //                }
        //            });
        //            return yes;
        //        }

        public override void Initialize()
        {
            if (IsInit)
            {
                return;
            }
            IsInit = true;

            //#if USE_HOT
            //            //Debug.Log("ManagerController:Initialize 1");
            //            hotMgr.Init();
            //            //Debug.Log("ManagerController:Initialize 2");
            //            //HotDelegate.Initialize();
            //#endif

            MGameArchiveManager = new GameArchiveManager(this);
            //            //MCombatManager = new CombatManager(this);
            //            MDataManager = new DataManager(this);
            //            MCharacterManager = new CharacterManager(this);
            //            MCharacterSystem = new CharacterSystem(this);
            //            MBehaviorManager = new BehaviorManager(this);
            //            MBuffManager = new BuffManager(this);
            //            MGameSceneConfigManager = new GameSceneConfigManager(this);
            //            MRaceStrongPointManager = new RaceStrongPointManager(this);
            //            MSkillManager = new SkillManager(this);
            //            MCreateSystem = new CreateSystem(this);
            //            MPositionSystem = new PositionSystem(this);
            //            //MSaveManager = new SaveManager(this);
            //            MGamePropManager = new GamePropManager(this);
            //            MAttributeSystem = new AttributeSystem(this);
            //            MLifeSystem = new LifeSystem(this);

            //            MNetChangedEventArgs = new NetListenManager.NetChangedEventArgs(netStatusNow);
            //            MServerTimeManager = new ServerTimeManager(this);
            //            MCountTimeManager = new CountTimeManager(this);

            //            Debug.Log("HotDelegate.HotInitializeAction");
            //            HotDelegate.HotInitializeAction(this);

            //            //MBattleSystem = new BattleSystem(this);
            //            //MBattleSystem.SetBuffManager(MBuffManager);
            //            //MBattleSystem.SetDataTableManager(MDataTableManager);



            //            MDataTableManager.LoadDataTables();

            //            //这里是测试代码 没啥用 后期删了吧 begin
            //            TestDefaultData.CreateData();
            //            MCSetTeamStateEnter(Init.CharacterCamp.CAMP_ENEMY | Init.CharacterCamp.CAMP_HERO);

            //            MCSetDefaultPosition(MCGetCharacterSavesOnEnterByCamp(Init.CharacterCamp.CAMP_HERO));
            //            MCSetDefaultPosition(MCGetCharacterSavesOnEnterByCamp(Init.CharacterCamp.CAMP_ENEMY));
            //            //这里是测试代码 没啥用 后期删了吧 end

            //            //hotMgr.appdomain.Invoke("hot.Manager.ManagerMgr", "Initialize", null, this);



        }


        //        //public void MCOnSongSkillBreakHandler(long uid,long attackUID,int skillid,int split ,Init.BreakSongType breakSong) {
        //        //    MSongSkillBreakHandler?.Invoke(uid,attackUID,skillid,split,breakSong);
        //        //}

        //        //public void MCAddSongSkillBreakHandler(SongSkillBreakHandler handler) {
        //        //    MSongSkillBreakHandler += handler;
        //        //}

        //        private void Update()
        //        {
        //            //CommonTools.Tool.Log("更新中。。。");
        //            //MCombatManager.Update();
        //        }


        //        /// <summary>
        //        /// 清理 CharacterSave 及Character 数据
        //        /// </summary>
        //        /// <param name="uid"></param>
        //        public void MCRemoveCharacterDataByUID(long uid)
        //        {
        //            MCRemoveCharacterByUID(uid);
        //            MCRemoveCharacterSaveByUID(uid);
        //        }

        //        /// <summary>
        //        /// 战斗结束后调用的函数
        //        /// </summary>
        //        public BattleEndModel MCBattleEnd()
        //        {
        //            Tool.Log("-------------------------------------------------------MCBattleEnd()战斗结束 清理数据");
        //            // 清理敌人的CharacterSave数据 同时清理 技能和buff数据
        //            MCharacterManager.CleanAllEnemyCharacterSave();
        //            // 清理英雄战队的CharacterSave中的非英雄角色的数据 包括 宠物 战旗等 并清理他们引起的技能及buff数据
        //            MCharacterManager.CleanHeroNoCharacter();
        //            // 这里清理 敌人的Character数据
        //            MCharacterManager.CleanCharactersByCamp(Init.CharacterCamp.CAMP_ENEMY);
        //            // 清理敌人的站位数据
        //            MCCleanEnemyPosition();

        //            MRaceStrongPointManager.RSPTryReliveForHero();

        //            // 把在战斗中死亡的角色放入祭坛
        //            MCharacterManager.ExcuDeadHerosToJT();


        //            MCharacterManager.CleanHeroCharacterList();

        //            MGamePropManager.CleanSendGamePropStopHandler();

        //            List<CharacterSave> characterSaves = MCGetCharacterSavesOnEnterByCamp(Init.CharacterCamp.CAMP_HERO);
        //            for (int i = 0; i < characterSaves.Count; i++)
        //            {
        //                TraitTick(characterSaves[i].UID, Init.TickTraitKind.BattleEnd);
        //            }
        //            ClearTraitData();
        //            MBehaviorManager.SetCharacterControlType(Init.CharacterControlType.Manual_Control);
        //            return new BattleEndModel();
        //        }
        //        /// <summary>
        //        /// 查询分裂后的史莱姆的UID
        //        /// </summary>
        //        /// <returns></returns>
        //        public List<long> MCGetReliveSlime(long uid)
        //        {
        //            if (DIC_Relive_Slime.ContainsKey(uid)) {
        //                return DIC_Relive_Slime[uid];
        //            }
        //            return null;
        //        }

        //        public bool MCIsSlimeSplit(long uid) {
        //            if (DIC_Relive_Slime.ContainsKey(uid)) {
        //                var a = DIC_Relive_Slime[uid];
        //                if (a != null && a.Count > 0) {
        //                    return true;
        //                }
        //            }
        //            return false;
        //        }

        //        /// <summary>
        //        /// 创建宠物 状态为Enter 位置及血量设置完成
        //        /// </summary>
        //        /// <param name="masterUID"></param>
        //        /// <param name="petCID"></param>
        //        /// <param name="level"></param>
        //        /// <returns></returns>
        //        public long MCCreatePet(long masterUID, int petCID, int level)
        //        {
        //            return MCreateSystem.CreatePet(masterUID, petCID, level);
        //        }
        //        /// <summary>
        //        /// 创建角色
        //        /// </summary>
        //        /// <param name="cid"></param>
        //        /// <param name="level"></param>
        //        /// <param name="camp"></param>
        //        /// <param name="test_Active_all_skill"></param>
        //        /// <param name="skillLv"></param>
        //        /// <returns></returns>
        //        public CharacterSave MCCreateCharacter(int cid, int level, Init.CharacterCamp camp, bool test_Active_all_skill = false, int skillLv = 1)
        //        {
        //            return MCreateSystem.CreateCharacter(cid, level, camp, test_Active_all_skill, skillLv);
        //        }
        //        /// <summary>
        //        /// 创建牢笼
        //        /// </summary>
        //        /// <param name="masterUID"></param>
        //        /// <param name="pirsonID"></param>
        //        /// <param name="level"></param>
        //        /// <param name="combatPosition"></param>
        //        /// <returns></returns>
        //        public long MCCreatePirson(long masterUID, int pirsonID, int level, Init.CombatPosition combatPosition)
        //        {
        //            return MCreateSystem.CreatePirson(masterUID, pirsonID, level, combatPosition);
        //        }
        //        /// <summary>
        //        /// 战斗内创建角色
        //        /// </summary>
        //        /// <param name="cid"></param>
        //        /// <param name="level"></param>
        //        /// <param name="characterCamp"></param>
        //        /// <param name="isInEnemyCamp"></param>
        //        /// <param name="combatPosition"></param>
        //        /// <returns></returns>
        //        public long MCCreateCharacterInBattle(int cid, int level, Init.CharacterCamp characterCamp, bool isInEnemyCamp,
        //                                                Init.CombatPosition combatPosition)
        //        {
        //            return MCreateSystem.CreateCharacterInBattle(cid, level, characterCamp, isInEnemyCamp, combatPosition);
        //        }
        //        /// <summary>
        //        /// 创建分裂后的史莱姆
        //        /// </summary>
        //        /// <param name="cs"></param>
        //        public void MCCreateSmallSlime(CharacterSave cs)
        //        {
        //            MCreateSystem.CreateSmallSlime(cs);
        //        }
        //        /// <summary>
        //        /// 这里是 技能【来人】创建出角色后初始化数据的
        //        /// </summary>
        //        /// <param name="save"></param>
        //        /// <returns></returns>
        //        public bool MCInitialCharacterSkillAndState(CharacterSave save)
        //        {
        //            if (save != null)
        //            {
        //                List<int> allSkill = MDataTableManager.GetCharacterAllSkillsByCID(save.CID);
        //                foreach (int skillid in allSkill)
        //                {
        //                    save.SetActivateSkillLevel(skillid, 1);
        //                    SkillBasicsDataTable skill = MainManager.GetSkillBasicsDataTable(skillid);
        //                    if (skill.SkillMode == Init.SkillMode.ACTIVE || skill.SkillMode == Init.SkillMode.CONTINUE)
        //                    {
        //                        save.AddEnterSkill(skillid);
        //                    }
        //                }
        //                save.CharacterState = Init.CharacterState.ENTER;
        //                MSkillManager.CreateCharacterSkillNoPassive(save.UID);
        //                Instance.MSkillManager.CreatePassivesSkill(save.UID);
        //                return true;
        //            }
        //            return false;
        //        }

        //        /// <summary>
        //        /// 这里判断 该角色是否有在后面站位所引起的buff
        //        /// </summary>
        //        /// <param name="attackMan"></param>
        //        /// <param name="skillID"></param>
        //        /// <returns></returns>
        //        public List<SkillAddtionStateDataTable> MCSkillRecalculateContidionAdditionBuff(CharacterSave attackMan, int skillID)
        //        {
        //            List<SkillAddtionStateDataTable> result = new List<SkillAddtionStateDataTable>();
        //            SkillEffectChangeDataTable skillEffectChangeModel = MDataTableManager.
        //                                    GetSkillEffectChangeDataTableByLevel(skillID, attackMan.GetSkillLevel(skillID), Init.SkillEffectChangeType.OnBack_DoEffect);
        //            if (skillEffectChangeModel != null)
        //            {
        //                List<SkillAddtionStateDataTable> skillAddtionStateDataTables = MDataTableManager.GetSkillAddtionStateDataTablesByLevel(skillID, attackMan.GetSkillLevel(skillID), Init.SkillProcessMode.By_SkillEffectChange_Contidition);
        //                if (skillAddtionStateDataTables != null && skillAddtionStateDataTables.Count > 0)
        //                {
        //                    result.AddRange(skillAddtionStateDataTables);
        //                }
        //            }
        //            return result;
        //        }

        //        /// <summary>
        //        /// 被动技能为主动技能附加buff
        //        /// </summary>
        //        /// <returns>The recalculate addition buff.</returns>
        //        /// <param name="uid">Uid.</param>
        //        /// <param name="skillProcessMode">Skill object.</param>
        //        public List<SkillAddtionStateDataTable> MCSkillRecalculateAdditionBuff(long uid, Init.SkillProcessMode skillProcessMode = Init.SkillProcessMode.Skill_Addition)
        //        {
        //            return MSkillManager.SkillRecalculateAdditionBuff(uid, skillProcessMode);
        //        }

        //        public List<SkillAddtionStateDataTable> MCSkillRecalculateDebuffToMeAdd(long uid, Init.SkillProcessMode skillProcessMode = Init.SkillProcessMode.Debuff_To_me_Add) {
        //            return MSkillManager.SkillRecalculateDebuffToMeAdd(uid, skillProcessMode);
        //        }

        //        /// <summary>
        //        /// 为某些特殊技能服务，当使用某些技能杀死了敌人时，修改角色的属性
        //        /// </summary>
        //        /// <param name="characterSave"></param>
        //        /// <param name="SkillID"></param>
        //        public void MCKillTargetUpdateAttribute(CharacterSave characterSave, int SkillID)
        //        {
        //            //foreach (var item in characterSave.GetActivateSkillLevel()) {
        //            //    SkillKillEnemyAttributeDataTable table = ManagerController.Instance.MDataTableManager.GetSkillKillEnemyAttributeDataTable(item.Key,item.Value);
        //            //    if (table != null)
        //            //    {
        //            //if (table.OptionSkillID == SkillID) {
        //            characterSave.AddSkillKillCount(SkillID);
        //            characterSave.UpdateBodyPartBloodForMaxBlood();
        //            //        }
        //            //    }
        //            //}
        //        }

        //        /// <summary>
        //        /// 查询是否有根据杀死多少角色 给变角色属性的操作
        //        /// </summary>
        //        /// <param name="characterSave"></param>
        //        /// <returns></returns>
        //        public List<SkillKillEnemyAttributeDataTable> MCGetSkillKillEnemyAttributeDataTables(CharacterSave characterSave)
        //        {
        //            List<SkillKillEnemyAttributeDataTable> result = new List<SkillKillEnemyAttributeDataTable>();
        //            foreach (var item in characterSave.GetActivateSkillLevel())
        //            {
        //                SkillKillEnemyAttributeDataTable table = MDataTableManager.GetSkillKillEnemyAttributeDataTable(item.Key, item.Value);
        //                if (table != null)
        //                {
        //                    result.Add(table);
        //                }
        //            }
        //            return result;
        //        }

        //        /// <summary>
        //        /// 这里是设置阵营内所有人的上场状态
        //        /// </summary>
        //        /// <param name="camp"></param>
        //        public void MCSetTeamStateEnter(Init.CharacterCamp camp = Init.CharacterCamp.CAMP_HERO) {
        //            //List<CharacterSave> l = new List<CharacterSave>();
        //            if ((camp & Init.CharacterCamp.CAMP_HERO) == Init.CharacterCamp.CAMP_HERO) {
        //                var l = MCGetAllCharacterSavesByCamp(Init.CharacterCamp.CAMP_HERO);
        //                int count = 0;
        //                for (int i = 0; i < l.Count; i++)
        //                {
        //                    if (count >= Init.ATTENDANCE)
        //                    {
        //                        break;
        //                    }
        //                    CharacterSave c = l[i];
        //                    c.CharacterState = Init.CharacterState.ENTER;
        //                    count++;
        //                }
        //            }
        //            if ((camp & Init.CharacterCamp.CAMP_ENEMY) == Init.CharacterCamp.CAMP_ENEMY)
        //            {
        //                var l = MCGetAllCharacterSavesByCamp(Init.CharacterCamp.CAMP_ENEMY);
        //                int count = 0;
        //                for (int i = 0; i < l.Count; i++)
        //                {
        //                    if (count >= Init.ATTENDANCE)
        //                    {
        //                        break;
        //                    }
        //                    CharacterSave c = l[i];
        //                    c.CharacterState = Init.CharacterState.ENTER;
        //                    count++;
        //                }
        //            }
        //        }

        //        /// <summary>
        //        /// 角色复活后 把血量恢复 状态改为Enter
        //        /// </summary>
        //        /// <param name="cs"></param>
        //        /// <returns></returns>
        //        public long MCReliveCharacter(CharacterSave cs)
        //        {
        //            for (int i = 0; i < cs.BodyParts.Count; i++)
        //            {
        //                BodyPartSave bps = cs.BodyParts[i];
        //                bps.Blood = bps.GetMaxBlood();
        //                bps.EquipBlood = bps.MaxEquipBlood;
        //                bps.Cripple = false;
        //            }
        //            cs.CharacterState = Init.CharacterState.ENTER;
        //            return cs.UID;
        //        }


        //        public void MCBattleToMain() {
        //            var list = MCharacterManager.GetCharacterSavesOnEnterByCamp(Init.CharacterCamp.CAMP_HERO);
        //            for (int i = 0; i < list.Count; i++) {
        //                CharacterChangeForm(list[i], true);
        //            }
        //        }


        //        // 角色不同形态间的转换 黑骑士
        //        /// <summary>
        //        /// 不同形态间的转换
        //        /// </summary>
        //        /// <param name="save"></param>
        //        /// /// <param name="backfrist">是否要返回初始状态</param>
        //        public void CharacterChangeForm(CharacterSave save, bool backfrist = false)
        //        {
        //            if (save == null)
        //            {
        //                return;
        //            }
        //            if (save.CID != 10048 && save.CID != 10049 && save.CID != 10050) {
        //                return;
        //            }
        //            int nextFormCID;

        //            if (backfrist) {
        //                nextFormCID = MDataTableManager.GetCharacterInitialForm(save.CID);
        //            }
        //            else {
        //                nextFormCID = MDataTableManager.GetCharacterNextForm(save.CID);
        //            }

        //            if (nextFormCID != 0)
        //            {
        //                Dictionary<int, int> c = save.GetActivateSkillLevel();
        //                List<int> skills = new List<int>();
        //                foreach (int key in c.Keys)
        //                {
        //                    if (key != 0)
        //                    {
        //                        skills.Add(key);
        //                    }
        //                }

        //                for (int i = 0; i < skills.Count; i++)
        //                {
        //                    int skillID = skills[i];
        //                    int newSkillID = MDataTableManager.FindCorrespondingSkillForSkillIDAndCID(save.CID, skillID, nextFormCID);
        //                    if (newSkillID != 0)
        //                    {
        //                        save.ChangeSkillForForm(skillID, newSkillID);
        //                    }
        //                }

        //                {
        //                    List<int> enterSkills = new List<int>(save.GetEnterSkills());
        //                    save.ClearEnterSkill();
        //                    //List<int> s = new List<int>();
        //                    for (int i = 0; i < enterSkills.Count; i++)
        //                    {
        //                        int newSkillID = MDataTableManager.FindCorrespondingSkillForSkillIDAndCID(save.CID, enterSkills[i], nextFormCID);
        //                        if (newSkillID != 0)
        //                        {
        //                            //s.Add(newSkillID);
        //                            save.AddEnterSkill(newSkillID, false);
        //                        }

        //                        for (int j = 0; j < save.SkillBookEnterSkillIds.Count; j++) {
        //                            if (save.SkillBookEnterSkillIds[j] == enterSkills[i]) {
        //                                save.SkillBookEnterSkillIds[j] = newSkillID;
        //                            }
        //                        }
        //                    }
        //                }

        //                // 修改技能书中的技能
        //                //for (int i = 0;i < save.SkillBookEnterSkillIds.Count;i++) {
        //                //    int newSkillID = MDataTableManager.FindCorrespondingSkillForSkillIDAndCID(save.CID, save.SkillBookEnterSkillIds[i], nextFormCID);
        //                //    save.SkillBookEnterSkillIds[i] = newSkillID;
        //                //}


        //            }


        //            save.BodyParts.ForEach(item => {
        //                save.SetHQSEquieLevel(save.CID, item.BodyPartName, item.Level);
        //            });
        //            save.ClearCurrentEquipEffect();
        //            save.CID = nextFormCID;
        //            save.BodyParts.RemoveAll(a => true);
        //            List<BodyPartDataTable> bodyPartDataTables = MDataTableManager.GetBodyPartsByCID(save.CID);
        //            foreach (BodyPartDataTable dt in bodyPartDataTables)
        //            {
        //                BodyPartSave bs = new BodyPartSave(dt.PartName, dt.Place, save.UID);
        //                bs.SetLevel(save.GetLevel());
        //                save.AddBodyPart(bs);
        //            }

        //            // 护甲
        //            List<EquipDataTable> equipDataTables = MDataTableManager.GetEquipDataTablesByCID(save.CID);
        //            foreach (EquipDataTable equipDataTable in equipDataTables)
        //            {
        //                BodyPartSave bodyPartSave = save.GetBodyPartSave(equipDataTable.BodyPartName);
        //                if (bodyPartSave != null)
        //                {
        //                    bodyPartSave.EquipID = equipDataTable.EquipCID;
        //                    bodyPartSave.SetLevel(save.GetHQSEquipLevel(save.CID, bodyPartSave.BodyPartName));
        //                }
        //                else
        //                {
        //                    Tool.Log("护甲数据附加 这里似乎没有找到匹配的身体部位 " + equipDataTable.BodyPartName);
        //                }
        //            }

        //            // 武器 
        //            List<WeaponDataTable> weaponDataTables = MDataTableManager.GetWeaponDataTablesByCharacterCID(save.CID);
        //            foreach (WeaponDataTable weaponDataTable in weaponDataTables)
        //            {
        //                if (weaponDataTable.BodyPartName == Init.BODY_PART_ALLARMS)
        //                {
        //                    BodyPartSave bodyPartSave1 = save.GetBodyPartSave(Init.BODY_PART_LEFTARM);
        //                    if (bodyPartSave1 != null)
        //                    {
        //                        bodyPartSave1.WeaponID = weaponDataTable.WeaponCID;
        //                    }

        //                    BodyPartSave bodyPartSave2 = save.GetBodyPartSave(Init.BODY_PART_RIGHTARM);
        //                    if (bodyPartSave2 != null)
        //                    {
        //                        bodyPartSave2.WeaponID = weaponDataTable.WeaponCID;
        //                    }
        //                }
        //                else if (weaponDataTable.BodyPartName == Init.BODY_PART_ALLLEGS)
        //                {
        //                    BodyPartSave bodyPartSave1 = save.GetBodyPartSave(Init.BODY_PART_LEFTLEG);
        //                    if (bodyPartSave1 != null)
        //                    {
        //                        bodyPartSave1.WeaponID = weaponDataTable.WeaponCID;
        //                    }

        //                    BodyPartSave bodyPartSave2 = save.GetBodyPartSave(Init.BODY_PART_RIGHTLEG);
        //                    if (bodyPartSave2 != null)
        //                    {
        //                        bodyPartSave2.WeaponID = weaponDataTable.WeaponCID;
        //                    }
        //                }
        //                else
        //                {
        //                    BodyPartSave bodyPartSave2 = save.GetBodyPartSave(weaponDataTable.BodyPartName);
        //                    if (bodyPartSave2 != null)
        //                    {
        //                        bodyPartSave2.WeaponID = weaponDataTable.WeaponCID;
        //                    }
        //                }
        //            }

        //            save.AddCurrentEquipEffect();

        //            //初始化护甲效果字典
        //            //By MZC
        //            //save.InitEquipEffectSave();
        //            save.InitRoleAccessory();
        //            MRaceStrongPointManager.CreateCharacterRaceStrongPoint(save.UID, (int)save.CharacterData.RaceType);

        //            MCCreateCharacterSkillNoPassive(save.UID);
        //            MCCreatePassivesSkill(save.UID);
        //            if (save.CharacterData.CharacterType == Init.CharacterType.Type_Pet)
        //            {
        //                MCInitPetBoold(save);
        //            }
        //            else
        //            {
        //                MCInitCharacterBlood(save);
        //            }
        //            // 这里初始化了 技能资源
        //            save.SetMP(MainManager.MainGetMainProperty(save.UID).MP);

        //            var cc = MainManager.GetCharacterById(save.UID);
        //            cc.CID = save.CID;
        //        }

        //        //public void MCInitializeBattleFlow(IBattleFlow bf) {
        //        //    bf.m_BattleSystem = MBattleSystem;
        //        //    bf.m_BuffManager = MBuffManager;
        //        //    bf.m_DataTableManager = MDataTableManager;
        //        //    bf.m_SystemManager = this;
        //        //}


        //        /*---------------------------------------------------------------------*/
        //        // AttributeSystem

        //        /// <summary>
        //        /// 查询角色的属性值
        //        /// </summary>
        //        /// <param name="uid"></param>
        //        /// <returns></returns>
        //        public MainProperty MCGetMainProperty(long uid) {
        //            return MAttributeSystem.GetMainProperty(uid);
        //        }

        //        /*---------------------------------------------------------------------*/
        //        // CombatManager
        //        // cjl 这里要改---------------------开始
        //        /// <summary>
        //        /// 技能施放
        //        /// </summary>
        //        /// <param name="uid"></param>
        //        /// <param name="skillid"></param>
        //        /// <param name="TargetList"></param>
        //        /// <param name="split"></param>
        //        /// <returns></returns>
        //        public FinalResult MCFireSkillToTarget(long uid, int skillid, List<SkillFireModel> TargetList, int split)
        //        {
        //            return HotDelegate.HotFireSkillToTargetFunc(uid, skillid, TargetList, split);
        //        }
        //        /// <summary>
        //        /// 陷阱的伤害函数
        //        /// </summary>
        //        /// <param name="characterUID"></param>
        //        /// <param name="gamePropUID"></param>
        //        /// <param name="CharacterEnemyUID"></param>
        //        /// <returns></returns>
        //        public CharacterSkillHurtResult MCGamePropHurt(long characterUID, long gamePropUID, long CharacterEnemyUID)
        //        {
        //            //GamePropHurtFlow c = new GamePropHurtFlow(null, null);
        //            //return c.GamePropHurt(characterUID, gamePropUID, CharacterEnemyUID);
        //            return HotDelegate.HotGamePropHurtFunc(characterUID, gamePropUID, CharacterEnemyUID);
        //            //return null;
        //        }
        //        /// <summary>
        //        /// 炸弹的伤害函数
        //        /// </summary>
        //        /// <param name="attackManUID"></param>
        //        /// <param name="CharacterEnemyUID"></param>
        //        /// <returns></returns>
        //        public CharacterSkillHurtResult MCGameBombHurt(long attackManUID, long CharacterEnemyUID)
        //        {
        //            //GameBombHurtFlow c = new GameBombHurtFlow(null, null);
        //            //return c.GameBombHurt(attackManUID, CharacterEnemyUID);
        //            return HotDelegate.HotGameBombHurtFunc(attackManUID, CharacterEnemyUID);
        //            //return MCombatManager.GameBombHurt(attackManUID, CharacterEnemyUID);
        //            //return null;
        //        }
        //        /// <summary>
        //        /// 反击的伤害
        //        /// </summary>
        //        /// <param name="attackManUID"></param>
        //        /// <param name="targetManUID"></param>
        //        /// <returns></returns>
        //        public SkillHurtResult BeatBack(long attackManUID, long targetManUID)
        //        {
        //            //ParryBackFlow parryBackFlow = new ParryBackFlow(null, null);
        //            //return parryBackFlow.ParryBackHurt(attackManUID, targetManUID);
        //            return HotDelegate.HotParryBackFunc(attackManUID, targetManUID);
        //            //return null;
        //        }

        //        // cjl 这里要改---------------------结束

        //        /// <summary>
        //        /// 角色死亡时 做的一些事情
        //        /// </summary>
        //        /// <param name="deadCharacter"></param>
        //        public void MCDeadedDoSth(CharacterSave deadCharacter, bool isRelive = false)
        //        {
        //            deadCharacter.CharacterState = Init.CharacterState.DEAD;
        //            // 改变角色的形态
        //            MCChangeBossSection(deadCharacter);
        //            //CharacterChangeForm(deadCharacter);
        //            // 复活史莱姆
        //            if (!isRelive) {
        //                MCReliveSlime(deadCharacter);
        //            }

        //            // 清理该角色产生的所有游戏物体
        //            MGamePropManager.DelAllGamePropByCharacterUID(deadCharacter.UID);
        //        }

        //        /// <summary>
        //        /// 由前端调用形态转换
        //        /// </summary>
        //        /// <param name="uid"></param>
        //        public void MCDoChangeForm(long uid) {
        //            var cs = MCGetCharacterSaveByUID(uid);
        //            cs.CharacterState = Init.CharacterState.ENTER;
        //            CharacterChangeForm(cs);
        //        }

        //        public void MCReliveSlime(CharacterSave characterSaveEnemy)
        //        {
        //            {
        //                // 判断是否是史莱姆
        //                if (characterSaveEnemy.CharacterData.RaceType == Init.RaceType.Rect_shilaimu && characterSaveEnemy.MasterUID == 0)
        //                {
        //                    // 这里判断 目标有没有 分裂的种族天赋 史莱姆种族天赋 史莱姆种族特长 史莱姆 种族天赋
        //                    if (MRaceStrongPointManager.RSPCalculateSlimeSplit(characterSaveEnemy.UID))
        //                    {
        //                        MCCreateSmallSlime(characterSaveEnemy);
        //                    }
        //                }
        //            }
        //        }
        //        /// <summary>
        //        /// 判断该角色是否可以分裂
        //        /// </summary>
        //        /// <param name="uid"></param>
        //        /// <returns></returns>
        //        public bool MCSlimeCanSplit(long uid) {
        //            var cs = MCGetCharacterSaveByUID(uid);
        //            if (cs != null && cs.CharacterData.RaceType == Init.RaceType.Rect_shilaimu && cs.MasterUID == 0) {
        //                return MRaceStrongPointManager.RSPCalcuateSlimeCanSplit(cs.UID);
        //            }
        //            return false;
        //        }

        //        public void MCChangeBossSection(CharacterSave cs, BodyPartSave bps)
        //        {
        //            if (cs != null && bps != null)
        //            {
        //                if (cs.CID == 10041 && bps.Cripple && bps.BodyPartName == Init.BODY_PART_HEAD)
        //                {
        //                    cs.Section = 3;
        //                    cs.ClearEnterSkill();
        //                    cs.InitActiveSkill();
        //                    // 这里执行更换阶段的逻辑
        //                    MCCreateCharacterSkillNoPassive(cs.UID);
        //                    MCCreatePassivesSkill(cs.UID);
        //                    return;
        //                }
        //                if (cs.CID == 10041) {
        //                    var left1 = cs.GetBodyPartSave(Init.BODY_PART_LEFTARM);
        //                    var right = cs.GetBodyPartSave(Init.BODY_PART_RIGHTARM);
        //                    if (left1 != null && right != null)
        //                    {
        //                        if (left1.EquipBlood <= 0 && right.EquipBlood <= 0 && left1.GetBlood() <= 0 && right.GetBlood() <= 0)
        //                        {
        //                            MCCreateCharacterSkillNoPassive(cs.UID);
        //                            MCCreatePassivesSkill(cs.UID);
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        public void MCChangeBossSection(CharacterSave cs)
        //        {
        //            if (cs != null)
        //            {
        //                if (cs.CID == 10044)
        //                {
        //                    List<CharacterSave> l = MCGetCharacterSavesByCamp(cs, false);
        //                    CharacterSave boss = null;
        //                    CharacterSave friend = null;
        //                    for (int i = 0; i < l.Count; i++)
        //                    {
        //                        if (l[i].CID == 10045)
        //                        {
        //                            friend = l[i];
        //                        }
        //                        else if (l[i].CID == 10041)
        //                        {
        //                            boss = l[i];
        //                        }
        //                    }
        //                    if (boss != null && boss.Section != 3)
        //                    {
        //                        if (cs.CharacterState == Init.CharacterState.DEAD && (friend == null || friend.CharacterState == Init.CharacterState.DEAD))
        //                        {
        //                            boss.Section = 2;
        //                            boss.ClearEnterSkill();
        //                            boss.InitActiveSkill();
        //                            // 这里执行更换阶段的逻辑
        //                            MCCreateCharacterSkillNoPassive(boss.UID);
        //                            MCCreatePassivesSkill(boss.UID);
        //                        }
        //                    }
        //                }
        //                else if (cs.CID == 10045)
        //                {
        //                    List<CharacterSave> l = MCGetCharacterSavesByCamp(cs, false);
        //                    CharacterSave boss = null;
        //                    CharacterSave friend = null;
        //                    for (int i = 0; i < l.Count; i++)
        //                    {
        //                        if (l[i].CID == 10044)
        //                        {
        //                            friend = l[i];
        //                        }
        //                        else if (l[i].CID == 10041)
        //                        {
        //                            boss = l[i];
        //                        }
        //                    }
        //                    if (boss != null && boss.Section != 3)
        //                    {
        //                        if (cs.CharacterState == Init.CharacterState.DEAD && (friend == null || friend.CharacterState == Init.CharacterState.DEAD))
        //                        {
        //                            boss.Section = 2;
        //                            boss.ClearEnterSkill();
        //                            boss.InitActiveSkill();
        //                            // 这里执行更换阶段的逻辑
        //                            MCCreateCharacterSkillNoPassive(boss.UID);
        //                            MCCreatePassivesSkill(boss.UID);
        //                        }
        //                    }
        //                }
        //            }
        //        }




        //        /// <summary>
        //        /// buff 命中计算
        //        /// </summary>
        //        /// <returns><c>true</c>, if is hit the target was buffed, <c>false</c> otherwise.</returns>
        //        /// <param name="targetUID">Character save.</param>
        //        public bool MCBuffIsHitTheTarget(long attackUID, float Probatility, long targetUID)
        //        {
        //            float Resist = MCGetMainProperty(targetUID).Resist;
        //            Resist = MBuffManager.BuffCalculateLoseResistance(attackUID, Resist);
        //            if (MBuffManager.BuffCalculateModificationResistanceToZero(targetUID))
        //            {
        //                Resist = 0.0f;
        //            }
        //            float random = CommonTools.Tool.RandomRangeFloat(0, Init.RANDOM_MAX_NUM);
        //            CommonTools.Tool.Log("buff附加随机数:" + random + " 最终buff命中:" + (Probatility * (100.0f - Resist) / 100.0f));
        //            return random < Probatility * (100.0f - Resist) / 100.0f;
        //        }

        //        /*-------------------------------------------------------------------------------------------------------------*/
        //        /// <summary>
        //        /// 查看该角色是否可以被技能改变位置
        //        /// </summary>
        //        /// <param name="cid"></param>
        //        /// <returns></returns>
        //        public bool MCCheckCanMove(int cid)
        //        {
        //            return MPositionSystem.CheckCanMove(cid);
        //        }

        //        /// <summary>
        //        /// 设置角色站位
        //        /// </summary>
        //        /// <param name="cs"></param>
        //        /// <param name="combatPosition"></param>
        //        /// <returns></returns>
        //        public Init.CombatPosition MCSetCharacterPosition(CharacterSave cs, Init.CombatPosition combatPosition)
        //        {
        //            return MPositionSystem.SetCharacterPosition(cs, combatPosition);
        //        }

        //        /// <summary>
        //        /// 宠物默认设置到最前排
        //        /// </summary>
        //        /// <param name="characterSave"></param>
        //        public void MCSetPetPosition(CharacterSave characterSave)
        //        {
        //            MPositionSystem.SetPetPosition(characterSave);
        //        }

        //        /// <summary>
        //        /// 查看，该技能实际应该攻击到的站位
        //        /// </summary>
        //        /// <param name="skillID"></param>
        //        /// <param name="targets"></param>
        //        /// <returns></returns>
        //        public List<Init.CombatPosition> MCCheckSkillReallyPositionForTargets(int skillID, List<SkillFireModel> targets)
        //        {
        //            return MPositionSystem.CheckSkillReallyPositionForTargets(skillID, targets);
        //        }
        //        /// <summary>
        //        /// 设置list中角色的站位 全随机 除特殊外
        //        /// </summary>
        //        /// <param name="list"></param>
        //        public void MCSetDefaultPosition(List<CharacterSave> list)
        //        {
        //            MPositionSystem.SetDefaultPosition(list);
        //        }

        //        public void MCCleanEnemyPosition() {
        //            MPositionSystem.CleanEnemyPosition();
        //        }

        //        /// <summary>
        //        /// 有修改技能攻击目标站位的buff时，返回原站位，返回修改后的站位
        //        /// </summary>
        //        /// <param name="combatPositions"></param>
        //        /// <param name="c"></param>
        //        /// <returns></returns>
        //        public List<Init.CombatPosition> MCAddSomePositionForPosition(List<Init.CombatPosition> combatPositions, int c)
        //        {
        //            return MPositionSystem.AddSomePositionForPosition(combatPositions, c);
        //        }
        //        /// <summary>
        //        /// 敌人全体随机站位 除个别特殊的
        //        /// </summary>
        //        public void MCSetEnemyDefaultPosition()
        //        {
        //            MCSetDefaultPosition(MCGetAllCharacterSavesByCamp(Init.CharacterCamp.CAMP_ENEMY, Init.CharacterState.ENTER));
        //        }
        //        /// <summary>
        //        /// 根据站位查找符合条件的目标
        //        /// </summary>
        //        /// <param name="characterCamp"></param>
        //        /// <param name="targetPosition"></param>
        //        /// <param name="direction"></param>
        //        /// <param name="count"></param>
        //        /// <returns></returns>
        //        public List<CharacterSave> MCFindCharacterByPositionAndDirAndCount(Init.CharacterCamp characterCamp,
        //                Init.CombatPosition targetPosition, Init.Direction direction, int count)
        //        {
        //            return MPositionSystem.FindCharacterByPositionAndDirAndCount(characterCamp, targetPosition, direction, count);
        //        }
        //        /// <summary>
        //        /// 根据站位查找相应的目标
        //        /// </summary>
        //        /// <param name="characterCamp"></param>
        //        /// <param name="combatPositions"></param>
        //        /// <returns></returns>
        //        public List<CharacterSave> MCFindCharactersByPosition(Init.CharacterCamp characterCamp, List<Init.CombatPosition> combatPositions)
        //        {
        //            return MPositionSystem.FindCharactersByPosition(characterCamp, combatPositions);
        //        }

        //        /// <summary>
        //        /// 设置站位
        //        /// </summary>
        //        /// <param name="cs"></param>
        //        public void MCSetPositionForCharacterSave(CharacterSave cs)
        //        {
        //            MPositionSystem.SetPositionForCharacterSave(cs);
        //        }


        //        /*-------------------------------------------------------------------------------------------------------------*/
        //        // LifeManager


        //        /// <summary>
        //        /// 设置宠物的血量
        //        /// </summary>
        //        /// <param name="save"></param>
        //        public void MCInitPetBoold(CharacterSave save)
        //        {
        //            MLifeSystem.InitPetBoold(save);
        //        }
        //        /// <summary>
        //        /// 设置角色 非宠物的角色的血量
        //        /// </summary>
        //        /// <param name="characterSave"></param>
        //        public void MCInitCharacterBlood(CharacterSave characterSave)
        //        {
        //            MLifeSystem.InitCharacterBlood(characterSave);
        //        }
        //        /// <summary>
        //        /// 设置牢笼的血量
        //        /// </summary>
        //        /// <param name="save"></param>
        //        public void MCInitPrisonBlood(CharacterSave save)
        //        {
        //            MLifeSystem.InitPrisonBlood(save);
        //        }
        //        /// <summary>
        //        /// 最大护甲值
        //        /// </summary>
        //        /// <param name="uid"></param>
        //        /// <param name="bodyPartName"></param>
        //        /// <returns></returns>
        //        public float MCGetCharacterBodyPartMaxEquipBlood(long uid, string bodyPartName) {
        //            return MLifeSystem.GetCharacterBodyPartMaxEquipBlood(uid, bodyPartName);
        //        }
        //        /// <summary>
        //        /// 最大血量值
        //        /// </summary>
        //        /// <param name="uid"></param>
        //        /// <param name="bodyPartName"></param>
        //        /// <returns></returns>
        //        public float MCGetCharacterBodyPartMaxBlood(long uid, string bodyPartName) {
        //            return MLifeSystem.GetCharacterBodyPartMaxBlood(uid, bodyPartName);
        //        }


        //        /*----------------------------------------------------------------------------*/
        //        // CharacterManager
        //        /// <summary>
        //        /// 将新建的角色添加到数组中
        //        /// </summary>
        //        /// <param name="characterCamp"></param>
        //        /// <param name="cs"></param>
        //        public void MCAddCharacterSaveToList(Init.CharacterCamp characterCamp, CharacterSave cs)
        //        {
        //            MCharacterManager.AddCharacterSaveToList(characterCamp, cs);
        //        }
        //        /// <summary>
        //        /// 根据UID查询角色数据 无论上场与否、死亡与否
        //        /// </summary>
        //        /// <param name="uid"></param>
        //        /// <returns></returns>
        //        public CharacterSave MCGetCharacterSaveByUID(long uid)
        //        {
        //            return MCharacterManager.GetCharacterSaveByUID(uid);
        //        }
        //        /// <summary>
        //        /// 查询该阵营下 所有上场的活人
        //        /// </summary>
        //        /// <param name="characterCamp"></param>
        //        /// <returns></returns>
        //        public List<CharacterSave> MCGetCharacterSavesOnEnterByCamp(Init.CharacterCamp characterCamp)
        //        {
        //            return MCharacterManager.GetCharacterSavesOnEnterByCamp(characterCamp);
        //        }

        //        /// <summary>
        //        /// 查询该阵营下的所有角色 所有状态
        //        /// </summary>
        //        /// <param name="characterCamp"></param>
        //        /// <returns></returns>
        //        public List<CharacterSave> MCGetAllCharacterSavesByCamp(Init.CharacterCamp characterCamp, Init.CharacterState characterState)
        //        {
        //            return MCharacterManager.GetAllStateCharacterSavesByCamp(characterCamp, characterState);
        //        }

        //        public List<CharacterSave> MCGetAllCharacterSavesByCamp(Init.CharacterCamp characterCamp)
        //        {
        //            return MCharacterManager.GetAllStateCharacterSavesByCamp(characterCamp, Init.CharacterState.REST |
        //                 Init.CharacterState.ENTER | Init.CharacterState.DEAD | Init.CharacterState.NO_ENTER | Init.CharacterState.DEAD_NO_ENTER);
        //        }
        //        /// <summary>
        //        /// 返回该阵营下的所有角色的UID
        //        /// </summary>
        //        /// <param name="characterCamp"></param>
        //        /// <returns></returns>
        //        public List<long> MCGetCharacterSaveUIDsByCamp(Init.CharacterCamp characterCamp)
        //        {
        //            var l = MCGetAllCharacterSavesByCamp(characterCamp);
        //            List<long> r = new List<long>();
        //            foreach (var item in l)
        //            {
        //                r.Add(item.UID);
        //            }
        //            return r;
        //        }
        //        /// <summary>
        //        /// 根据站位返回角色
        //        /// </summary>
        //        /// <param name="camp"></param>
        //        /// <param name="positions"></param>
        //        /// <returns></returns>
        //        public List<CharacterSave> MCGetCharacterSavesByPosition(Init.CharacterCamp camp, List<Init.CombatPosition> positions, Init.CharacterState characterState)
        //        {
        //            return MCharacterManager.GetCharacterSavesByPosition(camp, positions, characterState);
        //        }

        //        /// <summary>
        //        /// 查询所有角色数据 所有阵营 所有状态
        //        /// </summary>
        //        /// <returns></returns>
        //        public List<CharacterSave> MCGetAllCharacterSaves()
        //        {
        //            return MCharacterManager.GetCharacterSavesByCamp();
        //        }
        //        /// <summary>
        //        /// 查询该角色的同阵营下的角色 ，enter
        //        /// </summary>
        //        /// <param name="characterSave"></param>
        //        /// <param name="includeMySelf"></param>
        //        /// <returns></returns>
        //        public List<CharacterSave> MCGetCharacterSavesByCamp(CharacterSave characterSave, bool includeMySelf)
        //        {
        //            return MCharacterManager.GetCharacterSavesByCamp(characterSave, includeMySelf);
        //        }
        //        /// <summary>
        //        /// 查询该阵营在本场战斗中出站的角色，状态包含 enter rest dead
        //        /// </summary>
        //        /// <param name="characterSave"></param>
        //        /// <param name="includeMySelf"></param>
        //        /// <returns></returns>
        //        public List<CharacterSave> MCGetCharacterSavesByCampAllEnterInThisGame(CharacterSave characterSave, bool includeMySelf)
        //        {
        //            return MCharacterManager.GetCharacterSavesByCampAllEnterInThisGame(characterSave, includeMySelf);
        //        }
        //        /// <summary>
        //        /// 查看最前方站位（宠物站位）是否是空的
        //        /// </summary>
        //        /// <param name="characterCamp"></param>
        //        /// <returns>true 空的</returns>
        //        public bool MCCheckNoPetAndPropPositionOnHeadmost(Init.CharacterCamp characterCamp)
        //        {
        //            return MCharacterManager.CheckNoPetAndPropPositionOnHeadmost(characterCamp);
        //        }
        //        /// <summary>
        //        /// 查询该角色名下的特定宠物（cid）数据 仅上场
        //        /// </summary>
        //        /// <param name="characterUID"></param>
        //        /// <param name="cid"></param>
        //        /// <returns></returns>
        //        public CharacterSave MCGetPetSaveByMasterIDAndPetCid(long characterUID, int cid)
        //        {
        //            return MCharacterManager.GetPetSaveByMasterIDAndPetCid(characterUID, cid);
        //        }
        //        /// <summary>
        //        /// 查询该角色名下的所有上场召唤的宠物数据 仅上场
        //        /// </summary>
        //        /// <param name="characterUID"></param>
        //        /// <returns></returns>
        //        public CharacterSave MCGetPetCharacterSaveByMasterID(long characterUID)
        //        {
        //            return MCharacterManager.GetPetCharacterSaveByMasterID(characterUID);
        //        }
        //        /// <summary>
        //        /// 查询该角色是否有宠物 上场未死
        //        /// </summary>
        //        /// <param name="characterUID"></param>
        //        /// <returns></returns>
        //        public CharacterSave MCGetCharacterPet(long characterUID)
        //        {
        //            return MCharacterManager.GetCharacterPet(characterUID);
        //        }

        //        public List<Init.CombatPosition> MCCheckNoCharacterPosition(Init.CharacterCamp characterCamp, Init.CombatPosition combatPosition)
        //        {
        //            return MPositionSystem.GetNullPosition(characterCamp, combatPosition);
        //        }


        //        public CharacterSave MCGetCharacterSaveByCampCID(Init.CharacterCamp characterCamp, int cid)
        //        {
        //            return MCharacterManager.GetCharacterSaveByCampCID(characterCamp, cid);
        //        }

        //        public bool MCRemoveCharacterSaveByUID(long UID)
        //        {
        //            return MCharacterManager.RemoveCharacterSaveByUID(UID);
        //        }

        //        public bool MCRemoveCharacterByUID(long UID)
        //        {
        //            return MCharacterManager.RemoveCharacterByUID(UID);
        //        }

        //        /// <summary>
        //        /// 根据阵营查询Character数据
        //        /// </summary>
        //        /// <param name="camp"></param>
        //        /// <returns></returns>
        //        public List<Character> MCGetCharactersByCamp(Init.CharacterCamp camp = Init.CharacterCamp.CAMP_ENEMY | Init.CharacterCamp.CAMP_HERO)
        //        {
        //            return MCharacterManager.GetCharactersByCamp(camp);
        //        }

        //        public Character MCGetCharacaterByUID(long uid)
        //        {
        //            return MCharacterManager.GetCharacterByUID(uid);
        //        }

        //        public void MCAddCharacterToListByCamp(Character character, Init.CharacterCamp type)
        //        {
        //            MCharacterManager.AddCharacterToListByCamp(character, type);
        //        }

        //        /// <summary>
        //        /// 根据角色状态 查询英雄战队的的角色数据
        //        /// </summary>
        //        /// <param name="state"></param>
        //        /// <returns></returns>
        //        public List<Character> MCGetHeroCharactersByState(Init.CharacterState state)
        //        {
        //            return MCharacterManager.GetCharactersByCampAndState(Init.CharacterCamp.CAMP_HERO, state);
        //        }


        //        /*----------------------------------------------------------------------------*/
        //        // CharacterSystem
        //        /// <summary>
        //        /// 调用类函数 创建CharacterSave
        //        /// </summary>
        //        /// <param name="cid"></param>
        //        /// <param name="level"></param>
        //        /// <param name="cc"></param>
        //        /// <param name="masterUID"></param>
        //        /// <returns></returns>
        //        public CharacterSave MCCreateNewCharater(int cid, int level, Init.CharacterCamp cc, long masterUID)
        //        {
        //            return MCharacterSystem.CreateNewCharater(cid, level, cc, masterUID);
        //        }

        //        /*-------------------------------------------------------------*/
        //        // GameArchiveManager
        //        public List<GameArchive> MCLoadGameArchives()
        //        {
        //            return MGameArchiveManager.LoadGameArchives();
        //        }

        //        public void MCStartGameByIndex(int index)
        //        {
        //            MGameArchiveManager.StartGameByIndex(index);
        //        }
        //        public void MCSave()
        //        {
        //            MGameArchiveManager.Save();
        //        }

        //        /*-------------------------------------------------------------*/
        //        // BehaviorManager
        //        /// <summary>
        //        /// 查询当前玩家 控制类型
        //        /// </summary>
        //        /// <returns></returns>
        //        public Init.CharacterControlType MCGetCharacterControlType()
        //        {
        //            return MBehaviorManager.GetCharacterControlType();
        //        }

        //        /// <summary>
        //        /// 设置手动 操作或者AI代管
        //        /// </summary>
        //        /// <param name="characterControlType"></param>
        //        public void MCSetHeroControlType(Init.CharacterControlType characterControlType)
        //        {
        //            MBehaviorManager.SetCharacterControlType(characterControlType);
        //        }

        //        public AutoSkillFireModel MCCreateAutoSkillFireModel(SkillObject so, long targetUID = 0)
        //        {
        //            return MBehaviorManager.CreateAutoSkillFireModel(so, targetUID);
        //        }

        //        /*-------------------------------------------------------------*/
        //        // SkillManager

        //        /// <summary>
        //        /// 
        //        /// </summary>
        //        /// <param name="CharacterUID"></param>
        //        public void MCCreateCharacterSkillNoPassive(long CharacterUID)
        //        {
        //            MSkillManager.CreateCharacterSkillNoPassive(CharacterUID);
        //        }

        //        public void MCCreatePassivesSkill(long CharacterUID)
        //        {
        //            MSkillManager.CreatePassivesSkill(CharacterUID);
        //        }

        //        public float MCSkillForCSKillEnemyForSkillToUpHP(CharacterSave cs, int skillid, int skilllv)
        //        {
        //            return MSkillManager.SkillForCSKillEnemyForSkillToUpHP(cs, skillid, skilllv);
        //        }

        //        /// <summary>
        //        /// 召唤 物体  尖刺陷阱等
        //        /// </summary>
        //        /// <param name="finalResult">Final result.</param>
        //        public List<SkillTargetBuffBack> MCSummonProp(SkillObject skillObject, FinalResult finalResult)
        //        {
        //            return MSkillManager.SummonProp(skillObject, finalResult);
        //        }

        //        /// <summary>
        //        /// 召唤炸弹
        //        /// </summary>
        //        /// <param name="skillObject"></param>
        //        /// <param name="finalResult"></param>
        //        public void MCFireBomb(SkillObject skillObject, FinalResult finalResult)
        //        {
        //            MSkillManager.FireBomb(skillObject, finalResult);
        //        }

        //        /// <summary>
        //        /// 召唤宠物
        //        /// </summary>
        //        /// <param name="skillObject"></param>
        //        /// <param name="finalResult"></param>
        //        public void MCSummonPet(SkillObject skillObject, FinalResult finalResult)
        //        {
        //            MSkillManager.SummonPet(skillObject, finalResult);
        //        }
        //        /// <summary>
        //        /// 召唤牢笼
        //        /// </summary>
        //        /// <param name="skillObject"></param>
        //        /// <param name="finalResult"></param>
        //        /// <param name="TargetMan"></param>
        //        public void MCSummonPrison(SkillObject skillObject, FinalResult finalResult, CharacterSave TargetMan)
        //        {
        //            MSkillManager.SummonPrison(skillObject, finalResult, TargetMan);
        //        }

        //        /// <summary>
        //        /// 判断技能是否可以释放
        //        /// </summary>
        //        /// <param name="skillObject"></param>
        //        /// <returns></returns>
        //        public Init.FireSkillState MCIsReady(SkillObject skillObject)
        //        {
        //            //CommonTools.Tool.Log("----------------------------------------------------------");
        //            //CommonTools.Tool.Log("当前 技能id=" + SkillID);
        //            var OwnerCharacterSave = skillObject.OwnerCharacterSave;
        //            var SkillID = skillObject.SkillID;
        //            var SkillBasicsData = skillObject.SkillBasicsData;
        //            if (OwnerCharacterSave.CID == 10002 && SkillID == 20028)
        //            {
        //                Tool.Log("当前 技能id=" + SkillID);
        //            }

        //            if (MBuffManager.BuffCalculateDontFireSkill(OwnerCharacterSave.UID) || MBuffManager.BuffBehaviorLimit(OwnerCharacterSave.UID) == Init.CharacterBehaviorLimit.Only_Attack_Common_Skill)
        //            {
        //                if (SkillBasicsData.SkillMode != Init.SkillMode.COMMON)
        //                {
        //                    return Init.FireSkillState.Buff_Limit_Dont_Fire;
        //                }
        //            }

        //            if (SkillBasicsData.SkillFunctionType == Init.SkillFunctionType.Summon_Porp)
        //            {
        //                List<GamePropModel> gamePropModels = MGamePropManager.GetGamePropModels(OwnerCharacterSave.UID);
        //                if (gamePropModels != null && gamePropModels.Count > 0)
        //                {
        //                    //CommonTools.Tool.Log("None_Location");
        //                    return Init.FireSkillState.None_Location;
        //                }
        //                if (MCGetPetCharacterSaveByMasterID(OwnerCharacterSave.UID) != null && SkillID != 20031)
        //                {
        //                    //CommonTools.Tool.Log("Buff_Limit_Dont_Fire");
        //                    return Init.FireSkillState.None_Location;
        //                }
        //            }
        //            if (SkillBasicsData.SkillFunctionType == Init.SkillFunctionType.Fire_Bomb) {
        //                var c = OwnerCharacterSave.CharacterCamp == Init.CharacterCamp.CAMP_ENEMY ? Init.CharacterCamp.CAMP_HERO : Init.CharacterCamp.CAMP_ENEMY;
        //                var l = MCCheckNoCharacterPosition(c, Init.CombatPosition.HEADMOST);
        //                if (l == null || l.Count <= 0) {
        //                    return Init.FireSkillState.None_Location;
        //                }


        //                var bomb = MCGetGameBombByLocationAndPosition(c, Init.CombatPosition.HEADMOST);
        //                if (bomb != null) {
        //                    return Init.FireSkillState.None_Location;
        //                }

        //            }
        //            if (SkillBasicsData.SkillFunctionType == Init.SkillFunctionType.Summon_Pet)
        //            {
        //                List<GamePropModel> gamePropModels = MGamePropManager.GetGamePropModels(OwnerCharacterSave.UID);
        //                if (gamePropModels != null && gamePropModels.Count > 0)
        //                {
        //                    if (gamePropModels.Count == 1 && gamePropModels[0].PropCID == 10060)
        //                    {

        //                    }
        //                    else {
        //                        return Init.FireSkillState.None_Location;
        //                    }

        //                }
        //                CharacterSave petSave = MCGetPetCharacterSaveByMasterID(OwnerCharacterSave.UID);
        //                if (petSave != null)
        //                {
        //                    SkillSummonDataTable skillSummonDataTable = MDataTableManager.GetSkillSummonCIDByOwnerCIDAndSkillID(OwnerCharacterSave.CID, SkillID);
        //                    if (skillSummonDataTable.SummonCharacterCID == petSave.CID)
        //                    {
        //                        //CommonTools.Tool.Log("Firing");
        //                        return Init.FireSkillState.Firing;
        //                    }
        //                }
        //            }

        //            if (SkillBasicsData.SkillFunctionType == Init.SkillFunctionType.Summon_Prison) {
        //                var l = MCCheckNoCharacterPosition(OwnerCharacterSave.CharacterCamp, Init.CombatPosition.HEADMOST);
        //                if (l == null || l.Count <= 0)
        //                {
        //                    return Init.FireSkillState.None_Location;
        //                }
        //            }



        //            // 持续技能 返回 释放中
        //            if (SkillBasicsData.SkillMode == Init.SkillMode.CONTINUE)
        //            {

        //                if (skillObject.Worked)
        //                {
        //                    //CommonTools.Tool.Log("Firing");
        //                    if (SkillID == 20059 || SkillID == 20310)
        //                    {
        //                        List<BuffData> l = MBuffManager.GetBuffDatasByBuffID(OwnerCharacterSave.UID, 34);
        //                        if (l != null && l.Count > 0)
        //                        {
        //                            return Init.FireSkillState.Firing;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        return Init.FireSkillState.Firing;
        //                    }

        //                }
        //            }

        //            if (SkillID == 20379 || SkillID == 20251)
        //            {
        //                // 如果这是 我饿啦 判断一下 是不是已经把人含嘴里了
        //                if (MBuffManager.BuffImHungryIsFire(OwnerCharacterSave.UID))
        //                {
        //                    CommonTools.Tool.Log("Other_NoFire 3asd");
        //                    return Init.FireSkillState.Other_NoFire;
        //                }
        //            }


        //            if (!OwnerCharacterSave.CheckCharacterArmIsFine(SkillBasicsData.FireSkillArm))
        //            {
        //                //CommonTools.Tool.Log("Arm_Lose");
        //                return Init.FireSkillState.Arm_Lose;
        //            }
        //            if (!OwnerCharacterSave.CheckCharacterLegIsFine(SkillBasicsData.FireSkillLeg))
        //            {
        //                //CommonTools.Tool.Log("Leg_Lose");
        //                return Init.FireSkillState.Leg_Lose;
        //            }

        //            //SkillBasicsData.FireSkillArm

        //            if (skillObject.MP() > OwnerCharacterSave.MP)
        //            {
        //                //CommonTools.Tool.Log("Little_MP");
        //                return Init.FireSkillState.Little_MP;
        //            }
        //            // 判断疲劳值是否足够
        //            //if (FTG() < 0 && UnityEngine.Mathf.Abs( FTG()) > OwnerCharacterSave.FTG) {
        //            //    return Init.FireSkillState.Little_FTG;
        //            //}

        //            //if (OwnerCharacterSave.CombatPosition == Init.CombatPosition.BACK)
        //            //{
        //            //    if (SkillBasicsData.BackPositionTarget == Init.BattleRow.NONE) {
        //            //        //CommonTools.Tool.Log("Location_Cant_Fire");
        //            //        return Init.FireSkillState.Location_Cant_Fire;
        //            //    }
        //            //}
        //            //if (OwnerCharacterSave.CombatPosition == Init.CombatPosition.FRONT)
        //            //{
        //            //    if (SkillBasicsData.FrontPositionTarget == Init.BattleRow.NONE) {
        //            //        //CommonTools.Tool.Log("Location_Cant_Fire");
        //            //        return Init.FireSkillState.Location_Cant_Fire;
        //            //    }
        //            //}

        //            // 这里判断 当拥有【只能进行非移动行为】时，该技能如果是移动类技能，则无法释放
        //            //Init.CharacterBehaviorLimit characterBehaviorLimit = MainManager.GetCharacterLimitedActionBuff(OwnerCharacterSave.UID);
        //            Init.CharacterBehaviorLimit characterBehaviorLimit = MBuffManager.BuffBehaviorLimit(OwnerCharacterSave.UID);
        //            if (characterBehaviorLimit == Init.CharacterBehaviorLimit.Only_Do_NoMove && SkillBasicsData.SkillMoveType == Init.SkillMoveType.MOVE)
        //            {
        //                CommonTools.Tool.Log("Other_NoFire 1");
        //                return Init.FireSkillState.Other_NoFire;
        //            }

        //            // 如果是移动类技能 并且角色拥有定身buff 则无法释放
        //            if (SkillBasicsData.SkillMoveType == Init.SkillMoveType.MOVE && !MBuffManager.BuffGetCharacterCanMove(OwnerCharacterSave.UID))
        //            {
        //                CommonTools.Tool.Log("Other_NoFire 2");
        //                return Init.FireSkillState.Other_NoFire;
        //            }


        //            // 为 20201 【来人！】做的特殊处理 20464 亡者复生
        //            if (SkillID == ConfigSkillCID.ACTIVE_COME_ON_BABY || SkillID == ConfigSkillCID.ACTIVE_CALL_FRIENDS)
        //            {
        //                List<CharacterSave> css = MCGetCharacterSavesByCamp(OwnerCharacterSave, false);
        //                for (int i = 0; i < css.Count; i++)
        //                {
        //                    if (css[i].CharacterState == Init.CharacterState.ENTER)
        //                    {
        //                        Tool.Log("Other_NoFire 3");
        //                        return Init.FireSkillState.Other_NoFire;
        //                    }
        //                }
        //            }

        //            // 潜行技能 判断对方是否施放了闪光弹或者照明弹
        //            if (SkillID == 20059 || SkillID == 20310)
        //            {
        //                Init.CharacterCamp character = OwnerCharacterSave.CharacterCamp == Init.CharacterCamp.CAMP_ENEMY ? Init.CharacterCamp.CAMP_HERO : Init.CharacterCamp.CAMP_ENEMY;
        //                List<CharacterSave> l = MCGetAllCharacterSavesByCamp(character);
        //                for (int i = 0; i < l.Count; i++)
        //                {
        //                    if (MGamePropManager.HaveGamePropByPropCID(l[i].UID, 10060))
        //                    {
        //                        CommonTools.Tool.Log("Other_NoFire 3333");
        //                        return Init.FireSkillState.Other_NoFire;
        //                    }
        //                }
        //            }

        //            SkillRelyOnDataTable d = MDataTableManager.GetSkillRelyOnDataTable(SkillID);
        //            if (d != null)
        //            {
        //                bool fire = false;
        //                int buffID = d.BuffID;
        //                if (d.CID != 0)
        //                {
        //                    List<CharacterSave> list = MCGetCharacterSavesByCamp(OwnerCharacterSave, false);
        //                    for (int i = 0; i < list.Count; i++)
        //                    {
        //                        if (list[i].CID == d.CID)
        //                        {
        //                            List<BuffData> bd = MBuffManager.GetBuffDatasByBuffID(list[i].UID, buffID);
        //                            for (int j = 0; j < bd.Count; j++)
        //                            {
        //                                if (bd[j].RealRound >= d.RoundOver)
        //                                {
        //                                    fire = true;
        //                                }
        //                            }
        //                            if (!fire)
        //                            {
        //                                CommonTools.Tool.Log("Other_NoFire 433");
        //                                return Init.FireSkillState.Other_NoFire;
        //                            }
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    List<BuffData> bd = MBuffManager.GetBuffDatasByBuffID(OwnerCharacterSave.UID, buffID);
        //                    for (int i = 0; i < bd.Count; i++)
        //                    {
        //                        if (bd[i].RealRound >= d.RoundOver)
        //                        {
        //                            fire = true;
        //                        }
        //                    }
        //                    if (!fire)
        //                    {
        //                        CommonTools.Tool.Log("Other_NoFire 44");
        //                        return Init.FireSkillState.Other_NoFire;
        //                    }
        //                }

        //            }


        //            if (skillObject.Round <= 0)
        //            {

        //            }
        //            //CommonTools.Tool.Log("===============" + Init.FireSkillState.Get_Ready);
        //            return Init.FireSkillState.Get_Ready;
        //            //return Init.FireSkillState.Other_NoFire;
        //        }
        //        /// <summary>
        //        /// 查询全部被动技能
        //        /// </summary>
        //        /// <param name="CharacterUID"></param>
        //        /// <returns></returns>
        //        public List<SkillObject> MCGetAllPassiveSkill(long CharacterUID)
        //        {
        //            return MSkillManager.GetAllPassiveSkill(CharacterUID);
        //        }
        //        /// <summary>
        //        /// 停止技能 一般用于停止持续技能
        //        /// </summary>
        //        /// <param name="uid"></param>
        //        /// <param name="skillID"></param>
        //        /// <returns></returns>
        //        public List<SkillTargetBuffBack> MCStopSkill(long uid, int skillID)
        //        {
        //            return MSkillManager.StopSkill(uid, skillID);
        //        }
        //        /// <summary>
        //        /// 查询普通攻击
        //        /// </summary>
        //        /// <param name="characterUID"></param>
        //        /// <returns></returns>
        //        public SkillObject MCGetCommonSkill(long characterUID)
        //        {
        //            return MSkillManager.GetCommonSkill(characterUID);
        //        }
        //        /// <summary>
        //        /// 查询技能数据（主动技能）
        //        /// </summary>
        //        /// <param name="uid"></param>
        //        /// <param name="skillID"></param>
        //        /// <returns></returns>
        //        public SkillObject MCGetSkillObjectBySkillID(long uid, int skillID)
        //        {
        //            return MSkillManager.GetSkillObjectBySkillID(uid, skillID);
        //        }
        //        /// <summary>
        //        /// 查询持续技能
        //        /// </summary>
        //        /// <param name="characterUID"></param>
        //        /// <returns></returns>
        //        public List<SkillObject> MCGetContinueSkill(long characterUID)
        //        {
        //            return MSkillManager.GetContinueSkill(characterUID);
        //        }
        //        /// <summary>
        //        /// 查询所有的非被动技能
        //        /// </summary>
        //        /// <param name="characterUID"></param>
        //        /// <returns></returns>
        //        public List<SkillObject> MCGetAllNoPassiveSkill(long characterUID)
        //        {
        //            return MSkillManager.GetAllNoPassiveSkill(characterUID);
        //        }

        //        /// <summary>
        //        /// 清空技能数据
        //        /// </summary>
        //        /// <param name="uid"></param>
        //        public void MCCleanSkillDatasByUID(long uid)
        //        {
        //            MSkillManager.CleanSkillDatasByUID(uid);
        //        }
        //        /// <summary>
        //        /// 刷新技能数据
        //        /// </summary>
        //        /// <param name="uid"></param>
        //        public void MCRefreshSkillData(long uid)
        //        {
        //            MSkillManager.RefreshSkillData(uid);
        //        }

        //        public SkillObject MCGetPassiveSkill(long uid, int skillid)
        //        {
        //            return MSkillManager.GetPassiveSkill(uid, skillid);
        //        }

        //        /*-------------------------------------------------------------*/
        //        // GamePropManager
        //        /// <summary>
        //        /// 设置回调
        //        /// </summary>
        //        /// <param name="handler"></param>
        //        public void MCSetGamePropStopHandler(SendGamePropStopHandler handler) {
        //            MGamePropManager.SetGamePropStopHandler(handler);
        //        }
        //        public List<GamePropModel> MCGetGamePropModels(long CharacterUID) {
        //            return MGamePropManager.GetGamePropModels(CharacterUID);
        //        }

        //        public void MCDelAllProp() {
        //            MGamePropManager.DelAllProp();
        //        }

        //        public GamePropModel MCGetGamePropModelByUID(long CharacterUID, long gamePropUID) {
        //            return MGamePropManager.GetGamePropModelByUID(CharacterUID, gamePropUID);
        //        }

        //        public GameBomb MCGetGameBombByUID(long bombUID) {
        //            return MGamePropManager.GetGameBombByUID(bombUID);
        //        }

        //        public void MCAddGameProp(long characterUID, GamePropModel gamePropModel) {
        //            MGamePropManager.AddGameProp(characterUID, gamePropModel);
        //        }

        //        public void MCAddGameBomb(GameBomb gameBomb) {
        //            MGamePropManager.AddGameBomb(gameBomb);
        //        }
        //        public void MCDelGameBombByUID(long bombUID)
        //        {
        //            MGamePropManager.DelGameBombByUID(bombUID);
        //        }
        //        /// <summary>
        //        /// 查看该站位有没炸弹
        //        /// </summary>
        //        /// <param name="characterCamp"></param>
        //        /// <param name="combatPosition"></param>
        //        /// <returns></returns>
        //        public GameBomb MCGetGameBombByLocationAndPosition(Init.CharacterCamp characterCamp, Init.CombatPosition combatPosition) {
        //            return MGamePropManager.GetGameBombByLocationAndPosition(characterCamp, combatPosition);
        //        }

        //        /*-------------------------------------------------------------*/

        //        /// <summary>
        //        /// 测试函数
        //        /// </summary>
        //        /// <param name="characterSave"></param>
        //        /// <param name="test_Active_all_skill"></param>
        //        /// <param name="lv"></param>
        //        public void MCTestActivateAllSkill(CharacterSave characterSave, bool test_Active_all_skill, int lv)
        //        {
        //            if (characterSave.CID == 10041 || !test_Active_all_skill)
        //            {
        //                return;
        //            }
        //            List<int> allSkill = MDataTableManager.GetCharacterAllSkillsByCID(characterSave.CID);
        //            foreach (int skillid in allSkill)
        //            {
        //                characterSave.SetActivateSkillLevel(skillid, lv);

        //                SkillBasicsDataTable skill = MainManager.GetSkillBasicsDataTable(skillid);
        //                if (skill != null)
        //                {
        //                    if (skill.SkillMode == Init.SkillMode.ACTIVE || skill.SkillMode == Init.SkillMode.CONTINUE)
        //                    {
        //                        characterSave.AddEnterSkill(skillid);
        //                    }
        //                }
        //            }
        //        }

        //        /// <summary>
        //        /// 还原游戏角色存档
        //        /// </summary>
        //        /// <returns></returns>
        //        public void LoadGameArchiveToCharacterSave(List<CharacterArchive> listCharacterArchives)
        //        {
        //            if (listCharacterArchives.Count > 0)
        //            {

        //                for (int i = 0; i < listCharacterArchives.Count; i++)
        //                {
        //                    CharacterArchive ca = listCharacterArchives[i];

        //                    CharacterSave cs = MainManager.GetCharacterSaveByUID(ca.UID);
        //                    if (cs == null)
        //                    {
        //                        CharacterSave save = MCharacterSystem.LoadCharacter(ca);
        //                        Character character = new Character(save.CID, save.UID);
        //                        MCAddCharacterToListByCamp(character, save.CharacterCamp);
        //                    }
        //                }
        //            }
        //            else
        //                return;
        //        }

        //        /// <summary>
        //        /// 还原游戏地图的存档
        //        /// </summary>
        //        /// <returns></returns>
        //        public void LoadGameArchiveToMapSave(List<MapColumnNodeArchive> listMapColumnArchive)
        //        {
        //            MainManager.LoadMapColumnArchToSave(listMapColumnArchive);
        //        }

        //        /// <summary>
        //        /// 还原游戏货币存档
        //        /// </summary>
        //        /// <returns></returns>
        //        public void LoadGameArchiveToCoinSave(CoinArchive coinArchive)
        //        {
        //            MainManager.LoadCoinArchToSave(coinArchive);
        //        }

        //        /// <summary>
        //        /// 还原游戏场景存档
        //        /// </summary>
        //        /// <returns></returns>
        //        public void LoadGameArchiveToSceneSave(SceneArchive sceneArchive)
        //        {
        //            MainManager.LoadSceneArchToSave(sceneArchive);
        //        }

        //        /// <summary>
        //        /// 还原游戏仓库存档
        //        /// </summary>
        //        /// <returns></returns>
        //        public void LoadGameArchiveToWarehouseSave(WarehouseArchive warehouseArchives)
        //        {
        //            WarehouseManager ws = new WarehouseManager();
        //            ws.ItemUIDCounter = warehouseArchives.ItemUIDCounter;
        //            ws.AccessoryUIDCounter = warehouseArchives.AccessoryUIDCounter;
        //            LoadGameArchiveToItemSave(warehouseArchives.List_ItemArchives);
        //            LoadGameArchiveToAccessorySave(warehouseArchives.List_AccessoryArchives);

        //        }

        //        // 还原道具存档数据
        //        public List<ItemSave> LoadGameArchiveToItemSave(List<ItemArchive> itemArchives)
        //        {
        //            if (itemArchives.Count > 0)
        //            {
        //                List<ItemSave> ListItemSave = new List<ItemSave>();
        //                Debug.Log(" 遍历所有道具存档数据 Archive，加载到存档对象 Save " + itemArchives);
        //                for (int i = 0; i < itemArchives.Count; i++)
        //                {
        //                    ItemArchive ia = itemArchives[i];

        //                    Debug.Log("开始在save中查询获取道具的存档：" + ia.CID);
        //                    ItemSave _is = MainManager.GetItemSaveByID(ia.CID, ia.UID);
        //                    if (_is == null)
        //                    {
        //                        Debug.Log("如果在save中查询获取失败，则把Archive中的存档数值还原给save存档对象");
        //                        ItemSave save = MWarehouseManager.LoadItemArchToSave(ia);

        //                        ListItemSave.Add(save);

        //                        // Item item = new Item(save.CID, save.UID);
        //                        // Debug.Log("根据save存档的ID新建一个道具");

        //                        //  Debug.Log("根据save存档把新的道具添加到仓库");
        //                        // MIAddItemToWarehouse(save, true);

        //                    }
        //                }
        //                return ListItemSave;
        //            }
        //            return null;
        //        }

        //        // 还原饰品存档数据
        //        public List<AccessorySave> LoadGameArchiveToAccessorySave(List<AccessoryArchive> accessoryArchives)
        //        {
        //            if (accessoryArchives.Count > 0)
        //            {
        //                List<AccessorySave> ListAccessorySave = new List<AccessorySave>();
        //                Debug.Log(" 遍历所有饰品存档数据 Archive，加载到存档对象 Save " + accessoryArchives);
        //                for (int i = 0; i < accessoryArchives.Count; i++)
        //                {
        //                    AccessoryArchive aa = accessoryArchives[i];

        //                    Debug.Log("开始在save中查询获取道具的存档：" + aa.CID);
        //                    AccessorySave _as = MainManager.GetAccessorySaveByUID(aa.UID);
        //                    if (_as == null)
        //                    {
        //                        Debug.Log("如果在save中查询获取失败，则把Archive中的存档数值还原给save存档对象");
        //                        AccessorySave save = MWarehouseManager.LoadAccessoryArchToSave(aa);

        //                        ListAccessorySave.Add(save);

        //                    }
        //                }
        //                return ListAccessorySave;
        //            }
        //            return null;
        //        }


        //        public BeBattleModel ManagerToBeBattle()
        //        {
        //            List<CharacterSave> heros = MCharacterManager.GetCharacterSavesByCamp(Init.CharacterCamp.CAMP_HERO);
        //            BeBattleModel beBattleModel = new BeBattleModel();
        //            for (int i = 0; i < heros.Count; i++)
        //            {
        //                List<TraitResultData> resultDatas = BattleTool.ExecuteTrait(heros[i].UID, Init.TraitEffectTime_Battle.EffectTime_JoinBattle, null);
        //                if (resultDatas != null && resultDatas.Count > 0)
        //                {
        //                    beBattleModel.AddTraitResultDatas(resultDatas);
        //                }
        //                MSkillManager.CreateCharacterSkillNoPassive(heros[i].UID);
        //                MSkillManager.CreatePassivesSkill(heros[i].UID);
        //            }
        //            return beBattleModel;
        //        }

        //        public void InitSkillDataByHero()
        //        {
        //            List<CharacterSave> heros = MCharacterManager.GetCharacterSavesByCamp(Init.CharacterCamp.CAMP_HERO);
        //            for (int i = 0; i < heros.Count; i++)
        //            {
        //                MSkillManager.CreateCharacterSkillNoPassive(heros[i].UID);
        //                MSkillManager.CreatePassivesSkill(heros[i].UID);
        //            }
        //        }

        //        public void InitSkillDataByEnemy()
        //        {
        //            List<CharacterSave> heros = MCharacterManager.GetCharacterSavesByCamp(Init.CharacterCamp.CAMP_ENEMY);
        //            for (int i = 0; i < heros.Count; i++)
        //            {
        //                MSkillManager.CreateCharacterSkillNoPassive(heros[i].UID);
        //                MSkillManager.CreatePassivesSkill(heros[i].UID);
        //            }
        //        }

        //        public void RefreshCharacterData(long UID)
        //        {
        //            //CharacterSave cs = MainManager.GetCharacterSaveByUID(UID);
        //            MBuffManager.CleanBuffDataByCharacterUID(UID);
        //            MSkillManager.CreateCharacterSkillNoPassive(UID);
        //            MSkillManager.CreatePassivesSkill(UID);
        //            //MDataManager.InitCharacterBlood(cs);
        //            //MGameArchiveManager.Save();
        //        }



        //        /*-------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        //        // DataTableManager

        //        /// <summary>
        //        /// 根据技能ID 等级 及 buff附加类型，查询buff数据
        //        /// </summary>
        //        /// <param name="skillID"></param>
        //        /// <param name="LEVEL"></param>
        //        /// <param name="skillProcessMode"></param>
        //        /// <returns></returns>
        //        public List<SkillAddtionStateDataTable> MCGetSkillAddtionStateDataTablesByLevel(int skillID, int LEVEL, Init.SkillProcessMode skillProcessMode)
        //        {
        //            return MDataTableManager.GetSkillAddtionStateDataTablesByLevel(skillID, LEVEL, skillProcessMode);
        //        }

        //        public List<SkillAddtionStateDataTable> MCGetSkillAddtionStateDataTablesByLevel(SkillObject skillObject, Init.SkillProcessMode skillProcessMode)
        //        {
        //            return MDataTableManager.GetSkillAddtionStateDataTablesByLevel(skillObject.SkillID, skillObject.Level(), skillProcessMode);
        //        }

        //        /// <summary>
        //        /// 查询技能攻击范围修改表
        //        /// </summary>
        //        /// <param name="skillid"></param>
        //        /// <returns></returns>
        //        public SkillChangeScopeDataTable MCGetSkillChangeScopeDataTable(int skillid)
        //        {
        //            return MDataTableManager.GetSkillChangeScopeDataTable(skillid);
        //        }

        //        public SkillDescribeDataTable MCGetSkillDescribeDataTable(int skillID)
        //        {
        //            return MDataTableManager.GetSkillDescribeDataTable(skillID);
        //        }

        //        public CharacterDataTable GetCharacterTableByCID(int cid)
        //        {
        //            return MDataTableManager.GetCharacterTableByCID(cid);
        //        }

        //        public SkillLevelDataTable MCGetSkillLevelDataTableByLevel(int skillid, int lv)
        //        {
        //            return MDataTableManager.GetSkillLevelDataTableByLevel(skillid, lv);
        //        }

        //        /// <summary>
        //        /// 查询 数据表述数据表
        //        /// </summary>
        //        /// <returns>The describe data table.</returns>
        //        /// <param name="cid">Cid.</param>
        //        public DescribeDataTable GetDescribeDataTable(int cid)
        //        {
        //            DescribeDataTable table = MDataTableManager.GetDescribeDataTable(cid);
        //            return table;
        //        }

        //        public BuffDataTable GetBuffDataTableByBuffID(int buffID)
        //        {
        //            return MDataTableManager.GetBuffDataTableByBuffID(buffID);
        //        }



        //        /// <summary>
        //        /// 用于每回合结束最后的操作
        //        /// </summary>
        //        /// <returns>The end.</returns>
        //        /// <param name="characterUID">Character uid.</param>
        //        public List<EffectResultBackModel> GetRoundEnd(long characterUID, Init.AIBehaviorState aIBehaviorState = Init.AIBehaviorState.AI_None)
        //        {
        //            List<EffectResultBackModel> results = new List<EffectResultBackModel>();

        //            CharacterSave cs = MainManager.GetCharacterSaveByUID(characterUID);

        //            float hfmp = 0.0f;
        //            float hfftg = 0.0f;
        //            var kbel = MainManager.GetEquipEffectRoundEnd(characterUID);
        //            kbel.ForEach(item => {
        //                if (item.BuffBackType == Init.EffectResultBackType.Modification_MP) {
        //                    hfmp = item.BuffBackValue;
        //                }
        //                if (item.BuffBackType == Init.EffectResultBackType.Modification_TiredNum)
        //                {
        //                    hfftg = item.BuffBackValue;
        //                }
        //            });
        //            if (aIBehaviorState == Init.AIBehaviorState.AI_Standby) {
        //                if (cs.MaxMP > 0)
        //                {
        //                    hfmp += 5.0f;
        //                }
        //                else {
        //                    hfmp = 0;
        //                }
        //                hfftg -= 5.0f;
        //            }

        //            if (!Tool.FloatCompare(hfmp, 0.0f)) {
        //                EffectResultBackModel e1 = new EffectResultBackModel(characterUID, Init.EffectResultBackType.Modification_MP, hfmp, Init.EffectResultBackModelType.Buff, 322, 0, "");
        //                cs.SetMP(cs.MP + hfmp);
        //                if (cs.MP > cs.MaxMP)
        //                {
        //                    cs.SetMP(cs.MaxMP);
        //                }
        //                results.Add(e1);
        //            }
        //            if (!Tool.FloatCompare(hfftg, 0.0f)) {
        //                EffectResultBackModel e = new EffectResultBackModel(characterUID, Init.EffectResultBackType.Modification_TiredNum, hfftg, Init.EffectResultBackModelType.Buff, 321, 0, "");
        //                cs.SetFTG(cs.FTG + hfftg);
        //                if (cs.FTG < 0)
        //                {
        //                    cs.SetFTG(0);
        //                }
        //                results.Add(e);
        //            }

        //            // 每回合结束后 buff中的 各种操作
        //            List<EffectResultBackModel> list1 = MBuffManager.BuffOnTick(characterUID, Init.BuffTakeEffect.Round_End);
        //            if (list1.Count > 0)
        //            {
        //                results.AddRange(list1);
        //            }

        //            MGamePropManager.OnTick(characterUID);
        //            // 各种技能的数据返回
        //            List<EffectResultBackModel> list2 = MSkillManager.SkillOnTick(characterUID);
        //            if (list2 != null && list2.Count > 0)
        //            {
        //                results.AddRange(list2);
        //            }
        //            // 由持续技能或者持续恢复某些属性的buff引起的数值的改变
        //            List<EffectResultBackModel> ll = MBuffManager.OnBuffForContinue(characterUID, Init.BuffTakeEffect.Round_End);
        //            if (ll != null && ll.Count > 0) {
        //                results.AddRange(ll);
        //            }

        //            for (int i = 0; i < cs.BodyParts.Count; i++)
        //            {
        //                if (cs.BodyParts[i].Cripple)
        //                {
        //                    List<SkillTargetBuffBack> skillTargetBuffBacks = MBuffManager.StopBodyPartBuff(cs.UID, cs.BodyParts[i].BodyPartName, Init.BuffLoseType.BodyPart_Lose);
        //                    if (skillTargetBuffBacks != null && skillTargetBuffBacks.Count > 0)
        //                    {
        //                        for (int j = 0; j < skillTargetBuffBacks.Count; j++)
        //                        {
        //                            EffectResultBackModel erb = new EffectResultBackModel(characterUID, Init.EffectResultBackType.None, 0, Init.EffectResultBackModelType.Buff, cs.CID, 0, cs.BodyParts[i].BodyPartName);
        //                            erb.BuffState = Init.BuffState.Buff_Over;
        //                            results.Add(erb);
        //                        }
        //                    }
        //                }
        //            }

        //            List<CharacterSave> l = MCGetAllCharacterSavesByCamp(Init.CharacterCamp.CAMP_HERO, Init.CharacterState.ENTER);
        //            l.ForEach(item => {
        //                MainManager.SetPosJewelRoleUID(item.CombatPosition, item.UID);
        //            });

        //            {
        //                var rr = MCGetAllCharacterSaves();
        //                rr.ForEach(ccs => {
        //                    if (ccs.CharacterState == Init.CharacterState.DEAD) {
        //                        var dr = AttackDeadCleanBuff(ccs.UID);
        //                        dr.ForEach(sbb => {
        //                            EffectResultBackModel erb = new EffectResultBackModel(sbb.UID, Init.EffectResultBackType.None, 0, Init.EffectResultBackModelType.Buff, sbb.BuffID, sbb.SkillID, sbb.BodyPartName);
        //                            erb.BuffState = Init.BuffState.Buff_Over;
        //                            results.Add(erb);
        //                        });
        //                    }
        //                });
        //            }

        //            return results;
        //        }
        //        /// <summary>
        //        /// 复活 并回复到受伤害前的状态
        //        /// </summary>
        //        /// <returns>The resurgence.</returns>
        //        /// <param name="characterUID">Character uid.</param>
        //        public bool MCCharacterResurgence(long characterUID)
        //        {
        //            return MBuffManager.BuffCharacterResurgence(characterUID);
        //        }




        //        Dictionary<long, int> dic_relive = new Dictionary<long, int>();
        //        private string netStatusNow;

        //        /// <summary>
        //        /// 当前角色每回合开始时调用的函数
        //        /// </summary>
        //        /// <param name="uid"></param>
        //        /// <returns></returns>
        //        public ReadyBattleModel ReadyForBattle(long uid)
        //        {
        //            Tool.Log("ReadyForBattle ------------------------------------------------------------------------------- start");
        //            Tool.Log("ReadyForBattle uid=" + uid);
        //            CharacterSave characterSave = MainManager.GetCharacterSaveByUID(uid);
        //            if (characterSave.CID == 10059)
        //            {
        //                Tool.Log("这里需要输出一下");
        //            }

        //            if (characterSave.CharacterState == Init.CharacterState.DEAD)
        //            {
        //                MRaceStrongPointManager.RSPDoReliveTick(characterSave);
        //                if (characterSave.CID == 10037 || characterSave.CID == 10038 || characterSave.CID == 10039)
        //                {
        //                    if (dic_relive.ContainsKey(characterSave.UID))
        //                    {
        //                        int c = dic_relive[characterSave.UID];
        //                        c++;
        //                        if (c >= 3)
        //                        {
        //                            dic_relive.Remove(characterSave.UID);
        //                            MCReliveCharacter(characterSave);
        //                        }
        //                        else
        //                        {
        //                            dic_relive[characterSave.UID] = c;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        dic_relive[characterSave.UID] = 1;
        //                    }
        //                }
        //            }
        //            else {
        //                if (characterSave.CharacterData.RaceType == Init.RaceType.Rect_shilaimu) {
        //                    var friends = MCGetCharacterSavesByCamp(characterSave, false);
        //                    friends.ForEach(item =>
        //                    {
        //                        if (item.MasterUID == characterSave.UID) {
        //                            MCRemoveCharacterDataByUID(item.UID);
        //                        }
        //                    });
        //                }
        //            }
        //            List<EffectResultBackModel> ll = MBuffManager.OnBuffForContinue(uid, Init.BuffTakeEffect.Round_Begin);
        //            List<EffectResultBackModel> list1 = MBuffManager.BuffOnTick(uid, Init.BuffTakeEffect.Round_Begin);
        //            List<EffectResultBackModel> list2 = MBuffManager.BuffCalculateHurtAllEnemyRandomBodyPart(uid);
        //            if (list2 != null && list2.Count > 0)
        //            {
        //                list1.AddRange(list2);
        //            }
        //            if (ll != null && ll.Count > 0) {
        //                list1.AddRange(ll);
        //            }
        //            // 这里增加该角色的回合数
        //            //mCombatManager.UpdateCharacterRoundByUID(uid);


        //            // AI控制限制
        //            MBuffManager.BuffAIControlLimit(uid);
        //            ReadyBattleModel readyBattleModel = new ReadyBattleModel
        //            {
        //                // 设置当前行为限制类型
        //                CharacterBehaviorLimit = MBuffManager.BuffBehaviorLimit(uid),
        //                // 设置当前控制类型
        //                CharacterControlType = characterSave.ControlType,
        //                EffectResultBackModels = list1,
        //            };

        //            // 特质 生效时间点 每回合开始时
        //            List<TraitResultData> resultDatas = BattleTool.ExecuteTrait(uid, Init.TraitEffectTime_Battle.EffectTime_AllRoundBegin, null);
        //            readyBattleModel.TraitResultDatas_List = resultDatas;

        //            // 这里是下回合 无操作
        //            if (!characterSave.CharacterOperation)
        //            {
        //                if (characterSave.LifeLimit)
        //                {
        //                    if (characterSave.RoundBeginTick() <= 0)
        //                    {
        //                        InGameOptionDataTable table = MDataTableManager.GetInGameOptionDataTable(characterSave.CID);
        //                        if (table.LifeOverFireSkillID != 0)
        //                        {
        //                            readyBattleModel.CharacterControlType = Init.CharacterControlType.AI_Control;
        //                            InGameOptionDataTable skilltable = MDataTableManager.GetInGameOptionDataTable(table.LifeOverFireSkillID);
        //                            MBehaviorManager.InGameLogic(characterSave, readyBattleModel, skilltable, Init.SkillMode.ACTIVE);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        readyBattleModel.CharacterBehaviorLimit = Init.CharacterBehaviorLimit.Restricted_Activity;
        //                    }
        //                }
        //                else
        //                {
        //                    readyBattleModel.CharacterBehaviorLimit = Init.CharacterBehaviorLimit.Restricted_Activity;
        //                }
        //            }
        //            else
        //            {
        //                //SkillObject so = CheckCharacterSong(uid);
        //                SkillObject so = MSkillManager.GetSongSkill(uid);
        //                if (so != null)
        //                {
        //                    if (MCCheckSkillSongByTargetState(uid))
        //                    {
        //                        readyBattleModel.songState = Init.SkillSongState.Break;
        //                    }
        //                    else {
        //                        Tool.Log("吟唱剩余回合：" + so.SongCounter);
        //                        if (MSkillManager.SongTick(so))
        //                        {
        //                            // 说明吟唱结束了  该释放技能了
        //                            AutoSkillFireModel asfm = new AutoSkillFireModel(so.SkillID, so.TargetList);
        //                            readyBattleModel.MautoSkillFireModel = asfm;
        //                        }
        //                        readyBattleModel.songState = so.SkillSongState;
        //                        readyBattleModel.SongCounter = so.SongCounter;
        //                        readyBattleModel.SongMaxCount = so.SongMaxCount;
        //                        readyBattleModel.SongSkillID = so.SkillID;
        //                    }
        //                }
        //                else
        //                {
        //                    if (characterSave.ControlType == Init.CharacterControlType.AI_Control)
        //                    {
        //                        // 这里说明是AI代管 可能是敌人AI，也可能是玩家自动，也可能是当前角色被 AI限制
        //                        MBehaviorManager.BMLogic(uid, readyBattleModel);
        //                    }
        //                    else
        //                    {
        //                        // 这里说明角色由玩家正常控制
        //                        // 当readyBattleModel.IsSong时 角色持续播放吟唱动画
        //                    }
        //                }
        //            }
        //            readyBattleModel.CharacterState = characterSave.CharacterState;
        //            Tool.Log("ReadyForBattle ------------------------------------------------------------------------------- end");
        //            return readyBattleModel;
        //        }



        //        public bool MCCheckSkillSongState(long uid) {
        //            SkillObject so = MSkillManager.GetSongSkill(uid);
        //            if (so == null) {
        //                return false;
        //            }
        //            bool isStop = false;
        //            var owner = MCGetCharacterSaveByUID(uid);
        //            Init.CharacterAIControlLimit characterAIControlLimit = MBuffManager.BuffAIControlLimit(uid);
        //            Init.CharacterBehaviorLimit characterBehaviorLimit = MBuffManager.BuffBehaviorLimit(uid);

        //            //Init.BreakSongType breakSongType = Init.BreakSongType.Cripple;
        //            if (characterAIControlLimit != Init.CharacterAIControlLimit.ControlLimit_Hurt_Any_For_Probability && characterAIControlLimit != Init.CharacterAIControlLimit.UnLimited)
        //            {
        //                MSkillManager.SongSkillStop(uid);
        //                isStop = true;
        //                //breakSongType = Init.BreakSongType.Limit_Buff;
        //            }
        //            if (characterBehaviorLimit != Init.CharacterBehaviorLimit.UnLimited)
        //            {
        //                MSkillManager.SongSkillStop(uid);
        //                isStop = true;
        //                //breakSongType = Init.BreakSongType.Limit_Buff;
        //            }

        //            if (!owner.CheckCharacterArmIsFine(so.SkillBasicsData.FireSkillArm))
        //            {
        //                MSkillManager.SongSkillStop(uid);
        //                isStop = true;
        //            }
        //            if (!owner.CheckCharacterLegIsFine(so.SkillBasicsData.FireSkillLeg))
        //            {
        //                MSkillManager.SongSkillStop(uid);
        //                isStop = true;
        //            }
        //            return isStop;
        //            //if (isStop) {
        //            //MCOnSongSkillBreakHandler(uid,attackuid,breakSkillID,split , breakSongType);
        //            //}
        //        }

        //        public bool MCCheckSkillSongByTargetState(long uid) {
        //            SkillObject so = MSkillManager.GetSongSkill(uid);
        //            if (so == null)
        //            {
        //                return false;
        //            }

        //            if (so.SkillBasicsData.SkillSelectType != Init.SkillSelectType.TYPE_ONE_ANYBODYPART && so.SkillBasicsData.SkillSelectType != Init.SkillSelectType.TYPE_ONE_BODY) {
        //                return false;
        //            }
        //            if (so.TargetList == null || so.TargetList.Count > 1 || so.TargetList.Count == 0) {
        //                return false;
        //            }

        //            var item = so.TargetList[0];
        //            var cha = MCGetCharacterSaveByUID(item.CharacterUID);
        //            if (cha == null || cha.CharacterState == Init.CharacterState.DEAD || cha.CharacterState == Init.CharacterState.REST) {
        //                MSkillManager.SongSkillStop(uid);
        //                return true;
        //            }
        //            if (item.BodyParts != null && item.BodyParts.Count > 0) {
        //                bool br = true;
        //                item.BodyParts.ForEach(bp => {
        //                    var bps = cha.GetBodyPartSave(bp);
        //                    if (!bps.Cripple) {
        //                        br = false;
        //                    }
        //                });
        //                if (br) {
        //                    MSkillManager.SongSkillStop(uid);
        //                    return true;
        //                }
        //            }
        //            {
        //                var bd = MBuffManager.GetBuffDatasByBuffID(cha.UID, 34);
        //                if (bd != null && bd.Count > 0)
        //                {
        //                    MSkillManager.SongSkillStop(uid);
        //                    return true;
        //                }
        //            }
        //            {
        //                var bd = MBuffManager.GetBuffDatasByBuffID(cha.UID, 65);
        //                if (bd != null && bd.Count > 0)
        //                {
        //                    MSkillManager.SongSkillStop(uid);
        //                    return true;
        //                }
        //            }

        //            {
        //                var bd = MBuffManager.GetBuffDatasByBuffID(cha.UID, 252);
        //                if (bd != null && bd.Count > 0)
        //                {
        //                    MSkillManager.SongSkillStop(uid);
        //                    return true;
        //                }
        //            }

        //            return false;
        //        }


        //        public SkillObject CheckCharacterSong(long uid)
        //        {
        //            Init.CharacterAIControlLimit characterAIControlLimit = MBuffManager.BuffAIControlLimit(uid);
        //            Init.CharacterBehaviorLimit characterBehaviorLimit = MBuffManager.BuffBehaviorLimit(uid);
        //            SkillObject so = MSkillManager.GetSongSkill(uid);
        //            if (so == null)
        //            {
        //                return null;
        //            }
        //            if (characterAIControlLimit != Init.CharacterAIControlLimit.ControlLimit_Hurt_Any_For_Probability && characterAIControlLimit != Init.CharacterAIControlLimit.UnLimited)
        //            {
        //                MSkillManager.SongSkillStop(uid);
        //                return null;
        //            }
        //            if (characterBehaviorLimit != Init.CharacterBehaviorLimit.UnLimited)
        //            {
        //                MSkillManager.SongSkillStop(uid);
        //                return null;
        //            }
        //            return so;
        //        }



        //        /// <summary>
        //        /// 角色死亡时，清除由该角色引起的buff
        //        /// </summary>
        //        /// <returns>The dead clean buff.</returns>
        //        /// <param name="AttackUID">Attack uid.</param>
        //        public List<SkillTargetBuffBack> AttackDeadCleanBuff(long AttackUID)
        //        {
        //            List<CharacterSave> characterSaves = MCGetAllCharacterSaves();
        //            List<SkillTargetBuffBack> result = new List<SkillTargetBuffBack>();
        //            for (int i = 0; i < characterSaves.Count; i++)
        //            {
        //                if (characterSaves[i].UID == AttackUID)
        //                {
        //                    continue;
        //                }
        //                List<SkillTargetBuffBack> s = MBuffManager.StopBuffByAttackDead(characterSaves[i].UID, AttackUID);
        //                if (s != null && s.Count > 0)
        //                {
        //                    result.AddRange(s);
        //                }
        //            }
        //            return result;
        //        }


        //        /// <summary>
        //        /// 创建临时的Open_ID 用于注册用户
        //        /// </summary>
        //        /// <returns></returns>
        //        public string CreateTempOpen_ID()
        //        {
        //            string open_id;
        //            if (PlayerPrefs.HasKey("Open_ID"))
        //            {
        //                open_id = PlayerPrefs.GetString("Open_ID");
        //            }
        //            else
        //            {
        //                open_id = "Open_ID_" + CommonTools.Tool.GetTimeStamp();
        //                PlayerPrefs.SetString("Open_ID", open_id);
        //            }
        //            return open_id;
        //        }

        //        /*---------------------------------------------------------------------*/

        //        //==================查询仓库共用数据的存档==========
        //        // public WarehouseManager MWGetAllWarehouseShareSave()
        //        // {
        //        // 仓库共用数据存档
        //        //     return MWarehouseManager.GetAllWarehouseShare();
        //        //}


        //        //==================查询仓库道具的存档==========

        //        /// <summary>
        //        /// 查询所有道具数据 
        //        /// </summary>
        //        /// <returns></returns>
        //        public List<ItemSave> MIGetAllItemSaves()
        //        {
        //            // return WarehouseManager.AllWarehouseItem;
        //            return MWarehouseManager.GetAllItemFromWarehouse();
        //        }

        //        /// <summary>
        //        /// 查询所有临时道具数据 
        //        /// </summary>
        //        /// <returns></returns>
        //        public List<ItemSave> MIGetAllTempItemSaves()
        //        {
        //            // return WarehouseManager.AllWarehouseItem;
        //            return MWarehouseManager.GetTempItemSaves();
        //        }


        //        /// <summary>
        //        /// 通过CID查找道具的数据表
        //        /// </summary>
        //        /// <param name="CID"></param>
        //        /// <returns></returns>
        //        public ItemDataTable GetItemDataTableByCID(int CID)
        //        {
        //            return MDataTableManager.GetItemDataTableByCID(CID);
        //        }
        //        /// <summary>
        //        /// 通过道具CID获得道具信息
        //        /// </summary>
        //        /// <param name="CID"></param>
        //        /// <returns></returns>
        //        public string[] GetItemInfoByCID(int CID)
        //        {
        //            return MDataTableManager.GetItemInfo_CN_ByItemId(CID);
        //        }

        //        /// <summary>
        //        /// 把道具的存档数据还原给仓库对象
        //        /// </summary>
        //        /// <param name="itemSave"></param>
        //        /// <param name="IsConOverlay"></param>
        //        public void MIAddItemToWarehouse(ItemSave itemSave, bool IsConOverlay)
        //        {
        //            MWarehouseManager.AddNewItemSaveToWarehouse(itemSave, true);
        //        }


        //        /// <summary>
        //        /// 通过UID查询饰品的存档
        //        /// </summary>
        //        /// <param name="UID"></param>
        //        /// <returns></returns>
        //        public AccessorySave GetAccessorySaveByUID(int UID)
        //        {
        //            return MWarehouseManager.GetAccessorySaveByUID(UID);
        //        }
        //        /// <summary>
        //        /// 通过CID查找饰品的数据
        //        /// </summary>
        //        /// <param name="CID"></param>
        //        /// <returns></returns>
        //        public AccessoryFinalDataTable GetAccessoryDataTableByCID(int CID)
        //        {
        //            return MDataTableManager.GetAccessoryFinalDataTableByCID(CID);
        //        }

        //        /// <summary>
        //        /// 获取所有饰品存档数据
        //        /// </summary>
        //        /// <returns></returns>
        //        public List<AccessorySave> MAGetAllAccessorySaves()
        //        {
        //            return MWarehouseManager.GetAllAccessoryFromWarehouse();
        //        }

        //        /// <summary>
        //        /// 获得可以触发的特质，返回生效的特质结果数据
        //        /// </summary>
        //        /// <param name="UID">角色的UID</param>
        //        /// <param name="time_Battle">触发时刻</param>
        //        /// <param name="traitConditonData">附加条件</param>
        //        /// <returns></returns>
        //        public List<TraitResultData> GetTriggerTraitIds(long UID, Init.TraitEffectTime_Battle time_Battle, TraitConditonData traitConditonData = null)
        //        {
        //            return MTraitManager.GetTriggerTraitIds(UID, time_Battle, traitConditonData);
        //        }
        //        /// <summary>
        //        /// 刷新特质的持续条件
        //        /// </summary>
        //        /// <param name="UID">角色UID</param>
        //        /// <param name="TickTraitKind">要刷新的类型</param>
        //        public void TraitTick(long UID, Init.TickTraitKind TickTraitKind)
        //        {
        //            switch (TickTraitKind)
        //            {
        //                case Init.TickTraitKind.RoundEnd:
        //                    {
        //                        MTraitManager.TickConditionTrait(UID, Init.TraitLastTimeKind.LastRound);
        //                    }
        //                    break;
        //                case Init.TickTraitKind.BattleEnd:
        //                    {
        //                        MTraitManager.TickConditionTrait(UID, Init.TraitLastTimeKind.ThisBattle);
        //                    }
        //                    break;
        //            }
        //        }
        //        /// <summary>
        //        /// 获得生效的特质数值
        //        /// </summary>
        //        /// <param name="UID"></param>
        //        /// <param name="effectKind"></param>
        //        /// <returns></returns>
        //        public float GetTraitEffectValue(long UID, Init.TraitValueEffectKind effectKind)
        //        {
        //            return MTraitManager.GetTraitTriggerValue(UID, effectKind);
        //        }
        //        /// <summary>
        //        /// 清空战斗中保存的特质数据，战斗结束时候调用
        //        /// </summary>
        //        public void ClearTraitData()
        //        {
        //            MTraitManager.ClearTraitData();
        //        }
        //        ///// <summary>
        //        ///// 通过特质Id获得特质的Buff效果数据
        //        ///// </summary>
        //        ///// <param name="Id"></param>
        //        ///// <returns></returns>
        //        //public List<TraitBuff> GetTraitBuffDataByTraitId(int Id)
        //        //{
        //        //    return mTraitManager.GetTraitBuffDataByTraitId(Id);
        //        //}

        //        //==================网络倒计时相关==========

        //        /// <summary>
        //        /// 封装倒计时器订阅网络监听事件后的回调方法
        //        /// </summary>
        //        public void ScribeCallMethodToNetChangedEvent()
        //        {
        //            MCountTimeManager.ScribeMethod();
        //        }

        //        /// <summary>
        //        /// 封装网络监听器事件消息的广播
        //        /// </summary>
        //        /// <param name="e"></param>
        //        public void OnNetChanged(NetListenManager.NetChangedEventArgs e)
        //        {
        //            MNetListenManager.OnNetChanged(e);

        //        }

        //        /// <summary>
        //        /// 封装网络监听器的检查网络状态方法协程
        //        /// </summary>
        //        public void CheckNet()
        //        {
        //           StartCoroutine( MNetListenManager.CheckNet());
        //        }


        //        public void RequestNetworkTime()
        //        {
        //            MServerTimeManager.RequestNetworkTime();
        //        }

        //        public DateTime DataStandardTime()
        //        {
        //            return MServerTimeManager.DataStandardTime();
        //        }

        //        public void TimeCounter()
        //        {
        //            MCountTimeManager.TimeCounter();
        //        }



    }


}


