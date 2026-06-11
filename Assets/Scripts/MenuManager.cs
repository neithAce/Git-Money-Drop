using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static bool isStartingNewGame = false;

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
        Debug.Log("Play Game button clicked");
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
}
