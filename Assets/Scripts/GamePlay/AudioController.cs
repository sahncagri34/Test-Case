using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioData> audioList;

    public void PlaySound(AudioTypes audioType)
    {
        var audioClip = GetAudioClip(audioType);
        audioSource.PlayOneShot(audioClip);
    }
    private AudioClip GetAudioClip(AudioTypes audioType)
    {
       return audioList.Find(x => x.AudioType == audioType).AudioClip;
    }
    
}
