using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    private Transform target;
    private int waypointIndex = 0;

    private void Start()
    {
        //target begins at the very first waypoint
        target = Waypoint.waypoints[0];
    }

    
    void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //When the enemy is near the waypoint it will find the next waypoint
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            NextWaypoint();
        }
    }

    void NextWaypoint()
    {   
        if(waypointIndex >= Waypoint.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        //Allows access to the other waypoints
        waypointIndex++;
        target = Waypoint.waypoints[waypointIndex];
    
    }
}