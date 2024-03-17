using UnityEngine;
using UnityEngine.SceneManagement;  
using System.Collections;


public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialoguePanel; // Inspector'dan atayacağınız diyalog paneli

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialoguePanel.SetActive(true); // Oyuncu girdiğinde diyalog kutusunu göster
            StartCoroutine(LoadNextSceneAfterDelay(15f)); // 4 saniye bekleyip sahneyi yükle
        }
    }

    
    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Belirtilen süre kadar beklet

        // Mevcut sahnenin indeksini al ve bir sonraki sahneye geç
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
