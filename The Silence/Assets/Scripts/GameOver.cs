using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
     public void Checkpoint()
    {
        SceneManager.LoadScene("PlayScene");
    }
    
   public  void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

  public  void Exit()
    {
        Application.Quit();
    }
}
