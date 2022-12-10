using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] Transform rotatingPoint;
    [SerializeField] float rotatingPointSpeed;
    [SerializeField] Transform[] movePoints;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] Transform movingSun;

    bool isMoving = true;

    private void OnEnable()
    {
        KopernikMgr.FreezeSun += DisableMoveAnimation;
        PlanetSpawner.ResetLevel += EnableMoveAnimation;
    }
    private void OnDisable()
    {
        KopernikMgr.FreezeSun -= DisableMoveAnimation;
        PlanetSpawner.ResetLevel -= EnableMoveAnimation;
    }

    private void EnableMoveAnimation()
    {
        isMoving = true;
    }

    private void DisableMoveAnimation()
    {
        isMoving = false;
    }

    private void Start()
    {
        movingSun.position = movePoints[0].position;
    }

    private void FixedUpdate()
    {
        rotatingPoint.Rotate(new Vector3(0, 0, 1 * Time.deltaTime * rotatingPointSpeed));
    }

    float timer = 0;
    private void Update()
    {
        if (isMoving)
        {
            timer += Time.deltaTime * moveSpeed;
            float lerpValue = Mathf.PingPong(timer, 1);
            movingSun.position = Vector3.Lerp(movePoints[0].position, movePoints[1].position, lerpValue);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(movePoints[0].position, movePoints[1].position);
    }
}
