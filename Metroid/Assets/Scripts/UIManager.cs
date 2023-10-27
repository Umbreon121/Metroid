using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Vila, Mondo
//Edwards, Eric
//10/24/23
//UI to display coins collected and lives


public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    public TMP_Text energyText;

    // Update is called once per frame
    void Update()
    {
        energyText.text = "Energy: " + playerController.energy;
    }
}
