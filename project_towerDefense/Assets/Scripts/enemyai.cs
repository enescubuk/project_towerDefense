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
    GameObject nearestTower;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,enemySo.attackScanRange);
    }
    void Start()
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
                
                InvokeRepeating("attack",0f,enemySo.attackSpeed);
            }
            else
            {
                //CancelInvoke("attack");
            }
            enemyCanShoot = true;
        }
    }

    void againMove()
    {
        detectGoldCase();
        isItGo = false;
    }
    void attack()
    {
        if (isItGo == true)
        {
            if (nearestTower.GetComponent<towerDefense>().isDead == false)
            {
                Debug.Log(this.gameObject.name + " vurdu");
                nearestTower.GetComponent<towerDefense>().takeDamage(enemySo.damageValue);
            }
            else
            {
                isItGo = false;
                nearestTower.GetComponent<towerDefense>().cancelInv();
                nearestTower.SetActive(false);
                CancelInvoke("attack");
                againMove();
            }
        }
    }

    void detectGoldCase()
    {
        goldCase = GameObject.FindWithTag(enemySo.goldCaseTag);
        nextPos = goldCase.transform.position;
        Debug.Log("asdas");
    }
    void detectIsItGo()
    {
        if (Vector3.Distance(transform.position,nextPos) <= enemySo.attackRange)
        {
            isItGo = true;
            Debug.Log(111111);
        }
        else
        {
            isItGo = false;
        }
    }
    void scanTower()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag(enemySo.towerTags);
        float shortestDistance = Mathf.Infinity;
        nearestTower = null;
        
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
            
            nextPos = nearestTower.transform.position;
            detectNextPos = true;
        }
        else
        {

        }
    }
}