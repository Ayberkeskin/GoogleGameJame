using UnityEngine;
using UnityEngine.SceneManagement;  


public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialoguePanel; // Inspector'dan atayacağınız diyalog paneli

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialoguePanel.SetActive(true);
            LoadNextScene(); // Diyalog kutusunu göster
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialoguePanel.SetActive(false); // Oyuncu ayrıldığında diyalog kutusunu gizle
        }
    }
     void LoadNextScene()
    {
        // Mevcut sahnenin indeksini al
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Mevcut sahne indeksini bir artırarak bir sonraki sahneye geç
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
