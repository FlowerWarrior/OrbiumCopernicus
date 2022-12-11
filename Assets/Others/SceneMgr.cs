using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public static SceneMgr instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        QualitySettings.vSyncCount = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenLevelSelector()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenLevel(int id)
    {
        SceneManager.LoadScene($"level {id}");
    }

    public void OpenNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

    public int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public int GetCurrentLevelId()
    {
        return SceneManager.GetActiveScene().buildIndex - 2;
    }
}
