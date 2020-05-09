/* ***********************************************
* Discribe：
* ************************************************/
using UnityEngine;
using System.Collections.Generic;
using Models;
using System.IO;
//using LitJson;
using System;
using System.Security.Cryptography;

namespace Managers
{
    /// <summary>
    /// 游戏存档管理类
    /// </summary>
    public class GameArchiveManager :IGameSystem
    {
        void Start()
        {
            Debug.unityLogger.logEnabled =false;

        }
        const string File_Directory_Name = "/GameArchive";
        private static string saveFileDirect = Application.streamingAssetsPath + File_Directory_Name;
        // const string File_Archive_Name = "GameData.json";
        private static string key = "12345678912345678912345678912345";
        public static  int filename_id;
        private static string filePath=""; //  定义一个公共静态字段存放存档名称，用于生成存档文件名

        public GameArchiveManager(ManagerController mc) : base(mc)
        {
        }

        public GameArchive  MainGameArchive{get;set;} // 需要序列化的游戏数据对象
        public static int Archive_Index { get; set; } = 0;

        public List<GameArchive> LoadGameArchives()
        {
            // MainGameArchive = LoadArchive();
            //MainGameArchive = LoadArchive(filename_id);
            if (MainGameArchive!=null) {
                return null ;
            }
            return null;
        }

       //public void StartGameByIndex(int index) {
       //    Archive_Index = index;
       //    if (MainGameArchive == null) {
       //        MainGameArchive = new GameArchive();
       //    }
       //    GameArchive ga =MainGameArchive;
       //    if (ga == null)
       //    {
       //        ga = CreateGameArchive();
       //        //MainGameArchive.List_CharacterArchives.Add();
       //    }
       //    else {
       //          // 数据赋值
       //       //  for (int i = 0;i < ga.List_CharacterArchives.Count;i++) {
       //       //     ManagerController.Instance.MSaveManager.LoadCharacter(ga.List_CharacterArchives[i]);
       //       // }
       //        //ManagerController.Instance.LoadGameArchiveToCharacterSave(ga.List_CharacterArchives);
       //    }
       //}

        /// <summary>
        /// 删除指定编号存档
        /// </summary>
        /// <param name="index"></param>
        public static void DeleteGameByIndex(int index)
        {

            Archive_Index = index;
            string fileFullPath = Application.streamingAssetsPath + File_Directory_Name + "/save"+Archive_Index + ".json";
            Debug.Log("要删除的存档路径是：" + fileFullPath);
                // 1、首先判断文件或者文件路径是否存在
                if (File.Exists(fileFullPath))
                {
                    // 2、根据路径字符串判断是文件还是文件夹
                    FileAttributes attr = File.GetAttributes(fileFullPath);
                    // 3、根据具体类型进行删除
                    if (attr == FileAttributes.Directory)
                    {
                        // 3.1、删除文件夹
                        Directory.Delete(fileFullPath, true);
                    }
                    else
                    {
                        // 3.2、删除文件
                        File.Delete(fileFullPath);
                    }
                    File.Delete(fileFullPath);
                }
        }

        /// <summary>
        /// 手动存档操作方法
        /// </summary>
        public void Save()
        {
            if (MainGameArchive == null) {
                MainGameArchive = new GameArchive();
            }
            //UpdateGameArchiveData();
            Debug.Log("更新存档数据已完成。");

            string json = JsonUtility.ToJson(MainGameArchive);
            //string JsonStr =JsonMapper.ToJson(MainGameArchive);
            Debug.Log("存档数据已转为Json字符串");

            //JsonStr = DataEncrypt.RijndaelEncrypt(JsonStr, key);
            Debug.Log("存档完成加密。");

            //SaveToArchive(JsonStr);
            Debug.Log("存档操作已完成.");
        }

     //   public GameArchive GetGameArchive() {
     //     for (int i = 0; i < MainGameArchive.List_GameArchives.Count; i++)
     //      {
     //          if (MainGameArchive.List_GameArchives[i].Index == Archive_Index) {
     //              return MainGameArchive.List_GameArchives[i];
     //          }
     //      }
     //      return null;
     //   }


        /// <summary>
        /// 创建游戏存档
        /// </summary>
        /// <returns></returns>
        //public GameArchive CreateGameArchive() {
        //    GameArchive ga = new GameArchive();
        //   // ga.Index = Archive_Index;
        //    List<CharacterSave> characters = SystemManager.MCGetAllCharacterSaves();
        //    for (int i = 0; i < characters.Count; i++)
        //    {
        //        CharacterArchive ca = CreateCharacterArchive(characters[i]);
        //        ga.List_CharacterArchives.Add(ca);
        //    }
        //    return ga;
        //}

        //       public void UpdateGameArchiveData() {
        //           GameArchive ga = GetGameArchive();
        //           if (ga == null)
        //           {
        //               ga = CreateGameArchive();
        //               MainGameArchive.List_GameArchives.Add(ga);
        //           }
        //           else {
        //               ga.List_CharacterArchives.RemoveAll(j => true);
        //               List<CharacterSave> characters = SystemManager.MCGetAllCharacterSaves();
        //               for (int i = 0; i < characters.Count; i++)
        //               {
        //                   CharacterArchive ca = CreateCharacterArchive(characters[i]);
        //                   ga.List_CharacterArchives.Add(ca);
        //               }
        //           }
        //           
        //       }

        /// <summary>
        /// 更新存档数据
        /// </summary>
        //public void UpdateGameArchiveData()
        //{
        //    GameArchive ga = MainGameArchive;

        //    // 获取角色存档数值------------------------------------------
        //    ga.List_CharacterArchives.RemoveAll (j => true);
        //    Debug.Log("清空存档所有角色的数据");
        //    List<CharacterSave> characters = SystemManager.MCGetAllCharacterSaves();
        //    Debug.Log("开始查询所有角色数据并加入到存档数据中");
        //    for (int i = 0; i < characters.Count; i++)
        //    {
        //        CharacterArchive ca = CreateCharacterArchive(characters[i]);
        //        ga.List_CharacterArchives.Add(ca);
        //    }

        //    // 获取道具存档数据--------------------------------------------
        //    ga.WarehouseArchives.List_ItemArchives.RemoveAll(j => true);

        //    Debug.Log("开始查询所有道具对象的数据并加入到存档对象中");
        //    List<ItemSave> items = SystemManager.MIGetAllItemSaves();
        //    for (int i = 0; i < items.Count; i++)
        //    {
        //        ItemArchive ia = CreateItemArchive(items[i]);
        //        ga.WarehouseArchives.List_ItemArchives.Add(ia);
        //    }

        //    Debug.Log("开始查询所有临时道具对象的数据并加入到存档对象中");
        //    List<ItemSave> tempItems = SystemManager.MIGetAllTempItemSaves();
        //    for (int i = 0; i < tempItems.Count; i++)
        //    {
        //        ItemArchive ia = CreateItemArchive(tempItems[i]);
        //        ga.WarehouseArchives.List_ItemArchives.Add(ia);
        //    }

        //    // 获取饰品存档数据---------------------------------------------
        //    ga.WarehouseArchives.List_AccessoryArchives.RemoveAll(j => true);

        //    Debug.Log("开始查询所有饰品对象的数据并加入到存档对象中");
        //    List<AccessorySave> accessorys = SystemManager.MAGetAllAccessorySaves();
        //    for (int i = 0; i < accessorys.Count; i++)
        //    {
        //        AccessoryArchive aa = CreateAccessoryArchive(accessorys[i]);
        //        ga.WarehouseArchives.List_AccessoryArchives.Add(aa);
        //    }

        //    // 获取仓库存档数据----------------------------------------------
        //    WarehouseManager ws = ManagerController.Instance.MWarehouseManager;
        //    Debug.LogFormat("开始获取仓库存档数据. 道具UID计数器值是：{0}， 饰品UID计数器值是:{1}", ws.ItemUIDCounter, ws.AccessoryUIDCounter);
        //    ga.WarehouseArchives.ItemUIDCounter = ws.ItemUIDCounter;
        //    ga.WarehouseArchives.AccessoryUIDCounter = ws.AccessoryUIDCounter;

        //    // 获取货币存档数据----------------------------------------------
        //    CoinManager cs = ManagerController.Instance.MCoinManager;
        //    ga.CoinArchives.CoinPermanent.Gold= cs.CoinSave.Gold;
        //    ga.CoinArchives.CoinPermanent.Silver= cs.CoinSave.Silver;
        //    ga.CoinArchives.CoinPermanent.Copper= cs.CoinSave.Copper;
        //    ga.CoinArchives.CoinTemporary.Gold= cs.TempCoinSave.Gold;
        //    ga.CoinArchives.CoinTemporary.Silver= cs.TempCoinSave.Silver;
        //    ga.CoinArchives.CoinTemporary.Copper= cs.TempCoinSave.Copper;

        //    // 获取场景存档数据----------------------------------------------
        //    GameSceneManager ss = ManagerController.Instance.MGameSceneManager;
        //    ga.SceneArchives.IsFirstRollDice = ss.IsFirstRollDice;
        //    ga.SceneArchives.IsStartAdventure = ss.IsStartAdventure;
        //    ga.SceneArchives.IsBattleFinalBoss = ss.IsBattleFinalBoss;
        //    ga.SceneArchives.IsRewardMissionTarget = ss.IsRewardMissionTarget;
        //    ga.SceneArchives.IsStartBattle = ss.IsStartBattle;
        //    ga.SceneArchives.CurrentMissionKind = ss.CurrentMissionKind;
        //    ga.SceneArchives.GameScene = ss.GameScene;
        //    ga.SceneArchives.SceneLv = ss.SceneLv;
        //    ga.SceneArchives.StrengthKind = ss.StrengthKind;
        //    ga.SceneArchives.BattleStateKind = ss.BattleStateKind;
        //    ga.SceneArchives.IsBossBattle = ss.IsBossBattle;
        //    ga.SceneArchives.MeetEnemyIdList = ss.MeetEnemyIdList;
        //    ga.SceneArchives.CurrentMapSceneType = ss.CurrentMapSceneType;


        //    // 获取地图存档数据---------------------------------------------

        //    Debug.Log("清空存档所有地图列表对象的数据");        //    ga.List_MapNodesArchives.RemoveAll(j => true);        //    // 得到manager的save        //    MapNodeManager mapNodesSave = ManagerController.Instance.MMapNodeManager;        //    // 得到n列节点的save        //    List<List<MapNode>> mapNodesColumns = mapNodesSave.MapNodes;        //    if (mapNodesColumns != null)
        //    {
        //        for (int i = 0; i < mapNodesColumns.Count; i++)
        //        {
        //            Debug.Log(" 得到一列节点的存档");
        //            MapColumnNodeArchive mnal = CreateMapNodeArchiveList(mapNodesColumns[i]);
        //            ga.List_MapNodesArchives.Add(mnal);

        //        }
        //    }


        //}



        /*------------------------------------------------------------------------*/
        /// <summary>
        /// 创建一个角色存档的方法
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        //public CharacterArchive CreateCharacterArchive(CharacterSave cs) {
        //    CharacterArchive ca = new CharacterArchive
        //    {
        //        UID = cs.UID,
        //        CID = cs.CID,
        //        Level = cs.GetRealLevel(),
        //        FTG = cs.FTG,
        //        EXP = cs.Exp,
        //        CombatPosition = cs.CombatPosition,
        //        CharacterState = cs.CharacterState,
        //        CharacterCamp = cs.CharacterCamp,
        //        MP = cs.MP,
        //    };
        //    for (int i = 0;i<cs.BodyParts.Count;i++) {
        //        BodyPartArchive bpa = CreateBodyPartArchive(cs.BodyParts[i]);
        //        ca.List_BodyPart.Add(bpa);
        //    }

        //    foreach (var vk in cs.GetActivateSkillLevel()) {
        //        SkillLevelArchive sla = CreateSkillLevelArchive(vk.Key,vk.Value);
        //        ca.List_SkillLevelArchive.Add(sla);
        //    }

        //    for (int i = 0;i<cs.GetEnterSkills().Count;i++) {
        //        ca.List_EnterSkills.Add(cs.GetEnterSkills()[i]);
        //    }

        //    return ca;
        //}

        //public BodyPartArchive CreateBodyPartArchive(BodyPartSave bps) {
        //    BodyPartArchive bpa = new BodyPartArchive {
        //        BodyPartName = bps.BodyPartName,
        //        Level = bps.Level,
        //        CurrentBodyPartBlood = bps.GetRealBlood(),
        //        CurrentEquipBlood = bps.EquipBlood,
        //    };
        //    return bpa;
        //}

        public SkillLevelArchive CreateSkillLevelArchive(int skillID,int level) {
            SkillLevelArchive sla = new SkillLevelArchive {
                SkillID = skillID,
                Level = level,
            };
            return sla;
        }


        /*------------------------------------------------------------------------*/
        /// <summary>
        /// 创建一个道具存档的方法
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
       // public ItemArchive CreateItemArchive(ItemSave _is)
       // {
       //     Debug.Log("开始根据道具的存档save内容来创建出存档archive数值");
       //     ItemArchive ia = new ItemArchive
       //     {
       //         UID = _is.UID,
       //         CID = _is.CID,
       //         Count = _is.Count,
       //         ItemKind = _is.ItemKind,
       //         ItemOrAccessory = _is.ItemOrAccessory,
       //         AccessoryCreateKind = _is.AccessoryCreateKind,
       //         IsTemp = _is.IsTemp

       //     };
       //     Debug.Log("新建一个ItemArchive实例,把ItemSave的数据赋值给它");

       //     for (int i = 0; i < _is.EquipRoleInfoList.Count; i++)
       //     {
       //         EquipRoleInfoArchive eria = CreatEquipRoleInfoArchive(_is.EquipRoleInfoList[i]);
       //         ia.EquipRoleInfoList.Add(eria);
       //         Debug.Log("获取所有穿上道具的角色: " + _is.EquipRoleInfoList[i]);
       //     }

       //     Debug.Log("成功创建道具存档ItemArchive"+ia);
       //     return ia;

       // }

       // public EquipRoleInfoArchive CreatEquipRoleInfoArchive(EquipRoleInfo eri)
       // {
       //     EquipRoleInfoArchive eria = new EquipRoleInfoArchive
       //     {
       //         EquipRoleUID = eri.EquipRoleUID,
       //         ConsumableEquipPos = eri.ConsumableEquipPos,
       //     };
       //     Debug.Log("已经创建穿上道具的角色存档: "+eri);
       //     return eria;
       // }


       // /*----------------------------------------------------------------------*/
       // // 创建一个饰品存档的方法
       //public AccessoryArchive CreateAccessoryArchive (AccessorySave _as)
       // {
       //     Debug.Log("开始根据饰品的save存档内容来创建出archive存档数值");
       //     AccessoryArchive aa = new AccessoryArchive
       //     {
       //         UID = _as.UID,
       //         CID = _as.CID,
       //         UserUID=_as.UserUID,
       //         equipPos = _as.EquipPos,
       //         AccessoryQuality= _as.AccessoryQuality,
       //         // AccEffect = _as.AccEffect,
       //         RandomIconId = _as.RandomIconId
       //     };
       //     // 饰品效果
       //     aa.AccEffect.AccessoryCreateKind = _as.AccEffect.AccessoryCreateKind;
       //     aa.AccEffect.EffectId = _as.AccEffect.EffectId;
       //     if (aa.AccEffect.AccessoryCreateKind == Init.AccessoryCreateKind.RandomCreate)
       //     {
       //         // 饰品随机属性
       //         for (int i = 0; i < _as.AccEffect.AccessoryRandomAttDatas.Count; i++)
       //         {
       //             AccessoryRandomAttDataArchive carada = CreatAccessoryRandomAttDataArchive(_as.AccEffect.AccessoryRandomAttDatas[i]);
       //             aa.AccEffect.AccessoryRandomAttDatas.Add(carada);
       //         }
       //     }
       //     return aa;
       // }

       // private AccessoryRandomAttDataArchive CreatAccessoryRandomAttDataArchive(AccessoryRandomAttData accessoryRandomAttData)
       // {
       //     // 获取单个饰品的单个属性值
       //     AccessoryRandomAttDataArchive arada = new AccessoryRandomAttDataArchive();
       //     arada.AccessoryRandomAttKind = accessoryRandomAttData.AccessoryRandomAttKind;
       //     arada.AttValue = accessoryRandomAttData.AttValue;
       //     return arada;

       // }


       // /*----------------------------------------------------------------------*/
       // // 创建地图一列节点存档的方法

       // /// <summary>
       // /// 获取地图单列节点的数据
       // /// </summary>
       // /// <param name="mapNodes"></param>
       // /// <returns></returns>
       // public MapColumnNodeArchive CreateMapNodeArchiveList(List<MapNode> mapAColumnNodes)
       // {
       //     MapColumnNodeArchive mcna = new MapColumnNodeArchive();
       //         for (int i = 0; i < mapAColumnNodes.Count; i++)
       //         {
       //             // 获取单个节点的数据
       //             MapNodeArchive smna = CreateMapNodeArchive(mapAColumnNodes[i]);
       //             if (smna != null)
       //             {
       //                 mcna.MapColumnNodes.Add(smna);
       //             }
       //         }

       //     return mcna;
            
       // }

       // /// <summary>
       // /// 获取单个节点的数据
       // /// </summary>
       // /// <param name="mna"></param>
       // /// <returns></returns>       // public MapNodeArchive CreateMapNodeArchive(MapNode mapANode)
       // {
       //     if (mapANode != null)
       //     {
       //         MapNodeArchive asmna = new MapNodeArchive();
       //         asmna.NodeId = mapANode.NodeId;
       //         asmna.EventId = mapANode.EventId;
       //         asmna.LayerIndex = mapANode.LayerIndex;
       //         asmna.ColIndex = mapANode.ColIndex;
       //         asmna.ColPosIndex = mapANode.ColPosIndex;
       //         asmna.IsTrigger = mapANode.IsTrigger;
                
       //         // 节点位置
       //         asmna.LocalPos = CreateVector3Archive(mapANode.LocalPos);

       //         // 子节点列表
       //         for(int i=0;i<mapANode.ChildrenNodes.Count;i++)
       //         {
       //             int cnid = mapANode.ChildrenNodes[i].NodeId; 
       //             asmna.ChildrenNodesID.Add(cnid);
       //         }

       //         // 父节点列表
       //         for(int i=0;i<mapANode.FatherNodes.Count;i++)
       //         {
       //             int fnid = mapANode.FatherNodes[i].NodeId; 
       //             asmna.FatherNodesID.Add(fnid);
       //         }

       //         return asmna;
       //     }
       //         return null;

       // }

       // // 把vector位置float类型先转为string再转为LitJson支持的double类型
       // public Vector3Archive CreateVector3Archive(Vector2 v2)
       // {
       //     Vector3Archive v3a = new Vector3Archive();
       //     v3a.x = double.Parse(v2.x.ToString());
       //     v3a.y = double.Parse(v2.y.ToString());
       //     return v3a;
       // }



       // /*----------------------------------------------------------------------*/
       // // 文件处理相关

       // /// <summary>
       // /// 创建文件夹
       // /// </summary>
       // /// <param name="filePath"></param>
       // //
       // public static void CreateDirectory(string filePath) {
       //     if (IsDirectoryExists(filePath)) {
       //         return;
       //     }
       //     CommonTools.Tool.Log("没有找到这个文件,需要创建:"+filePath);
       //     Directory.CreateDirectory(filePath);
       // }

       // /// <summary>
       // /// 判断文件夹是否存在
       // /// </summary>
       // /// <param name="filePath"></param>
       // /// <returns></returns>
       // public static bool IsDirectoryExists(string filePath) {
       //     return Directory.Exists(filePath);
       // }

       // public static bool IsFileExists(string fileName) {
       //     return File.Exists(fileName);
       // }

       // public static void CreateFile(string fileName,string data) {

       //     CreateDirectory(saveFileDirect);
       //     StreamWriter sw = File.CreateText(fileName);
       //     sw.Write(data);
       //     sw.Close();
       //     filePath = Path.GetFullPath(fileName);
       //     Debug.LogFormat("已创建存档文件: {0}. ",filePath);
       // }

       // public void WriterFile(string fileName,string data) {
       //     StreamWriter sw = new StreamWriter(fileName);
       //     sw.Write(data);
       //     sw.Close();
       //     Debug.LogFormat("已写入存档文件: {0}", fileName);
       // }

       // public void SaveToFile(string fileName, string data) {
       //     if (IsFileExists(fileName))
       //     {
       //         CommonTools.Tool.Log("这里找到这个文件了，直接读取" + fileName);
       //         Debug.LogFormat("正在读取已有存档文件: {0}。", fileName);
       //         WriterFile(fileName,data);
               
       //     }
       //     else {
       //         CreateFile(fileName, data);
       //         Debug.LogFormat("未找到存档文件，正在创建 {0} ", fileName);

       //     }
       // }

       // public void SaveToArchive(string data)
       // {
       //     string path = Application.streamingAssetsPath + File_Directory_Name;
       //     CreateDirectory(path);
       //     // path += "/" + File_Archive_Name;
       //     path += "/save" + filename_id+".json";
       //     SaveToFile(path,data);
       // }

       // public static GameArchive LoadArchive(int save_id) {
       //     // string path = Application.streamingAssetsPath + File_Directory_Name +"/"+File_Archive_Name;
       //    filename_id= save_id;
       //     string path = Application.streamingAssetsPath + File_Directory_Name +"/save"+save_id+".json";
       //     Debug.Log("需要加载的存档路径是：" + path);
       //     if (IsFileExists(path)) {
       //         try
       //         {
       //             StreamReader sr = new StreamReader(path);
       //             string json = sr.ReadToEnd();
       //             sr.Close();
       //             Debug.Log("存档文件已经读入内存");

       //             //json = DataEncrypt.RijndaelDecrypt(json, key);
       //             Debug.Log("存档解密完成");

       //             GameArchive ga = JsonMapper.ToObject<GameArchive>(json);
       //             Debug.LogFormat("存档{0}数据 已加载到游戏对象",save_id);

       //             Debug.Log("还原角色存档到对象： " + ga.List_CharacterArchives);
       //             ManagerController.Instance.LoadGameArchiveToCharacterSave(ga.List_CharacterArchives);

       //             Debug.Log("还原仓库存档到对象");
       //             ManagerController.Instance.LoadGameArchiveToWarehouseSave(ga.WarehouseArchives);

       //             Debug.Log("还原货币存档到对象");
       //             ManagerController.Instance.LoadGameArchiveToCoinSave(ga.CoinArchives);

       //             Debug.Log("还原场景存档到对象");
       //             ManagerController.Instance.LoadGameArchiveToSceneSave(ga.SceneArchives);

       //             Debug.Log("还原地图存档到对象");
       //             ManagerController.Instance.LoadGameArchiveToMapSave(ga.List_MapNodesArchives);
       //         }
       //         catch
       //         {
       //             CommonTools.Tool.Log("存档数据损坏");
       //         }
                
       //     }
       //     return null;
            
       // }


        /*----------------------------------------------------------------------*/

        public CharacterArchive GetCharacterArchive(long uid)
        {
            
            return null;
        }

    }
}


