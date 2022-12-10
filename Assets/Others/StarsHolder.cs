using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsHolder : MonoBehaviour
{
    private void OnEnable()
    {
        Planet.Destroyed += ResetStars;
    }

    private void OnDisable()
    {
        Planet.Destroyed -= ResetStars;
    }

    private void ResetStars()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
