using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMGR : MonoBehaviour
{
    public static UIMGR instance;
    [SerializeField] GameObject lvlCompletedScreen;
    [SerializeField] TextMeshProUGUI levelIndicatorText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (levelIndicatorText != null)
        {
            levelIndicatorText.text = $"{SceneMgr.instance.GetCurrentSceneIndex() - 1}.";
        }
    }

    public void ShowCompletedScreen()
    {
        lvlCompletedScreen.SetActive(true);
    }
}
