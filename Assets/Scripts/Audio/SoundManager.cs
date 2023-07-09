using System.Collections.Generic;
using Plugins.Audio.Core;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum SoundType { CollectSound = 0, SliderSound,EagleSound,WinSound,LoseSound };

    private List<AudioSource> source = new List<AudioSource>();
    private SourceAudio _sourceAudio;

    public int sourceAmount = 3;
    
    public  float volume = 0.4f;
    [SerializeField]private float volumeK = 0.7f;

    public static SoundManager Instance;
 
    private void Start()
    {
        
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        _sourceAudio = GetComponent<SourceAudio>();

        volume = (PlayerPrefs.HasKey("VFX_VOLUME")) ? PlayerPrefs.GetFloat("VFX_VOLUME") : volume;

        volume *= volumeK;
        _sourceAudio.Volume = volume;

        for (int i = 0; i < sourceAmount; i++)
        {
            source.Add(gameObject.AddComponent<AudioSource>());
        }
        foreach (AudioSource aso in source)
        {
            aso.volume = volume;
        }
        

    }

    public  void ChangeVolume(float newVolume)
    {
        volume = newVolume;
        volume *= volumeK;

        foreach (AudioSource aso in source)
        {
            aso.volume = volume;
        }

        _sourceAudio.Volume = volume;
    }

    public void PlaySound(SoundType type)
    {
        _sourceAudio.Play(type.ToString());
        Debug.Log("Sound");
    }

    private void PlayLocal(AudioClip clip)
    {
        for (int i = 0; i < source.Count; i++)
        {
            if (source[i].isPlaying)
                continue;
            source[i].clip = clip;
            source[i].Play();
            return;
        }

        int rand = Random.Range(0, source.Count);
        source[rand].clip = clip;
        source[rand].Play();
    }

}