using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite chestClosed;
    public Sprite chestOpen;
    public GameObject[] treasures;

    public SpriteRenderer sp;

    public bool isOpened = false;
    public void OpenChest()
    {
        if (!isOpened)
        {
            isOpened = true;
            int rand = Random.Range(0, treasures.Length);
            sp.sprite = chestOpen;
            Instantiate(treasures[rand], transform.position + new Vector3(0, -1.3f, 0), Quaternion.identity);
        }
        else
        {
        }

    }
}
