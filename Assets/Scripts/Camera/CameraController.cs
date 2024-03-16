using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform hedef; // Oyuncu karakteri veya başka bir nesne
    public float kameraHizi = 5f;

    private void Update()
    {
        // Kameranın hedefi takip etmesi
        Vector3 yeniPozisyon = new Vector3(hedef.position.x, hedef.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, yeniPozisyon, kameraHizi * Time.deltaTime);
    }
}
