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
            // Toggle�� ���� ����� ������ ���� ON/OFF ����
            soundToggle.onValueChanged.AddListener(OnSoundToggleChanged);
        }

        if (volumeSlider != null)
        {
            // Slider�� ���� ����� ������ ���� ���� ����
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
