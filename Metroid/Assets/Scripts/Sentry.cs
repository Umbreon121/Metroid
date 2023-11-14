using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Vila, Mondo
//Edwards, Eric
//11/13/23
//Script for Regular Enemy: Sentry

public class Sentry : MonoBehaviour
{
    // The farthest  left point the enemy will go to.
    public GameObject leftPoint;
    // The farthest  right point the enemy will go to.
    public GameObject rightPoint;
    // The left point the enemy will go to.
    private Vector3 leftPos;
    // The right point the enemy will go to.
    private Vector3 rightPos;
    // How fast the enmey moves
    public int speed;
    /// Is the Enemy going left.
    public bool goingLeft;
    // Enemy Hp
    public int Hp = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Left and right transform positions where the enemy will move
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    /// <summary>
    /// Will move the ememy left and right.
    /// </summary>
    private void Move()
    {
        if (goingLeft)
        {
            if (transform.position.x <= leftPos.x)
            {
                goingLeft = false;
            }
            else
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }
        else
        {
            if (transform.position.x >= rightPos.x)
            {
                goingLeft = true;
            }
            else
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
    }
    /// <summary>
    /// If a beam hit this enemey deal 1 damage and if hp = 0 turn the enmey off
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Beam")
        {
            Hp--;
            other.gameObject.SetActive(false);
            if(Hp <= 0) 
            { 
            this.gameObject.SetActive(false);
            }

        }
    
    }

}
