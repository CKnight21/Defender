using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameEnd = false;

    public GameObject gameOverUI;

    private void Start()
    {
        Time.timeScale = 1f;
        gameEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameEnd)
        {
            return;
        }
        if(Player.towerHealth <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnd = true;

        Time.timeScale = 0f;

        gameOverUI.SetActive(true);
    }    
}
