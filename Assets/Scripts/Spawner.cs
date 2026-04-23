using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject moneyPrefab;
    public GameObject debtPrefab;
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
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

        if (randomValue < 70)
        {
            Instantiate(moneyPrefab, spawnPosition, Quaternion.identity);
        }
        else if(randomValue < 85)
        {
            Instantiate(debtPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefab, new Vector3(0f, -2f, 0f), Quaternion.identity);
        }
    }
}
