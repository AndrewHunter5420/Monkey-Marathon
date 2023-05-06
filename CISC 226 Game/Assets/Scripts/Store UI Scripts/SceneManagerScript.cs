using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    public string load;

    private static SceneManagerScript manager;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (manager == null)
        {
            manager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

