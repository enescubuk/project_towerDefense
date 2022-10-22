using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyai : MonoBehaviour
{
    static List<GameObject> towersList = new List<GameObject>();
    [SerializeField]enemySo enemySo;
    private GameObject goldCase;
    bool isItGo = false;
    private Vector3 nextPos;
    bool detectNextPos = false; 
    bool enemyCanShoot;
    GameObject nearestTower;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,enemySo.attackScanRange);
    }
    void Start()
    {
        detectGoldCase();
        GameObject[] towers = GameObject.FindGameObjectsWithTag(enemySo.towerTags);
        foreach (GameObject tower in towers)
        {
            towersList.Add(tower);
        }
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
                nearestTower.SetActive(false);
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