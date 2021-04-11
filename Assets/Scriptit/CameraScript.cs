using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    public AudioSource music;
    private bool isChanged = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
        if (PlayerController.visitedboss == true || PlayerController.visitedshop == true)
        {
            music.enabled = false;
        }
        else
        {
            music.enabled = true;
        }

        if (PlayerController.visitedboss && !isChanged)
        {
            Camera.main.GetComponent<Camera>().orthographicSize = Camera.main.GetComponent<Camera>().orthographicSize + 4;
            isChanged = true;
        }
    }

}