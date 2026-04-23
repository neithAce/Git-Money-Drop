using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public int money = 50;
    public int hp = 100;
    public float itemFallSpeed = 3f;
    public float enemySpeed = 2f;
    private float gameTime = 0f;
    private bool itemIncreased = false;
    private bool enemyIncreased = false;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime >= 30f && !itemIncreased)
        {
            itemFallSpeed += 2f;
            itemIncreased = true;
        }
        if (gameTime >= 30f && !enemyIncreased)
        {
            enemySpeed += 2f;
            enemyIncreased = true;
        }
        if (money <= 0 || hp <= 0)
        {
            SaveHighScore();
            ReturnToMenu();
        }

        if (SaveLoadManager.instance != null)
        {
            SaveLoadManager.instance.SaveGame();
        }
    }

    public void AddMoney()
    {
        score += 100;
        money += 10;
    }

    public void AddDebt()
    {
        score -= 10;
        money -= 10;
        Debug.Log("Money sekarang: " + money);
    }

    public void TakeDamage()
    {
        hp -= 25;
    }

    void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }

    void ReturnToMenu()
    {
        Time.timeScale = 0f;
        MenuManager menu = FindObjectOfType<MenuManager>();
        if (menu != null)
        {
            menu.ShowMenu();
        }
    }
}
