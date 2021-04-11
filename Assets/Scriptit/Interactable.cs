using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public SpriteRenderer sp;
    public int id;
    public int hinta;

    void Start()
    {
    }

    void Update()
    {

        if(isInRange)
        {
            sp.color = new Color(1f, 1f, 1f, .75f);
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
        if(!isInRange)
        {
            sp.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && id == 0)
        {
            isInRange = true;
            Debug.Log("Player now in range");
        }
        else if (collision.tag == "Player" && id == 1)
        {
            isInRange = true;
            Debug.Log("Player now in range");
        }
        else if (collision.tag == "Player" && id == 2)
        {
            isInRange = true;
            Debug.Log("Player now in range");
        }
        else if (collision.tag == "Player" && id == 3)
        {
            isInRange = true;
            Debug.Log("Player now in range");
        }
        else if (collision.tag == "Player" && id == 4)
        {
            isInRange = true;
            Debug.Log("Player now in range");
        }
        else if (collision.tag == "Player" && id == 5)
        {
            isInRange = true;
            Debug.Log("Player now in range");
        }
        else if (collision.tag == "Player" && id == 6)
        {
            isInRange = true;
            Debug.Log("Player now in range");
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInRange = false;
            Debug.Log("Player now not in range");
        }
    }


}
