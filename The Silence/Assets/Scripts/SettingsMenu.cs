using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainmixer;
    public void setVolume(float volume)
    {
        mainmixer.SetFloat("volume", volume);
    }
    public void setFulScreen(bool isfullscreen)
    {
        Screen.fullScreen = true;
    }
    
    public void SetQuality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }
    public void Backbutton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
