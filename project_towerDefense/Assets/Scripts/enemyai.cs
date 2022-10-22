using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyai : MonoBehaviour
{
    [SerializeField]enemySo enemySo;
    private GameObject goldCase;
    public bool isItGo = false;
    private Vector3 nextPos;
    public bool detectNextPos = false; 
    public bool enemyCanShoot;

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            detectGoldCase();
            isItGo = false;
        }
        if (isItGo == false)
        {
            scanTower();
            transform.position = Vector3.MoveTowards(transform.position,nextPos,enemySo.Speed * Time.deltaTime);
            detectIsItGo();
        }
        else
        {

            if (enemyCanShoot == false && isItGo == true)
            {
                Debug.Log(444444444);
                InvokeRepeating("attack",0f,enemySo.attackSpeed);
            }
            else
            {
                //CancelInvoke("attack");
            }
            enemyCanShoot = true;
        }
    }
    void attack()
    {
        if (isItGo == true)
        {
            Debug.Log(this.gameObject.name + " vurdu");
        }
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
        Debug.Log(11111111111);
        foreach (GameObject tower in towers)
        {
            float distanceToTower = Vector3.Distance(transform.position, tower.transform.position);
            if (distanceToTower < shortestDistance)
            {
                shortestDistance = distanceToTower;
                nearestTower = tower;
            }
        }
        if (nearestTower != null && shortestDistance <= enemySo.attackScanRange )
        {
            Debug.Log(22222222222);
            nextPos = nearestTower.transform.position;
            detectNextPos = true;
        }
        else
        {
            Debug.Log(33333333333333);
        }
    }
}