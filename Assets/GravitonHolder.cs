using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitonHolder : MonoBehaviour
{
    public static GravitonHolder instance;

    private void Awake()
    {
        instance = this;
    }

    public GravitySource[] GetGravitySources()
    {
        List<GravitySource> sources = new List<GravitySource>();
        for (int i = 0; i < transform.childCount; i++)
        {
            sources.Add(transform.GetChild(i).gameObject.GetComponent<GravitySource>());
        }
        return sources.ToArray();
    }
}
