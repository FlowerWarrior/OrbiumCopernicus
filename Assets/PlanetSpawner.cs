using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    [SerializeField] GameObject planetPrefab;

    public static PlanetSpawner instance;
    GameObject spawnedEarth = null;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        
    }

    public void SpawnEarthIfAvailable()
    {
        if (spawnedEarth != null)
            return;

        Instantiate(planetPrefab, transform.position, transform.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5f);
    }
}
