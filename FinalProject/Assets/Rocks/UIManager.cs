using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text levelText;

    private void Start()
    {
        // Initialize the UI text with the loaded level
        UpdateLevelText();
    }

    public void SaveLevelButton()
    {
        int levelToSave = DetermineLevelToSave();
        LevelManager.SaveLevel(levelToSave);
        UpdateLevelText();
    }

    public void LoadLevelButton()
    {
        int loadedLevel = LevelManager.LoadLevel();
        // Load the level based on the loadedLevel (you can implement this logic).
        UpdateLevelText();
    }

    private int DetermineLevelToSave()
    {
        // Here, you can implement your logic to determine the level to save.
        // For this example, let's say you want to save the current level.
        int currentLevel = GetCurrentLevel(); // Implement this function to get the current level.
        return currentLevel;
    }

    private int GetCurrentLevel()
    {
        // Implement this function to retrieve the current level based on your game's logic.
        // For this example, let's return a hardcoded level.
        return 5; // Assuming the current level is 5.
    }

    private void UpdateLevelText()
    {
        int loadedLevel = LevelManager.LoadLevel();
        levelText.text = "Current Level: " + loadedLevel.ToString();
    }
}
