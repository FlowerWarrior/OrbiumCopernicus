using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorMgr : MonoBehaviour
{
    [SerializeField] Image cursorImg;
    public Sprite cursorDefault;
    public Sprite cursorHover;
    public Sprite cursorDrag;

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
        Cursor.lockState = CursorLockMode.Confined;
        SetCursorDefault();
    }

    private void Update()
    {
        cursorImg.transform.position = Input.mousePosition;
        Cursor.visible = false;
    }

    public void SetCursorDefault()
    {
        //Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
        cursorImg.sprite = cursorDefault;
    }

    public void SetCursorToHover()
    {
        //Cursor.SetCursor(cursorHover, hotSpot, cursorMode);
        cursorImg.sprite = cursorHover;
    }

    public void SetCursorToDrag()
    {
        //Cursor.SetCursor(cursorDrag, hotSpot, cursorMode);
        cursorImg.sprite = cursorDrag;
    }
}
