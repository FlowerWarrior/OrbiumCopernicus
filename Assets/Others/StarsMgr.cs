using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarsMgr : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI starsText;
    [SerializeField] GameObject[] activeStarsUI;

    Animator animator;

    int stars = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Star.Collected += AddToStars;
        Planet.Destroyed += ResetStars;
        Planet.LevelCompleted += SaveStars;
    }

    private void OnDisable()
    {
        Star.Collected -= AddToStars;
        Planet.Destroyed -= ResetStars;
        Planet.LevelCompleted -= SaveStars;
    }

    void SaveStars()
    {
        for (int i = 0; i < stars; i++)
        {
            activeStarsUI[i].SetActive(true);
        }

        if (stars > PlayerPrefs.GetInt($"starsCollected{SceneMgr.instance.GetCurrentLevelId() - 1}", -1))
        {
            PlayerPrefs.SetInt($"starsCollected{SceneMgr.instance.GetCurrentLevelId() - 1 }", stars);
        }

        Debug.LogWarning($"{SceneMgr.instance.GetCurrentLevelId() - 1 }");
    }

    private void ResetStars()
    {
        stars = 0;
        starsText.text = $"Stars {stars}/3";
    }

    private void AddToStars()
    {
        stars++;
        starsText.text = $"Stars {stars}/3";
        animator.Play("starTxt", 0, 0);
    }

    public void OpenLevelSelector()
    {
        SceneMgr.instance.OpenLevelSelector();
    }
}
