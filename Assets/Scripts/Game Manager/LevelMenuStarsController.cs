using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuStarsController : MonoBehaviour {

    public LevelStars[] starsContainers;

    public void Start()
    {
        starsContainers[0].SetStars(PlayerPrefsManager.Get_LEVEL1_STARS());
        if (PlayerPrefsManager.Get_LEVEL2_UNLOCKED() == 1)
        {
            starsContainers[1].SetStars(PlayerPrefsManager.Get_LEVEL2_STARS());
        }
        else
        {
            starsContainers[1].gameObject.SetActive(false);
        }
        if (PlayerPrefsManager.Get_LEVEL3_UNLOCKED() == 1)
        {
            starsContainers[2].SetStars(PlayerPrefsManager.Get_LEVEL3_STARS());
        }
        else
        {
            starsContainers[2].gameObject.SetActive(false);
        }
    }




}
