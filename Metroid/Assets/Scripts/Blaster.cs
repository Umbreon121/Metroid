using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public GameObject beamPrefab;
    
    public bool reloading = false;

    private float reloadTime = 1f;

    public GameObject player;

    public bool HevayBlaster = false;
    public bool Blasters = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.KeypadEnter) && reloading == false) 
        { 
         shootBeam();
        reloading = true;
            StartCoroutine(reload());
        
        }
    }
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

    IEnumerator reload()
    {

        yield return new WaitForSeconds(reloadTime);

        reloading = false;

    }
}
