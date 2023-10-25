using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Vila, Mondo
//Edwards, Eric
//10/22/23
//Script to make sledgehammer go up and down


public class Sledgehammer : MonoBehaviour
{
    public float topY;
    public float bottomY;

    public float risingSpeed;
    public float fallingSpeed;

    public bool goingUp = true;
    public bool waiting = false;

    public float waitTimeAtTop = 4f;
    public float waitTimeAtBottom = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Check to see if the object is at the top. If so, flip direction
        if (!waiting)
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
                    //start wait routine
                    StartCoroutine(Wait(waitTimeAtBottom));
                }
                else
                {
                    //Since the object is not at the bottom, keep moving down
                    transform.position += Vector3.down * fallingSpeed * Time.deltaTime;
                }
            }
        }
    }


    /// <summary>
    /// A coroutine used to wait a specific amount of time before continuing moving
    /// </summary>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    IEnumerator Wait(float waitTime)
    {
        waiting = true;
        //start the timer, doesn't do any code after this line until the timer is up
        yield return new WaitForSeconds(waitTime);
        //after time has passed, the next lines occur
        waiting = false;
    }
}
