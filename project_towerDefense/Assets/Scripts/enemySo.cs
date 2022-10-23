using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "enemyStats",menuName = "Enemy/Enemy Stats")]
public class enemySo : ScriptableObject
{
    public float Speed;
    public float attackSpeed;
    public float damageValue;
    public string goldCaseTag;
    public float attackScanRange;
    public float attackRange;
    public string towerTags;
    public int stealMoney;

}
