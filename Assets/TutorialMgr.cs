using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMgr : MonoBehaviour
{
    [SerializeField] GameObject tutorialScreen;
    [SerializeField] GameObject kickOffButton;
    [SerializeField] GameObject textsHolder;

    // Start is called before the first frame update
    void Start()
    {
        kickOffButton.SetActive(false);
        UpdateQuestText();
    }

    private void OnEnable()
    {
        Draggable.Dropped += DraggedPlanet;
        Planet.LevelCompleted += SunOrbitCompleted;
        KopernikMgr.KickedEarth += LaunchedEarth;
    }

    private void OnDisable()
    {
        Draggable.Dropped -= DraggedPlanet;
        Planet.LevelCompleted -= SunOrbitCompleted;
        KopernikMgr.KickedEarth -= LaunchedEarth;
    }

    private void DraggedPlanet()
    {
        if (currentQuest == 0)
        {
            NextQuest();
            kickOffButton.SetActive(true);
        }
    }

    private void LaunchedEarth()
    {
        if (currentQuest == 1)
        {
            NextQuest();
        }
    }

    private void SunOrbitCompleted()
    {
        // show level completed
        textsHolder.SetActive(false);
        tutorialScreen.SetActive(true);
        PlayerPrefs.SetInt("TutorialCompleted", 1);
    }

    private void UpdateQuestText()
    {
        for (int i = 0; i < textsHolder.transform.childCount; i++)
        {
            textsHolder.transform.GetChild(i).gameObject.SetActive(false);
            if (currentQuest == i)
            {
                textsHolder.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    int currentQuest = 0;
    private void NextQuest()
    {
        currentQuest++;
        UpdateQuestText();
    }
}
