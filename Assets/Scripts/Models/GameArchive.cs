using UnityEngine;
using System.Collections.Generic;
using System;

namespace Models {
    // [Serializable]
    // public class GameArchiveWrap {
    //     public List<GameArchive> List_GameArchives = new List<GameArchive>();
    // }


    /// <summary>
    /// 游戏主存档
    /// </summary>
    [Serializable]
    // public int index;

    public class GameArchive
    {
        // 角色存档
        public List<CharacterArchive> List_CharacterArchives = new List<CharacterArchive>();

        //// 仓库存档
        //public WarehouseArchive WarehouseArchives = new WarehouseArchive();

        //// 金币存档
        //public CoinArchive CoinArchives= new CoinArchive();

        //// 场景存档
        //public SceneArchive SceneArchives = new SceneArchive();

        //// 地图存档
        //public List<MapColumnNodeArchive> List_MapNodesArchives = new List<MapColumnNodeArchive>();
    }
}


