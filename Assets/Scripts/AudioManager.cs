
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {  get; private set; }

    [System.Serializable]
    public struct SceneMusicPair
    {
        public string sceneName;
        public AudioClip clip;
    }

    [Header("Music")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioClip menuMusic;
    [SerializeField] private SceneMusicPair[] levelMusicPairs;
    private Dictionary<string, AudioClip> levelMusicDict;

    [Header("SFX")]
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioClip[] sfxClips;

    Dictionary<string, AudioClip> sfxDict;

    


    private void Awake ()
    {
        

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        sfxDict = new Dictionary<string, AudioClip>();
        foreach (var clip in sfxClips) 
            sfxDict[clip.name] = clip;

        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMusic(menuMusic);

        levelMusicDict = new Dictionary<string, AudioClip>();
        foreach (var pair in levelMusicPairs)
            levelMusicDict[pair.sceneName] = pair.clip;

        SceneManager.sceneLoaded += OnSceneLoaded;

        PlayMusic(menuMusic);
    }
    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.M))
            AudioListener.pause = !AudioListener.pause;
    }


    private void OnDestroy ()
    {
        if(Instance == this)
            SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip nextClip = levelMusicDict.TryGetValue(scene.name, out var clip)
            ? clip : menuMusic;

        if (musicSource.clip == nextClip) return;

        StartCoroutine(FadeAndPlay(nextClip, 1f));

       
    }
    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (!clip) return;
        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.Play();
    }

    public void PlaySFX(string clipName, float volume = 1f)
    {
        if (sfxDict.TryGetValue(clipName, out var clip))
            sfxSource.PlayOneShot(clip, volume);
        else
            Debug.LogWarning($"SFX '{clipName}' not found");
    }

    
    public void SetMusicVolume(float value01)
    {
        musicSource.volume = Mathf.Clamp01(value01); 
    }

    private IEnumerator FadeAndPlay(AudioClip nextClip, float fadeTime)
    {
        float startVol = musicSource.volume;

       
        for (float t = 0f; t < fadeTime; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(startVol, 0f, t / fadeTime);
            yield return null;
        }
        musicSource.volume = 0f;

        
        PlayMusic(nextClip);

       
        for (float t = 0f; t < fadeTime; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(0f, startVol, t / fadeTime);
            yield return null;
        }
        musicSource.volume = startVol;
    }

    public void PlayLoop(string clipName, float volume = 1f)
    {
        if(sfxDict.TryGetValue(clipName, out var clip))
        {
            sfxSource.clip = clip;
            sfxSource.volume = volume;
            sfxSource.loop = true;
            sfxSource.Play();
        }
    }

    public void StopLoop()
    {
        sfxSource.Stop();
        sfxSource.loop = false;
        sfxSource.clip = null;  
    }
}

