using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikeSound : MonoBehaviour
{
    void SpikeFallAudio()
    {
        FindObjectOfType<AudioManager>().Play("FallingSpikes");
    }
}
