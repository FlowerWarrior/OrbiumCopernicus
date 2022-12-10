using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMGR : MonoBehaviour
{
    public static UIMGR instance;
    [SerializeField] GameObject lvlCompletedScreen;

    private void Awake()
    {
        instance = this;
    }

    public void ShowCompletedScreen()
    {
        lvlCompletedScreen.SetActive(true);
    }
}
