using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarsMgr : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI starsText;

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
        if (stars > PlayerPrefs.GetInt($"starsCollected{SceneMgr.instance.GetCurrentSceneIndex() - 2}"))
        {
            PlayerPrefs.GetInt($"starsCollected{SceneMgr.instance.GetCurrentSceneIndex() - 2 }", stars);

        }
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
}
