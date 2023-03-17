using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{ 
 
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("Destroyed Wall and Enemy!");
            WaveSpawner.enemiesAlive--;
            Player.Money += 50;
        }

    }
}