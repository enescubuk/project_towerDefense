using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSctipt : MonoBehaviour
{
    public Vector3 target;

    public GameObject arrowObject;
    //public void ArrowSpawn(Vector3 target, GameObject arrowObj)
    //{
//
    //    GameObject arrow = Instantiate(arrowObj,target,Quaternion.identity);
    //    arrow.GetComponent<ArrowSctipt>().target = target;
    //    
    //}

    private void Start()
    {
        //ArrowSpawn(target,arrowObject);
    }
    private void Update()
    {


        ArrowMove(target);
       // Destroy(this.gameObject, 2f);
    }

    public void ArrowMove(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 10 * Time.deltaTime);
        transform.LookAt(target, Vector3.up);

    }
}
