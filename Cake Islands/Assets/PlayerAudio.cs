using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAudio : MonoBehaviour
{

    [SerializeField] private AudioClip jump;

    private AudioSource m_Jumpsound;

    void Start()
    {
        m_Jumpsound = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Jumpsound.Play();
        }
    }

    private void PlayJumpSound()
    {
        m_Jumpsound.clip = jump;
        m_Jumpsound.Play();
    }
}
