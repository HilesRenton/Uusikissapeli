using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile1 : MonoBehaviour
{
    //Projectilen nopeus, damage ja pelaajan alustus
    public float speed = 7f;
    private Transform player;
    private Vector2 movedirection;
    Rigidbody2D rb;
    GameObject playerref;
    PlayerController playerscript;
    public int dmg;


    void Start()
    {
        //Alustetaan pelaaja, ja ammuntasuunta pelaajan sijainnista
        playerref = GameObject.FindGameObjectWithTag("Player");
        playerscript = playerref.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        movedirection = (player.transform.position - transform.position).normalized * speed;
        movedirection.x = movedirection.x + Random.Range(-7, 7);
        movedirection.y = movedirection.y + Random.Range(-7, 7);
        rb.velocity = new Vector2(movedirection.x, movedirection.y);
        Destroy(gameObject, 6f);
    }

    void Update()
    {

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