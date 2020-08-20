using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour {
    private Music music;
    public Button musicToggleButton;
    public Text SoundText;
    
	// Use this for initialization
	void Start () {
        music = GameObject.FindObjectOfType<Music>();
        UpdateButton();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MuteMusic()
    {
        music.ToggleSound();
        UpdateButton();
    }

    public void UpdateButton()
    {
        Text sound = SoundText.GetComponent<Text>();
        string status;
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            status = "Mute";
            sound.text = status;
        }
        else
        {
            AudioListener.volume = 0;
            status = "Unmute";
            sound.text = status;
        }
        
        
    }
}
