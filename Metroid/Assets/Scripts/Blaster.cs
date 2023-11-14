using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Vila, Mondo
//Edwards, Eric
//11/13/23
//Will shoot the blaster on enter click

public class Blaster : MonoBehaviour
{
    // Will get the beam Prefab
    public GameObject beamPrefab;
    /// How fast the player can fire the beam
    public bool reloading = false;
    // the wait time before the player can fire
    private float reloadTime = 1f;
    //Will get the player Object
    public GameObject player;
    //Will get the heavy blaster for the player
    public bool HevayBlaster = false;
    // Will get the normal blaster
    public bool Blasters = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // will fire the blaster when the player press keypad enter and reloading is false then sets reloading to ture the starts the reload coroutine
        if(Input.GetKey(KeyCode.KeypadEnter) && reloading == false) 
        { 
         shootBeam();
        reloading = true;
            StartCoroutine(reload());
        
        }
    }
    /// <summary>
    /// Will shot a beam left or right deping on which way the player is faceing
    /// </summary>
    private void shootBeam()
    {
        if (player.transform.rotation.y == 0) 
        {
            if (Blasters == true)
            {
                GameObject BeamInstance = Instantiate(beamPrefab, transform.position, transform.rotation);
                BeamInstance.GetComponent<Beam>().goingRight = GameObject.Find("Samus").GetComponent<PlayerController>().goingRight;
            }
        }
        else 
        {
            if (Blasters == true)
            {
                GameObject BeamInstance = Instantiate(beamPrefab, transform.position, transform.rotation);
                BeamInstance.GetComponent<Beam>().goingRight = GameObject.Find("Samus").GetComponent<PlayerController>().goingRight;
            }
        }
    }
    /// <summary>
    /// will reload based on reload time the set reloading to false
    /// </summary>
    /// <returns></returns>
    IEnumerator reload()
    {

        yield return new WaitForSeconds(reloadTime);

        reloading = false;

    }
}
