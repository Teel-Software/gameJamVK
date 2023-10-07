//using CI.QuickSave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VolumeChanging : MonoBehaviour
{

    [SerializeField]
    AudioMixerGroup mixer;

    [SerializeField]
    Toggle musicToggle;

    [SerializeField]
    bool BackgroundMusic;

    private void Start()
    {
        string s;
        if (BackgroundMusic) s = "BackVolume";
        else s = "EffectsVolume";

        //var reader = QSReader.Create("VolumeData");
        //if (!reader.Exists("Current" + s)) return;
        ////musicToggle.isOn = reader.Read<bool>("CurrentBackMusicVolume");
        //if (reader.Read<bool>("Current"+s))
        //{
        //    mixer.audioMixer.SetFloat(s, 0f);
        //    musicToggle.isOn = true;
        //}
        //else
        //{
        //    mixer.audioMixer.SetFloat(s, -80f);
        //    musicToggle.isOn = false;
        //}
    }

    public void ChangeVolume()
    {
        string s;
        if (BackgroundMusic) s = "BackVolume";
        else s = "EffectsVolume";

        if (musicToggle.isOn)
            mixer.audioMixer.SetFloat(s, 0f);
        else
            mixer.audioMixer.SetFloat(s, -80f);
        
        //var writer = QuickSaveWriter.Create("VolumeData");
        //writer.Write("Current"+s, musicToggle.isOn);
        //writer.Commit();
    }
}
