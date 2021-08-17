using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFollowMouse : MonoBehaviour
{
    private Animator anim;
    public GameObject bullet,bullet1,bullet2;
    public Transform bulletpos,bulletpos1;
    public Rigidbody2D rb;
    public float bulletspeed = 5f;
    private Vector2 moving;//MousePos;
    public float moveSpeed=4f, temporarytimeforshop = 0.35f;
    public int maxhealth,currenthealth;
    public static PlayerFollowMouse instance;
    public Camera cam;
    public GameObject Sheild,Sheild1,Sheild2,shotGun,GameOver,flash,addhealth,redtorso,greentorso,pinktorso;
    public bool Sheild0onoroff=false, Sheild1onoroff = false,Sheild2onoroff = false,healthbuy=false;
    public int Coins=0;
    public HealthBar healthBar;
    public Text coin;
    public bool shotgun = false, ShotGun = false, gameover = false;
    AudioSource walking;
    public Joystick moveJoystick;public Joystick shootJoystick;
    public bool canShoot;
    public float cooldown;
    //public static bool redtorsoonoroff, greentorsoonoroff, pinktorsoonoroff;int issoldred,issoldgreen,issoldpink,isspeeD,isbullet;
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        anim = GetComponent<Animator>();
        walking = GetComponent<AudioSource>();
    }
    void Start()
    {
        coin.text = Coins.ToString();
        currenthealth = maxhealth;
        healthBar.setmaxhealth(maxhealth);
        if (ads.shottgun == true)
        {
            shotGun.SetActive(true);
            ShotGun = true;
        }
        /* print(isspeeD);print(moveSpeed);
         if (isspeeD == 6) { moveSpeed = 4f; }
         else if (isspeeD == 5) { moveSpeed = 4.2f; }
         else if (isspeeD == 4) { moveSpeed = 4.4f; }
         else if (isspeeD == 3) { moveSpeed = 4.6f; }
         else if (isspeeD == 2) { moveSpeed = 4.8f; }
         else if (isspeeD == 1) { moveSpeed = 5f; }
         else moveSpeed = 4.5f;

         if (ShopManager.shottgun == false)
         {
             if (isbullet == 6) { temporarytimeforshop = 0.35f; }
             else if (isbullet == 5) { temporarytimeforshop = 0.32f; }
             else if (isbullet == 4) { temporarytimeforshop = 0.30f; }
             else if (isbullet == 3) { temporarytimeforshop = 0.29f; }
             else if (isbullet == 2) { temporarytimeforshop = 0.27f; }
             else if (isbullet == 1) { temporarytimeforshop = 0.25f; }
         }
         else if (ShopManager.shottgun==true)
         {
             if (isbullet == 6) { temporarytimeforshop = 0.42f; }
             else if (isbullet == 5) { temporarytimeforshop = 0.40f; }
             else if (isbullet == 4) { temporarytimeforshop = 0.39f; }
             else if (isbullet == 3) { temporarytimeforshop = 0.37f; }
             else if (isbullet == 2) { temporarytimeforshop = 0.34f; }
             else if (isbullet == 1) { temporarytimeforshop = 0.30f; }
         }
         print(issoldred);
         if (issoldred == 1)
         {
             redtorso.SetActive(true);
         }
         else if (issoldred == 0) redtorso.SetActive(false);

         if (issoldgreen == 1)
         {
             greentorso.SetActive(true);
         }
         else if (issoldgreen == 0) greentorso.SetActive(false);
         if (issoldpink == 1)
         {
             pinktorso.SetActive(true);
         }
         else if (issoldpink == 0) pinktorso.SetActive(false);
         */
    }
    void Update()
    {
        
        
        if (Sheild0onoroff)
        {
        Sheild.SetActive(true);

        if (maxhealth == currenthealth)
        {
            healthBar.setmaxhealth(125);
        }
        }
        else
        {
        Sheild.SetActive(false);
        }
        if (Sheild1onoroff)
                {
                    Sheild1.SetActive(true);
                    if (maxhealth == currenthealth)
                    {
                        healthBar.setmaxhealth(150);
                    }
        }
        else
                {
                    Sheild1.SetActive(false);
        }
                if (Sheild2onoroff)
                {
                    Sheild2.SetActive(true);
                    if (maxhealth == currenthealth)
                    {
                        healthBar.setmaxhealth(175);
                    }

                }

                else
                {
                    Sheild2.SetActive(false);
                }

                if (healthbuy)
                {
                    healthbuy = false;

                    currenthealth = currenthealth + 25;

                    healthBar.SetHealth(currenthealth);

                    coin.text = (Coins - 25).ToString();

                    Coins = Coins - 25;

                    StartCoroutine(showaddhealth());

                }

        if (ads.shottgun==true)
        {
            shotGun.SetActive(true);
            ShotGun = true;
        }

                if (shotgun)
                {
                    coin.text = (Coins - 75).ToString();
                    Coins = Coins - 75;
                    shotgun = false;
                }
                if (gameover)
                {
                    GameOver.SetActive(true);
                    moveSpeed = 0;
                    canShoot = false;
                   // ShopManager.shottgun = false;
                    
                }
                if (anim.GetBool("Speed"))
                {
                    if (!walking.isPlaying)
                    {
                        walking.Play();
                    }
                }
                else
                {
                    walking.Stop();
                }
         /*issoldred = PlayerPrefs.GetInt("BuyReD");
        issoldgreen = PlayerPrefs.GetInt("BuyGreeN");
        issoldpink = PlayerPrefs.GetInt("BuyPinK");
        isspeeD = PlayerPrefs.GetInt("SpeedBuy");

        isbullet = PlayerPrefs.GetInt("BulletBuy");
        */

                Death();
                CoolDownTimer();
                }
            void FixedUpdate()
            {
        moving.x = Input.GetAxisRaw("Horizontal");
        moving.y = Input.GetAxisRaw("Vertical");
        if (canShoot && cooldown == 0)
        {
            Shoot();
            cooldown = temporarytimeforshop;
        }
        //Vector2 LookDir = MousePos - rb.position;
            if (moveJoystick.InputDir != Vector3.zero)
            {
            moving = moveJoystick.InputDir;
            
            }
            rb.MovePosition(rb.position + moving * moveSpeed * Time.fixedDeltaTime);
            Movement();
            if (shootJoystick.InputDir != Vector3.zero)
                {
                    float angle = Mathf.Atan2(shootJoystick.InputDir.y, shootJoystick.InputDir.x) * Mathf.Rad2Deg + 1;
                    rb.rotation = angle;
                }
                // float angless = Mathf.Atan2(looking.y, looking.x) * Mathf.Rad2Deg + 1;


                // rb.rotation = angless;
            }

            void CoolDownTimer()
            {
                if (cooldown > 0)
                {
                    cooldown -= Time.deltaTime;
                }
                if (cooldown < 0)
                {
                    cooldown = 0;
                }
            }

            void Movement()
            {
                if (moving.x > 0 || moving.x < 0 || moving.y > 0 || moving.y < 0)
                {
                    anim.SetBool("Speed", true);
                }
                else
                {

                    anim.SetBool("Speed", false);
                }

            }
            void Shoot()
            {
                /* if (Input.GetMouseButtonDown(0)&&!gameover)
                 {

                     if (!ShotGun)
                     {

                         FindObjectOfType<SoundManager>().Play("pistol");
                         Instantiate(bullet, bulletpos.position, Quaternion.identity);
                         anim.SetTrigger("Shoot");
                     }
                     else if (ShotGun)
                     {
                         FindObjectOfType<SoundManager>().Play("shotgun");
                         StartCoroutine(ShotgunBulletspawn());
                         anim.SetTrigger("ShotGunShoot");
                     }

                 }*/

                if (!ShotGun)
                {
                    StartCoroutine(Bulletspawnpistol());

                    //Instantiate(bullet, bulletpos.position, Quaternion.identity);
                    anim.SetTrigger("Shoot");
                }
                else if (ShotGun)
                {
                    FindObjectOfType<SoundManager>().Play("shotgun");
                    StartCoroutine(ShotgunBulletspawn());
                    anim.SetTrigger("ShotGunShoot");
                }


            }
            IEnumerator ShotgunBulletspawn()
            {
                Instantiate(bullet1, bulletpos1.position, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                Instantiate(bullet2, bulletpos1.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                StopCoroutine(ShotgunBulletspawn());
            }
            IEnumerator Bulletspawnpistol()
            {
                FindObjectOfType<SoundManager>().Play("pistol");
                Instantiate(bullet, bulletpos.position, Quaternion.identity);
                yield return new WaitForSeconds(0.01f);

                StopCoroutine(Bulletspawnpistol());
            }
            IEnumerator showaddhealth()
            {
                addhealth.SetActive(true);
                yield return new WaitForSeconds(0.2f);
                addhealth.SetActive(false);
                StopCoroutine(showaddhealth());
            }

            public void TakeDamage(int damage)
            {
        FindObjectOfType<CameraShake>().shakeitmedium();
        if (!gameover)
                {
                    
                    StartCoroutine(PlayerFlash());
                    currenthealth -= damage;
                    healthBar.SetHealth(currenthealth);
                }
            }
            void Death()
            {
                if (currenthealth <= 0)
                {
                    gameover = true;
                    flash.SetActive(false);
                    ads.shottgun = false;
                }
            }
            IEnumerator PlayerFlash()
            {
                flash.SetActive(true);

                yield return new WaitForSeconds(0.5f);

                flash.SetActive(false);

                StopCoroutine(PlayerFlash());
            }
            void OnCollisionEnter2D(Collision2D col)
            {
                if (col.gameObject.tag == "Coins")
                {
                    Destroy(col.gameObject);
                    Coins = Coins + 1;
                    coin.text = Coins.ToString();
                    ShopManager.CoinS = Coins;
                }
            }
        }
