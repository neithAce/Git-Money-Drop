using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Money", GameManager.instance.money);
        PlayerPrefs.SetInt("Score", GameManager.instance.score);
        PlayerPrefs.SetInt("HP", GameManager.instance.hp);
        PlayerPrefs.SetInt("HasSave", 1);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.GetInt("HasSave", 0) == 1)
        {
            GameManager.instance.money = PlayerPrefs.GetInt("Money");
            GameManager.instance.score = PlayerPrefs.GetInt("Score");
            GameManager.instance.hp = PlayerPrefs.GetInt("HP");
            Debug.Log("Game Loaded");
        }
    }
}
