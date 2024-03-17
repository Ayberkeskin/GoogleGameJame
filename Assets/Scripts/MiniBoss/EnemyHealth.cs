using UnityEngine;
using UnityEngine.UI; // Slider için
using TMPro; // TextMeshPro için
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int health = 70;
    public TMP_Text winMessageText; // Win message için TextMeshPro referansı
    public Slider healthSlider; // Sağlık çubuğu olarak kullanılacak Slider referansı

    void Start()
    {
        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(false); // Win mesajını başlangıçta gizle
        }

        if (healthSlider != null)
        {
            healthSlider.maxValue = health; // Slider'ın maksimum değerini maksimum sağlık değeri ile eşitle
            healthSlider.value = health; // Slider'ın mevcut değerini mevcut sağlık değeri ile eşitle
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (healthSlider != null)
        {
            healthSlider.value = health; // Sağlık çubuğunu güncelle
        }

        if (health <= 0)
        {
            ShowWinMessage();
            Destroy(gameObject); // Düşmanı yok et
            LoadNextScene(); // Bir sonraki sahneye geç
        }
    }

    void ShowWinMessage()
    {
        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(true); // Win mesajını göster
        }
    }

    void LoadNextScene()
    {
        // Mevcut sahnenin indeksini al ve bir sonraki sahneye geç
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1); // Sonraki sahneye geç
    }
}
