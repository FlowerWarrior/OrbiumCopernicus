using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    [SerializeField] GameObject planetPrefab;

    GameObject spawnedEarth = null;

    // Start is called before the first frame update
    void OnEnable()
    {
        //Instantiate(planetPrefab, transform.position, transform.rotation);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && spawnedEarth == null)
        {
            spawnedEarth = Instantiate(planetPrefab, transform.position, transform.rotation);
        }
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Instantiate(planetPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5f);
    }
}
