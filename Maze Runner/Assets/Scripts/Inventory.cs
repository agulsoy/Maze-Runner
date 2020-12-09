using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public int slotsX, slotsY;
    public GUISkin skin;
    public List<Items> inventory = new List<Items>();
    public List<Items> slots = new List<Items>();
    private bool showInventory;
    private ItemDatabase database;
    private bool showToolTip;
    private string tooltip;

    private bool dragging; //Stores info to a boolean
    private Items dragged; // Holds the information of the item we are dragging

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            slots.Add(new Items());
            inventory.Add(new Items());
        }
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        //inventory[0] = database.items[0];
        //AddItem(0);
        //AddItem(1);
        /*AddItem(0);
        AddItem(1);
        RemoveItem(0);*/
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            showInventory = !showInventory;
        }
    }

    void OnGUI()
    {
        tooltip = "";
        GUI.skin = skin;
        if (showInventory)
        {
            DrawInventory();
            if (showToolTip)
            {
                GUI.Box(new Rect(Event.current.mousePosition.x + 15f, Event.current.mousePosition.y, 200, 200), tooltip, skin.GetStyle("Tooltip"));
            }
        }
        if (dragging)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), dragged.itemIcon);
        }
    }

    void DrawInventory()
    {
        int i = 0;
        for (int y = 0; y < slotsY; y++)
        {
            for (int x = 0; x < slotsX; x++)
            {
                Rect slotRect = new Rect(x * 60, y * 60, 50, 50);
                GUI.Box(slotRect, "");// skin.GetStyle("Slot"));
                slots[i] = inventory[i];
                if (slots[i].wordName != null)
                {
                    GUI.DrawTexture(slotRect, slots[i].itemIcon);
                    if (slotRect.Contains(Event.current.mousePosition))
                    {
                        tooltip = CreateToolTip(slots[i]);
                        showToolTip = true;
                        if (Event.current.button == 0 && Event.current.type == EventType.MouseDrag)
                        {
                            dragging = true;
                            dragged = slots[i];
                        }
                    }
                }
                if (tooltip == "")
                {
                    showToolTip = false;
                }

                i++;
            }
        }
    }

    string CreateToolTip(Items item)
    {
        tooltip = "<color=#4DA4BF>" + item.wordName + "</color>\n\n";
        return tooltip;
    }

    void RemoveItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemID == id)
            {
                inventory[i] = new Items();
                break;
            }
        }
    }

    void AddItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].wordName == null)
            {
                for (int j = 0; j < database.items.Count; j++)
                {
                    if (database.items[j].itemID == id)
                    {
                        inventory[i] = database.items[j];
                    }
                }
                break;
            }
        }
    }

    bool InventoryStock(int id)
    {
        bool result = false;
        for (int i = 0; i < inventory.Count; i++)
        {
            result = inventory[i].itemID == id;
            if (result)
            {
                break;
            }
        }
        return result;
    }
}