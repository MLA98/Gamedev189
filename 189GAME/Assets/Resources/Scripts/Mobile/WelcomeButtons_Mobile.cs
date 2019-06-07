using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeButtons_Mobile : MonoBehaviour
{ 
    [SerializeField] 
    private AudioSource clickAudio;
    // Start the game
    public void SwtichToGameScene()
    {
        clickAudio.Play();
        SceneManager.LoadScene("Game_Mobile");
    }

    // Quit the game
    public void ExitGame()
    {
        clickAudio.Play();
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
