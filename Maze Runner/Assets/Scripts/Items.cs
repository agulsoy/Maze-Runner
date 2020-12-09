using UnityEngine;
using System.Collections;

[System.Serializable]
public class Items
{
    public string wordName;
    public int itemID;
    public string itemAcc;
    public Texture2D itemIcon;
    public int itemPower;
    public int itemSpeed;
    public ItemType itemType;

    public enum ItemType
    {
        Words
    }

    public Items(string name, int id, string desc, int power, int speed, ItemType type)
    {
        wordName = name;
        itemID = id;
        itemAcc = desc;
        itemIcon = Resources.Load<Texture2D>("Item Icons/" + name);
        itemPower = power;
        itemSpeed = speed;
        itemType = type;
    }

    public Items()
    {

    }

    // public ItemType itemType;
    // public int amount;
}