using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RidleyBoss : MonoBehaviour
{
    public float MinDistance = 2;
    public float MaxDistance = 5;
    public float Speed = 6;
    public Transform Player;

    public float topY;
    public float bottomY;
    public float risingSpeed;
    public float fallingSpeed;
    public bool goingUp = true;
    public bool waiting = false;

    void Update()
    {
        transform.LookAt(Player);
        if (Vector3.Distance(transform.position, Player.position) >= MinDistance)
        {
            Vector3 follow = Player.position;

            follow.y = this.transform.position.y;

            // remenber to use the new 'follow' position, not the Player.transform.position or else it'll move directly to the player
            this.transform.position = Vector3.MoveTowards(this.transform.position, follow, Speed * Time.deltaTime);
        }

        Fly();
    }

    private void Fly()
    {
        if (goingUp)
        {
            //Check to see if object is at the top, if so, flip direction
            if (transform.position.y >= topY)
            {
                goingUp = false;
            }
            else
            {
                //Since object isn't at the top, keep moving upwards
                transform.position += Vector3.up * risingSpeed * Time.deltaTime;
            }
        }
        //If going up is false, go down until it reaches the bottom
        else
        {
            if (transform.position.y <= bottomY)
            {
                goingUp = true;
            }
            else
            {
                //Since the object is not at the bottom, keep moving down
                transform.position += Vector3.down * fallingSpeed * Time.deltaTime;
            }
        }
    }
}
