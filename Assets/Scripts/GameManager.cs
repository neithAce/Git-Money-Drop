using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public int money = 50;
    public int hp = 100;
    public float itemFallSpeed = 3f;
    public float enemySpeed = 2f;
    private float baseItemSpeed;
    private float baseEnemySpeed;
    private float gameTime = 0f;
    public int speedLevel = 1;
    public CameraShake cameraShake;
    private bool isInvincible = false;
    private bool itemIncreased = false;
    private bool enemyIncreased = false;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        baseItemSpeed = itemFallSpeed;
        baseEnemySpeed = enemySpeed;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        int newLevel = Mathf.Min(Mathf.FloorToInt(gameTime / 30f) + 1, 4);
        if(newLevel != speedLevel)
        {
            speedLevel = newLevel;
            itemFallSpeed = baseItemSpeed * speedLevel;
            enemySpeed = baseEnemySpeed * speedLevel;
            Debug.Log("Speed Level: " + speedLevel);
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
        if (isInvincible) return;
        hp -= 25;
        if(cameraShake != null)
        {
            cameraShake.ShakeCamera();
        }

        StartCoroutine(Invincibility());
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(2f);
        isInvincible = false;
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
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
