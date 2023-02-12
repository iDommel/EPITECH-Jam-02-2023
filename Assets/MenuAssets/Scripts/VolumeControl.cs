using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private Slider m_VolumeSlider = null;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("Volume");
            m_VolumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            AudioListener.volume = 0.5f;
            m_VolumeSlider.value = 0.5f;
        }
    }

    public void VolumeSlider(float volume)
    {
        AudioListener.volume = m_VolumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
