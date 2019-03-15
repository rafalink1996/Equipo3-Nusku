using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //Destroy(GameObject.Find("Canvas/HUD"));

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickMenu()
    {
        //GameStats.stats.health = 100;
        SceneManager.LoadScene(GameStats.stats.currentScene);
        Time.timeScale = 1f;
    }
    public void OnClickQuit()
    {
        SceneManager.LoadScene("Menu");

    }
    public void SelectButton()
    {
        GetComponentInChildren<Button>().Select();
        GetComponentInChildren<Button>().OnSelect(null);
    }

}
