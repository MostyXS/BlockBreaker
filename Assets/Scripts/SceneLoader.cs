using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void NextSceneLoad()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
       

    }
    public void StartSceneLoad()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().RestartStatus();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
