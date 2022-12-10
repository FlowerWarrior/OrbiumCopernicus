using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] GameObject ray;
    [SerializeField] float teleportTime = 1f;
    [SerializeField] float teleportOffset = -8f;
    bool didTeleport = false;

    private void OnEnable()
    {
        PlanetSpawner.ResetLevel += ResetUfo;
    }
    private void OnDisable()
    {
        PlanetSpawner.ResetLevel -= ResetUfo;
    }

    private void ResetUfo()
    {
        didTeleport = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !didTeleport)
        {
            Rigidbody2D playerRb = other.gameObject.GetComponent<Rigidbody2D>();
            StartCoroutine(TeleportRoutine(playerRb));
            didTeleport = true;
        }
    }

    IEnumerator TeleportRoutine(Rigidbody2D rb)
    {
        ray.SetActive(true);
        rb.transform.GetChild(0).gameObject.SetActive(false);
        rb.transform.GetChild(1).gameObject.SetActive(false);

        Vector2 savedVelocity = rb.velocity;
        rb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(teleportTime);
        Vector3 newPos = rb.transform.position;
        newPos.y = teleportOffset + newPos.y;
        rb.transform.position = newPos;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = savedVelocity;

        rb.transform.GetChild(0).gameObject.SetActive(true);
        rb.transform.GetChild(1).gameObject.SetActive(true);
        ray.SetActive(false);
    }
}
