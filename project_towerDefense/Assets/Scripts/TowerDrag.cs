using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDrag : MonoBehaviour
{
    public bool isOnGrid;

    public bool isSelected;
    private PlaceTower placeTower;
    // Start is called before the first frame update
    void Start()
    {
        placeTower = FindObjectOfType<PlaceTower>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOnGrid)
        {
            transform.position = placeTower.smoothMousePos + new Vector3(0, 0.5f, 0);
        }
        
    }

    private void OnMouseDown()
    {

        foreach (var node in placeTower.nodes)
        {
            if (node.cellPosition == placeTower.mousePos && !node.isPlaceable)
            {
                node.isPlaceable = true;

            }
            
        }
        isOnGrid = false;
        placeTower.onMousePrefab = gameObject.transform;

        



    }
    private void OnMouseUp()
    {
        if (isOnGrid == true)
        {
            foreach (var node in placeTower.nodes)
            {

                if (node.cellPosition == placeTower.mousePos && node.isPlaceable)
                {
                    node.isPlaceable = false;
                }
                //isOnGrid = true;
                //placeTower.onMousePrefab = null;
            }
        }
        
    }

    /*private void OnMouseDrag()
    {
        isSelected = true;
        
    }*/
}
