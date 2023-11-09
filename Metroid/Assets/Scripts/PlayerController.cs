using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public bool goingRight = true;

    public Material Swhite;

    public Material SOrange;

    public bool Invceable = false;

    public float Ifram = 2f;

    public bool JumpCrate = false;

    public bool HPMax = false;

    public int Heal = 20;

    // Start is called before the first frame update
    void Start()
    {
        // Set a refrecene to the player's attached rigied body
        rigidbody = GetComponent<Rigidbody>();
        GetComponent<MeshRenderer>().material = SOrange;
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

                if (JumpCrate == true)
                {
                    GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce * 2, ForceMode.Impulse);

                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
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
        if (other.gameObject.tag == "Jump")
        {
            JumpCrate = true;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "MaxHp")
        {
            HPMax = true;
            Hp = 190;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "HealthPack")
        {
            Hp += Heal;
            other.gameObject.SetActive(false);
        }


    }
    IEnumerator Iframe()
    {
        GetComponent<MeshRenderer>().material = Swhite;
        yield return new WaitForSeconds(Ifram);
        Invceable = false;
        GetComponent<MeshRenderer>().material = SOrange;

    }
}
