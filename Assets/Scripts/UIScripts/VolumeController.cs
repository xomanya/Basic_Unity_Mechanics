using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;
    public Text valueText;

    private const float _multiplier = 20.0f;
    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        var volumeValue = Mathf.Log10(value) * _multiplier;
        mixer.SetFloat(volumeParameter, volumeValue);
        valueText.text = volumeValue.ToString();
    }
    void Update()
    {
        
    }
}
