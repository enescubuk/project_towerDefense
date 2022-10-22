using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMashBaker : MonoBehaviour
{

    public List<NavMeshSurface> surfacess;
    public GameObject[] surfaces;
    public Transform[] objectsToRotate;


    private void Awake()
    {
        surfaces = GameObject.FindGameObjectsWithTag("Tile");
        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].GetComponent<NavMeshSurface>().BuildNavMesh();
        }
    }
    // Use this for initialization
    void Update()
    {
      /*
        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].GetComponent<NavMeshSurface>().BuildNavMesh();
        }*/
    }

   
}
