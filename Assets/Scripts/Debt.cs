using UnityEngine;

public class Debt : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.down * GameManager.instance.itemFallSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.instance != null)
        {
            GameManager.instance.AddDebt();
            Destroy(gameObject);
        }
    }
}
