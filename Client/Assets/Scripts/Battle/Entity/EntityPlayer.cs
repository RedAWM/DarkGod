/****************************************************
	文件：EntityPlayer.cs
	作者：SIKI学院——Plane
	邮箱: 1785275942@qq.com
	日期：2019/03/19 7:13   	
	功能：玩家逻辑实体
*****************************************************/

using UnityEngine;

public class EntityPlayer : EntityBase {

    public override Vector2 GetDirInput() {
        return battleMgr.GetDirInput();
    }
}
