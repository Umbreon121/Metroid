using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Vila, Mondo
//Edwards, Eric
//10/24/23
//Script for Regular Enemy: Sentry

public class Sentry : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;
    private Vector3 leftPos;
    private Vector3 rightPos;
    public int speed;
    public bool goingLeft;
    public int Hp;

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
