    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class BuildingSystem : MonoBehaviour
{
    public FloatSo[] SOs;
    public int count = 0;
    public static BuildingSystem current;

    public GridLayout gridLayout;
    public GridLayout gridLayoutY;
    private Grid grid;

    [SerializeField] private Tilemap main;
    [SerializeField] private Tilemap white;

    public GameObject tower;

    private PlaceableObject objectToPlace;

    public List<GameObject> towers;

    GameObject ghostObj;

    #region Unity methods


    private void Awake()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    public void StartDrag(GameObject prefab)
    {
        
        Vector3 position = SnapCoordinateToGrid(GetMouseWorldPos());
        ghostObj = Instantiate(prefab, GetMouseWorldPos(), Quaternion.Euler(new Vector3(-90, 0, 0)));
    }

    public void DragImage()
    {
        
        ghostObj.transform.position = SnapCoordinateToGrid(GetMouseWorldPos());

    }
    public void OnMouseClickOnUI(GameObject game)
    {
        Destroy(ghostObj);
        InitilazeWithObject(tower);
        game.SetActive(false);


    }

    #endregion

    #region Utils

    public static Vector3 GetMouseWorldPos()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
            if (Physics.Raycast(ray,out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }
    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position); 
        position = grid.GetCellCenterWorld(cellPos);
        return position;

    }
    #endregion

    #region Tower Placement

    public void InitilazeWithObject(GameObject prefab)
    {

        Vector3 position = SnapCoordinateToGrid(GetMouseWorldPos());
        GameObject obj = Instantiate(prefab, position, Quaternion.Euler(new Vector3(-90, 0, 0)));

        
        towers.Add(obj);



        objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();
        obj.GetComponent<towerDefense>().health = SOs[count];
        
        count++;
    }



    #endregion
}
