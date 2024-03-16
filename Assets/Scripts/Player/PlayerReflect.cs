using UnityEngine;

public class PlayerReflect : MonoBehaviour
{
    public KeyCode reflectKey = KeyCode.Space; // Yansıtma tuşu
    public float reflectForce = 10f; // Yansıtma kuvveti

    private void Update()
    {
        if (Input.GetKeyDown(reflectKey))
        {
            ReflectProjectile();
        }
    }

    void ReflectProjectile()
    {
        // Collider'ları trigger olarak işaretleyin
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 5f); // 5 birimlik bir yarıçapta tespit et
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Bullet") // "Bullet" tag'ine sahip objeleri kontrol et
            {
                Rigidbody2D rb = hitCollider.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 direction = (rb.transform.position - transform.position).normalized; // Mermiden oyuncuya doğru olan yön
                    rb.velocity = direction * reflectForce; // Mermiyi yansıt
                }
            }
        }
    }
}
