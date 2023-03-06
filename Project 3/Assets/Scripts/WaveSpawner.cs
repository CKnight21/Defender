using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemy;

    public float time;

    private float countdown = 5;

    private int waveNumber = 1;

    public Transform spawnPoint;

    private void Update()
    {
        //When countdown <= 0 spawn enemies
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());

            countdown = time;

        }
        //Takes time down by 1 each second
            countdown -= Time.deltaTime;
    }
      
    IEnumerator SpawnWave()
    { 
        
        waveNumber++;
        //for every countdown spawn one more enemy
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {   //spwans enemy
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
