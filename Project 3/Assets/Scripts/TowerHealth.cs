using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TowerHealth : MonoBehaviour
{
    public TextMeshProUGUI towerHealth;

    // Update is called once per frame
    void Update()
    {
        towerHealth.text = Player.towerHealth + " Health";
    }
}
