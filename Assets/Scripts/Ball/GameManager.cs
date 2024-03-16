using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab; // Topun prefab'ı
    private float gameTimer = 45f; // Oyun süresi
    private int maxBalls = 5; // Maksimum top sayısı
    private float timeBetweenSpawns = 9f; // Topların çıkma aralığı
    private float spawnTimer;
    private int currentBallCount = 0; // Mevcut top sayısı

    void Start()
    {
        StartCoroutine(GameTimer());
        SpawnBall(); // Oyun başladığında bir top yarat
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= timeBetweenSpawns && currentBallCount < maxBalls)
        {
            SpawnBall();
            spawnTimer = 0; // Zamanlayıcıyı sıfırla
        }
    }

    IEnumerator GameTimer()
    {
        while (gameTimer > 0f)
        {
            yield return new WaitForSeconds(1f);
            gameTimer -= 1f;
        }

        Debug.Log("Oyun Bitti!");
        Time.timeScale = 0; // Oyunu durdur
    }

    void SpawnBall()
    {
        if (currentBallCount >= maxBalls) return; // Maksimum top sayısına ulaşıldıysa daha fazla top yaratma
        
        GameObject ball = Instantiate(ballPrefab, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), Quaternion.identity);
        currentBallCount++; // Mevcut top sayısını artır

        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float forceX = Random.Range(-100f, 100f); // X yönünde rastgele bir kuvvet
            float forceY = Random.Range(-100f, 100f); // Y yönünde rastgele bir kuvvet
            rb.AddForce(new Vector2(forceX, forceY));
        }
    }

    public void BallDestroyed()
    {
        currentBallCount--; // Bir top yok edildiğinde mevcut top sayısını azalt
    }
}
