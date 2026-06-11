using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static bool isStartingNewGame = false;

    public GameObject mainMenuPanel;
    public GameObject gameUIPanel;
    public GameObject continueButton;
    public GameObject pausePanel;

    public TextMeshProUGUI highScoreText;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;

        if(PlayerPrefs.GetInt("HasSave", 0) == 0)
            continueButton.SetActive(false);

        if (isStartingNewGame)
        {
            isStartingNewGame = false;
            mainMenuPanel.SetActive(false);
            gameUIPanel.SetActive(true);

            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    public void PlayGame()
    {
        isStartingNewGame = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

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
        Time.timeScale = 1f;
        SaveLoadManager.instance.LoadGame();
        mainMenuPanel.SetActive(false);
        gameUIPanel.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void ExitToMenu()
    {
        if(SaveLoadManager.instance != null)
        {
            SaveLoadManager.instance.SaveGame();
        }

        pausePanel.SetActive(false);
        gameUIPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
