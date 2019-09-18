/****************************************************
	文件：SkillMgr.cs
	作者：SIKI学院——Plane
	邮箱: 1785275942@qq.com
	日期：2019/03/15 9:09   	
	功能：技能管理器
*****************************************************/
using System.Collections.Generic;
using UnityEngine;

public class SkillMgr : MonoBehaviour {
    private ResSvc resSvc;
    private TimerSvc timeSvc;

    public void Init() {
        resSvc = ResSvc.Instance;
        timeSvc = TimerSvc.Instance;
        PECommon.Log("Init SkillMgr Done.");
    }

    /// <summary>
    /// 技能效果表现
    /// </summary>
    public void AttackEffect(EntityBase entity, int skillID) {
        SkillCfg skillData = resSvc.GetSkillCfg(skillID);

        entity.SetAction(skillData.aniAction);
        entity.SetFX(skillData.fx, skillData.skillTime);

        CalcSkillMove(entity, skillData);

        entity.canControl = false;
        entity.SetDir(Vector2.zero);

        timeSvc.AddTimeTask((int tid) => {
            entity.Idle();
        }, skillData.skillTime);
    }

    private void CalcSkillMove(EntityBase entity, SkillCfg skillData) {
        List<int> skillMoveLst = skillData.skillMoveLst;
        int sum = 0;
        for (int i = 0; i < skillMoveLst.Count; i++) {
            SkillMoveCfg skillMoveCfg = resSvc.GetSkillMoveCfg(skillData.skillMoveLst[i]);
            float speed = skillMoveCfg.moveDis / (skillMoveCfg.moveTime / 1000f);
            sum += skillMoveCfg.delayTime;
            if (sum > 0) {
                timeSvc.AddTimeTask((int tid) => {
                    entity.SetSkillMoveState(true, speed);
                }, sum);
            }
            else {
                entity.SetSkillMoveState(true, speed);
            }

            sum += skillMoveCfg.moveTime;
            timeSvc.AddTimeTask((int tid) => {
                entity.SetSkillMoveState(false);
            }, sum);
        }
    }
}
