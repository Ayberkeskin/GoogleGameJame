using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooting : MonoBehaviour
{
    public GameObject bullet; // Mermi prefab'ı
    public Transform bulletPos; // Mermi çıkış noktası
    private float timer = 0;
    public float shootingInterval = 1f; // Mermiler arasındaki atış aralığı (saniye)
    private int shootCount = 0; // Ateş etme sayacı
    private const int maxShootCount = 30; // Maksimum ateş etme sayısı
    private float pauseDuration = 2f; // Duraklama süresi (saniye)
    private bool isPaused = false; // Ateş etme duraklatıldı mı?

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            // Duraklama süresi kontrolü
            timer += Time.deltaTime;
            if (timer >= pauseDuration)
            {
                // Duraklama süresi bittiğinde
                isPaused = false;
                timer = 0; // Timer'ı sıfırla
                shootCount = 0; // Ateş etme sayısını sıfırla
            }
        }
        else
        {
            // Ateş etme kontrolü
            timer += Time.deltaTime;
            if (timer >= shootingInterval && shootCount < maxShootCount)
            {
                Shoot();
                shootCount++; // Ateş etme sayısını artır
                timer = 0; // Timer'ı sıfırla

                if (shootCount >= maxShootCount)
                {
                    // Maksimum ateş etme sayısına ulaşıldı, duraklat
                    isPaused = true;
                }
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
