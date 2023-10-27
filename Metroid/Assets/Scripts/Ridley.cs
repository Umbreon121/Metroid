using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kraid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class Ridley : MonoBehaviour
{
    public float MinDistance = 5;
    public float MaxDistance = 10;
    public float Speed = 7;
    public Transform Player;


    void Update()
    {
        transform.LookAt(Player);
        if (Vector3.Distance(transform.position, Player.position) >= MinDistance)
        {
            Vector3 follow = Player.position;
            //setting always the same Y position
            follow.y = this.transform.position.y;

            // remenber to use the new 'follow' position, not the Player.transform.position or else it'll move directly to the player
            this.transform.position = Vector3.MoveTowards(this.transform.position, follow, Speed * Time.deltaTime);
        }
    }
}