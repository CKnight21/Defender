using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float speed;

    public Transform target;

    public GameObject impact;

    public int damage = 50;

    public void Track(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;

        float dis = speed * Time.deltaTime;

        if(dir.magnitude <= dis)
        {
            Hit();
            return;
        }
        transform.Translate(dir.normalized * dis, Space.World);
    }

    void Damage(Transform enemy)
    {
        EnemyMovement e = enemy.GetComponent<EnemyMovement>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }

    }

    void Hit()
    {
        Instantiate(impact, transform.position, transform.rotation);

        
        Damage(target);

       
    }

}
