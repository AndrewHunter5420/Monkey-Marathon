using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MonkeyScript : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public HealthBarScript healthBar;

    public bool isDead;

    public int sneakSpeed = 3;
    public int sprintSpeed = 15;
    public int moveSpeed;
    public bool toggleSneak;
    public bool isSneaking;

    public int maxPistolAmmo, pistolDmg, maxSlingshotAmmo, maxShotgunAmmo, shotgunDmg, maxARAmmo, ARDmg;
    public int pistolAmmo, slingshotAmmo, shotgunAmmo, ARAmmo;

    public GameObject ammoTextObject;
    private TMP_Text ammoText;

    public bool pistolPurchased, slingshotPurchased, shotgunPurchased, ARPurchased, silencerPurchased;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    private WeaponScript weaponscript;

    public string weapon = "AR";
    public float pistolCooldown = 0.5f;
    public float slingshotCooldown = 1.5f;
    public float shotgunCooldown = 1.3f;
    public float ARCooldown = 0.4f;
    private float currTime;
    public bool loud = false;

    public GameObject distanceTracker;
    private DistanceScript distanceScript;

    public GameObject Hotbar;
    private HotBarScript hotbarScript;

    public GameObject goldTracker;
    private GoldScript goldScript;

    public GameObject noise;

    public GameObject DeathScreen;
    private DeathScreenScript deathScript;

    public SpriteRenderer spriteRenderer;
    private Animator anim;

	public AudioSource getHit;
	public AudioSource footsteps;
	public AudioSource theme;
	private double volume;
	private double musicVol;

    private void Start()
    {
        spriteRenderer.enabled = false;
        isDead = false;

        currTime = 0f;
        weaponscript = gameObject.GetComponent<WeaponScript>();
        distanceScript = distanceTracker.GetComponent<DistanceScript>();
        goldScript = goldTracker.GetComponent<GoldScript>();
        deathScript = DeathScreen.GetComponent<DeathScreenScript>();
        hotbarScript = Hotbar.GetComponent<HotBarScript>();
        anim = GetComponent<Animator>();

        pistolAmmo = maxPistolAmmo;
        slingshotAmmo = maxSlingshotAmmo;
        shotgunAmmo = maxShotgunAmmo;
        ARAmmo = maxARAmmo;

        ammoText = ammoTextObject.GetComponent<TMP_Text>();
        switch (weapon)
        {
            case "pistol":
                SetAmmoText(pistolAmmo, maxPistolAmmo);
                hotbarScript.selectPistol();
                break;
            case "slingshot":
                SetAmmoText(slingshotAmmo, maxSlingshotAmmo);
                hotbarScript.selectSlingshot();
                break;
            case "shotgun":
                SetAmmoText(shotgunAmmo, maxShotgunAmmo);
                hotbarScript.selectShotgun();
                break;
            case "AR":
                SetAmmoText(ARAmmo, maxARAmmo);
                hotbarScript.selectAR();
                break;
        }

        toggleSneak = PlayerPrefs.GetInt("toggleSneak") == 1;
        moveSpeed = sprintSpeed;

        // The float values (20,10,100) are to scale the sound volume to a reasonable level
		volume = PlayerPrefs.GetInt("SFXVol");
		getHit.volume = (float)volume / 20f;
		footsteps.volume = (float)volume / 10f;

        musicVol = PlayerPrefs.GetInt("musicVol");
		theme.volume = (float)musicVol / 100f;
    }

    public void Restart()
    {
        isDead = false;
        currTime = 0f;

        gameObject.transform.position = new Vector2(0f, 0f);

        setMaxHealth(maxHealth);

        pistolAmmo = maxPistolAmmo;
        slingshotAmmo = maxSlingshotAmmo;
        shotgunAmmo = maxShotgunAmmo;
        ARAmmo = maxARAmmo;

        switch (weapon)
        {
            case "pistol":
                SetAmmoText(pistolAmmo, maxPistolAmmo);
                hotbarScript.selectPistol();
                break;
            case "slingshot":
                SetAmmoText(slingshotAmmo, maxSlingshotAmmo);
                hotbarScript.selectSlingshot();
                break;
            case "shotgun":
                SetAmmoText(shotgunAmmo, maxShotgunAmmo);
                hotbarScript.selectShotgun();
                break;
            case "AR":
                SetAmmoText(ARAmmo, maxARAmmo);
                hotbarScript.selectAR();
                break;
        }
    }

    void Update()
    {
        if (!isDead)
        {
            // dev commands for testing:
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Dies();
            }
            
            float xMove = Input.GetAxisRaw("Horizontal");
            float yMove = Input.GetAxisRaw("Vertical");

            movement.x = xMove;
            movement.y = yMove;

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetKeyDown(KeyCode.Alpha1) && pistolPurchased == true)
            {
                weapon = "pistol";
                SetAmmoText(pistolAmmo, maxPistolAmmo);
                hotbarScript.selectPistol();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && slingshotPurchased == true)
            {
                weapon = "slingshot";
                SetAmmoText(slingshotAmmo, maxSlingshotAmmo);
                hotbarScript.selectSlingshot();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && shotgunPurchased == true)
            {
                weapon = "shotgun";
                SetAmmoText(shotgunAmmo, maxShotgunAmmo);
                hotbarScript.selectShotgun();

            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && ARPurchased == true)
            {
                weapon = "AR";
                SetAmmoText(ARAmmo, maxARAmmo);
                hotbarScript.selectAR();
            }

            // Weapon Fire:
            if (Input.GetButton("Fire1"))
            {
                if (weapon == "pistol" && currTime <= Time.time && pistolAmmo > 0)
                {
                    weaponscript.pistolShoot();

                    pistolAmmo--;
                    SetAmmoText(pistolAmmo, maxPistolAmmo);

                    currTime = Time.time + pistolCooldown;
                //loud = true;
                if (silencerPurchased == false) //checks if silencer purchased
                {
                    GameObject gunSound = Instantiate(noise, transform.position, weaponscript.firePoint.rotation * Quaternion.Euler(0f, 0f, 180f));
                }
                //Destroy(gunSound, 0.5f);
                }
                else if (weapon == "slingshot" && currTime <= Time.time && slingshotAmmo > 0)
                {
                    weaponscript.slingshotShoot();

                    slingshotAmmo--;
                    SetAmmoText(slingshotAmmo, maxSlingshotAmmo);

                    currTime = Time.time + slingshotCooldown;
                }
                else if (weapon == "shotgun" && currTime <= Time.time && shotgunAmmo > 0)
                {
                    currTime = Time.time + shotgunCooldown;
                    StartCoroutine(weaponscript.shotgunShoot());

                    shotgunAmmo--;
                    SetAmmoText(shotgunAmmo, maxShotgunAmmo);
                //loud = true;
                GameObject gunSound = Instantiate(noise, transform.position, weaponscript.firePoint.rotation * Quaternion.Euler(0f, 0f, 180f));
                //Destroy(gunSound, 0.5f);
                }
                else if (weapon == "AR" && currTime <= Time.time && ARAmmo > 0)
                {
                    currTime = Time.time + ARCooldown;
                    StartCoroutine(weaponscript.ARShoot());

                    ARAmmo--;
                    SetAmmoText(ARAmmo, maxARAmmo);
                //loud = true;
                GameObject gunSound = Instantiate(noise, transform.position, weaponscript.firePoint.rotation * Quaternion.Euler(0f, 0f, 180f));
                //Destroy(gunSound, 0.5f);
                }
            }
            // sneaking vs sprinting
            if (toggleSneak)  // toggle shift to sneak
            {
                // switch between shift and sneak
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    if (isSneaking)
                    {
                        // now sprinting
                        moveSpeed = sprintSpeed;
                    }
                    else
                    {
                        // now sneaking
                        moveSpeed = sneakSpeed;
                    }
                    // switch isSneaking state
                    isSneaking = !isSneaking;
                }

                if ((xMove == 0 && yMove == 0) || isSneaking)  // if monkey is not moving AND 
                {
                    anim.SetInteger("Running State", 0);  // idle animation
                    loud = false;
                    spriteRenderer.enabled = false;  // don't show noise circle
                }
                else  // the monkey is sprinting and moving
                {
                    anim.SetInteger("Running State", 1);
                    loud = true;
                    spriteRenderer.enabled = true;

                    if (!footsteps.isPlaying)
                    {
                        footsteps.Play();
                    }
                }
            }


            else  // hold shift to sneak (instead of toggle)
            {
                // Sneaking or not moving
                if (Input.GetKey(KeyCode.LeftShift) || (xMove == 0 && yMove == 0))
                {
                    moveSpeed = sneakSpeed;

                    anim.SetInteger("Running State", 0); // idle animation
                    loud = false;
                    spriteRenderer.enabled = false;
                }
                else  // currently sprinting
                {
                    moveSpeed = sprintSpeed;

                    anim.SetInteger("Running State", 1);
                    loud = true;
                    spriteRenderer.enabled = true;

                    if (!footsteps.isPlaying)
                    {
                        footsteps.Play();
                    }
                }
            }

        }
        
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.deltaTime);

            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }

    private void SetAmmoText(int ammo, int maxAmmo)
    {
        ammoText.text = ammo + "/" + maxAmmo;
    }

    public void setMaxHealth(int setHealthTo)
    {
        maxHealth = setHealthTo;
        health = setHealthTo;

        healthBar.SetMaxHealth(setHealthTo);
    }

    public void takeDmg(int dmg)
    {
        if (!isDead)
        {
			getHit.Play();
            health -= dmg;
            healthBar.SetHealth(health);
            if (health <= 0)
            {
                Dies();
            }
        }
    }

    public void Dies()
    {
        isDead = true;
        
        int distanceTravelled = distanceScript.distanceTravelled;

        PlayerPrefs.SetString("lastWeapon", weapon);

        deathScript.OpenDeathScreen(distanceTravelled, goldScript.coinsPickedUp);
    }
}
