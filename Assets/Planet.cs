using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] float mass;
    [SerializeField] float thrustForce;
    [SerializeField] int playerId = 0;
    [SerializeField] float controlSensitivity = 1f;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.up * thrustForce, ForceMode2D.Impulse);
        Destroy(gameObject, 30);
    }

    Vector2 axisInput = Vector2.zero;
    private void Update()
    {
        axisInput.y = Input.GetAxis("Vertical");
    }

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
                finalForceVector += direction * sources[i].mass * 1/distance;
            }
        }

        rb.AddForce(finalForceVector, ForceMode2D.Force);
        //rb.transform.position += finalForceVector;

        rb.transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
