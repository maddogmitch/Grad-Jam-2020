using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[3];

    public void AddItem(GameObject item)
    {

        bool itemAdded = false;
    
        //find first open slot in inventory
        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                //Do something with the object
                item.SendMessage("DoInteraction");
                break;
            }
        }

        //inventory full
        if(!itemAdded)
        {
            Debug.Log("Inventory is Full - Item not added");
        }
    }

    public bool FindItem(GameObject item)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i] == item)
            {
                //found the item
                return true;
            }
        }
        //item was not found
        return false;
    }
}
