using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speed = 5f;
    public float destroyDelay = 7f;
    public int damage = 1; // Bıçağın verdiği hasar miktarı

    void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    void Update()
    {
        // Mermi, sağa doğru hareket eder.
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Çarpışma yapılan nesne "Player" etiketine sahipse
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>(); // Oyuncunun sağlık bileşenini al
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Oyuncuya hasar ver
            }
            Destroy(gameObject); // Bıçağı yok et
        }
    }
}
