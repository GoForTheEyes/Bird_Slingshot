using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsManager {

    public static string LEVEL2_UNLOCKED = "level2_unlocked";
    public static string LEVEL3_UNLOCKED = "level3_unlocked";

    public static string LEVEL1_STARS = "level1_stars";
    public static string LEVEL2_STARS = "level2_stars";
    public static string LEVEL3_STARS = "level3_stars";

    #region LEVEL2_UNLOCK
    public static void Set_LEVEL2_UNLOCKED(int value)
    {
        PlayerPrefs.SetInt(LEVEL2_UNLOCKED, value);
    }

    public static int Get_LEVEL2_UNLOCKED()
    {
        return PlayerPrefs.GetInt(LEVEL2_UNLOCKED);
    }
    #endregion

    #region LEVEL3_UNLOCK
    public static void Set_LEVEL3_UNLOCKED(int value)
    {
        PlayerPrefs.SetInt(LEVEL3_UNLOCKED, value);
    }

    public static int Get_LEVEL3_UNLOCKED()
    {
        return PlayerPrefs.GetInt(LEVEL3_UNLOCKED);
    }
    #endregion

    #region LEVEL1_STARS
    public static void Set_LEVEL1_STARS(int value)
    {
        PlayerPrefs.SetInt(LEVEL1_STARS, value);
    }

    public static int Get_LEVEL1_STARS()
    {
        return PlayerPrefs.GetInt(LEVEL1_STARS);
    }
    #endregion

    #region LEVEL2_STARS
    public static void Set_LEVEL2_STARS(int value)
    {
        PlayerPrefs.SetInt(LEVEL2_STARS, value);
    }

    public static int Get_LEVEL2_STARS()
    {
        return PlayerPrefs.GetInt(LEVEL2_STARS);
    }
    #endregion

    #region LEVEL3_STARS
    public static void Set_LEVEL3_STARS(int value)
    {
        PlayerPrefs.SetInt(LEVEL3_STARS, value);
    }

    public static int Get_LEVEL3_STARS()
    {
        return PlayerPrefs.GetInt(LEVEL3_STARS);
    }
    #endregion

}
