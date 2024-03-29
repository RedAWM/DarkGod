/****************************************************
	文件：StateIdle.cs
	作者：SIKI学院——Plane
	邮箱: 1785275942@qq.com
	日期：2019/03/19 6:41   	
	功能：待机状态
*****************************************************/

using UnityEngine;

public class StateIdle : IState {
    public void Enter(EntityBase entity, params object[] args) {
        entity.currentAniState = AniState.Idle;
        entity.SetDir(Vector2.zero);
        PECommon.Log("Enter StateIdle.");
    }

    public void Exit(EntityBase entity, params object[] args) {
        PECommon.Log("Exit StateIdle.");
    }

    public void Process(EntityBase entity, params object[] args) {
        if (entity.GetDirInput() != Vector2.zero) {
            entity.Move();
            entity.SetDir(entity.GetDirInput());
        }
        else {
            entity.SetBlend(Constants.BlendIdle);
        }
        PECommon.Log("Process StateIdle.");
    }
}
