using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BallShooting : MonoBehaviour
{
    public GameObject bullet; // Mermi prefab'ı
    public Transform bulletPos; // Mermi çıkış noktası
    private float timer = 0;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        

        if (distance < 10)
        {
            timer+= Time.deltaTime;
            if (timer >= 1)
        {
            timer = 0;
            Shoot();
        }
        }
        
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    
    }
}
