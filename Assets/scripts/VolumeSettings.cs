using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeSettings : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioMixMode mixMode;
    [SerializeField] private string groupName;
    public enum AudioMixMode
    {
        LinearMixerVolume,
        LogarithmicMixerVolume
    }
    public void OnChangeSlider(float value)
    {
        switch (mixMode)
        {
            case AudioMixMode.LinearMixerVolume:
                mixer.SetFloat(groupName, -80 + value * 100);
                break;
            case AudioMixMode.LogarithmicMixerVolume:

                break;
            default:
                break;
        }
    }
}
