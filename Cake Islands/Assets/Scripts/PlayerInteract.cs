using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public Interaction currentInterObjScript = null;
    public Inventory inventory;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown ("Interact") && currentInterObj)
        {
            //Check to see if this object is to be stored in inventory
            if(currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);
            }

            //Check to see if this object can be opened
            if(currentInterObjScript.openable)
            {
                //Check if locked
                if(currentInterObjScript.locked)
                {
                    //Check to see if we have the object to unlock
                    //Search our inventory for the item needed - if found unlock object
                    if(inventory.FindItem(currentInterObjScript.key))
                    {
                        //Found item needed unlock the door
                        currentInterObjScript.locked = false;
                        Debug.Log(currentInterObj.name + " was unlocked");
                        currentInterObjScript.Open();
                    }
                    else
                    {
                        Debug.Log(currentInterObj.name + " was not unlocked");

                    }
                }
                else
                {
                    //Door is not locked - open the door
                    Debug.Log(currentInterObj.name + " is unlocked");
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("interactable"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<Interaction>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interactable"))
        {
            if(other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
            
        }

    }

}
