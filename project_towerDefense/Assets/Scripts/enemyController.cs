using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        this.gameObject.GetComponent<enemyai>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            this.gameObject.GetComponent<enemyai>().enabled = true;
            this.gameObject.GetComponent<enemyController>().enabled = false;
        }
    }
}
