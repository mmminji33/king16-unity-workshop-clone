using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class SceneBgmSetting : SceneSingleton<SceneBgmSetting>
{
    public String bgmName;
    void Start()
    {
        SoundManager.Instance.PlayBgm(bgmName);
    }
}