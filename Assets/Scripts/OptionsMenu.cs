using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;


    public void SetVolume(float pVolume)
    {
        Debug.Log("Volume:" + pVolume);
        audioMixer.SetFloat("volume", pVolume);
    }
}
