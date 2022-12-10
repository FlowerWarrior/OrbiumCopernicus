using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToRespawn;
    [SerializeField] GameObject planetPrefab;
    [SerializeField] Animator animator;

    public static PlanetSpawner instance;
    internal GameObject spawnedEarth = null;
    internal bool canDragObjects = true;

    public static System.Action ResetLevel;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        Planet.Destroyed += ReenableObjects;
    }

    private void OnDisable()
    {
        Planet.Destroyed -= ReenableObjects;
    }

    private void PlayFadeResetAnim()
    {
        animator.Play("resetFadeAnim", 0, 0);
    }
    public void ReenableObjects()
    {
        ResetLevel?.Invoke();
        for (int i = 0; i < objectsToRespawn.Length; i++)
        {
            objectsToRespawn[i].SetActive(true);
        }
    }

    public void SpawnEarthIfAvailable()
    {
        if (spawnedEarth != null)
            return;

        spawnedEarth = Instantiate(planetPrefab, transform.position, transform.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5f);
    }
}
