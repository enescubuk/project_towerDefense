using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coinController : MonoBehaviour
{
    [SerializeField]FloatSo coin;
    private int coinIncrase;
    public TMP_Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void enemyDead()
    {
        coin.Set(coin.Get() + coinIncrase);
        //health.Set((health.Get()) - amount);
    }
    public void stealMoney(int a)
    {
        coin.Set(coin.Get() - a);
    }
    // Update is called once per frame
    void Update()
    {
        coinText.text = coin.Get().ToString();
    }
}
