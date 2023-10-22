using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSystem : MonoBehaviour
{
    public Toggle soundToggle; 
    public Slider volumeSlider; 
    public AudioSource audioSource;

    void Start()
    {
        soundToggle = GetComponent<Toggle>();
        volumeSlider = GetComponent<Slider>();

        if (soundToggle != null)
        {
            audioSource.enabled = soundToggle.isOn;
            // Toggle의 값이 변경될 때마다 사운드 ON/OFF 제어
            soundToggle.onValueChanged.AddListener(OnSoundToggleChanged);
        }

        if (volumeSlider != null)
        {
            // Slider의 값이 변경될 때마다 사운드 볼륨 조절
            volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        }



    }

     void OnSoundToggleChanged(bool isSoundOn)
     {   
        audioSource.enabled = isSoundOn;
     }   
    void OnVolumeSliderChanged(float volume)
    {
        audioSource.volume = volume;
    }
}
