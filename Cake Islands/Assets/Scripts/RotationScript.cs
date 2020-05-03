using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public GameObject lever;
    public GameObject platform;

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Interact") && lever.CompareTag("lever"))
        {
            transform.Rotate(0, 0, -45);
            platform.transform.Rotate(0, 0, -45);
        }
    }
}
