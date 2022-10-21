using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "towerStats",menuName = "Tower/Tower Stats")]
public class towerStats : ScriptableObject
{
    public float attackRange;
    public float attackSpeed;
    public float attackDamage;
    public string enemyTag;
}
