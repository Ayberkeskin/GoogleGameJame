using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject borders;
    [SerializeField] private GameObject player;
    public Table table;
    
    private float visibilityDuration = 31f; // Görünürlük süresi (saniye)

    void Update()
    {
        if (table.OnTable)
        {
            // Nesnelerin görünürlüğünü etkinleştir
            spawnPoint.SetActive(true);
            canvas.SetActive(true);
            borders.SetActive(true);

    

            // Belirli bir süre sonra nesnelerin görünürlüğünü kapat
            StartCoroutine(DisableObjectsAfterDelay());
        }
    }

    IEnumerator DisableObjectsAfterDelay()
    {
        Debug.Log("Coroutine başladı");
        // Belirli bir süre bekleyip sonra nesnelerin görünürlüğünü kapat
        yield return new WaitForSeconds(visibilityDuration);

        // Nesnelerin görünürlüğünü devre dışı bırak
        spawnPoint.SetActive(false);
        canvas.SetActive(false);
        borders.SetActive(false);
        table.OnTable = false;

        Debug.Log("Coroutine bitti");
    }
}
