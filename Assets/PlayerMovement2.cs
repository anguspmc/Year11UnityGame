using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement2 : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 30f;

    Vector3 velocity;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown ("space") && Mathf.Abs(controller.velocity.y) <0.001f){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            anim.SetInteger("Jump", 1);
        }else{
            anim.SetInteger("Jump", 0);
        }
        if (Input.GetKeyDown ("r")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    void OnControllerColliderHit (ControllerColliderHit hit){

        if(hit.gameObject.tag == "Enemy"){
            Debug.Log("Respawn");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
