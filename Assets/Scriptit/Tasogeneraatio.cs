using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasogeneraatio : MonoBehaviour
{
    public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        float rand = Random.Range(0.2f, 0.9f);
        Invoke("Spawn", rand);
    }

    private void Update()
    {

    }

    private void Spawn()
    {
        int rand = Random.Range(0, objects.Length);
        Instantiate(objects[rand], transform.position, Quaternion.identity);
    }

}