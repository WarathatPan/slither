using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_Con : MonoBehaviour {
    public Vector3 ref_Vel;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GameObject head = GameObject.FindGameObjectWithTag("Hero");
        Vector3 P1 = head.transform.position;
        Vector3 P2 = transform.position;
        float m = Vector3.Distance(P1, P2);
        if (m < 2.0f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, head.transform.position, ref ref_Vel, 0.3f);
        }
    }
}
