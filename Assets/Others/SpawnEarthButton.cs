using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEarthButton : MonoBehaviour
{
    public static System.Action Clicked;
    public void ClickedSpawnEarth()
    {
        if (PlanetSpawner.instance.spawnedEarth == null)
        {
            KopernikMgr.instance.PlayKickTheBall();
            Clicked?.Invoke();
        }
    }
}
