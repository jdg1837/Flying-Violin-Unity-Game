using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour {
    private string _solution;
    private bool[] guesses= new bool[255];
   
    public void set_solution(string solution)
    {
        _solution = solution;
        for (int i = 0; i < 255; i++)
        {
            guesses[i] = false;
        }
        char c = '_';
        int j= (int)c;
        guesses[j] = true;
        guesses[31] = true;
        guesses[32] = true;
    }

    public bool guess(char c)
    {
        int j = 0;
      
            for (int i = 0; i < _solution.Length; i++)
            {
                if (c == _solution.ToCharArray()[i])
                {
                    guesses[c] = true;
                    j = 2;
                    return true; break;
                }
            }
        
        if (j != 2)
        { return false; }
        return false;
    }
    
    public bool solve(string proposed_solution)
    {
        string a = proposed_solution.ToLower();

          if (a == _solution)
          { return true; }
          else { return false; }
    }

    public string to_string()
    {
        string user_solution="";
        for (int i = 0; i < _solution.Length; ++i)
        {
            if (_solution[i] == ' ')
            { user_solution = user_solution + " "; }
            else
            {
                char a = _solution[i];
                int char_value = (int)a;
                if (char_value >= 65 && char_value <= 90) { char_value = char_value + 32; a = (char)char_value; }
                if (guesses[a] == true)
                { user_solution = user_solution + _solution[i].ToString().ToUpper(); }
                else
                { user_solution = user_solution + " _ "; }
            }
        }
        return user_solution;
    }

    public string give_hint(int i)
    {
        if(i == 2)
        {
            return "A famous Scientist";
        }else if(i == 1)
        {
            return "Hollywood movie";
        }
        else if(i == 3)
        {
            return "Famous 'American Football or soccer player'";
        }
        else if( i == 4)
        {
            return "Some english tough word";
        }
        return null;

    }
    public string get_solution()
    { return _solution; }

}



