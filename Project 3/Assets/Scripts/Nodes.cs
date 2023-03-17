using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Color hoverColor;
    public Color noMoneyColor;
    public Vector3 offset;
    private Renderer rend;
    private Color startColor;
    public GameObject Defense;
    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();

        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 BuildPosition()
    {
        return transform.position + offset;
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;

        if (!buildManager.canBuild)
        {
            return;
        }
        if (buildManager.money)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = noMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {

        if (!buildManager.canBuild)
        {
            return;
        }

        if(Defense != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        buildManager.BuildObjectOn(this);
        

      
    }
}
