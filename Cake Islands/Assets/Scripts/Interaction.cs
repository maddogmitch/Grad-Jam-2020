using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool inventory; //if true can be stored in our inventory
    public bool openable; //if true this object can be opened
    public bool locked; //if true the object is locked
    public bool IsOn = false;
    public GameObject key;

    [SerializeField]
    public GameObject SwitchON;

    [SerializeField]
    public GameObject SwitchOFF;

    public GameObject box1;
    public GameObject box2;
    public GameObject space1;
    public GameObject space2;

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

    public void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOFF.GetComponent<SpriteRenderer>().sprite;
    }

    public void OnTriggerEnter2D(Collider2D button)
    {
        if (button.CompareTag("switch"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SwitchON.GetComponent<SpriteRenderer>().sprite;
            IsOn = true;
        }
    }
}
