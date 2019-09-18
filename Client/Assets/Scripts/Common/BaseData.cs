/****************************************************
	文件：BaseData.cs
	作者：SIKI学院——Plane
	邮箱: 1785275942@qq.com
	日期：2018/12/14 6:54   	
	功能：配置数据类
*****************************************************/

using System.Collections.Generic;
using UnityEngine;

public class SkillMoveCfg : BaseData<SkillMoveCfg> {
    public int delayTime;
    public int moveTime;
    public float moveDis;
}

public class SkillCfg : BaseData<SkillCfg> {
    public string skillName;
    public int skillTime;
    public int aniAction;
    public string fx;
    public List<int> skillMoveLst;
}

public class StrongCfg : BaseData<StrongCfg> {
    public int pos;
    public int startlv;
    public int addhp;
    public int addhurt;
    public int adddef;
    public int minlv;
    public int coin;
    public int crystal;
}

public class AutoGuideCfg : BaseData<AutoGuideCfg> {
    public int npcID;//触发任务目标NPC索引号
    public string dilogArr;
    public int actID;
    public int coin;
    public int exp;
}

public class MapCfg : BaseData<MapCfg> {
    public string mapName;
    public string sceneName;
    public int power;
    public Vector3 mainCamPos;
    public Vector3 mainCamRote;
    public Vector3 playerBornPos;
    public Vector3 playerBornRote;
}

public class TaskRewardCfg : BaseData<TaskRewardCfg> {
    public string taskName;
    public int count;
    public int exp;
    public int coin;
}

public class TaskRewardData : BaseData<TaskRewardData> {
    public int prgs;
    public bool taked;
}

public class BaseData<T> {
    public int ID;
}
