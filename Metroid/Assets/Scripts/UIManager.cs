using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Vila, Mondo
//Edwards, Eric
//11/13/23
//UI to display coins collected and lives


public class UIManager : MonoBehaviour
{
        public PlayerController controller;
        public RidleyBoss Rcontroller;
        public TMP_Text Rhp;
        public TMP_Text lives;

        // Update is called once per frame
        void Update()
        {
            // will update the coin counter each time the player runs into one
            Rhp.text = "Ridley HP: " + Rcontroller.Hp;
            // will update the live counter each time the player respawns
            lives.text = "Hp:" + controller.Hp;
        }
  
}
