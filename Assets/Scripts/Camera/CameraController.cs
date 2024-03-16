using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform hedef; // Oyuncu karakteri veya başka bir nesne
    public float kameraHizi = 5f;
    public float minimumX; // Kameranın hareket edebileceği minimum X koordinatı
    public float maksimumX; // Kameranın hareket edebileceği maksimum X koordinatı

    private void Update()
    {
        // Kameranın hedefi takip etmesi için hedefin Y koordinatını kullan
        Vector3 yeniPozisyon = new Vector3(hedef.position.x, hedef.position.y, transform.position.z);

        // Kameranın X koordinatını sınırlar içinde tut
        yeniPozisyon.x = Mathf.Clamp(yeniPozisyon.x, minimumX, maksimumX);

        // Kameranın pozisyonunu güncelle
        transform.position = Vector3.Lerp(transform.position, yeniPozisyon, kameraHizi * Time.deltaTime);
    }
}