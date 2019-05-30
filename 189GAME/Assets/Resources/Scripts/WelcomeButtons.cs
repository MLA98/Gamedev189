using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WelcomeButtons : MonoBehaviour
{ 
    // Start the game
    public void SwtichToGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    // Quit the game
    public void ExitGame()
    {
        Application.Quit();
    }

    // Mute the volume
    public void VolumeOn()
    {
        if (AudioListener.volume != 0){
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
}
