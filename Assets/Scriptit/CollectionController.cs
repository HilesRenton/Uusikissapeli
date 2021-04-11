using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour
{

    //Alustetaan tavaran id
    public int id;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Pelaajan osuessa tavaraan, tiettyjä muutoksia tapahtuu pelaajan statseihin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Item 1
        if (collision.tag == "Player" && id == 0)
        {
            PlayerController.collectedAmount++;
            PlayerController.hpUpdate++;
            Destroy(gameObject);
        }
        //Item 2
        if (collision.tag == "Player" && id == 1)
        {
            PlayerController.collectedAmount++;
            PlayerController.dmgUpdate = PlayerController.dmgUpdate + (PlayerController.dmgUpdate / 5);
            Destroy(gameObject);
        }
        //Item 3
        if (collision.tag == "Player" && id == 2)
        {
            PlayerController.collectedAmount++;
            PlayerController.speedUpdate = PlayerController.speedUpdate + (PlayerController.speedUpdate / 5);
            Destroy(gameObject);
        }
        //Item 4
        if (collision.tag == "Player" && id == 3)
        {
            PlayerController.collectedAmount++;
            PlayerController.attSpeedUpdate = PlayerController.attSpeedUpdate - (PlayerController.attSpeedUpdate / 7);
            Destroy(gameObject);
        }
    }
}
