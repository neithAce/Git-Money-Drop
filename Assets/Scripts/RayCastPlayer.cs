using UnityEngine;

public class RayCastPlayer : MonoBehaviour
{
    public float rayDistance = 5f;
    public LayerMask enemyLayer;
    public LineRenderer lineRenderer;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, rayDistance, enemyLayer);
        if (hit.collider != null)
        {
            Debug.Log("Enemy detected!");
            GameManager.instance.TakeDamage();
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + Vector3.right * rayDistance);
        }
    }
}
