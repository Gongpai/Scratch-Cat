using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace Assets.Dev2.sacip
{
    public class VolumeSetting : MonoBehaviour
    {
        [SerializeField] AudioMixer mixer;
        [SerializeField] Slider bgmSlider;
        [SerializeField] Slider sfxSlider;

        const string MIXER_BGM = "BGMVolume";
        const string MIXER_SFX= "SFXVolume";

        void Awake()
        {
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }

        void SetBGMVolume(float value)
        {
            mixer.SetFloat(MIXER_BGM, Mathf.Log10(value)*20);
        }

        void SetSFXVolume(float value)
        {
            mixer.SetFloat(MIXER_SFX, Mathf.Log10(value)*20);
        }
    }
}
