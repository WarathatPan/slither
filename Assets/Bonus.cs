using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {
    public GameObject Enemy;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("generate", 2f, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void generate()
    {
        Vector3 pos = new Vector3(Random.Range(-3f, 3f), Random.Range(-5f, 5f), 0);
        Instantiate(Enemy, pos, transform.rotation);
    }
}
