using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform hedef; // Oyuncu karakteri veya başka bir nesne
    public float kameraHizi = 5f;
    public float minX; // Sahnenin minimum X koordinatı
    public float maxX; // Sahnenin maksimum X koordinatı
    public float minY; // Sahnenin minimum Y koordinatı
    public float maxY; // Sahnenin maksimum Y koordinatı

    private void Update()
    {
        // Kameranın görüş alanının yarısını hesapla
        float kameraYuksekligi = Camera.main.orthographicSize;
        float kameraGenisligi = kameraYuksekligi * Camera.main.aspect;
        
        // Kameranın X ve Y koordinatlarını sınırlar içinde tut
        float sinirlanmisX = Mathf.Clamp(hedef.position.x, minX + kameraGenisligi, maxX - kameraGenisligi);
        float sinirlanmisY = Mathf.Clamp(hedef.position.y, minY + kameraYuksekligi, maxY - kameraYuksekligi);
        
        // Kameranın yeni pozisyonunu ayarla
        Vector3 yeniPozisyon = new Vector3(sinirlanmisX, sinirlanmisY, transform.position.z);
        
        // Kameranın pozisyonunu güncelle
        transform.position = Vector3.Lerp(transform.position, yeniPozisyon, kameraHizi * Time.deltaTime);
    }
}
