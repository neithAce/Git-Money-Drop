using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int direction;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float[] lanes = { -3.5f, 0.6f};
        float spawnY = lanes[Random.Range(0, lanes.Length)];

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
        rb.linearVelocity = new Vector2(direction * GameManager.instance.enemySpeed, rb.linearVelocity.y);
        if (Mathf.Abs(transform.position.x) > 11f)
        {
            Destroy(gameObject);
        }

        if(transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with player!");
            GameManager.instance.TakeDamage();
            Destroy(gameObject);
        }
    }
}
