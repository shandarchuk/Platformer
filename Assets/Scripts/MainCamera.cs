using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public Transform trackingObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  позиция y и z - не меняется, позиция x - зависит от позиции игрока
        if(trackingObject!=null)
            transform.position = new Vector3(trackingObject.position.x, transform.position.y, transform.position.z);    
    }
}
