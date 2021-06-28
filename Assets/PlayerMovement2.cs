using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement2 : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -20f;
    public float jumpHeight = 3f;

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
            anim.SetBool("Jump", true);
        }else if(Mathf.Abs(controller.velocity.y) <0.001f){
            anim.SetBool("Jump", false);
        }
        if (Input.GetKeyDown ("r")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetAxis("Vertical") > 0){
            anim.SetBool("Walking", true);
        }else {
            anim.SetBool("Walking", false);
        }
    }


    void OnControllerColliderHit (ControllerColliderHit hit){

        if(hit.gameObject.tag == "Enemy"){
            Debug.Log("Respawn");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
