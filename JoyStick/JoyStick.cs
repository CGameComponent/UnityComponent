using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
  * 角色摇杆
  */
public class JoyStick : MonoBehaviour
{
    /** 画布 */
    public Canvas canvas2D;
    /** 摇杆 */
    public Image stick;
    /** 摇杆最大拖动半径 */
    public float maxR;

    public Vector2 dir = Vector2.zero;

    void Start()
    {
        this.resetJoystick();
    }

    void Update()
    {

    }

    public void OnDragStart() {
    }

    public void OnDragMove() {
        Vector2 touchLocalPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(this.transform as RectTransform, Input.mousePosition, this.canvas2D.worldCamera,out touchLocalPos);
        float len = touchLocalPos.magnitude;
        if (len > this.maxR) {
            touchLocalPos = touchLocalPos.normalized * this.maxR;
        }
        dir = touchLocalPos.normalized;
        this.stick.transform.localPosition = touchLocalPos;
    }

    public void OnDragEnd() {
        this.resetJoystick();
    }

    void resetJoystick() {
        this.dir = Vector2.zero;
        this.stick.transform.localPosition = Vector2.zero;
    }
}
