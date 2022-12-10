using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    bool isMouseDown = false;
    Vector3 mouseOffset = Vector3.zero;

    private void FixedUpdate()
    {
        if (isMouseDown)
        {
            Vector3 screenPos = Input.mousePosition;
            screenPos.z = 20;
            transform.position = Camera.main.ScreenToWorldPoint(screenPos) + mouseOffset;
        }
    }

    private void OnMouseEnter()
    {
        CursorMgr.instance.SetCursorToHover();
    }

    private void OnMouseExit()
    {
        CursorMgr.instance.SetCursorDefault();
    }

    void OnMouseDown()
    {
        Vector3 screenPos = Input.mousePosition;
        screenPos.z = 20;
        mouseOffset = transform.position - Camera.main.ScreenToWorldPoint(screenPos);
        isMouseDown = true;
        CursorMgr.instance.SetCursorToDrag();
    }

    void OnMouseUp()
    {
        isMouseDown = false;
        CursorMgr.instance.SetCursorToHover();
    }
}
