using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEarthButton : MonoBehaviour
{
    public void ClickedSpawnEarth()
    {
        PlanetSpawner.instance.SpawnEarthIfAvailable();
    }
}
