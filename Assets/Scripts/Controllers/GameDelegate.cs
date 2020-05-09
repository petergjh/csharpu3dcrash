using UnityEngine;
using System.Collections;
using Models;

public delegate void ReceiveDamageResultHandler(string str);

public delegate void SendGamePropStopHandler(long characterUID,long gamePropUID);

public delegate void HttpRequestComplate(bool yes);

/// <summary>
/// 专门用于通知 吟唱技能被打断的委托
/// </summary>
/// <param name="uid"></param>
/// <param name="attack">打断该次吟唱的技能的释放者UID</param>
/// <param name="skillid">打断该次吟唱的技能ID</param>
/// <param name="split">技能中的第几段被打断</param>
/// <param name="breakSong">打断吟唱的原因</param>
public delegate void SongSkillBreakHandler(long uid, long attack, int skillid, int split, Init.BreakSongType breakSong);
