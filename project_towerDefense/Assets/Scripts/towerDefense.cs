using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerDefense : MonoBehaviour
{
    public Transform target;
    [SerializeField]towerStats towerStats;
    private bool canShoot;
    private float rangeRadius;
    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,towerStats.attackRange);
    }
    void Update()
    {
        
        if (target == null)
        {   
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        gameObject.transform.rotation = Quaternion.Euler(0,rotation.y - 90,0);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(towerStats.enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= towerStats.attackRange )
        {
            if (target == null)
            {
                target = nearestEnemy.transform;
            }
            shooting();
            canShoot = true;
        }
        else
        {
            target = null;
            canShoot = false;
            CancelInvoke("taretShooting");
        }
    }
    void shooting()
    {
        if (canShoot == false)
        {
            InvokeRepeating("taretShooting",0,towerStats.attackSpeed);

        }

    }

    void taretShooting()
    {
        Debug.Log(this.gameObject.name + "vurdu");
    }
}