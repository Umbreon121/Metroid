using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

//Vila, Mondo
//Edwards, Eric
//11/5/23
//Ridley Boss script for flying and following player

public class RidleyBoss : MonoBehaviour
{
    public int Hp = 10;
    public float MinDistance = 1;
    public float MaxDistance = 5;
    public float Speed = 6;
    public Transform Player;

    public float topY;
    public float bottomY;
    public float risingSpeed;
    public float fallingSpeed;
    public bool goingUp = true;
    public bool waiting = false;

    public float waitTimeAtTop = 2;
    public float waitTimeAtBottom = 2f;


    void Update()
    {
        transform.LookAt(Player);
        if (Vector3.Distance(transform.position, Player.position) >= MinDistance)
        {
            Vector3 follow = Player.position;

            follow.y = this.transform.position.y;

            this.transform.position = Vector3.MoveTowards(this.transform.position, follow, Speed * Time.deltaTime);

            Vector3 playerPosition = new Vector3(Player.position.x, Player.position.y, Player.position.z);
            this.transform.LookAt(playerPosition);
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
                //Start wait routine
                StartCoroutine(Wait(waitTimeAtTop));
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
                //Start wait routine
                StartCoroutine(Wait(waitTimeAtBottom));

            }
            else
            {
                //Since the object is not at the bottom, keep moving down
                transform.position += Vector3.down * fallingSpeed * Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// a coroutine used to wait a specific amount of time before moving again
    /// </summary>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    IEnumerator Wait(float waitTime)
    {
        waiting = true;
        //Start the timer, doesn't do any code after this time until the timer is up
        yield return new WaitForSeconds(waitTime);
        //After time has passed, the next lines occur

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Beam")
        {
            Hp -= 1;
            if (Hp <= 0)
            {
              this.gameObject.SetActive(false);

            }
        }

    }
}
