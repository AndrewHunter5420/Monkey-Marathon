using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicScript : MonoBehaviour
{
    public AudioSource theme;
    private double volume;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        volume = PlayerPrefs.GetInt("musicVol") / 20f;
        theme.volume = (float) volume;
    }
}
