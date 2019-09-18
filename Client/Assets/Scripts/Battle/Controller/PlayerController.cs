/****************************************************
    文件：PlayerController.cs
	作者：SIKI学院——Plane
    邮箱: 1785275942@qq.com
    日期：2018/12/14 6:1:47
	功能：表现实体角色控制器类
*****************************************************/

using UnityEngine;

public class PlayerController : Controller {
    public GameObject daggeratk1fx;

    private Transform camTrans;
    private Vector3 camOffset;

    public CharacterController ctrl;

    private float targetBlend;
    private float currentBlend;

    public override void Init() {
        base.Init();

        camTrans = Camera.main.transform;
        camOffset = transform.position - camTrans.position;

        if (daggeratk1fx != null) {
            fxDic.Add(daggeratk1fx.name, daggeratk1fx);
        }
    }

    private void Update() {
        #region Input
        /*
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 _dir = new Vector2(h, v).normalized;
        if (_dir != Vector2.zero) {
            Dir = _dir;
            SetBlend(Constants.BlendMove);
        }
        else {
            Dir = Vector2.zero;
            SetBlend(Constants.BlendIdle);
        }
        */
        #endregion

        if (currentBlend != targetBlend) {
            UpdateMixBlend();
        }

        if (isMove) {
            //设置方向
            SetDir();
            //产生移动
            SetMove();
            //相机跟随
            SetCam();
        }

        if (skillMove) {
            SetSkillMove();
            //相机跟随
            SetCam();
        }
    }

    private void SetDir() {
        float angle = Vector2.SignedAngle(Dir, new Vector2(0, 1)) + camTrans.eulerAngles.y;
        Vector3 eulerAngles = new Vector3(0, angle, 0);
        transform.localEulerAngles = eulerAngles;
    }

    private void SetMove() {
        ctrl.Move(transform.forward * Time.deltaTime * Constants.PlayerMoveSpeed);
    }

    private void SetSkillMove() {
        ctrl.Move(transform.forward * Time.deltaTime * skillMoveSpeed);
    }

    public void SetCam() {
        if (camTrans != null) {
            camTrans.position = transform.position - camOffset;
        }
    }

    private void UpdateMixBlend() {
        if (Mathf.Abs(currentBlend - targetBlend) < Constants.AccelerSpeed * Time.deltaTime) {
            currentBlend = targetBlend;
        }
        else if (currentBlend > targetBlend) {
            currentBlend -= Constants.AccelerSpeed * Time.deltaTime;
        }
        else {
            currentBlend += Constants.AccelerSpeed * Time.deltaTime;
        }
        ani.SetFloat("Blend", currentBlend);
    }

    //////////////////////////////////////////////////////////////////////////
    public override void SetBlend(float blend) {
        targetBlend = blend;
    }

    public override void SetFX(string name, float destroy) {
        GameObject go;
        if (fxDic.TryGetValue(name, out go)) {
            go.SetActive(true);
            timerSvc.AddTimeTask((int tid) => {
                go.SetActive(false);
            }, destroy);
        }
    }
}