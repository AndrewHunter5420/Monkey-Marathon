using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject rockPrefab;
    public float bulletForce = 50f;
    public AudioSource pistolSound;
    public AudioSource slingshotSound;
    public AudioSource shotgunSound;
    public AudioSource arSound;
	private double volume;

	void Start()
	{
		volume = PlayerPrefs.GetInt("SFXVol") / 20f;
		pistolSound.volume = (float)volume;
		slingshotSound.volume = (float)volume;
		shotgunSound.volume = (float)volume;
		arSound.volume = (float)volume;
	}

    public void pistolShoot()
    {
        pistolSound.Play();

        // Makes bullet from bullet prefab, with position rotation from firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // instantly applies force to rigidbody of bullet in direction of firePoint, and with magnitude bulletForce
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }

    public void slingshotShoot()
    {
        slingshotSound.Play();

        // Makes rock from rock prefab, with position rotation from firePoint
        GameObject rock = Instantiate(rockPrefab, firePoint.position, firePoint.rotation);
        
        // instantly applies force to rigidbody of bullet in direction of firePoint, and with magnitude bulletForce
        Rigidbody2D rb = rock.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public IEnumerator shotgunShoot()
    {
        shotgunSound.Play();
        
        for (int i = 0; i < 6; i++)
        {
            // Random direction for bullet
            float rndDir = Random.Range(-30f, 30f);

            // Makes bullet from bullet prefab, with position rotation from firePoint
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0f, 0f, rndDir));

            // instantly applies force to rigidbody of bullet in direction of firePoint +/- a random number of degrees, and with magnitude bulletForce
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(Quaternion.Euler(0f, 0f, rndDir) * firePoint.up * bulletForce, ForceMode2D.Impulse);

            // pause for 0.001 seconds
            yield return new WaitForSeconds(0.001f);
        }
    }

    public IEnumerator ARShoot()
    {
        for (int i = 0; i < 3; i++)
        {
            arSound.Play();
            
            // Makes bullet from bullet prefab, with position rotation from firePoint
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // instantly applies force to rigidbody of bullet in direction of firePoint, and with magnitude bulletForce
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            // pause for 0.05 seconds
            yield return new WaitForSeconds(0.05f);
        }
        
    }
}
