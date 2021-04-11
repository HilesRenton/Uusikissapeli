using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    //Statsit
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float revealDistance;
    private float attackSpeed;
    public float startAttackSpeed;
    public float hp;
    public float hpupdate = 0;
    public float maxhp;
    public float attackRange;

    //Komponentit
    public GameObject projectile;
    public Transform player;
    private AudioSource Boom;
    PlayerController playerscript;
    GameObject playerref;
    public Animator animator;
    public GameObject meat;

    //UI
    public EnemyHealthbar healthbar;

    //ID(melee = 1 vai range = 0)
    public int id;

    //Timerit yms.
    private float lastAttackTime;
    public bool isPoisoned = false;
    float elapsed = 0f;
    public int ticks = 0;
    public static bool isThereAnyMeat = false;
    private int critical; 

    void Start()
    {
        //Alustetaan vastustajalle löydettävä pelaaja, ammusääni ja statsit
        playerref = GameObject.FindGameObjectWithTag("Player");
        playerscript = playerref.GetComponent<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackSpeed = startAttackSpeed;
        Boom = GetComponent<AudioSource>();
        hpupdate = hp;
        maxhp = hp;
    }

    void Update()
    {
        critical = Random.Range(0, 10);
        //Liikkumis, ja löytämis scripti, sekä ansan priorisointi
        if (!isThereAnyMeat) 
        {
            meat = null;
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) < revealDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            } else if (Vector2.Distance(transform.position, player.position) < retreatDistance) {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
        }
        else
        {
            meat = GameObject.FindGameObjectWithTag("Dummy");
            transform.position = Vector2.MoveTowards(transform.position, meat.transform.position, speed * Time.deltaTime);
        }

        //Myrkytysvahingon otto
        if (ticks > 4)
        {
            isPoisoned = false;
        }
        if (isPoisoned)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;
                TakeHit(8);
                ticks++;
            }
        }

        //Ammuntascripti
        if(attackSpeed <= 0 && id == 0 && Vector2.Distance(transform.position, player.position) < revealDistance)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            Boom.Play();
            attackSpeed = startAttackSpeed;

        }else
        {
            attackSpeed -= Time.deltaTime;
        }
        //Mage-ammuntascripti
        if (attackSpeed <= 0 && id == 2 && Vector2.Distance(transform.position, player.position) < revealDistance)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attackSpeed = startAttackSpeed;

        }
        else
        {
            attackSpeed -= Time.deltaTime;
        }

        animator.SetFloat("Horizontal", player.position.x - transform.position.x);
        animator.SetFloat("Vertical", player.position.y - transform.position.y);
        animator.SetFloat("Speed", transform.position.magnitude);

        //Melee iskuscripti
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < attackRange && id == 1)
        {
            if (attackSpeed <= 0)
            {
                playerscript.LoseHealth(5);
                Boom.Play();
                attackSpeed = startAttackSpeed;
            }
            else
            {
                attackSpeed -= Time.deltaTime;
            }
        }

        //Tuhoutuminen
        if(hpupdate <= 0)
        {
            Destroy(gameObject);
            PlayerController.raha = PlayerController.raha + 10;
        }
        //hpbar update
        healthbar.SetHealth(hpupdate, maxhp);

    }

    private void FixedUpdate()
    {
        
    }

    //Healthbarin toiminta
    public void TakeHit(float dmg)
    {
        if (PlayerController.critical && critical > 8)
        {
            hpupdate = hpupdate - dmg * 4;
            healthbar.SetHealth(hpupdate, maxhp);
            Debug.Log("Crit!");
        }
        else
        {
            hpupdate = hpupdate - dmg;
            healthbar.SetHealth(hpupdate, maxhp);
        }
    }



}
