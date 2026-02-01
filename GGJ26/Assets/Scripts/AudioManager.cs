using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;


    [SerializeField] private AudioSource audioSource;
    [SerializeField] public AudioClip responseGoodClip;
    [SerializeField] public AudioClip responseBadClip;

    // References to the AudioMixer and AudioSources
    public AudioMixer audioMixer;
    private AudioSource masterSource;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    // Handles to the AudioMixerGroups
    private AudioMixerGroup masterGroup;
    private AudioMixerGroup musicGroup;
    private AudioMixerGroup sfxGroup;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the AudioMixerGroups and set the output of the AudioSources to them
        masterGroup = audioMixer.FindMatchingGroups("Master")[0];
        masterSource.outputAudioMixerGroup = masterGroup;

        musicGroup = audioMixer.FindMatchingGroups("Music")[0];
        musicSource.outputAudioMixerGroup = musicGroup;

        sfxGroup = audioMixer.FindMatchingGroups("SFX")[0];
        sfxSource.outputAudioMixerGroup = sfxGroup;

        SetMasterVolume(0.8f);
        SetMusicVolume(0.8f);
        SetSFXVolume(1.0f);
    }

    public void SetMasterVolume(float volume)
    {
        // Set the volume of the Master group in the AudioMixer
        // Volume needs to be exposed in the AudioMixer
        audioMixer.SetFloat("MasterVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        // Set the volume of the Music group in the AudioMixer
        // Volume needs to be exposed in the AudioMixer
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        // Set the volume of the SFX group in the AudioMixer
        // Volume needs to be exposed in the AudioMixer
        audioMixer.SetFloat("SFXVolume", volume);
    }


    public void playaudioGood()
    {

        audioSource.clip = responseGoodClip;
        audioSource.Play();
    }

    public void playaudioBad()
    {

        audioSource.clip = responseBadClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
