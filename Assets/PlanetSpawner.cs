using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    [SerializeField] GameObject planetPrefab;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Instantiate(planetPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(1);
        }
    }
}
