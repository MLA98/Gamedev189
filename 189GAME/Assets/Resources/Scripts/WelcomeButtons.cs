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
}
