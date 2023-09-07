using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

// Serializable class to represent the sound effects dictionary in the Inspector
[System.Serializable]
public class SoundEffectDictionary
{
    public string key;
    public AudioClip value;
    public int volume;
}

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public AudioMixer audioMixer;
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    // Use a List of SoundEffectDictionary entries to represent the sound effects
    public List<SoundEffectDictionary> soundEffectsList = new List<SoundEffectDictionary>();

    // Dictionary for quick lookup
    private Dictionary<string, AudioClip> soundEffects = new Dictionary<string, AudioClip>();

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("AudioManager");
                    instance = go.AddComponent<AudioManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // Populate the soundEffects dictionary from the soundEffectsList
        foreach (var entry in soundEffectsList)
        {
            if (!soundEffects.ContainsKey(entry.key))
            {
                soundEffects.Add(entry.key, entry.value);
            }
        }
    }

    public void PlayBackgroundMusic(AudioClip music)
    {
        bgmSource.clip = music;
        bgmSource.Play();
    }

    // Play a sound effect by key
    public void PlaySoundEffect(string key)
    {
        if (soundEffects.ContainsKey(key))
        {
            sfxSource.PlayOneShot(soundEffects[key]);
        }
        else
        {
            Debug.LogError("Sound effect key not found: " + key);
        }
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
}
