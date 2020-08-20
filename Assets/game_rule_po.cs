using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_rule_po : MonoBehaviour
{
    public GameObject window;
    public Text rules;
    public Button back;

    public void hide()
    {
        window.SetActive(false);
    }

    public void show()
    {
        window.SetActive(true);
    }

    public void show_message(string message)
    {
        rules.text = message;
        show();
    }
}
