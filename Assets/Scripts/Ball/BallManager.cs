using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab; // Topun prefab'ı
    private float gameTimer = 45f; // Oyun süresi
    private int maxBalls = 4; // Maksimum top sayısı
    private float timeBetweenSpawns = 9f; // Topların çıkma aralığı (45sn / 5 = 9sn)
    private float spawnTimer;

    void Start()
    {
        StartCoroutine(GameTimer());
        SpawnBall(); // Oyun başladığında bir top yarat
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= timeBetweenSpawns && GameObject.FindGameObjectsWithTag("Ball").Length < maxBalls)
        {
            SpawnBall();
            spawnTimer = 0f; // Zamanlayıcıyı sıfırla
        }
    }

    IEnumerator GameTimer()
    {
        while (gameTimer > 0f)
        {
            yield return new WaitForSeconds(1f);
            gameTimer -= 1f;
            Debug.Log("Kalan Süre: " + gameTimer);
        }

        // Süre bittiğinde yapılacak işlemler
        Debug.Log("Oyun Bitti!");
        Time.timeScale = 0; // Oyunu durdur
    }

    void SpawnBall()
    {
    // Topu yarat
    GameObject ball = Instantiate(ballPrefab, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), Quaternion.identity);
    
    // Rigidbody2D bileşenine eriş
    Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
    
    // Topa rastgele bir başlangıç kuvveti uygula
    if (rb != null)
    {
        float forceX = Random.Range(-100f, 100f); // X yönünde rastgele bir kuvvet
        float forceY = Random.Range(-100f, 100f); // Y yönünde rastgele bir kuvvet
        rb.AddForce(new Vector2(forceX, forceY));
    }
}

}
