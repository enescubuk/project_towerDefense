using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITowerCount2 : MonoBehaviour
{
    [SerializeField] FloatSo theTower;
    private void Start()
    {
        theTower = Resources.Load("tower2Health") as FloatSo;

        if (theTower.Get() <= 0)
        {

            Destroy(gameObject);
        }

    }
}
