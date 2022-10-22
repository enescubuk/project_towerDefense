using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyai : MonoBehaviour
{
    [SerializeField]enemySo enemySo;
    private GameObject goldCase;
    private bool isItGo = false;
    private Vector3 nextPos;
    private bool detectNextPos = false; 
    private bool enemyCanShoot;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,enemySo.attackScanRange);
    }
    void Awake()
    {
        detectGoldCase();
    }
    void Update()
    {
        if (isItGo == false)
        {
            scanTower();
            transform.position = Vector3.MoveTowards(transform.position,nextPos,enemySo.Speed * Time.deltaTime);
            detectIsItGo();
        }
        else
        {
            Debug.Log("attack");
            if (enemyCanShoot == false)
            {
                InvokeRepeating("attack",0f,enemySo.attackSpeed);
            }
            enemyCanShoot = true;
        }
    }
    void attack()
    {
        Debug.Log("enemy vurdu");
    }

    void detectGoldCase()
    {
        goldCase = GameObject.FindWithTag(enemySo.goldCaseTag);
        nextPos = goldCase.transform.position;
    }
    void detectIsItGo()
    {
        if (Vector3.Distance(transform.position,nextPos) <= enemySo.attackRange)
        {
            isItGo = true;
        }
    }
    void scanTower()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag(enemySo.towerTags);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestTower = null;
        foreach (GameObject tower in towers)
        {
            float distanceToTower = Vector3.Distance(transform.position, tower.transform.position);
            if (distanceToTower < shortestDistance)
            {
                shortestDistance = distanceToTower;
                nearestTower = tower;
            }
        }
        if (nearestTower != null && shortestDistance <= enemySo.attackScanRange)
        {
            nextPos = nearestTower.transform.position;
            Debug.Log(3131);
            detectNextPos = true;
        }
    }
}