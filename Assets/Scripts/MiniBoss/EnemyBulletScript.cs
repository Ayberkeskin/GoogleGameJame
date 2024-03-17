
using UnityEngine;


public class BulletScritp : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force = 5000f; // Mermiye uygulanan kuvvet, bu değeri artırarak mermilerin hızını artırabilirsiniz

    private float timer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot-90);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // PlayerHealth komponentine eriş ve hasar ver
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
            Destroy(gameObject);
        }
        
        
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // Düşmana hasar verme işlevini çağır
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            Animator enemyAnimator = collision.gameObject.GetComponent<Animator>();
            if (enemyHealth != null)
            {
                enemyAnimator.SetTrigger("Hit"); // "Hit" trigger'ını tetikle
                enemyHealth.TakeDamage(10); // Örneğin düşmana 10 hasar ver
                Debug.Log("Düşmanın kalan canı: " + enemyHealth.health);
                enemyAnimator.SetTrigger("nohit"); // "Hit" trigger'ını tetikle

            }

            // Mermiyi yok et
            Destroy(gameObject);
        
        }

    }

}
