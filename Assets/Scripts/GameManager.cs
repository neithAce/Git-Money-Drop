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
        instance = this;
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
            Debug.Log("Game Over!");
            Time.timeScale = 0f;
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
    }

    public void TakeDamage()
    {
        hp -= 25;
    }
}
