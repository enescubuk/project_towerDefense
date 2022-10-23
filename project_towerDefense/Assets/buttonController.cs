using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonController : MonoBehaviour
{
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
    public void last()
    {
        GameObject.Find("buttonController").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
