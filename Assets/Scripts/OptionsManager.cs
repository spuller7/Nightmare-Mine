using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

    public Slider volume;

    public AudioSource audioMain;

    public GameSettings gameSettings;

    private void OnEnable()
    {

        gameSettings = new GameSettings();

        volume.onValueChanged.AddListener(delegate { onMusicVolumeChange(); });
    }

    public void onMusicVolumeChange()
    {
        audioMain.volume = gameSettings.volume = volume.value;
    }

    public void onMouseSenseChange()
    {
        
    }

    public void saveSettings()
    {

    }
}
