using UnityEngine;
using UnityEngine.UI; // Slider için
using TMPro; // TextMeshPro için
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int health = 70;
    public TMP_Text winMessageText; // Win message için TextMeshPro referansı
    public Slider healthSlider; // Sağlık çubuğu olarak kullanılacak Slider referansı
    public string nextSceneName = "NextLevel"; // Geçilecek sonraki sahnenin adı

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
             // 2 saniye sonra sonraki sahneye geçiş yap
            Destroy(gameObject); // Düşmanı yok et
            LoadNextScene();
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
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
