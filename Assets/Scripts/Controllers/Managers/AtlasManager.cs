using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace Managers
{
    /// <summary>
    /// 图集管理器
    /// </summary>
    public class AtlasManager
    {
        /// <summary>
        /// 从图集中加载图片资源
        /// </summary>
        /// <returns></returns>
        public Sprite LoadSpriteByAtlas(AtlasType atlasType,string spriteName)
        {
            Sprite sprite = null;
            switch (atlasType)
            {
                case AtlasType.Coins:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/Coins").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.KlotskiGame:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/KlotskiGame").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.DrawLineGame:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/DrawLineGame").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.EquipIcon:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/EquipIcon").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.MiniGameGlob:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/MiniGameGlob").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.ArrayGame:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/ArrayGame").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.TrainingGround:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/TrainingGround").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.Tavern:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/Tavern").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.GameMap:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/GameMap").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.GameAdventureUI:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/GameAdventureUI").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.GameAreaInfoUI:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/GameAreaInfoUI").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.RoleHeadBox:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/RoleHeadBox").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.SkillBox:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/SkillBox").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.SkillIcon:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/SkillIcon").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.SkillBookUI:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/SkillBookUI").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.TeamEditUI:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/TeamEdit").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.TurnplateGame:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/TurnplateGame").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.ItemIcon:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/ItemIcon").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.RolePropertyUI:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/RolePropertyUI").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.ActionBarIcon:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/ActionBarIcon").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.RoleHeadIcon:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/RoleHeadIcon").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.BuffIcon:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/BuffIcon").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.FinalRewardUI:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/FinalRewardUI").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.Arena:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/Arena").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.WarehouseUI:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/WarehouseUI").GetSprite(spriteName);
                    }
                    break;
                case AtlasType.AltarUI:
                    {
                        sprite = Resources.Load<SpriteAtlas>("Atlas/AltarUI").GetSprite(spriteName);
                    }
                    break;
            }
            return sprite;
        }
    }

    /// <summary>
    /// 图集的枚举
    /// </summary>
    public enum AtlasType
    {
        /// <summary>
        /// 货币
        /// </summary>
        Coins,
        /// <summary>
        /// 华容道游戏
        /// </summary>
        KlotskiGame,
        /// <summary>
        /// 画线游戏
        /// </summary>
        DrawLineGame,
        /// <summary>
        /// 组合游戏
        /// </summary>
        ArrayGame,
        /// <summary>
        /// 护甲图标
        /// </summary>
        EquipIcon,
        /// <summary>
        /// 迷你游戏通用图集
        /// </summary>
        MiniGameGlob,
        /// <summary>
        /// 修炼场
        /// </summary>
        TrainingGround,
        /// <summary>
        /// 酒馆
        /// </summary>
        Tavern,
        /// <summary>
        /// 游戏地图
        /// </summary>
        GameMap,
        /// <summary>
        /// 游戏冒险界面
        /// </summary>
        GameAdventureUI,
        /// <summary>
        /// 游戏区域信息UI
        /// </summary>
        GameAreaInfoUI,
        /// <summary>
        /// 角色头像盒子
        /// </summary>
        RoleHeadBox,
        /// <summary>
        /// 技能盒子
        /// </summary>
        SkillBox,
        /// <summary>
        /// 技能图标
        /// </summary>
        SkillIcon,
        /// <summary>
        /// 技能书UI
        /// </summary>
        SkillBookUI,
        /// <summary>
        /// 编队
        /// </summary>
        TeamEditUI,
        /// <summary>
        /// 转轮游戏
        /// </summary>
        TurnplateGame,
        /// <summary>
        /// 全部道具图集（包括消耗品、饰品）
        /// </summary>
        ItemIcon,
        /// <summary>
        /// 角色属性UI
        /// </summary>
        RolePropertyUI,
        /// <summary>
        /// 角色头像图标-行动条
        /// </summary>
        ActionBarIcon,
        /// <summary>
        /// 角色头像图标-UI
        /// </summary>
        RoleHeadIcon,
        /// 总结算UI
        /// </summary>
        FinalRewardUI,
        /// <summary>
        /// 角色Buff图标
        /// </summary>
        BuffIcon,
        /// <summary>
        /// 竞技场
        /// </summary>
        Arena,
        /// <summary>
        /// 仓库UI
        /// </summary>
        WarehouseUI,
        /// <summary>
        /// 祭坛UI
        /// </summary>
        AltarUI
    }
}
