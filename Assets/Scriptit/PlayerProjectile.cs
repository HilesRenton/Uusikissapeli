using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    public float speed = 20f;
    public float splashDistance = 3f;
    public Rigidbody2D rb;
    GameObject enemy;
    EnemyController script;
    BossController bscript;
    public SpriteRenderer sp;
    GameObject boss;
    void Start()
    {
        
    }

    void Update()
    {
        rb.velocity = transform.right * speed;
        if (PlayerController.poisonammo)
        {
            sp.color = new Color(0,1,0,1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if(collision.tag == "Enemy")
        {
            //Räjähtäviin panoksiin liittyvä logiikka
            if (splashDistance > 0 && PlayerController.explosiveshot)
            {
                var hitColliders = Physics2D.OverlapCircleAll(transform.position, splashDistance);

                foreach (var hitCollider in hitColliders)
                {
                    var vihu = hitCollider.GetComponent<EnemyController>();
                    if (vihu)
                    {
                        var closestPoint = hitCollider.ClosestPoint(transform.position);
                        var distance = Vector3.Distance(closestPoint, transform.position);

                        var dmgPercentage = Mathf.InverseLerp(splashDistance, 0, distance);
                        vihu.TakeHit(dmgPercentage * PlayerController.dmgUpdate);
                    }
                }
            }

            //vihun hp pois
            enemy = collision.gameObject;
            script = enemy.GetComponent<EnemyController>();
            if (!PlayerController.explosiveshot)
            {
                script.TakeHit(PlayerController.dmgUpdate);
            }
            if (PlayerController.poisonammo)
            {
                script.ticks = 0;
                script.isPoisoned = true;
            }
            Destroy(gameObject);
        }

        else if (collision.tag == "Player" || collision.tag == "Item" || collision.tag == "Projectile" || collision.tag == "Dummy" || collision.tag == "BossRoom" || collision.tag == "Shop" || collision.tag == "MainRoom")
        {
            //eimitää
        }

        else if (collision.tag == "Boss")
        {
            //vihun hp pois
            boss = collision.gameObject;
            bscript = boss.GetComponent<BossController>();
            bscript.TakeHit(PlayerController.dmgUpdate);
            if (PlayerController.poisonammo)
            {
                bscript.ticks = 0;
                bscript.isPoisoned = true;
            }
            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
