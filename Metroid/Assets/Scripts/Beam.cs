using System.Collections;
using UnityEngine;
//Vila, Mondo
//Edwards, Eric
//11/13/23
//Script for the beam
public class Beam : MonoBehaviour
{
    // How Fast the Beam will move
    public float speed;

    // how long until the bullet despawns
    public float Despawn = 5f;

    //public GameObject player;
    public bool goingRight;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DespawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        // if move right is true it laser will move right. if it is false the laser will move left.
        if (goingRight == true)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

        }
    }
    IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(Despawn);
        Destroy(this.gameObject);
    }
}
