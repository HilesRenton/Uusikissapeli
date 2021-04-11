using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;

    private void Start()
    {
        transition.SetTrigger("Start");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

  public void QuitGame ()
    {
        Debug.Log("Quitted the game");
        Application.Quit();
    }
}
