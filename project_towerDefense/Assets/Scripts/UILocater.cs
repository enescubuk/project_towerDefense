using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILocater : MonoBehaviour
{
    [SerializeField] Transform target;
    private void Update()
    {
        var wantedPos = Camera.main.WorldToViewportPoint(target.position);
        transform.position = wantedPos;
    }
}
