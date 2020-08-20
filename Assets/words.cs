using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class words : MonoBehaviour {

    string[] choice_words = { "The Shawshank Redemption" , "Inception","Interstellar","Saving Private Ryan", "The wolf of wall street","Harry Potter and the Chamber of Secrets","Harry Potter and the Prisoner of Azkaban","Million Dollar Baby","Ace Ventura When Nature Calls","X Men Wolverine","Aristotle","Archimedes","Galileo Galilei","Michael Faraday","Thomas Alva Edison","Marie Curie Sklodowska","Louis Pasteur","Albert Einstein"," Nikola Tesla","Sir Issac Newton","Tom Brady","Russell Wilson","Brett Favre","Antonio Brown","Aron Rodgers","Alex Morgan","lionel messi","Cristiano Ronaldo","David Beckham","Zinedine Zidane","abarticulation","abdominocentesis","euphorbiaceae","excommunication","fremontodendron","gyneolatry","heautontimorumenos","morphophonemics","smoothtongued","tetrasporangium"};

     public string Give_word(int choice)
    {
        int i = 0;
        if(choice == 1)
        {
            i = Random.Range(0, 9);
        }
        else if(choice == 2)
        {
            i = Random.Range(10, 19);
        }
        else if (choice == 3)
        {
            i = Random.Range(20, 29);
        }
        else if (choice == 4)
        {
            i = Random.Range(30, 39);
        }
        
      return choice_words[i];
    }
   
 }
