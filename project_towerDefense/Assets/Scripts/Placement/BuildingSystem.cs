using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem current;

    public GridLayout gridLayout;
    public GridLayout gridLayoutY;
    private Grid grid;

    [SerializeField] private Tilemap main;
    [SerializeField] private Tilemap white;

    public GameObject tower;

    private PlaceableObject objectToPlace;

    public List<GameObject> towers;

    #region Unity methods


    private void Awake()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    public void OnMouseClickOnUI(GameObject game)
    {
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

        Vector3 position = SnapCoordinateToGrid(new Vector3(4,2,4));
        GameObject obj = Instantiate(prefab, position,Quaternion.identity);

        
        towers.Add(obj);



        objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();
    }



    #endregion
}
