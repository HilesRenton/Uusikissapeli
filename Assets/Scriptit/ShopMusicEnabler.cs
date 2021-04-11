using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMusicEnabler : MonoBehaviour
{
    public AudioSource shopmusic;
    public AudioSource victory;


    // Update is called once per frame
    void Update()
    {
        if (PlayerController.visitedshop == true)
        {
            shopmusic.enabled = true;
        }
        else
        {
            shopmusic.enabled = false;
        }
        if (PlayerController.victory == true)
        {
            victory.enabled = true;
        }
        else
        {
            victory.enabled = false;
        }
    }

}