using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StickType {
    /** 固定遥杆 */
    Normal = 1,
    /** 遥杆在点击处作为开始点 */
    CurTouch,
}
/**
  * 角色摇杆
  */
public class JoyStick : MonoBehaviour
{
    /** 画布 */
    public Canvas canvas2D;
    /** 摇杆节点 */
    public GameObject stickNode;
    /** 摇杆 */
    public Image stickCircle;
    /** 触碰类型 */
    public StickType stickType = StickType.Normal;
    /** 摇杆最大拖动半径 */
    public float maxR;
    /** 摇杆初始位置 */
    public Vector2 startPos = new Vector2(0, -400);

    /** 遥杆向量 */
    public Vector2 dir = Vector2.zero;

    void Start()
    {
        this.resetJoystick();
    }

    void Update()
    {

    }

    public void OnDragStart() {
        switch(this.stickType){
            case StickType.Normal: {
                break;
            }
            case StickType.CurTouch: {
                // this.stickNode.transform.set;
                // GameObject _stick = this.
                Vector2 touchLocalPos;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(this.transform as RectTransform, Input.mousePosition, this.canvas2D.worldCamera, out touchLocalPos);
                this.stickNode.transform.localPosition = touchLocalPos;
                break;
            }
        }
    }

    public void OnDragMove() {
        Vector2 touchLocalPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(this.stickNode.transform as RectTransform, Input.mousePosition, this.canvas2D.worldCamera,out touchLocalPos);
        float len = touchLocalPos.magnitude;
        if (len > this.maxR) {
            touchLocalPos = touchLocalPos.normalized * this.maxR;
        }
        this.dir = touchLocalPos.normalized;
        this.stickCircle.transform.localPosition = touchLocalPos;
    }

    public void OnDragEnd() {
        this.resetJoystick();
    }

    void resetJoystick() {
        this.dir = Vector2.zero;
        this.stickCircle.transform.localPosition = Vector2.zero;
        this.stickNode.transform.localPosition = this.startPos;
    }
}
