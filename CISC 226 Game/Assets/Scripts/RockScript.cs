using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    public GameObject hitEffect;
    public Transform rock;
    public GameObject noise;
    public AudioSource hitWall;
	private double volume;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(11, 3); // Rock ignores gold coin
        Physics2D.IgnoreLayerCollision(11, 10);  // Rock ignores Guard Bullets
        Physics2D.IgnoreLayerCollision(11, 6);  // Rock ignores Player
        Physics2D.IgnoreLayerCollision(11, 7);  // // Rock ignores Player Bullets
        Physics2D.IgnoreLayerCollision(11, 9); // Rock ignores guards
        Physics2D.IgnoreLayerCollision(11, 10); // Rock ignores guard bullets
		
		volume = PlayerPrefs.GetInt("SFXVol")/10.0;
		hitWall.volume = (float)volume;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Instantiate hit effect
        GameObject effect = Instantiate(hitEffect, transform.position, rock.rotation * Quaternion.Euler(0f, 0f, 180f));
        AudioSource.PlayClipAtPoint(hitWall.clip, transform.position, 1.0F);
        Destroy(gameObject);
        Destroy(effect, 0.05f);

        // Instantiate noise circle
        GameObject rockSound = Instantiate(noise, transform.position, rock.rotation * Quaternion.Euler(0f, 0f, 180f));
        Destroy(rockSound, 0.1f);
    }
}