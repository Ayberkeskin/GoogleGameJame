using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yönetimi için gerekli ad alanı

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Maksimum sağlık değeri
    private int currentHealth; // Mevcut sağlık değeri

    void Start()
    {
        currentHealth = maxHealth; // Oyun başladığında karakterin canını maksimum yap
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Karakterin canını azalt
        Debug.Log("Kalan Can: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // Karakterin canı 0'a eşit veya daha az ise ölüm fonksiyonunu çağır
        }
    }

    void Die()
    {
        Debug.Log("Karakter Öldü!");
        RestartLevel(); // Karakter öldüğünde mevcut sahneyi yeniden başlat
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Mevcut sahneyi yeniden yükle
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage")) // Çarpışma yapılan nesne "Ball" etiketine sahipse
        {
            TakeDamage(1); // Karakterin canını 1 azalt
        }
    }
}
