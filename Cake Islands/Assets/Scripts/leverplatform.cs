using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverplatform : MonoBehaviour
{
    bool isOpen = true;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //function to switch animation position
    public void switchPos()
    {
        if(isOpen == true)
        {
            //set open to false so next time called it will,do the fase part of statment
            isOpen = false;
            anim.SetBool("isopen", true);
        }
        else
        {
            isOpen = true;
            anim.SetBool("isopen", false);
        }
    }
}
