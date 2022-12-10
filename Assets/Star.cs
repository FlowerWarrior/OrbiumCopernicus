using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public static System.Action Collected;
    [SerializeField] GameObject collectedParticles;

    private void Start()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play("starIdle", 0, Random.Range(0, 1));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collected?.Invoke();
        Instantiate(collectedParticles, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
