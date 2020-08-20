﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    private Snake next;
    static public Action<String> hit;

    public void Setnext(Snake IN)
    {
        next = IN;
    }

    public Snake GetNext()
    {
        return next;
    }

    public void RemoveTail()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if(hit != null)
        {
            hit(other.transform.tag);
        }    
        if(other.tag == "Food")
        {
            Destroy(other.gameObject);
        }
    }
}   
