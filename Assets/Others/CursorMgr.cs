using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMgr : MonoBehaviour
{
    public Texture2D cursorDefault;
    public Texture2D cursorHover;
    public Texture2D cursorDrag;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public static CursorMgr instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetCursorDefault();
    }

    public void SetCursorDefault()
    {
        Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
    }

    public void SetCursorToHover()
    {
        Cursor.SetCursor(cursorHover, hotSpot, cursorMode);
    }

    public void SetCursorToDrag()
    {
        Cursor.SetCursor(cursorDrag, hotSpot, cursorMode);
    }
}
