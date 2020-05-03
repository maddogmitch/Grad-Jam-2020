using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public GameObject cake;
    public GameManager gm;

    public void OnTriggerEnter2D(Collider2D cake)
    {
        if(cake.CompareTag("cake"))
        {
            gm.nextLevel();
        }
    }
}
