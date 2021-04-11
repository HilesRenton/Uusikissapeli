using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileFragment : MonoBehaviour
{
    //Projectilen nopeus, damage ja pelaajan alustus
    public float speed = 10f;
    private Transform player;
    GameObject playerref;
    PlayerController playerscript;
    private Vector2 movedirection;
    Vector2 x;
    Vector2 y;
    private Transform random;
    Rigidbody2D rb;
    public int dmg;


    void Start()
    {
        //Alustetaan pelaaja, ja ammuntasuunta pelaajan sijainnista
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerref = GameObject.FindGameObjectWithTag("Player");
        playerscript = playerref.GetComponent<PlayerController>();
        random = transform;
        movedirection = (random.position - transform.position).normalized * speed;
        movedirection.x = movedirection.x + Random.Range(-10, 10);
        movedirection.y = movedirection.y + Random.Range(-10, 10);
        rb.velocity = new Vector2(movedirection.x, movedirection.y);
        Destroy(gameObject, 4f);
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