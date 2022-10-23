using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyai : MonoBehaviour
{
    NavMeshAgent agent => GetComponent<NavMeshAgent>();
    [SerializeField]enemySo enemySo;
    private GameObject goldCase;
    public bool isItGo = false;
    public Vector3 nextPos;
    public bool detectNextPos = false; 
    public bool enemyCanShoot;
    public GameObject nearestTower;

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
        if (nearestTower != null &&nearestTower.GetComponent<towerDefense>().isDead == true)
        {
            againMove();
        }
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    detectGoldCase();
        //    isItGo = false;
        //}
        if (isItGo == false)
        {
            
            
            agent.isStopped = false;
            
            scanTower();
            //transform.position = Vector3.MoveTowards(transform.position,nextPos,enemySo.Speed * Time.deltaTime);
            agent.SetDestination(nextPos);
            detectIsItGo();
        }
        else
        {
            if (goldCase.transform.position != nextPos && nearestTower.transform.position == nextPos)
            {
                agent.isStopped = true;
            }
            if (enemyCanShoot == false && isItGo == true)
            {
                
                InvokeRepeating("attack",1f,enemySo.attackSpeed);
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
                //Debug.Log(this.gameObject.name + " vurdu");
                if (nextPos != goldCase.transform.position)
                {
                    nearestTower.GetComponent<towerDefense>().takeDamage(enemySo.damageValue);
                    Debug.Log("kuleye vuruyor");
                }
                else
                {
                    Debug.Log("altına vuruyo");
                    GameObject.Find("coinController").GetComponent<coinController>().stealMoney(enemySo.stealMoney);
                }
                
            }
            else
            {
                Debug.Log(2);
                isItGo = false;
                nearestTower.GetComponent<towerDefense>().cancelInv();
                nearestTower.SetActive(false);
                nearestTower = null;
                CancelInvoke("attack");
                againMove();
            }
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
            InvokeRepeating("attack",1,enemySo.attackSpeed);
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
            if (this.gameObject.name.Contains("enemy"))
            {
                if (nextPos.y >= 7)
                {
                    Debug.Log(3131);
                    detectGoldCase();
                }
                else
                {
                    Debug.Log("hobaa");
                }
            }
            detectNextPos = true;
        }
        else
        {

        }
    }
}