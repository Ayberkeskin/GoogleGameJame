using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] private float countdownDuration = 10f; // Geri sayım süresi (saniye)
    private float currentTime;
    private TextMeshProUGUI countdownText;
    private bool _finishTime=false;

    private void Start()
    {
        countdownText = GetComponent<TextMeshProUGUI>();
        currentTime = countdownDuration;
    }

    private void Update()
    {
        // Geri sayımı güncelle
        currentTime -= Time.deltaTime;
        int secondsRemaining = Mathf.CeilToInt(currentTime);
        countdownText.text = secondsRemaining.ToString();

        // Geri sayım tamamlandıysa bir şeyler yapabilirsiniz
        if (currentTime <= 0f)
        {
            // Örneğin: "Geri sayım tamamlandı!" mesajını göster
            _finishTime = true;
            countdownText.text = "Geri sayım tamamlandı!";
        }
    }
}
