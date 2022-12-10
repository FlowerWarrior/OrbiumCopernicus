using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarsMgr : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI starsText;

    int stars = 0;

    private void OnEnable()
    {
        Star.Collected += AddToStars;
        Planet.Destroyed += ResetStars;
    }

    private void OnDisable()
    {
        Star.Collected -= AddToStars;
        Planet.Destroyed -= ResetStars;
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
    }
}
