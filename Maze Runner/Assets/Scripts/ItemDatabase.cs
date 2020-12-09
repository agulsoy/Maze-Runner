using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Items> items = new List<Items>();

    void Start()
    {
        items.Add(new Items("First", 0, "", 2, 0, Items.ItemType.Words));
        items.Add(new Items("You", 1, "", 2, 0, Items.ItemType.Words));
    }

}