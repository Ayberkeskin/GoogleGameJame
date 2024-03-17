using UnityEngine;

public class BulletRedirect : MonoBehaviour
{
    public float redirectForce = 10f; // Yönlendirme kuvveti
    public float detectionRadius = 2f; // Mermileri algılama yarıçapı

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
        // Player çevresindeki tüm collider'ları algıla, algılama yarıçapını kullan
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
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

                    // Mermiyi düşmana doğru döndür (mermi dönüş açısını ayarla)
                    float angle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg;
                    hitCollider.transform.rotation = Quaternion.Euler(0, 0, angle + 90);

                    // Bir mermi yönlendirildikten sonra döngüyü kır
                    break;
                }
            }
        }
    }
}
