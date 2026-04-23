using UnityEngine;

public class Money : MonoBehaviour
{
    public AudioClip coinSound;

    void Update()
    {
        transform.Translate(Vector2.down * GameManager.instance.itemFallSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.instance != null)
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            GameManager.instance.AddMoney();
            Destroy(gameObject);
        }
    }
}
