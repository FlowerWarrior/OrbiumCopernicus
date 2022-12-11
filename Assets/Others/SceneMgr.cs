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

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0);
        }
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
        if (PlayerPrefs.GetInt("TutorialCompleted", 0) == 0)
        {
            SceneManager.LoadScene($"tutorial");
            return;
        }
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

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
