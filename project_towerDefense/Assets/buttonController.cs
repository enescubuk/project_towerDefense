using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonController : MonoBehaviour
{
    [SerializeField]FloatSo Coin;
    public FloatSo tower1Health;
    public FloatSo tower2Health;
    public FloatSo tower3Health;
    public Text tower1Text;
    public Text tower2Text;
    public Text tower3Text;
    
    // Start is called before the first frame update
    void Start()
    {
        first();
    }
    public void first()
    {
        //tower1Health.Set((tower1Health.Get()) * 2);
        float a = tower1Health.Get() *2;
        float b = tower2Health.Get() *2;
        float c = tower3Health.Get() *2;
        tower1Text.text =  "%" +tower1Health.Get().ToString();
        tower2Text.text =  "%" +tower2Health.Get().ToString();
        tower3Text.text =  "%" +tower3Health.Get().ToString();
    }
    void write()
    {
        tower1Text.text =  "%" +tower1Health.Get().ToString();
        tower2Text.text =  "%" +tower2Health.Get().ToString();
        tower3Text.text =  "%" +tower3Health.Get().ToString();
    }
    public void last()
    {
        GameObject.Find("buttonController").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void kule1()
    {
        if (Coin.Get() > Mathf.RoundToInt((100-tower1Health.Get())/10) && tower1Health.Get() < 100)
        {
            Coin.Set(Coin.Get()-Mathf.RoundToInt((100-tower1Health.Get())/10));
            Debug.Log(Mathf.RoundToInt((100-tower1Health.Get())/10));
            tower1Health.Set(tower1Health.Get()+100-tower1Health.Get());
        }
        write();
    }
    public void kule2()
    {
        if (Coin.Get() > Mathf.RoundToInt((100-tower2Health.Get())/10) && tower2Health.Get() < 100)
        {
            Coin.Set(Coin.Get()-Mathf.RoundToInt((100-tower2Health.Get())/10));
            Debug.Log(Mathf.RoundToInt((100-tower2Health.Get())/10));
            tower2Health.Set(tower2Health.Get()+100-tower2Health.Get());
        }
        write();
    }
    public void kule3()
    {
        if (Coin.Get() > Mathf.RoundToInt((100-tower3Health.Get())/10) && tower3Health.Get() < 100)
        {
            Coin.Set(Coin.Get()-Mathf.RoundToInt((100-tower3Health.Get())/10));
            Debug.Log(Mathf.RoundToInt((100-tower3Health.Get())/10));
            tower3Health.Set(tower3Health.Get()+100-tower3Health.Get());
        }
        write();
    }
}
