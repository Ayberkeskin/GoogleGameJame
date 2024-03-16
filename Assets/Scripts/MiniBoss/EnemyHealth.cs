using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {   

            Debug.Log("Düşman öldü");
            // Düşmanı yok et
            Destroy(gameObject);
        }
    }
}
