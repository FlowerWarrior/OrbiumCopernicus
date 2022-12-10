using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalStarsMgr : MonoBehaviour
{
    [SerializeField] Transform[] planets;
    [SerializeField] TextMeshProUGUI textNextUnlock;

    // Start is called before the first frame update
    void Start()
    {
        int starsPerPlanet = 3;
        int totalStars = PlayerPrefs.GetInt("totalStars", 0);
        int planetsUnlocked = Mathf.FloorToInt(((float)totalStars / (float)starsPerPlanet));

        for (int i = 0; i < planets.Length; i++)
        {
            planets[i].GetChild(0).gameObject.SetActive(false);
            planets[i].GetChild(1).gameObject.SetActive(true);
        }

        for (int i = 0; i < planetsUnlocked; i++)
        {
            planets[i].GetChild(0).gameObject.SetActive(true);
            planets[i].GetChild(1).gameObject.SetActive(false);
        }

        textNextUnlock.text = $"Collect {totalStars % starsPerPlanet} more to get next planet collectible.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
