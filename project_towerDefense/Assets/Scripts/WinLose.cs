using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject loseCanvas;

    [SerializeField] List<GameObject> enemies;
    [SerializeField] List<FloatSo> towers;
    [SerializeField] List<float> towerHps;

    public bool isWin;
    public bool isLose;

    private void Awake()
    {

        
    }

    
    private void Update()
    {
        WinState();
    }
    public void WinState()
    {
        if (towers[0].Get() + towers[1].Get() + towers[2].Get() > 0 && enemies.Count == 0)
        {
            loseCanvas.SetActive(false);    
            winCanvas.SetActive(true);
            

        }
        if(towers[0].Get()+ towers[1].Get() + towers[2].Get() <= 0)
        {

            winCanvas.SetActive(false);
            loseCanvas.SetActive(true);
        }
    }

    /*public void LoseState()
    {

        
    }*/
}
