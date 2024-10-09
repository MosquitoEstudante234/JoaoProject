using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelEvents : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
