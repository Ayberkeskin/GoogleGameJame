using System.IO;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 5; // Düşmanın canı

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damage")) // Mermi ile çarpışma kontrolü
        {
            TakeDamage(1); // Her mermi çarptığında 1 hasar al
            Destroy(collision.gameObject); // Mermiyi yok et
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die(); // Düşman öldü
        }
    }
    
    void Die()
    {
        // Düşmanın ölümüyle ilgili işlemler
        Destroy(gameObject); // Düşmanı yok et
    }
}
