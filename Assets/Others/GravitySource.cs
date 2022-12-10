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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

        if (haloTransform == null)
            return;
        haloTransform.localScale = Vector3.one * radius / 10f;
    }
}
