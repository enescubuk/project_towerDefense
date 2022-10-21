using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public List<Transform> towers;

    public Transform gridCellPrefab;
    public Transform tower;

    public Transform onMousePrefab;
    public Vector3 smoothMousePos;

    public int height, width;

    public Vector3 mousePos;
    Plane plane;

    public Node[,] nodes;
    void Start()
    {
        CreateGrid();
        plane = new Plane(Vector3.up, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePosOnGrid();
    }

    public void OnMouseClickOnUI()
    {
        if (onMousePrefab == null && towers.Count < 3)
        {
            onMousePrefab = Instantiate(tower,mousePos,Quaternion.identity);
            towers.Add(onMousePrefab);
        }
    }

   /* public void OnClickTowerAgain()
    {

        if (onMousePrefab == null)
        {
            onMousePrefab = Instantiate(tower, mousePos, Quaternion.identity);
        }

    }*/
    void GetMousePosOnGrid()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray,out var enter))
        {
            
            mousePos = ray.GetPoint(enter);
            smoothMousePos = mousePos;
            mousePos.y = 0;
            mousePos = Vector3Int.RoundToInt(mousePos);

            foreach (var node in nodes)
            {
                if (node.cellPosition == mousePos && node.isPlaceable)
                {
                    if (Input.GetMouseButton(0) && onMousePrefab != null)
                    {
                        node.isPlaceable = false;
                        onMousePrefab.GetComponent<TowerDrag>().isOnGrid = true;
                        onMousePrefab.position = node.cellPosition + new Vector3(0, 0.5f, 0);
                        onMousePrefab = null;
                    }
                }
            }
        }

    }
    void CreateGrid()
    {
        nodes = new Node[width, height];

        var name = 0;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 worldPosition = new Vector3(i*4, 0, j*4);
                Transform obj = Instantiate(gridCellPrefab, worldPosition, Quaternion.identity);

                Debug.Log(""+ name);

                nodes[i, j] = new Node(true, worldPosition, obj);

                name++;
            }
        }


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
