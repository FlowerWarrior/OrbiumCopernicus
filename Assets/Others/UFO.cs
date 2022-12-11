using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] GameObject ray;
    [SerializeField] float teleportTime = 1f;
    [SerializeField] float teleportOffset = -8f;
    bool didTeleport = false;

    float teleportTimer = 999f;
    public static System.Action UfoIn;
    public static System.Action UfoOut;

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
            playerRb = other.gameObject.GetComponent<Rigidbody2D>();
            didTeleport = true;

            ray.SetActive(true);
            playerRb.transform.GetChild(0).gameObject.SetActive(false);

            savedVelocity = playerRb.velocity;
            playerRb.bodyType = RigidbodyType2D.Static;

            initialPos = playerRb.transform.position;
            targetPos = playerRb.transform.position + Vector3.up * teleportOffset;

            teleportTimer = 0f;

            StartCoroutine(ReleaseAfterRoutine());
        }
    }
    Rigidbody2D playerRb = null;
    Vector3 initialPos, targetPos;
    Vector3 savedVelocity;

    private void Update()
    {
        if (teleportTimer < teleportTime)
        {
            teleportTimer += Time.deltaTime;
            playerRb.transform.position = Vector3.Lerp(initialPos, targetPos, teleportTimer / teleportTime);
        }
    }

    IEnumerator ReleaseAfterRoutine()
    {
        UfoIn?.Invoke();
        yield return new WaitForSeconds(teleportTime);

        playerRb.transform.position = targetPos;
        playerRb.bodyType = RigidbodyType2D.Dynamic;
        playerRb.velocity = Vector3.zero;
        playerRb.velocity = savedVelocity;

        UfoOut?.Invoke();

        playerRb.transform.GetChild(0).gameObject.SetActive(true);
        ray.SetActive(false);
    }
}
