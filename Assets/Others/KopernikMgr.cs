using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KopernikMgr : MonoBehaviour
{
    [SerializeField] Animator animator;

    public static KopernikMgr instance;
    public static System.Action FreezeSun;

    private void Awake()
    {
        instance = this;
    }

    public void PlayFreezeSun()
    {
        animator.Play("koperikSun", 0, 0);
    }

    public void SendFreezeSun()
    {
        FreezeSun?.Invoke();
    }

    public void PlayKickTheBall()
    {
        animator.Play("kopernikKick", 0, 0);
    }

    public void SendSpawnEarth()
    {
        PlanetSpawner.instance.SpawnEarthIfAvailable();
        FreezeSun?.Invoke();
    }
}
