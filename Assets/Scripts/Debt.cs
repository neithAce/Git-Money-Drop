using UnityEngine;

public class Debt : MonoBehaviour
{
    public AudioClip debtSound;
    public GameObject DebtPickUpEffect;

    void Update()
    {
        transform.Translate(Vector2.down * GameManager.instance.itemFallSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameManager.instance != null)
        {
            if (debtSound != null)
            {
                AudioSource.PlayClipAtPoint(debtSound, transform.position);
            }

            Instantiate(DebtPickUpEffect, transform.position, Quaternion.identity);
            GameManager.instance.AddDebt();
            Destroy(gameObject);
        }
    }
}
