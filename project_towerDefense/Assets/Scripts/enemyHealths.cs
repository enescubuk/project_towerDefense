using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealths : MonoBehaviour
{
    public int health = 10;
    public void takeDamage()
    {
        health--;
        //Debug.Log(this.gameObject.name + " canı : " + health);
    }
}
