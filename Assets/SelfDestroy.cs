using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] float destroyAfterSec;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyAfterSec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
