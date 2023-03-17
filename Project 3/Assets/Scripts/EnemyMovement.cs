using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    private Transform target;
    private int waypointIndex = 0;

    public int health = 100;
    public int earnings = 50;

    private bool isDead = false;

    private void Start()
    {
        //target begins at the very first waypoint
        target = Waypoint.waypoints[0];
    }

    public void TakeDamage(int ammount)
    {
        health -= ammount;

        if (health <= 0 && !isDead)
        {
            Die();
            WaveSpawner.enemiesAlive--;
        }
    }

    void Die()
    {
        isDead = true;
        Player.Money += earnings;
        Destroy(gameObject);
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
        if (waypointIndex >= Waypoint.waypoints.Length - 1)
        {
            EndGoal();
            return;
        }

        //Allows access to the other waypoints
        waypointIndex++;
        target = Waypoint.waypoints[waypointIndex];

    }

    void EndGoal()
    {
        Player.towerHealth--;
        Destroy(gameObject);
        WaveSpawner.enemiesAlive--;
    }

    
}