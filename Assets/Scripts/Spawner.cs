using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject moneyPrefab;
    public GameObject debtPrefab;
    public float spawnInterval = 2f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnItem();
            timer = 0f;
        }
    }

    void SpawnItem()
    {
        int randomValue = Random.Range(0, 100);
        Vector3 spawnPosition = new Vector3(Random.Range(-4f, 4f), 6f, 0f);

        if (randomValue < 70)
        {
            Instantiate(moneyPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(debtPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
