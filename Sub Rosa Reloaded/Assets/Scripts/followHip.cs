using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followHip : MonoBehaviour
{

    public Transform target;
    public Transform thisObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {  
        thisObject.transform.position = new Vector3(target.transform.position.x, 0, target.transform.position.z);
    }
}
