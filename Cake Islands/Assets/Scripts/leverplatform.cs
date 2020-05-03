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
    public void switchPos()
    {
        if(isOpen == true)
        {
            anim.SetBool("isopen", true);
        }
        else
        {
            anim.SetBool("isopen", false);
        }
    }
}
