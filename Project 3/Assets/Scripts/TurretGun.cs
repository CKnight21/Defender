using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGun : MonoBehaviour
{
    public Transform target;

    public float range = 10f;

    public string enemyTag = "Enemy";

    public Transform rotationPart;

    public float rotationSpeed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);


    }

    void UpdateTarget()
    {
        //helps find the enemey
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //shortest distance between object and enemy
        float shrtDis = Mathf.Infinity;
        //enemy that is closest
        GameObject nearbyEnemy = null;
        //loops to search for enemeies
        foreach(GameObject enemy in enemies)
        {
            //figures out the distance between ojbect and enemey
            float disEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if(disEnemy < shrtDis)
            {
                shrtDis = disEnemy;

                nearbyEnemy = enemy;
            }
        }

        if(nearbyEnemy != null && shrtDis <= range)
        {
            //locks onto enemy
            target = nearbyEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }


        Vector3 dir = target.position - transform.position;

        //rotates the position of the gameobject
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        //locks onto target smoothly
        Vector3 rotation = Quaternion.Lerp(rotationPart.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        rotationPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
