using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MovementSpeed = 1;
    private Rigidbody _rigidbody;
    public float JumpForce;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var movementX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movementX, 0, 0) * Time.deltaTime * MovementSpeed;
        var movementZ = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, 0, movementZ) * Time.deltaTime * MovementSpeed;

        if(Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) <0.001f){ 

            _rigidbody.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        }

    }
}
