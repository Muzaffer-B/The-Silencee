using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControl : MonoBehaviour
{
    

    
    public void ButtonStart()
    {
        //Audio.Stop();
        SceneManager.LoadScene("MainStory");
    }
    public void ButtoýnQuit()
    {
        Application.Quit();
    }
    public void Settings()
    {
        SceneManager.LoadScene("Options");
    }
}
