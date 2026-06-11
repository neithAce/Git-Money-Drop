using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject moneyPrefab;
    public GameObject debtPrefab;
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    private float timer;
    private float gameTime;

    void Update()
    {
        timer += Time.deltaTime;
        gameTime += Time.deltaTime;

        UpdateDifficulty();

        if (timer >= spawnInterval)
        {
            SpawnItem();
            timer -= spawnInterval;
        }
    }

    void SpawnItem()
    {
        int randomValue = Random.Range(0, 100);
        Vector3 spawnPosition = new Vector3(Random.Range(-9f, 9f), 4f, 0f);

        if (randomValue < 50)
        {
            Instantiate(moneyPrefab, spawnPosition, Quaternion.identity);
        }
        else if(randomValue < 75)
        {
            Instantiate(debtPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefab, new Vector3(0f, -2f, 0f), Quaternion.identity);
        }
    }

    void UpdateDifficulty()
    {
        if (gameTime >= 90f)
        {
            spawnInterval = 0.25f;
        }
        else if (gameTime >= 60f)
        {
            spawnInterval = 0.5f;
        }
        else if (gameTime >= 30f)
        {
            spawnInterval = 1f;
        }
        else
        {
            spawnInterval = 2f;
        }
    }
}
