using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBod : MonoBehaviour
{
    [SerializeField] float randomization = 1f;
    [SerializeField] Vector3 rotVector = new Vector3(0, 0, 100);

    // Start is called before the first frame update
    void Start()
    {
        rotVector.x += Random.Range(0, randomization);
        rotVector.y += Random.Range(0, randomization);
        rotVector.z += Random.Range(0, randomization);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotVector * Time.deltaTime, Space.Self);
    }
}
