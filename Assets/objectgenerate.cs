using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectgenerate : MonoBehaviour {

    bool ch = true;
    Ray ray;
    RaycastHit hit;
    public GameObject prefab;
   
    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(!Input.GetKey(KeyCode.Mouse0))
        {
            ch = true;
            return;
        }
        if (Physics.Raycast(ray, out hit))
        {

            if (ch && Input.GetKey(KeyCode.Mouse0))
            {
                ch = false;
                Vector3 pos = Vector3.Project((hit.point - hit.transform.position), hit.normal) + hit.transform.position;
                GameObject obj = Instantiate(prefab, new Vector3((int)pos.x, (int)pos.y + 1 , (int)pos.z), Quaternion.identity) as GameObject;
            }
        }
    }
}
