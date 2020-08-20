using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class behavior_change : MonoBehaviour
{
    mini_game_button mini_game = new mini_game_button();
    game_rule_po game_rule = new game_rule_po();
    mini_game_rule_pop mini_rules = new mini_game_rule_pop();

    public GameObject mini_window;
    public GameObject game_rule_window;
    public Text game_rule_text;
    public GameObject mini_pop_window;

    public Button back_to_main;
    public Button Game_rule_buuton;
    public Button mini_game_rules;
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        game_rule.window = game_rule_window;
        game_rule.rules = game_rule_text;
        mini_game.window = mini_window;
        mini_rules.window = mini_pop_window;
        mini_rules.hide();
        mini_game.hide();
        game_rule.hide();
    }

    public void game_rules_clicked()
    {
        string rules = "Our game is a choose your own adventure game.\nYou, the player, will choose the direction you want to go \nand at every decision point you will be launched into\n one of five minigames that correspond with the story.\n Happy Adventures!\nTo see the rules of winning criteria of minigame go the 'Minigame Rules' button";
        game_rule.show_message(rules);
    }

    public void Mini_games_clicked()
    {
        mini_game.show();
    }

    public void back_to_main_clicked()
    {
        SceneManager.LoadScene(0);
    }
}
