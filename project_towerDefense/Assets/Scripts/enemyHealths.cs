using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealths : MonoBehaviour
{
    coinController coinController;
    public int health = 10;
    void Awake()
    {
        coinController = GameObject.Find("coinController").GetComponent<coinController>();
    }
    public void takeDamage()
    {
        if (health <= 0)
        {
            coinController.enemyDead();
            
            Destroy(this.gameObject);
        }
        else
        {
            health--;
        }
        //Debug.Log(this.gameObject.name + " canı : " + health);
    }
}
