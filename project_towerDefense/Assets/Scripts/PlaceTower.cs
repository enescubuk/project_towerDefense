using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public Transform gridCellPrefab;
    public Transform tower;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateGrid()
    {



    }

    public class Node
    {
        public bool isPlaceable;
        public Vector3 cellPosition;
        public Transform obj;

        public Node(bool isPlaceable, Vector3 cellPosition , Transform obj)
        {
            this.isPlaceable = isPlaceable;
            this.cellPosition = cellPosition;
            this.obj = obj;


        }

    }
}
