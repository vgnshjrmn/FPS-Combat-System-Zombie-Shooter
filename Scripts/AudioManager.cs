using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music")]
    public AudioClip menuMusic;
    public AudioClip gameplayMusic;
    public AudioClip gameOverMusic;

    [Header("UI / SFX")]
    public AudioClip buttonClick;
    public AudioClip gunShot;
    public AudioClip enemyHit;
    public AudioClip enemyDie;
    public AudioClip playerHit;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else

            Destroy(gameObject);
    }
    void Start()
    {
        // Load saved volumes or default to 1
        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 1f);

        musicSource.volume = musicVol;
        sfxSource.volume = sfxVol;
    }
    // 🎵 MUSIC VOLUME
    public void SetMusicVolume(float value)
    {
        musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);

        if (!musicSource.isPlaying)
            musicSource.Play();
    }


    public void SetSFXVolume(float value)
    {
        sfxSource.volume = value;
        PlayerPrefs.SetFloat("SFXVolume", value);
    }


    // 🎵 Play Background Music
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip) return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    // 🔊 Play Sound Effect
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip, sfxSource.volume);
    }

}
