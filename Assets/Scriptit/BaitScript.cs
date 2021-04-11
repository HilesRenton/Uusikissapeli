using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaitScript : MonoBehaviour
{
    public static bool hasBait = false;
    public KeyCode interactKey;
    public Transform player;
    public GameObject meat;
    private float timer;
    private bool timeStarted = false;
    private Image baitImg;

    // Start is called before the first frame update
    void Start()
    {
        baitImg = GameObject.FindGameObjectWithTag("BaitInventory").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBait)
        {
            if (Input.GetKeyDown(interactKey) && !timeStarted)
            {
                hasBait = false;
                EnemyController.isThereAnyMeat = true;
                Instantiate(meat, player.position, player.rotation);
                timeStarted = true;
                baitImg.enabled = false;
            }
        }
        if (timeStarted)
        {
            timer = timer + Time.deltaTime;
            Debug.Log("timer=" + timer + "timedeltatime=" + Time.deltaTime);
            if (timer > 5f)
            {
                EnemyController.isThereAnyMeat = false;
                timeStarted = false;
                timer = 0f;
                Destroy(GameObject.FindGameObjectWithTag("Dummy"));
            }
        }
    }
}