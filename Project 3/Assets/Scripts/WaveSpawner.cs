using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;

    public Wave[] waves;

    public float time;

    private float countdown = 5;

    public int waveNumber = 0;

    public Transform spawnPoint;

    public TextMeshProUGUI waveTimer;

    private void Start()
    {
        enemiesAlive = 0;
    }

    private void Update()
    {
        if(enemiesAlive > 0)
        {
            return;
        }

        if (waveNumber == waves.Length)
        {
            Debug.Log("You Win!");
            SceneManager.LoadScene("Win Screen");
            this.enabled = false;
        }
        //When countdown <= 0 spawn enemies
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());

            countdown = time;

            return;
        }
        //Takes time down by 1 each second
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveTimer.text = string.Format("{0:0.00}", countdown);

    }
      
    IEnumerator SpawnWave()
    { 
        
        Player.waves++;
        
        Wave wave = waves[waveNumber];
        

        //for every countdown spawn one more enemy
        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);

        }

        waveNumber++;


    }

    void SpawnEnemy(GameObject enemy)
    {   //spwans enemy
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);

        enemiesAlive++;
    }
}
