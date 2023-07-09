using System.Collections.Generic;
using Plugins.Audio.Core;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum SoundType { CollectSound = 0, StepSound,LoseSound,RewardSound };

    private List<AudioSource> source = new List<AudioSource>();

    [SerializeField]private List<AudioClip> clips = new List<AudioClip>();
    public int sourceAmount;
    
    public  float volume = 0.4f;
    [SerializeField]private float volumeK = 0.7f;

    public static SoundManager Instance;
 
    private void Start()
    {
        sourceAmount = clips.Count;
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        volume = (PlayerPrefs.HasKey("VFX_VOLUME")) ? PlayerPrefs.GetFloat("VFX_VOLUME") : volume;

        volume *= volumeK;


        for (int i = 0; i < sourceAmount; i++)
        {
            source.Add(gameObject.AddComponent<AudioSource>());
            source[i].clip = clips[i];
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

    }

    public void PlaySound(SoundType type)
    {
        //_sourceAudio.Play(type.ToString());
        source[(int)type].Play();
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