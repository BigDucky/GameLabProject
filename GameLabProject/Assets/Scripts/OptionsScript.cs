using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour {

    public AudioMixer audioMixer;

    public void VolumeController(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}