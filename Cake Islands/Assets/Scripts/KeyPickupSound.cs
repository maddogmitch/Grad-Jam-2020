using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickupSound : MonoBehaviour
{
    [SerializeField] private AudioClip keyPickup;
    private AudioSource m_KeyPickup;

    void Start()
    {
        m_KeyPickup = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        PlaySound();
    }

    private void PlaySound()
    {
        m_KeyPickup.clip = keyPickup;
        m_KeyPickup.Play();
    }
}
