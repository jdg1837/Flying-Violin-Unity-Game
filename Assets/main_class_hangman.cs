using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class main_class_hangman : MonoBehaviour
{

    pop_up_window_hangman pop_up = new pop_up_window_hangman();
    public GameObject window;
    public Button window_button;
    public Text window_text;
    public Button science;
    public Button vocab;
    public Button sports;
    public Button movies;
    public Button Enter_char;
    public Button Enter_whole;
    public Button hint;
    public Text hint_provided;
    public Text progress;
    public Text Guesses_left;
    public InputField answer_field;
    public Image images;
    public string image_to_load;
    int scene = 84;
    int player_score = 0;
    int direct_score = 100;
    words word = new words();
    puzzle start = new puzzle();
    Fuse fuse = new Fuse();
    string user_solution = "";
    int user_theme = 0;
    string hint_given = "";
    void Start()
    {
        pop_up.window = window;
        pop_up.message = window_text;
        pop_up.ok = window_button;
		pop_up.scence = 0;
        Button movies_btn = movies.GetComponent<Button>();

        Button science_btn = science.GetComponent<Button>();

        Button sports_btn = sports.GetComponent<Button>();

        Button vocab_btn = vocab.GetComponent<Button>();

        Button Enter_char_btn = Enter_char.GetComponent<Button>();

        Button Enter_whole_btn = Enter_whole.GetComponent<Button>();

        Button hint_btn = hint.GetComponent<Button>();

        Image image = images.GetComponent<Image>();
        image.sprite = (Sprite)Resources.Load<Sprite>("Hangman_images/" + "hangman_do_it") as Sprite;

        Enter_char_btn.interactable = false;
        Enter_whole_btn.interactable = false;
        hint_btn.interactable = false;

        //    science_btn.onClick.AddListener(science_clicked);
        //    sports_btn.onClick.AddListener(sports_clicked);
        //    vocab_btn.onClick.AddListener(vocab_clicked);
        //    hint_btn.onClick.AddListener(hint_clicked);
        //    movies_btn.onClick.AddListener(movies_clicked);
        //    Enter_char_btn.onClick.AddListener(Enter_char_clicked);
        //    Enter_whole_btn.onClick.AddListener(Enter_whole_clicked);
    }

    public void window_button_clicked()
    {
        pop_up.Button_clickced(999);
    }

    public void Enter_whole_clicked()
    {
        Button Enter_whole_btn = Enter_whole.GetComponent<Button>();
        Enter_whole_btn.onClick.RemoveAllListeners();
        //  Enter_whole_btn.onClick.AddListener(Enter_whole_clicked);

        Debug.Log("You should enter one time");
        Text _progress = progress.GetComponent<Text>();
        string b;
        Text guesses_left = Guesses_left.GetComponent<Text>();
        InputField Answer_field = answer_field.GetComponent<InputField>();
        string a = Answer_field.text;
        bool in_game = start.solve(a);
        if (in_game)
        {
            player_score = direct_score;
            string show = "You Won , Your Score is " + player_score.ToString();
            Answer_field.text = show;
            Answer_field.interactable = false;

            b = fuse.to_string();
            guesses_left.text = b;
            b = start.to_string();
            _progress.text = b;
            lost_or_win();
			pop_up.scence = 0;
			Save.Instance.lost = 0;
			Save.Instance.score = Save.Instance.score + 100;
			SceneManager.LoadScene (6);
            pop_up.set_Active();
            pop_up.Show_message(show, scene);
            return;

            return;
        }
        else if (direct_score < 100)
        {
            // Button Enter_whole_btn = Enter_whole.GetComponent<Button>();
            Enter_whole_btn.interactable = false;
            string show = "It's " + start.get_solution().ToUpper() + "   Sorry You Lost";
            Answer_field.text = show;
            Image image = images.GetComponent<Image>();
            image.sprite = (Sprite)Resources.Load<Sprite>("Hangman_images/" + "hangman8") as Sprite;
			pop_up.scence = 0;
			Save.Instance.lost = 1;
			SceneManager.LoadScene (6);
            pop_up.set_Active();
            pop_up.Show_message(show, scene);
            return;
        }
        else
        {
            lost_or_win();
            //  Button Enter_whole_btn = Enter_whole.GetComponent<Button>();
            direct_score -= 25;
            Answer_field.text = "Second Chance";
            Answer_field.interactable = true;
            Enter_whole_btn.interactable = true;
        }
    }

    public void Enter_char_clicked()
    {
        Text guesses_left = Guesses_left.GetComponent<Text>();
        InputField Answer_field = answer_field.GetComponent<InputField>();
        string a = Answer_field.text;
        int i = a.Length;
        if (i > 1)
        {
            Answer_field.text = "Enter one charcater at at time or press whole solution for entering whole solution";
        }
        else
        {
            Answer_field.text = "";
            char c = a.ToCharArray()[0];
            int char_value = (int)c;
            if (char_value < 91) { char_value = char_value + 32; c = (char)char_value; }
            bool solve = start.guess(c);
            if (solve == false)
            {
                bool in_game = fuse.burn();
                Debug.Log("You have to see image on the screen");
                set_image();
                if (in_game == false)
                {
                    // Answer_field.text = "You Lost "+start.get_solution();
                    player_score = 0;
                    Answer_field.interactable = false;
                    Image image = images.GetComponent<Image>();

                    string cc = fuse.to_string();
                    guesses_left.text = cc;
                    image.sprite = (Sprite)Resources.Load<Sprite>("Hangman_images/" + "hangman8") as Sprite;
                    string show = "It's " + start.get_solution() + ", You Lost Better Luck Next Time";
                    Answer_field.text = show;
                    Answer_field.interactable = false;
                    lost_or_win();
					pop_up.scence = 0;
					Save.Instance.lost = 1;
					SceneManager.LoadScene (6);
                    pop_up.set_Active();
                    pop_up.Show_message(show, scene);
                    return;
                }
            }

            string b = fuse.to_string();
            guesses_left.text = b;
            b = start.to_string();
            Text _progress = progress.GetComponent<Text>();
            _progress.text = b;
            bool won = start.solve(b);
            if (won)
            {
                int score = fuse.give_score();
                player_score = score;
                string show = "You Won , Your Score is " + score.ToString(); ; Answer_field.interactable = false; lost_or_win();
                Answer_field.text = show;
				pop_up.scence = 0;
				Save.Instance.lost = 0;
				Save.Instance.score = Save.Instance.score + 100;
				SceneManager.LoadScene (6);
                pop_up.set_Active();
                pop_up.Show_message(show, scene);
                return;

            }
        }

    }

    public void set_image()
    {
        Image image = images.GetComponent<Image>();
        int i = fuse.get_time();
        if (i == 8)
            image.sprite = (Sprite)Resources.Load<Sprite>("Hangman_images/" + "hangman_do_it") as Sprite;
        else if (i == 7)
            image.sprite = (Sprite)Resources.Load<Sprite>("Hangman_images/" + "hangman1") as Sprite;
        else if (i == 6)
            image.sprite = (Sprite)Resources.Load<Sprite>("Hangman_images/" + "hangman2") as Sprite;
        else if (i == 5)
            image.sprite = (Sprite)Resources.Load<Sprite>("Hangman_images/" + "hangman3") as Sprite;
        else if (i == 4)
            image.sprite = (Sprite)Resources.Load<Sprite>("Hangman_images/" + "hangman4") as Sprite;
        else if (i == 3)
            image.sprite = (Sprite)Resources.Load<Sprite>("Hangman_images/" + "hangman5") as Sprite;
        else if (i == 2)
            image.sprite = (Sprite)Resources.Load<Sprite>("Hangman_images/" + "hangman6") as Sprite;
        else if (i == 1)
            image.sprite = (Sprite)Resources.Load<Sprite>("Hangman_images/" + "hangman7") as Sprite;
    }

    public void hint_clicked()
    {
        Text _hint_give = hint_provided.GetComponent<Text>();

        string a = start.give_hint(user_theme);
        if (a == null)
        {
            a = "Fist Select the theme for Hangman";
            _hint_give.text = a;

        }
        else
        {
            _hint_give.text = a;
            Button hint_btn = hint.GetComponent<Button>();
            hint_btn.interactable = false;
        }
    }

    public void science_clicked()
    {
        user_theme = 2;
        any_button_selected(2);
    }
    public void sports_clicked()
    {
        user_theme = 3;
        any_button_selected(3);
    }
    public void vocab_clicked()
    {
        user_theme = 4;
        any_button_selected(4);
    }
    public void movies_clicked()
    {
        user_theme = 1;
        any_button_selected(1);
    }

    public void any_button_selected(int i)
    {
        string a = word.Give_word(i).ToLower();
        start.set_solution(a);
        fuse.set_time(8);
        Text guesses_left = Guesses_left.GetComponent<Text>();
        string b = fuse.to_string();

        guesses_left.text = b;
        b = start.to_string();
        Text _progress = progress.GetComponent<Text>();

        _progress.text = b;
        Button movies_btn = movies.GetComponent<Button>();

        Button science_btn = science.GetComponent<Button>();

        Button sports_btn = sports.GetComponent<Button>();

        Button vocab_btn = vocab.GetComponent<Button>();

        Button Enter_char_btn = Enter_char.GetComponent<Button>();

        Button Enter_whole_btn = Enter_whole.GetComponent<Button>();

        Button hint_btn = hint.GetComponent<Button>();

        movies_btn.interactable = false;
        science_btn.interactable = false;
        sports_btn.interactable = false;
        vocab_btn.interactable = false;
        Enter_char_btn.interactable = true;
        Enter_whole_btn.interactable = true;
        hint_btn.interactable = true;
    }

    public void lost_or_win()
    {
        Button movies_btn = movies.GetComponent<Button>();

        Button science_btn = science.GetComponent<Button>();

        Button sports_btn = sports.GetComponent<Button>();

        Button vocab_btn = vocab.GetComponent<Button>();

        Button Enter_char_btn = Enter_char.GetComponent<Button>();

        Button Enter_whole_btn = Enter_whole.GetComponent<Button>();

        Button hint_btn = hint.GetComponent<Button>();

        movies_btn.interactable = false;
        science_btn.interactable = false;
        sports_btn.interactable = false;
        vocab_btn.interactable = false;
        Enter_char_btn.interactable = false;
        Enter_whole_btn.interactable = false;
        hint_btn.interactable = false;
    }
}
