using System;
using System.Collections;
using UnityEngine;
using Plugins.Audio.Core;

public class MusicManager : MonoBehaviour
{

    
    private SourceAudio _sourceAudio;
    public float volume = 0.5f;

    [SerializeField]private float volumeK = 0.7f;
    public enum MusicType { MainMenuMusic = 0, InGameMusic };

    [SerializeField] private AudioClip[] Clips;
    [SerializeField] private float[] ClipsLength;

    private MusicType curMusicType;
    private float curTime = 0;

    public static MusicManager Instance;
    void Start()
    {

        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(transform.parent);
        }
        else
        {
            Destroy(gameObject);
        }
        
        _sourceAudio = GetComponent<SourceAudio>();
        volume = (PlayerPrefs.HasKey("MUSIC_VOLUME")) ? PlayerPrefs.GetFloat("MUSIC_VOLUME") : volume;
        volume *= volumeK;
        _sourceAudio.Volume = volume;

        curTime = 0;
        ChangeMusic(MusicType.MainMenuMusic);

        for (int i = 0; i < Clips.Length; i++)
        {
            ClipsLength[i] = Clips[i].length;
        }
        
    }
    
    public void ChangeVolume(float newVolume)
    {
        volume = newVolume;
        volume *= volumeK;
        _sourceAudio.Volume = volume;

    }

    private void Update()
    {
        curTime += Time.unscaledDeltaTime;
        
        if (curTime > ClipsLength[(int)curMusicType] - 1)
        {
              _sourceAudio.Play(curMusicType.ToString());
            curTime = 0;
        }
    }

    public void ChangeMusic(MusicType type)
    {
        curTime = 0;
        curMusicType = type;
        _sourceAudio.Play(curMusicType.ToString());
    }

}
