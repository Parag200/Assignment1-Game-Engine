using UnityEngine;

public class LevelManager
{
    public static void SaveLevel(int level)
    {
        PlayerPrefs.SetInt("SavedLevel", level);
        PlayerPrefs.Save();
    }

    public static int LoadLevel()
    {
        return PlayerPrefs.GetInt("SavedLevel", 1); // Default to level 1 if no saved level
    }
}
