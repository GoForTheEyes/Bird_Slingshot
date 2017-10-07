using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

    public LevelStars levelStar;
    public GameObject endGamePanel;
    public Text menuText;
    public GameObject continueButton;
    public GameObject gameplayBackButton;

    public void GoBack()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver(bool wonlevel)
    {
        endGamePanel.SetActive(true);
        gameplayBackButton.SetActive(false);
        if (wonlevel)
        {
            menuText.text = "Success";
        }
        else
        {
            menuText.text = "Try again";
        }
        levelStar.SetStars(GetCurrentStars());
    }

    private int GetCurrentStars()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            return PlayerPrefsManager.Get_LEVEL1_STARS();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            return PlayerPrefsManager.Get_LEVEL2_STARS();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            return PlayerPrefsManager.Get_LEVEL3_STARS();
        }
        return 0;
    }
}
