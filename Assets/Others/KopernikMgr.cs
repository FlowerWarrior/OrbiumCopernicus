using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KopernikMgr : MonoBehaviour
{
    [SerializeField] Animator animator;

    public static KopernikMgr instance;
    public static System.Action FreezeSun;
    public static System.Action KickedEarth;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        Planet.Destroyed += ResetVar;
    }

    private void OnDisable()
    {
        Planet.Destroyed -= ResetVar;
    }

    public void PlayFreezeSun()
    {
        animator.Play("koperikSun", 0, 0);
    }

    public void SendFreezeSun()
    {
        FreezeSun?.Invoke();
    }

    private void ResetVar()
    {
        didSpawnAnim = false;
    }

    bool didSpawnAnim = false;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayKickTheBall();
        }
    }

    public void PlayKickTheBall()
    {
        if (!didSpawnAnim)
        {
            animator.Play("kopernikKick", 0, 0);
            didSpawnAnim = true;
        }
    }

    public void SendSpawnEarth()
    {
        PlanetSpawner.instance.SpawnEarthIfAvailable();
        KickedEarth?.Invoke();
        FreezeSun?.Invoke();
    }
}
