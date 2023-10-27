using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


//Edwards, Eric, Project Manager
//Vila, Mondo
//10/24/23
//PlayerController to be updated by Eric Edwards

public class PlayerController : MonoBehaviour
{
    //This will determine how much Hp the player has
    public int Hp = 99;

    public int speed;
    // Controls how high the player can Jump
    public float jumpForce = 10f;

    private Rigidbody rigidbody;

    private bool goingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        // Set a refrecene to the player's attached rigied body
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) 
        {
            if (!goingRight) 
            {
                transform.Rotate(Vector3.up * 180); 
             goingRight = true;
            }

            // traslate the players speed by speed using time.deltatime
            transform.position += Vector3.right * speed * Time.deltaTime;
           
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (goingRight)
            {
                transform.Rotate(Vector3.up * 180);
                goingRight = false;
            }
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        HandelJumping();
    }

    private void HandelJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;

            // If  the rayacast returns true then an object has been hit and the player is toching the floor
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {

                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

    }


}
