using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    public AudioMixer Main;
    public AudioMixer SFX;
    public Slider Main_Slider;
    public Slider SFX_Slider;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Main"))
        {
            Main.SetFloat("Main", PlayerPrefs.GetFloat("Main"));
            Main_Slider.value = PlayerPrefs.GetFloat("Main");
        }

        if (PlayerPrefs.HasKey("SFX"))
        {   Main.SetFloat("SFX", PlayerPrefs.GetFloat("SFX"));
            SFX_Slider.value = PlayerPrefs.GetFloat("SFX");
        }
    }
    public void SetVolume_Main(float volume)
    {
        Main.SetFloat("Main", volume);
        PlayerPrefs.SetFloat("Main", volume);
        PlayerPrefs.Save();
    }
    public void SetVolume_SFX(float volume)
    {
        SFX.SetFloat("SFX", volume);
        PlayerPrefs.SetFloat("SFX", volume);
        PlayerPrefs.Save();
    }
}
