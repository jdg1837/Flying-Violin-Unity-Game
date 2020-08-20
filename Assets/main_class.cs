using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System;

public class main_class : MonoBehaviour
{
    bool win = false;
    bool loose = false;

    sticks stick = new sticks();
	pop_up_window_hangman pop_up = new pop_up_window_hangman();
    public GameObject windows;
    public Button window_button;
    public Text window_text;

    public GameObject window;
    public Button button;
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Button Stick_btn1;
    public Button Stick_btn2;
    public Button Stick_btn3;
    public Button Stick_btn4;
    public Button Stick_btn5;
    public Button Stick_btn6;
    public Button Stick_btn7;
    public Button Stick_btn8;
    public Button Stick_btn9;
    public Button Select_another;
    int scene;
    public Text computers_choice;
    public Text row1;
    public Text row2;
    public Text row3;
    public Text row4;
    public Text row5;

    // Use this for initialization
    void Start()
    {
        window.SetActive(false);
        pop_up.window = windows;
        pop_up.message = window_text;
        pop_up.ok = window_button;
    /*  Button btn = button.GetComponent<Button>();
        Button btn1 = Button1.GetComponent<Button>();
        Button btn2 = Button2.GetComponent<Button>();
        Button btn3 = Button3.GetComponent<Button>();
        Button btn4 = Button4.GetComponent<Button>();
        Button s_btn1 = Stick_btn1.GetComponent<Button>();
        Button s_btn2 = Stick_btn2.GetComponent<Button>();
        Button s_btn3 = Stick_btn3.GetComponent<Button>();
        Button s_btn4 = Stick_btn4.GetComponent<Button>();
        Button s_btn5 = Stick_btn5.GetComponent<Button>();
        Button s_btn6 = Stick_btn6.GetComponent<Button>();
        Button s_btn7 = Stick_btn7.GetComponent<Button>();
        Button s_btn8 = Stick_btn8.GetComponent<Button>();
        Button s_btn9 = Stick_btn9.GetComponent<Button>();
        Button select_another = Select_another.GetComponent<Button>();
  */      make_sticks_disabled();
      }

    public void update_button_text()
    {
        Text Row1 = row1.GetComponent<Text>();
        Text Row2 = row2.GetComponent<Text>();
        Text Row3 = row3.GetComponent<Text>();
        Text Row4 = row4.GetComponent<Text>();
        Text Row5 = row5.GetComponent<Text>();
        Row1.text = stick.get_sticks(1).ToString();
        Row2.text = stick.get_sticks(2).ToString();
        Row3.text = stick.get_sticks(3).ToString();
        Row4.text = stick.get_sticks(4).ToString();
        Row5.text = stick.get_sticks(5).ToString();
        return;
    }

    public void make_row_disabled()
    {
        Button btn = button.GetComponent<Button>();
        Button btn1 = Button1.GetComponent<Button>();
        Button btn2 = Button2.GetComponent<Button>();
        Button btn3 = Button3.GetComponent<Button>();
        Button btn4 = Button4.GetComponent<Button>();
        btn.interactable = false;
        btn1.interactable = false;
        btn2.interactable = false;
        btn3.interactable = false;
        btn4.interactable = false;
        return;
    }

    public void make_sticks_disabled()
    {
        Button s_btn1 = Stick_btn1.GetComponent<Button>();
        Button s_btn2 = Stick_btn2.GetComponent<Button>();
        Button s_btn3 = Stick_btn3.GetComponent<Button>();
        Button s_btn4 = Stick_btn4.GetComponent<Button>();
        Button s_btn5 = Stick_btn5.GetComponent<Button>();
        Button s_btn6 = Stick_btn6.GetComponent<Button>();
        Button s_btn7 = Stick_btn7.GetComponent<Button>();
        Button s_btn8 = Stick_btn8.GetComponent<Button>();
        Button s_btn9 = Stick_btn9.GetComponent<Button>();
        Button select_another = Select_another.GetComponent<Button>();
        s_btn1.interactable = false;
        s_btn2.interactable = false;
        s_btn3.interactable = false;
        s_btn4.interactable = false;
        s_btn5.interactable = false;
        s_btn6.interactable = false;
        s_btn7.interactable = false;
        s_btn8.interactable = false;
        s_btn9.interactable = false;
        select_another.interactable = false;
        return;
    }

    public void button_on_click()
    {
        stick.set_row(1);
        any_button_click(1);
    }

    public void button1_on_click()
    {
        stick.set_row(2);
        any_button_click(2);
    }

    public void button2_on_click()
    {
        stick.set_row(3);
        any_button_click(3);
    }

    public void button3_on_click()
    {
        stick.set_row(4);
        any_button_click(4);
    }

    public void button4_on_click()
    {
        stick.set_row(5);
        any_button_click(5);
    }

    public void any_button_click(int i)
    {
        make_row_disabled();
        window.SetActive(true);
        transfer_new_scene();
    }

    public void back_to_rows()
    {
        window.SetActive(false);
        update_button_text();
        make_sticks_disabled();
        transfer_back_to_main();
    }
    public void s_btn1_on_click()
    {
        Debug.Log("1 selected");
        int row_selected = stick.get_row();
        stick.Update_stick(row_selected, 1);
        Make_button_visible(1);
        return;
    }
    public void s_btn2_on_click()
    {
        Debug.Log("2 selected");
        int row_selected = stick.get_row();
        stick.Update_stick(row_selected,2);
        Make_button_visible(2);
        return;
    }
    public void s_btn3_on_click()
    {
        Debug.Log("You selected 3");
        int row_selected = stick.get_row();
        stick.Update_stick(row_selected,3);
        Make_button_visible(3);
         return;
    }
    public void s_btn4_on_click()
    {
        int row_selected = stick.get_row();
        stick.Update_stick(row_selected, 4);
        Make_button_visible(4);
        return;
    }
    public void s_btn5_on_click()
    {
        int row_selected = stick.get_row();
        stick.Update_stick(row_selected, 5);
        Make_button_visible(5);
        return;
    }
    public void s_btn6_on_click()
    {
        int row_selected = stick.get_row();
        stick.Update_stick(row_selected, 6);
        Make_button_visible(6);
        return;
    }
    public void s_btn7_on_click()
    {
        int row_selected = stick.get_row();
        stick.Update_stick(row_selected, 7);
        Make_button_visible(7);
        return;
    }
    public void s_btn8_on_click()
    {
        int row_selected = stick.get_row();
        stick.Update_stick(row_selected,8);
        Make_button_visible(8);
        return;
    }
    public void s_btn9_on_click()
    {
        int row_selected = stick.get_row();
        stick.Update_stick(row_selected, 9);
        Make_button_visible(9);
        return;
    }
    public void Make_button_visible(int sticks_selected)
    {
        window.SetActive(false);
        string computer = "";
        Text computers = computers_choice.GetComponent<Text>();
        update_button_text();
        bool re = stick.game_on();
        if (!re)
        {
            make_sticks_disabled();
            make_row_disabled();
            computer = "You WON with score 100";
            scene = 0;
			Save.Instance.lost = 0;
			Save.Instance.score = Save.Instance.score + 100;
			SceneManager.LoadScene (6);
            pop_up.set_Active();
            pop_up.Show_message(computer, scene);
            return;
        }
        else
        {
            make_sticks_disabled();
            computer = computer_choice();
            update_button_text();
            re = stick.game_on();
            if (!re)
            {
                
                computer = "The Wizard Won, better luck next time";
                scene = 0;
				Save.Instance.lost = 1;
				SceneManager.LoadScene (6);
                pop_up.set_Active();
                pop_up.Show_message(computer, scene);
                return;
            }
            else
            {
                transfer_back_to_main();
            }
        }
        computers.text = computer;
        return;
    }

    //anabling or disabling button in select row
    public void transfer_back_to_main()
    {
        Button btn = button.GetComponent<Button>();
        Button btn1 = Button1.GetComponent<Button>();
        Button btn2 = Button2.GetComponent<Button>();
        Button btn3 = Button3.GetComponent<Button>();
        Button btn4 = Button4.GetComponent<Button>();
        Button select_another = Select_another.GetComponent<Button>();
        select_another.interactable = false;
        btn.interactable = false;
        btn1.interactable = false;
        btn2.interactable = false;
        btn3.interactable = false;
        btn4.interactable = false;
        Debug.Log("You are transfer_main");
                if (stick.get_sticks(1) > 0)
                {
                    btn.interactable = true;
                }
                if (stick.get_sticks(2) > 0)
                {
                    btn1.interactable = true;
                }
                if (stick.get_sticks(3) > 0)
                {
                    btn2.interactable = true;
                }
                if (stick.get_sticks(4) > 0)
                {
                    btn3.interactable = true;
                }
                if (stick.get_sticks(5) > 0)
                {
                    btn4.interactable = true;
                }
        return; 
    }
    

    //enabling or disabling button in select stick bbutton
    public void transfer_new_scene()
    {
        Button s_btn1 = Stick_btn1.GetComponent<Button>();
        Button s_btn2 = Stick_btn2.GetComponent<Button>();
        Button s_btn3 = Stick_btn3.GetComponent<Button>();
        Button s_btn4 = Stick_btn4.GetComponent<Button>();
        Button s_btn5 = Stick_btn5.GetComponent<Button>();
        Button s_btn6 = Stick_btn6.GetComponent<Button>();
        Button s_btn7 = Stick_btn7.GetComponent<Button>();
        Button s_btn8 = Stick_btn8.GetComponent<Button>();
        Button s_btn9 = Stick_btn9.GetComponent<Button>();
        Button select_another = Select_another.GetComponent<Button>();
        select_another.interactable = true;
        s_btn9.interactable = true;
        s_btn8.interactable = true;
        s_btn7.interactable = true;
        s_btn6.interactable = true;
        s_btn5.interactable = true;
        s_btn4.interactable = true;
        s_btn3.interactable = true;
        s_btn2.interactable = true;
        s_btn1.interactable = true;

        int row_selected = stick.get_row();
        int i = stick.get_sticks(row_selected);
        Text computers = computers_choice.GetComponent<Text>();
        computers.text = "You have " + i.ToString() + " choices";
        int selection = i + 1;
        for (int j = selection; j < 10; j++)
        {
            if(j == 9)
               s_btn9.interactable = false;
            if (j == 8)
                s_btn8.interactable = false;
            if (j == 7)
                s_btn7.interactable = false;
            if (j == 6)
                s_btn6.interactable = false;
            if (j == 5)
                s_btn5.interactable = false;
            if (j == 4)
                s_btn4.interactable = false;
            if (j == 3)
                s_btn3.interactable = false;
            if (j == 2)
                s_btn2.interactable = false;
            if (j == 1)
                s_btn1.interactable = false; 
        }
    }
    


    public string computer_choice()
    {
       if (stick.get_sticks(5) % 2 == 0 && stick.get_sticks(5) >= 5)
        {
            stick.Update_stick(5, 4);
            string a = "Computer Choose 4 stick from row 5";
            return a;
        }
        else if (stick.get_sticks(4) % 2 == 0 && stick.get_sticks(4) >= 5)
        {
            stick.Update_stick(4, 4);
            string a = "Computer Choose 4 stick from row 4";
            return a;
        }
        else if (stick.get_sticks(3) % 2 == 0 && stick.get_sticks(3) >= 4)
        {
            stick.Update_stick(3, 2);
            string a = "Computer Choose 2 stick from row 3";
            return a;
        }
        else if (stick.get_sticks(2) % 2 == 0 && stick.get_sticks(2) >= 2)
        {
           
            stick.Update_stick(2, 2);
            string a = "Computer Choose 2 stick from row 2";
            return a;
        }
        else if (stick.get_sticks(5) > 0)
        {
            int random = Random.Range(1, stick.get_sticks(5));
            stick.Update_stick(5, random);
            string a = "Computer Choose " + random.ToString() + " sticks from row 5";
            return a;
        }
        else if (stick.get_sticks(4) > 0)
        {
            int random = Random.Range(1, stick.get_sticks(4));
            stick.Update_stick(4, random);
            string a = "Computer Choose " + random.ToString() + " sticks from row 4";
            return a;
        }
        else if (stick.get_sticks(3) > 0)
        {
            int random = Random.Range(1, stick.get_sticks(3));
            stick.Update_stick(3, random);
            string a = "Computer Choose " + random.ToString() + " sticks from row 3";
            return a;
        }
        else if (stick.get_sticks(2) > 0)
        {
            int random = Random.Range(1, stick.get_sticks(2));
            stick.Update_stick(2, random);
            string a = "Computer Choose " + random.ToString() + " sticks from row 2";
            return a;
        }
        else if (stick.get_sticks(1) > 0)
        {
            int random = Random.Range(1, stick.get_sticks(1));
            stick.Update_stick(1, random);
            string a = "Computer Choose " + random.ToString() + " sticks from row 1";
            return a;
        }

        return null;
    }

}
