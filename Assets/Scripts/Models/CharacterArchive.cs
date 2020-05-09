using UnityEngine;
using System.Collections.Generic;
using System;

namespace Models {
    /// <summary>
    /// 角色存档数据
    /// </summary>
   [Serializable]
    public class CharacterArchive
    {
        public long UID;
        public int CID;
        public int Level;
        public float FTG;
        public float EXP;
        public float MP;
        //public Init.CombatPosition CombatPosition;
        //public Init.CharacterState CharacterState;
        //public Init.CharacterCamp CharacterCamp;
        /// <summary>
        /// 身体各部位的存档
        /// </summary>
        public List<BodyPartArchive> List_BodyPart = new List<BodyPartArchive>();
        /// <summary>
        /// 拥有的技能及等级
        /// </summary>
        public List<SkillLevelArchive> List_SkillLevelArchive = new List<SkillLevelArchive>();

        /// <summary>
        /// 上场的技能
        /// </summary>
        public List<int> List_EnterSkills = new List<int>();

    }
    [Serializable]
    public class BodyPartArchive {
        public string BodyPartName;
        public int Level;
        public float CurrentBodyPartBlood;
        public float CurrentEquipBlood;

    }
    [Serializable]
    public class SkillLevelArchive {
        public int SkillID;
        public int Level;
    }

}


