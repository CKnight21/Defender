using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public static Transform[] waypoints;
    public GameObject waypoint;

    private void Awake()
    {
        waypoints = new Transform[transform.childCount];

        //Goes through the parent object to see how many child objects there are
        for (int i = 0; i < waypoints.Length; i++)
        {
            //set the waypoint equal to the child
            waypoints[i] = transform.GetChild(i);
        }
    }
}
