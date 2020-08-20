using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class pop_up_window_hangman : MonoBehaviour
{

    public GameObject window;
    public Text message;
    public Button ok;
    public int scence = 999;
    public void Show_message(string messaged, int scene_to_upload)
    {
        message.text = messaged;
        scence = scene_to_upload;
        window.SetActive(true);
    }

    public void set_Active()
    {
        window.SetActive(true);
    }
    public void Button_clickced(int i)
    {
		if (i == 999) {
			hide ();
		} else 
		{
			SceneManager.LoadScene(0);
		}
    }

    public void click_button()
    {
        Button_clickced(scence);
    }

    public void hide ()
    {
        window.SetActive(false);	
	}
	
}
