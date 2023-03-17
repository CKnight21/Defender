using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //the only build manager
    public static BuildManager instance; //stores the build manager inside the build manager

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one build");
            return;
        }

        instance = this;
    }

    public GameObject turret1prefab;

    public GameObject wallprefab;

    public GameObject buildEffect;

    private BuildingBlueprint defense;

    //property; only allow it to get something(prefab)
    public bool canBuild { get { return defense != null; } }
    public bool money { get { return Player.Money >= defense.cost; } }

    public void BuildObjectOn (Nodes node)
    {
        if(Player.Money < defense.cost)
        {
            Debug.Log("No Money?");
            return;
        }

        Player.Money -= defense.cost;

        GameObject thing =  Instantiate(defense.prefab, node.transform.position + node.offset, Quaternion.identity);

        node.Defense = thing;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.transform.position + node.offset, Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Yes, building now! Money left: " + Player.Money);
    }

    public void SelectBuild(BuildingBlueprint thing)
    {
        defense = thing;
    }


}
