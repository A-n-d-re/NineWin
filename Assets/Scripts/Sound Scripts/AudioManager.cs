using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [SerializeField] private List<AudioClip> sfxClips;

    private Dictionary<string, AudioClip> sfxDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAudioSettings();

            Application.targetFrameRate = 120;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeSFXDictionary();
    }

    private void InitializeSFXDictionary()
    {
        sfxDictionary = new Dictionary<string, AudioClip>();
        foreach (var clip in sfxClips)
        {
            sfxDictionary[clip.name] = clip;
        }
    }

    public void PlaySound(string clipName)
    {
        if (sfxDictionary.ContainsKey(clipName))
        {
            sfxSource.PlayOneShot(sfxDictionary[clipName], sfxSource.volume);
        }
        else
        {
            Debug.LogWarning($"Звуковой эффект '{clipName}' не найден!");
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void SetMusicVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0f, 1f);
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0f, 1f);
        sfxSource.volume = volume;
    }

    public void SaveAudioSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSource.volume);
        PlayerPrefs.SetFloat("SFXVolume", sfxSource.volume);
        PlayerPrefs.Save();
    }

    private void LoadAudioSettings()
    {
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume");
    }
}

