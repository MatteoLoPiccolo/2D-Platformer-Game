using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    private bool _isMute = false;
    private float _volume = 1f;

    [Header("Music")]
    [SerializeField] AudioSource _soundMusic;
    [SerializeField] AudioSource _soundEffect;

    [Space]
    [SerializeField] List<Sounds> _soundsList = new List<Sounds>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetMusicVolume(0.5f);
        SetSoundsVolume(1f);
        PlayMusic(SoundsType.Music);
    }

    public void Mute(bool status)
    {
        _isMute = status;
    }

    public void SetMusicVolume(float volume)
    {
        _volume = volume;
        _soundMusic.volume = volume;
    }

    public void SetSoundsVolume(float volume)
    {
        _volume = volume;
        _soundEffect.volume = volume;
    }

    public void PlayMusic(SoundsType soundType, string soundName = null)
    {
        if (_isMute)
            return;

        AudioClip _clip = GetSoundClip(soundType, soundName);
        if (_clip != null)
        {
            _soundMusic.PlayOneShot(_clip);
            //_soundMusic.clip = _clip;
            //_soundMusic.Play();
        }
        else
        {
            Debug.LogWarning("AudioClip not found for sound type: " + soundType);
        }
    }

    public void PlaySound(SoundsType soundType, string soundName = null)
    {
        AudioClip _clip = GetSoundClip(soundType, soundName);

        if (_clip != null)
        {
            _soundEffect.PlayOneShot(_clip);
            //_soundEffect.clip = _clip;
            //_soundEffect.Play();
        }
        else
        {
            Debug.LogWarning("AudioClip not found for sound type: " + soundType);
        }
    }

    private AudioClip GetSoundClip(SoundsType soundType, string soundName = null)
    {
        Sounds sound = _soundsList.Find(s => s._soundType == soundType && (soundName == null || s._soundName == soundName));
        return sound != null ? sound._audioClip : null;
    }

    [Serializable]
    public class Sounds
    {
        public SoundsType _soundType;
        public string _soundName;
        public AudioClip _audioClip;
    }

    public enum SoundsType
    {
        ButtonClick,
        Music,
        Collectable,
        PlayerMove,
        PlayerDeath,
        EnemyDeath
    }
}