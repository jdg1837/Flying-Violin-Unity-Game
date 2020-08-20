using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticks : MonoBehaviour {

    private int[] stick = new int[] { 1, 3, 5, 7, 9 };
    private int previous_row = 0;

    public int get_row()
    {
        return previous_row;
    }
    public void set_row( int i)
    {
        previous_row = i;
    }
    public int get_sticks(int row)
    {
        return stick[row - 1];
    }

    public void Update_stick(int row,int sticks_choosen)
    {
        stick[row - 1]  = stick[row-1] - sticks_choosen;
    }

    public bool game_on()
    {
        int total = stick[0]+ stick[1]+ stick[2]+stick[3] + stick[4];
        if(total == 1)
        {
            return false;
        }
        return true;
    }

}
