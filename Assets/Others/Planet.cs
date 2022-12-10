using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] float mass;
    [SerializeField] float thrustForce;
    [SerializeField] int playerId = 0;
    [SerializeField] float controlSensitivity = 1f;
    [SerializeField] Transform trail;
    [SerializeField] LayerMask sunLayer;
    [SerializeField] GameObject explosionParticles;

    Rigidbody2D rb;

    public static System.Action Destroyed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(rb.transform.up * thrustForce, ForceMode2D.Impulse);
        Destroy(gameObject, 30);
    }

    Vector2 axisInput = Vector2.zero;
    private void Update()
    {
        axisInput.y = Input.GetAxis("Vertical");
    }

    Transform sunPoint = null;
    private void FixedUpdate()
    {
        Vector3 finalForceVector = Vector3.zero;

        GravitySource[] sources = GravitonHolder.instance.GetGravitySources();
        for (int i = 0; i < sources.Length; i++)
        {
            Vector3 direction = sources[i].transform.position - transform.position;
            float distance = Vector3.Distance(rb.transform.position, sources[i].transform.position);
            if (distance < sources[i].radius)
            {
                finalForceVector += direction * sources[i].mass * 1/distance * 1 / distance;

                if (sources[i].tag == "Sun" && distance < sources[i].radius -1)
                {
                    RaycastHit hit;
                    // Does the ray intersect any objects excluding the player layer
                    if (Physics.Raycast(transform.position, rb.transform.forward, out hit, 1000, sunLayer))
                    {
                        // on tracjectory to hit sun
                    }
                    else
                    {
                        //rb.bodyType = RigidbodyType2D.Static;
                        //transform.parent = sources[i].transform.GetChild(0).GetChild(0);
                        //orbitSun = true;
                        sunPoint = sources[i].transform;
                        StartCoroutine(LevelCompletedRoutine());
                    }
                }
            }
        }
        
        if (sunPoint == null)
        {
            rb.AddForce(finalForceVector, ForceMode2D.Force);
        }
        else
        {
            rb.velocity = Vector3.zero;
            float speed = 1;
            Vector3 orbitVector = rb.transform.forward * speed + (sunPoint.position - transform.position) * speed;
            rb.AddForce(orbitVector);
        }
        //rb.transform.position += finalForceVector;

        rb.transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
    }

    IEnumerator LevelCompletedRoutine()
    {
        UIMGR.instance.ShowCompletedScreen();
        yield return new WaitForSeconds(2);
        SceneMgr.instance.OpenNextLevel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        trail.parent = trail.parent;
        Destroyed?.Invoke();
        Destroy(gameObject);

        if (collision.collider.tag == "Obstacle")
        {
            Instantiate(explosionParticles, transform.position, transform.rotation);
        }
    }
}
