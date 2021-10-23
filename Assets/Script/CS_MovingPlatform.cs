using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform[] myWayPoints;
    private int myIndex;
    [SerializeField] float mySpeed;
    [SerializeField] Rigidbody2D myRigidbody2D;

    private void Start()
    {
        myIndex = 0;
        this.transform.position = myWayPoints[0].position;
    }

    private void Update()
    {
        UpdateRigidbody();
    }

    private void UpdateRigidbody()
    {
        Vector2 t_direction = myWayPoints[GetNextIndex(myIndex)].position - myWayPoints[myIndex].position;
        t_direction = t_direction.normalized;

        myRigidbody2D.velocity = t_direction * mySpeed;

        Vector2 t_currentDirection = myWayPoints[GetNextIndex(myIndex)].position - this.transform.position;
        if (Vector2.Angle(t_direction, t_currentDirection) > 90)
        {
            myIndex = GetNextIndex(myIndex);
        }
    }

    private int GetNextIndex(int g_index)
    {
        g_index++;
        if (g_index >= myWayPoints.Length)
        {
            g_index -= myWayPoints.Length;
        }
        return g_index;
    }
}
