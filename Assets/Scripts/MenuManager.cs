using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gameUIPanel;
    public GameObject continueButton;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;

        if(PlayerPrefs.GetInt("HasSave", 0) == 0)
            continueButton.SetActive(false);

        Time.timeScale = 0f;
    }

    public void PlayGame()
    {
        mainMenuPanel.SetActive(false);
        gameUIPanel.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ShowMenu()
    {
        mainMenuPanel.SetActive(true);
        gameUIPanel.SetActive(false);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
    }

    public void ContinueGame()
    {
        mainMenuPanel.SetActive(false);
        gameUIPanel.SetActive(true);
        SaveLoadManager.instance.LoadGame();
        Time.timeScale = 1f;
    }
}
