using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UISliderMusic : MonoBehaviour
{
    public AudioMixer audioMixer;

    public const float DefaultVolumeLevel = 1.0f;

    public void Start()
    {
        

    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("MyExposedParam", Mathf.Log10(volume) * 20);
    }
}
