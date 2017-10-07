using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStars : MonoBehaviour {

    public Image[] stars;

    private Color greyFade = new Color(0f / 255f, 0f / 255f, 0f / 255f, 0.5f);

    public void SetStars(int starsUnlocked)
    {
        if (starsUnlocked == 0) {
            stars[0].color = greyFade;
            stars[1].color = greyFade;
            stars[2].color = greyFade;
        }
        else if (starsUnlocked == 1)
        {
            stars[0].color = Color.white;
            stars[1].color = greyFade;
            stars[2].color = greyFade;
        }
        else if (starsUnlocked == 2)
        {
            stars[0].color = Color.white;
            stars[1].color = Color.white;
            stars[2].color = greyFade;
        }
        else if (starsUnlocked == 3)
        {
            stars[0].color = Color.white;
            stars[1].color = Color.white;
            stars[2].color = Color.white;
        }
    }

	
}
