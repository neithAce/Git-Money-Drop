using UnityEngine;

public class Money : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.down * GameManager.instance.itemFallSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddMoney();
            Destroy(gameObject);
        }
    }
}
