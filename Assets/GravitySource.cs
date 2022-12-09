using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySource : MonoBehaviour
{
    [SerializeField] internal float radius;
    [SerializeField] internal float mass;
    [SerializeField] internal Transform haloTransform;
    private void OnDrawGizmos()
    {
        haloTransform.localScale = Vector3.one * radius / 10f;
    }
}
