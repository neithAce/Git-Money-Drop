using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    private int direction;

    void Start()
    {
        float spawnY = -4f;

        if (Random.value < 0.5f)
        {
            transform.position = new Vector3(-9f, spawnY, 0f);
            direction = 1;
        }
        else
        {
            transform.position = new Vector3(9f, spawnY, 0f);
            direction = -1;
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x) > 11f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.TakeDamage();
            Destroy(gameObject);
        }
    }
}
