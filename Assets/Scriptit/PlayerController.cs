using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{   
    //Komponentit
    public Rigidbody2D rgbody;
    private Camera cam;
    public Animator animator;
    public HealthBar healthBar;


    //UI tekstit
    public Text healtit;
    public Text damaget;
    public Text speedit;
    public Text aspeedit;
    public Text rahat;

    //Statsit
    public static int collectedAmount = 0;
    public float speed;
    public static float speedUpdate = 0;
    public int hp;
    public static int hpUpdate = 0;
    public float attSpeed;
    public static float attSpeedUpdate = 0;
    public int dmg;
    public static int dmgUpdate = 0;
    public static int maxHp = 0;
    public static int raha = 0;

    //Aikoja yms
    private float invincibilityTime = 0.5f;
    private bool isInvincible = false;
    

    //Ammus-modifierit
    public static bool poisonammo = false;
    public static bool tripleshot = false;
    public static bool explosiveshot = false;
    public static bool critical = false;

    //Teleporttien toiminta
    public static bool visitedshop = false;
    public static bool visitedboss = false;
    public static bool victory = false;





    void Start()
    {
        // Alustetaan pelaajan attribuutit
        hpUpdate = hp;
        attSpeedUpdate = attSpeed;
        speedUpdate = speed;
        dmgUpdate = dmg;
        cam = Camera.main;
        healthBar.SetMaxHealth(hp);
        maxHp = hp;
        raha = 0;
        
    }

    void Update()
    {
        //Alustetaan X ja Y akseleiden liikkumispainikkeet
        attSpeed = attSpeedUpdate;
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        //Alustetaan pelaajan nopeus "Speed" statsista ja näkyvät UI tekstit
        rgbody.velocity = new Vector3(hor * speedUpdate, ver * speedUpdate, 0);
        healtit.text = hpUpdate + "/" + hp;
        damaget.text = "DMG = " + dmgUpdate;
        speedit.text = "MS = " + speedUpdate;
        aspeedit.text = "AS = " + attSpeedUpdate;
        rahat.text = "" + raha;
        healthBar.SetMaxHealth(hp);
        healthBar.SetHealth(hpUpdate);


        //Animaatioita varten suunnat ja muut
        animator.SetFloat("Horizontal", hor);
        animator.SetFloat("Vertical", ver);
        animator.SetFloat("Speed", rgbody.velocity.magnitude);


        //Jos pelaajan HP 0 tai alle, siirtymä Main menuun
        if (hpUpdate <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //Jos pelaajan hp menee maksimin yli, ne laskevat maksimiin
        if(hpUpdate > maxHp)
        {
            hpUpdate = maxHp;
        }



    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("invincible");
        isInvincible = true;

        yield return new WaitForSeconds(invincibilityTime);

        isInvincible = false;
        Debug.Log("not invincible");
    }

    public void LoseHealth(int amount)
    {
        if (isInvincible) return;

        hpUpdate -= amount;

        StartCoroutine(BecomeTemporarilyInvincible());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shop")
        {
            visitedshop = true;
        }
        else if( collision.tag == "BossRoom")
        {
            visitedshop = false;
            visitedboss = true;
        }
        else if (collision.tag == "MainRoom")
        {
            visitedshop = false;
            visitedboss = false;
        }
    }

}
