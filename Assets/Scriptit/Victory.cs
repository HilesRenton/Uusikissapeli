using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public Transform boss;
    public Vector3 offset;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(boss.position.x + offset.x, boss.position.y + offset.y, offset.z);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
