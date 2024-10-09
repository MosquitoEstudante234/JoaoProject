using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    void Awake()
    {

        DontDestroyOnLoad(gameObject);
    }

    public void LoadSchool()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadPreGame()
    {
        SceneManager.LoadScene("PreGameScene");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void DeleteSelf()
    {
        Destroy(this.gameObject);
    }
}
