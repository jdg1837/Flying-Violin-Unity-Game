using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mini_game_button : MonoBehaviour {

    public GameObject window;
    public Button nim;
    public Button hangman;
    public Button ghost;
    public Button pong;
    public Button snake;
    public Button back;
    public GameObject window_game_rules;
    public Text gamerule_text;
    mini_game_rule_pop mini_game = new mini_game_rule_pop();
    string rule;

    public void hide()
    {
        window.SetActive(false);
    }

    public void show()
    {
        window.SetActive(true);
    }

    public void go_to_rules(string message)
    {
        mini_game.window = window_game_rules;
        mini_game.rules = gamerule_text;
        mini_game.show_message(message);
    }
    public void hangman_clicked()
    {
       rule  = "The basic rules to play Hangman game are as follow:\n"+                                 
"1. First select the theme of words you want to guess\n"+
"2. 'Science'  'Sports'  'Vocab' 'Movies'\n"+
"3. Then enter a character in guess filled and press 'enter a"+    
"char' button\n"+
"4. The number of 'O' shows the number of guesses left for the user\n"+
"5. If you get the word you will win the game\n"+
"6. If you want to guess whole solution, you can enter whole solution and press 'enter whole'\n"+
"7. The buttons in red color are disabled.\n" +
"8. The buttons in blue color are enabled.\n" ;
        go_to_rules(rule);
    }

    public void  nim_clicked()
    {
        rule = "Your goal in the game is to leave last stick for your opponent.\n If you get the last stick then you loose\nThe basic rules to play nim are as follows:\n1. First select the rows \n2. A dialog will appear to select the sticks from the row\n3. If you want to select another row you can click on 'select another row button'.\n4. After you select the sticks system will select the sticks from one row automatically.\n5. The number in between the row defines the number of sticks row has.\n6. When all the sticks were slected from row, it will be disabled. ";
        go_to_rules(rule);
    }
    public void ghost_clicked()
    {
        rule = " Your goal is to make all ghosts be destroyed by fires or other ghosts\n If ghosts hit each other, they disappear in an spectral fire. If you hit a ghost or a fire, you lose.\n Move Up, Down, Left, or Right to avoid the ghosts. Middle button will let you stand still as ghots move, and the one farther right will teleport you elsewhere in the map.\n You only have 5 teleports per game.\n ";
        go_to_rules(rule);
    }

    public void snake_clicked()
    {
        rule = "The goal of the game is to collect 15 items.\n Press on the buttons surrounding the screen to change your direction.";
        go_to_rules(rule);
    }
    public void pong_clicked()
    {
        rule = "The goal of the game is to score on your opponent 5 times.\n Controls are as follows:\n Press on the upper half of the screen to move the paddle up.\n Press on the lower half of the screen to move the paddle down.";
        go_to_rules(rule);
    }
}
