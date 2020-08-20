using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    public bool burn()
    {
        _time = _time - 1;
        if (_time == 0)
        { return false; }
        else { return true; }
    }

    public int give_score()
    {
        int i = 8 - _time;
        int score = 100 - (i * 5);
        return score;
    }
    public string to_string()
    {
        string firecracker="";
        for (int i = 0; i < _time; i++)
        {
            firecracker = firecracker + " O ";
        }
        firecracker = firecracker + " * ";
        return firecracker;
    }

    public int get_time()
    {
        return _time;
    }
    int _time;
    public void set_time(int time)
    {
        _time = time;
    }

}
