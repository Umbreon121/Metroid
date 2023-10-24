using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the player Left by useing speed useing Delta Time
        if (Input.GetKey(KeyCode.A)) 
        {
            // traslate the players speed by speed using time.deltatime
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        //Moves the player Right by useing speed useing Delta Time
        if (Input.GetKey(KeyCode.D))
        {
            // traslate the players speed by speed using time.deltatime
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
         
        
    }
}
