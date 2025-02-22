﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class You : MonoBehaviour, IInventoryItem 
{
    public string Name
    {
        get
        {
            return "You";
        }
    }

    public Sprite _Image;
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }
}
