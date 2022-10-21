using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/FloatSo")]
public class FloatSo : ScriptableObject
{
    public event Action onChanged;

    [SerializeField] private float amount;

    public void Set(float amount)
    {
        if (amount < 0)
        {
            this.amount = 0;
            return;
        }

        this.amount = amount;

        onChanged.Invoke();
    }

    public float Get()
    {

        return amount;

    }
}
