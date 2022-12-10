using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFreezer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            KopernikMgr.instance.PlayFreezeSun();
            gameObject.SetActive(false);
        }
    }
}
