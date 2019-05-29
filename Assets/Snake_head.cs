using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_head : MonoBehaviour {

    public float speed;
    public float speedRot;
    public Camera MainCamera;
    //public GameObject tail1, tail2, tail3, tail4, tail5;//<<ให้โมเดลเป็นหางวิ่งตาม 1 หาง
    public List<GameObject> tail_obj = new List<GameObject>(); //<<< get tail
    private Vector3[] ref_Vel; //<<< get speed tail
    public GameObject model_tail; //<<< get model
    // Use this for initialization
    void Start () {
        ref_Vel = new Vector3[1000];//<<<
        //InvokeRepeating("gen_tail", 0, 0.5f);
    }

    //Vector3 ref_vel1, ref_vel2, ref_vel3, ref_vel4, ref_vel5;//<<

	// Update is called once per frame
	void Update () {

        /*float x = Input.GetAxis("Horizontal");
        transform.Translate(0, speed, 0);
        transform.Rotate(0, 0, -x*speedRot);*/

        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 1000.0f);
        Vector3 mouse_hit = new Vector3(hit.point.x, hit.point.y, 0);
        transform.LookAt(mouse_hit, new Vector3(0, 0, 1));
        transform.Translate(0, 0, speed);

        for(int i = 0; i < tail_obj.Count; i++)
        {
            if(i==0)
            {
                tail_obj[i].transform.position = Vector3.SmoothDamp(tail_obj[i].transform.position, transform.position, ref ref_Vel[i], 0.08f);
            }
            else
            {
                tail_obj[i].transform.position = Vector3.SmoothDamp(tail_obj[i].transform.position, tail_obj[i-1].transform.position, ref ref_Vel[i], 0.3f);
            }
            
        }

        /*tail1.transform.position = Vector3.SmoothDamp(tail1.transform.position, transform.position, ref ref_vel1, 0.3f);
        tail2.transform.position = Vector3.SmoothDamp(tail2.transform.position, tail1.transform.position, ref ref_vel2, 0.3f);
        tail3.transform.position = Vector3.SmoothDamp(tail3.transform.position, tail2.transform.position, ref ref_vel3, 0.3f);
        tail4.transform.position = Vector3.SmoothDamp(tail4.transform.position, tail3.transform.position, ref ref_vel4, 0.3f);
        tail5.transform.position = Vector3.SmoothDamp(tail5.transform.position, tail4.transform.position, ref ref_vel5, 0.3f);*/

        
	}

    void gen_tail()
    {
        GameObject new_tail = Instantiate(model_tail, transform.position, transform.rotation) as GameObject;
        tail_obj.Add(new_tail); //<< increase tail;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bonus")
        {
            Destroy(other.gameObject);
            Invoke("gen_tail", 0.5f);
        }
    }
}
