using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("IntroScene");
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Saindo...");
    }

    public void ReplayButton()
    {
        Time.timeScale = 1;
    }
    public void ChangeMenus(GameObject NextButton) 
    {
    EventSystem.current.SetSelectedGameObject(NextButton);
    }
}
