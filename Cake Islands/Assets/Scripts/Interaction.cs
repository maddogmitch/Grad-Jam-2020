using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool inventory; //if true can be stored in our inventory
    public bool openable; //if true this object can be opened
    public bool locked; //if true the object is locked
    public GameObject key;

    public Animator anim;

    void DoInteraction()
    {
        //Picked up and put in inventory
        
        
         gameObject.SetActive(false);
        
    }

    public void Open()
    {
        anim.SetBool("open", true);
    }

}
