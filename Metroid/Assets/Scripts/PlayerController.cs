using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

//Vila, Mondo
//Edwards, Eric
//11/13/23
//PlayerController to be updated by Eric Edwards

public class PlayerController : MonoBehaviour
{
    //This will determine how much Hp the player has
    public int Hp = 99;

    public int speed;
    // Controls how high the player can Jump
    public float jumpForce = 10f;
    // gets player Rigidbody
    private Rigidbody rigidbody;
    // Sets going right to be true
    public bool goingRight = true;
    // will get the white Material
    public Material Swhite;
    // will get the Orange Material
    public Material SOrange;
    // Sets if the player is invinceable to false
    public bool Invceable = false;
    // how long the player is invinceable
    public float Ifram = 2f;

    public bool JumpCrate = false;
    //
    public bool HPMax = false;
    // How much the player heals when hiting the health create
    public int Heal = 20;

    // Where the player will respawn after death.
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Set a refrecene to the player's attached rigied body
        rigidbody = GetComponent<Rigidbody>();
        GetComponent<MeshRenderer>().material = SOrange;
        // Set the start position
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            // Faces the player to right.
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
            // Faces the player to left.
            if (goingRight)
            {
                transform.Rotate(Vector3.up * 180);
                goingRight = false;
            }
            // traslate the players speed by speed using time.deltatime
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        HandelJumping();
        Danger();

    }
    /// <summary>
    /// Will handel the players jumping if the player is grounded they will jump if not they wont. if the have the jumpcreate the will jump twice as high
    /// </summary>
    private void HandelJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;

            // If  the rayacast returns true then an object has been hit and the player is toching the floor
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {

                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                if (JumpCrate == true)
                {
                    GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce * 2, ForceMode.Impulse);

                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // // when the player runs into Sentry deal 15 damge to the playe
        if (other.gameObject.tag == "Sentry" && Invceable == false)
        {
            Hp -= 15;
            Invceable = true;
            StartCoroutine(Iframe());
        }
        if (Hp <= 0)
        {
            SceneManager.LoadScene(2);

        }
        // when the player runs into Ridley deal 35 damge to the player
        if (other.gameObject.tag == "Ridley" && Invceable == false)
        {
            Hp -= 35;
            Invceable = true;
            StartCoroutine(Iframe());

            if (Hp <= 0)
            {
                SceneManager.LoadScene(2);

            }

        }
        // when the player runs into jumpcreate set JumpCrate to true and then double the players jump.
        if (other.gameObject.tag == "Jump")
        {
            JumpCrate = true;
            other.gameObject.SetActive(false);
        }
        // when the player runs into MaxHp carete set max hp to 190
        if (other.gameObject.tag == "MaxHp")
        {
            HPMax = true;
            Hp = 190;
            other.gameObject.SetActive(false);
        }
        // when the player runs into HealthPack the will gain 20hp
        if (other.gameObject.tag == "HealthPack")
        {
            Hp += Heal;
            other.gameObject.SetActive(false);
        }
        // when the player runs into the portal the will teleport to the next level.
        if (other.gameObject.tag == "Portal")
        {
            startPosition = other.gameObject.GetComponent<Portal1>().spawnPoint.transform.position;

            transform.position = startPosition;

        }

    }
    IEnumerator Iframe()
    {
        GetComponent<MeshRenderer>().material = Swhite;
        yield return new WaitForSeconds(Ifram);
        Invceable = false;
        GetComponent<MeshRenderer>().material = SOrange;

    }
    /// <summary>
    /// If a Sledgehammer is above the player the will take damage
    /// </summary>
    private void Danger()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, 1f) && Invceable == false)
        {
            if (hit.collider.tag == "Sledgehammer")
            {
                Hp -= 15;
                Invceable = true;
                StartCoroutine(Iframe());
            }
        }


    }
}
