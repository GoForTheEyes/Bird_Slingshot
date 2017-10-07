using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    public Sprite[] levelSprites;
    public GameObject level1, level2, level3;
    public Sprite locked;


    public void Awake()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsManager.LEVEL2_UNLOCKED))
        {
            InitializeNew();
        }
        Initialize();
    }

    void InitializeNew()
    {
        //Setting up variables
        PlayerPrefsManager.Set_LEVEL2_UNLOCKED(0);
        PlayerPrefsManager.Set_LEVEL3_UNLOCKED(0);
        PlayerPrefsManager.Set_LEVEL1_STARS(0);
        PlayerPrefsManager.Set_LEVEL2_STARS(0);
        PlayerPrefsManager.Set_LEVEL3_STARS(0);
    }


    void Initialize()
    {
        if ( PlayerPrefsManager.Get_LEVEL2_UNLOCKED() == 0 )
        {
            level2.GetComponent<Image>().sprite = locked;
            level2.GetComponent<Button>().onClick.RemoveAllListeners();
        }
        else
        {
            level2.GetComponent<Image>().sprite = levelSprites[2-1];
            level2.GetComponent<Button>().onClick.AddListener( () => PlayLevel1() );

        }

        if (PlayerPrefsManager.Get_LEVEL3_UNLOCKED() == 0)
        {
            level3.GetComponent<Image>().sprite = locked;
            level3.GetComponent<Button>().onClick.RemoveAllListeners();
        }
        else
        {
            level3.GetComponent<Image>().sprite = levelSprites[3 - 1];
            level3.GetComponent<Button>().onClick.AddListener( () => PlayLevel1() );

        }

    }



    public void PlayLevel1()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
