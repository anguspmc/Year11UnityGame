using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalReset : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision hit){
        if(hit.gameObject.tag == "Goal"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
