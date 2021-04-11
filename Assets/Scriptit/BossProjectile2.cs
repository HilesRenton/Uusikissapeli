using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile2 : MonoBehaviour
{
    //Projectilen nopeus, damage ja pelaajan alustus
    public float speed = 7f;
    private Transform player;
    private Vector2 movedirection;
    public GameObject projectileFragment;
    Rigidbody2D rb;
    GameObject playerref;
    PlayerController playerscript;
    public float elapsed;
    public int dmg;


    void Start()
    {
        //Alustetaan pelaaja, ja ammuntasuunta pelaajan sijainnista
        playerref = GameObject.FindGameObjectWithTag("Player");
        playerscript = playerref.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        movedirection = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(movedirection.x, movedirection.y);
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        //Sirpaleitten spawnaaminen
        elapsed += Time.deltaTime;
        if (elapsed >= 1.99f)
        {
            Instantiate(projectileFragment, transform.position, Quaternion.identity);
            Instantiate(projectileFragment, transform.position, Quaternion.identity);
            Instantiate(projectileFragment, transform.position, Quaternion.identity);
            Instantiate(projectileFragment, transform.position, Quaternion.identity);
            Instantiate(projectileFragment, transform.position, Quaternion.identity);
            Instantiate(projectileFragment, transform.position, Quaternion.identity);
            Instantiate(projectileFragment, transform.position, Quaternion.identity);
            Instantiate(projectileFragment, transform.position, Quaternion.identity);
            Instantiate(projectileFragment, transform.position, Quaternion.identity);
        }
    }


    //Pelaajaan tai muuhun osuessa projectilen tuhoutuminen ja pelaajan HP tippuminen, jos osuttu on pelaaja
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
            playerscript.LoseHealth(dmg);
        }
        else if (other.CompareTag("Wall"))
        {
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}