using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum Sound
{
    Bgm,
    Effect,
    MaxCount
}

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioMixer mainAudioMixer;
    
    private AudioSource[] _audioSources = new AudioSource[(int)Sound.MaxCount];
    private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    void Start()
    {
        Init();
    }

    private void Init()
    {
        AudioMixerGroup bgmGroup = mainAudioMixer.FindMatchingGroups("BGM")[0];
        AudioMixerGroup sfxGroup = mainAudioMixer.FindMatchingGroups("SFX")[0];
        
        for (int i = 0; i < (int)Sound.MaxCount; i++)
        {
            GameObject go = new GameObject($"{(Sound)i} AudioSource");
            go.transform.parent = transform;
            _audioSources[i] = go.AddComponent<AudioSource>();
        }

        _audioSources[(int)Sound.Bgm].loop = true;
        _audioSources[(int)Sound.Bgm].outputAudioMixerGroup = bgmGroup;
        _audioSources[(int)Sound.Effect].outputAudioMixerGroup = sfxGroup;
    }

    // 재생 관련
    public void PlayBgm(string clipName, float volume = 1.0f)
    {
        AudioClip clip = GetOrAddClip(clipName);
        if (clip == null) return;

        AudioSource source = _audioSources[(int)Sound.Bgm];
        source.clip = clip;
        source.volume = volume;
        source.Play();
    }

    public void PlaySfx(string clipName, float volume = 1.0f)
    {
        AudioClip clip = GetOrAddClip(clipName);
        if (clip == null) return;
        
        _audioSources[(int)Sound.Effect].PlayOneShot(clip, volume);
    }
    
    public void PlayStoppableSfx(string clipName, float volume = 1.0f)
    {
        AudioClip clip = GetOrAddClip(clipName);
        if (clip == null) return;
        
        _audioSources[(int)Sound.Effect].PlayOneShot(clip, volume);
    }
    
    public void StopSfx()
    {
        _audioSources[(int)Sound.Effect].Stop();
    }
    

    public void StopBgm() => _audioSources[(int)Sound.Bgm].Stop();
    

    // 볼륨 조절
    public void SetVolume(string parameterName, float sliderValue)
    {
        float volume = Mathf.Log10(Mathf.Max(0.0001f, sliderValue)) * 20;
        mainAudioMixer.SetFloat(parameterName, volume);
    }

    // 리소스 로딩
    private AudioClip GetOrAddClip(string clipName)
    {
        if (_audioClips.TryGetValue(clipName, out AudioClip clip))
            return clip;

        clip = Resources.Load<AudioClip>($"Sounds/{clipName}");
        if (clip != null) _audioClips.Add(clipName, clip);
        
        return clip;
    }
}