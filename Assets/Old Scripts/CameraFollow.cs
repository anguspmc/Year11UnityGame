using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smotherSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0,0);
    private float rotationY;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Move camera position to view the charecter
        //transform.position = target.position + offset;

        transform.LookAt(target);
    }
}
