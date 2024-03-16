using UnityEngine;

public class BulletRedirect : MonoBehaviour
{
    public float redirectForce = 10f; // Yönlendirme kuvveti

    // Update is called once per frame
    void Update()
    {
        // "E" tuşuna basıldığında çağrılacak
        if (Input.GetKeyDown(KeyCode.E))
        {
            RedirectBulletTowardsEnemy();
        }
    }

    void RedirectBulletTowardsEnemy()
    {
        // Player çevresindeki tüm collider'ları algıla
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 5f);
        foreach (var hitCollider in hitColliders)
        {
            // Eğer collider bir mermiye aitse
            if (hitCollider.gameObject.CompareTag("Bullet"))
            {
                // Düşmanı bul
                GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
                if(enemy != null && hitCollider.GetComponent<Rigidbody2D>() != null)
                {
                    Rigidbody2D rb = hitCollider.GetComponent<Rigidbody2D>();

                    // Mermiyi düşmana doğru yönlendir
                    Vector2 directionToEnemy = (enemy.transform.position - hitCollider.transform.position).normalized;
                    rb.velocity = directionToEnemy * redirectForce;

                    // Mermiyi düşmana doğru döndür
                    float angle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg;
                    hitCollider.transform.rotation = Quaternion.Euler(0, 0, angle);
                }
            }
        }
    }
}
