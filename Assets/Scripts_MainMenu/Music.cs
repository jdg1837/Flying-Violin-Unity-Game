using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour {

    static Music instance = null;
    public static Music Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            this.transform.parent = null;
            instance = this;           
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
            //AudioListener.volume = 1;
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
            //AudioListener.volume = 0;
        }
    }
}
