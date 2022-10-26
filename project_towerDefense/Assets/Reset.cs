using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public FloatSo health1 => Resources.Load("tower1Health") as FloatSo;
    public FloatSo health2 => Resources.Load("tower2Health") as FloatSo;
    public FloatSo health3 => Resources.Load("tower3Health") as FloatSo;

    public FloatSo coin;
    private void Awake()
    {
        health1.Set(100);
        health2.Set(100);
        health3.Set(100);
        coin.Set(60);

    }
}
