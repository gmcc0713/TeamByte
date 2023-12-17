using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSliderController : MonoBehaviour
{
    [SerializeField] private Sound_Type soundType;
    private Slider soundSlider;  

    void OnEnable()
    {
        soundSlider = gameObject.GetComponent<Slider>();
        SetValue();
    }
    public void ChangeValue()
    {
        AudioManger.Instance.ChangeAudioVolume(soundType, soundSlider.value);
    }
    public void SetValue()
    {
        Debug.Log(AudioManger.Instance);
        soundSlider.value = AudioManger.Instance.GetVolumValue(soundType);
    }
}
