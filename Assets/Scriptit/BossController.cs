using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    //Statseja ja hpbar
    public int hp;
    public int maxhp;
    public BossHealth healthbar;
    private float attackSpeed;
    public float startAttackSpeed;
    public GameObject health;
    public AudioSource bossmusic;
    public AudioSource victory;

    //timereita yms
    public bool isPoisoned = false;
    public int ticks = 0;
    float elapsed = 0f;
    float attackStyleTime = 0f;
    private bool normalAttack = true;
    private int critical;

    //Komponentteja
    public GameObject projectile1;
    public GameObject projectile2;
    PlayerController playerscript;
    GameObject playerref;
    public Transform player;
    public Animator animator;

    void Start()
    {
        //Alustetaan pelaaja,sekä omat hp:t
        maxhp = hp;
        playerref = GameObject.FindGameObjectWithTag("Player");
        playerscript = playerref.GetComponent<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackSpeed = startAttackSpeed;
        healthbar.SetMaxHealth(maxhp);

    }
    void Update()
    {
        critical = Random.Range(0, 10);
        //Animaatio
        animator.SetFloat("Horizontal", player.position.x - transform.position.x);
        animator.SetFloat("Vertical", player.position.y - transform.position.y);

        //Ammuntascripti
        if (normalAttack)
        {
            if (attackSpeed <= 0 && PlayerController.visitedboss && true)
            {

                Instantiate(projectile1, transform.position, Quaternion.identity);
                attackSpeed = startAttackSpeed;
                health.SetActive(true);
                bossmusic.enabled = true;

            }
            else
            {
                attackSpeed -= Time.deltaTime;
            }
        }
        if (!normalAttack)
        {
            if (attackSpeed <= 0 && PlayerController.visitedboss && true)
            {
                Instantiate(projectile2, transform.position, Quaternion.identity);
                attackSpeed = startAttackSpeed;
                health.SetActive(true);
                bossmusic.enabled = true;

            }
            else
            {
                attackSpeed -= Time.deltaTime / 4;
            }
        }
        //Tuhoutuminen
        if (hp <= 0)
        {
            health.SetActive(false);
            bossmusic.enabled = false;
            PlayerController.victory = true;
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

        }
        //Ampumistyylin vaihtuminen
        attackStyleTime += Time.deltaTime;
        if(attackStyleTime >= 8f == normalAttack)
        {
            attackStyleTime = attackStyleTime % 8f;
            normalAttack = false;
        }
        else if (attackStyleTime >= 8f == !normalAttack)
        {
            attackStyleTime = attackStyleTime % 8f;
            normalAttack = true;
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

        //hpbar update
        healthbar.SetHealth(hp);
    }

    public void TakeHit(int dmg)
    {

        if (PlayerController.critical && critical > 8)
        {
            hp = hp - dmg * 4;
            healthbar.SetHealth(hp);
            Debug.Log("Crit!");
        }
        else
        {
            hp = hp - dmg;
            healthbar.SetHealth(hp);
        }

    }
}