using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float LookRadius = 20f;
    public float gravity = -9.8f;
    public float MoveSpeed = 2f;
    public CharacterController controller;
    Transform target;
    Transform spawnPoint;
    Vector3 velocity;


    void Start(){

        target = PlayerManager.instance.player.transform;
        spawnPoint = EnemyManager.instance.spawnPoint.transform;
    }


    void Update(){

        if(Vector2.Distance(transform.position, target.position) <= LookRadius) {
            transform.LookAt(target);
        }else{
            transform.LookAt(spawnPoint);
        }

        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles = new Vector3(0, eulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(eulerAngles);


        Vector3 move = transform.forward;
        controller.Move(move * MoveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void OnDrawGizmosSelected(){

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius);
    }


}
