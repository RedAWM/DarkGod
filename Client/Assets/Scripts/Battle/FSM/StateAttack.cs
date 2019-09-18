/****************************************************
	文件：StateAttack.cs
	作者：SIKI学院——Plane
	邮箱: 1785275942@qq.com
	日期：2019/03/20 8:30   	
	功能：攻击状态
*****************************************************/

public class StateAttack : IState {
    public void Enter(EntityBase entity, params object[] args) {
        entity.currentAniState = AniState.Attack;
        PECommon.Log("Enter StateAttack.");
    }

    public void Exit(EntityBase entity, params object[] args) {
        entity.canControl = true;
        entity.SetAction(Constants.ActionDefault);
        PECommon.Log("Exit StateAttack.");
    }

    public void Process(EntityBase entity, params object[] args) {
        entity.AttackEffect((int)args[0]);
        PECommon.Log("Process StateAttack.");
    }
}
