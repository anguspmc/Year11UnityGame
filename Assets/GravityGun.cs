using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 10/06/21 - https://www.youtube.com/watch?v=O93dev7l5Vg [log 1]


public class GravityGun : MonoBehaviour
{
    [SerializeField] Camera Camera;
    [SerializeField] float grabRange, throwForce, lerpSpeed;
    [SerializeField] Transform objectHolder;
    

    Rigidbody grabbedBody;


    void Start()
    {
        
    }


    void Update()
    {

        if(grabbedBody){
            grabbedBody.MovePosition(Vector3.Lerp(grabbedBody.position, objectHolder.transform.position, Time.deltaTime * lerpSpeed));

            if(Input.GetKeyDown(KeyCode.Q)){
                grabbedBody.isKinematic = false;
                grabbedBody.AddForce(Camera.transform.forward * throwForce, ForceMode.VelocityChange);
                grabbedBody = null;
            }
        }

        //tests for the trigger button down
        if(Input.GetButtonDown("Fire1")){
            //runs if object exists
            if(grabbedBody){

                grabbedBody.isKinematic = false;
                grabbedBody = null;
            }
            else{
                RaycastHit hit;
                Ray ray = Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if(Physics.Raycast(ray, out hit, grabRange)){

                    grabbedBody = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if(grabbedBody){
                        grabbedBody.isKinematic = true;
                    }
                }
            }
        }
    }
}
