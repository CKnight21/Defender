using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    BuildManager buildManager;

    public BuildingBlueprint turret1;
    public BuildingBlueprint wall;


    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTurret1()
    {
        Debug.Log("Turret 1 selected");
        buildManager.SelectBuild(turret1);
    }

    public void SelectWall()
    {
        Debug.Log("Wall selected");
        buildManager.SelectBuild(wall);

    }
}
