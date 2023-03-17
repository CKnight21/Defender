using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int Money;
    public int startingMoney = 75;

    public static int towerHealth;

    public int startingTowerHealth;

    public static int waves;

    // Start is called before the first frame update
    void Start()
    {
        Money = startingMoney;
        
        towerHealth = startingTowerHealth;

        waves = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
