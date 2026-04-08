using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundVolumeData", menuName = "Audio/Sound Volume Data")]
public class SoundVolumeData : ScriptableObject
{
    [System.Serializable]
    public class SoundVolumeSetting
    {
        public string clipName;
        [Range(0f, 1f)]
        public float volume = 1f; // 초기 볼륨
    }
    
    public List<SoundVolumeSetting> bgmVolumes = new List<SoundVolumeSetting>();   // BGM 목록
    public List<SoundVolumeSetting> sfxVolumes = new List<SoundVolumeSetting>();   // SFX 목록
}