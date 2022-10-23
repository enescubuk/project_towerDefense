using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealths : MonoBehaviour
{
    coinController coinController;
    public Slider slider;
    public int health = 10;
    void Awake()
    {
        slider.value = health;
        //coinController = GameObject.Find("coinController").GetComponent<coinController>();
    }
    public void takeDamage()
    {
        if (health < 1)
        { Debug.Log(3131313131311);
            //coinController.enemyDead();
            
            Destroy(gameObject);
        }
        else
        {
            health--;
            slider.value = health;
        }
        //Debug.Log(this.gameObject.name + " canı : " + health);
    }
}
