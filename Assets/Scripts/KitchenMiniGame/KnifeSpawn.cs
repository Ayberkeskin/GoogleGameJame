using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawn : MonoBehaviour
{
    public GameObject bulletPrefab;
       public Transform[] spawnPoints;
       public float minSpawnInterval = 1f;
       public float maxSpawnInterval = 3f;
   
       void Start()
       {
           StartCoroutine(SpawnBullets());
       }
   
       IEnumerator SpawnBullets()
       {
           while (true)
           {
               yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
   
               int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
               Transform spawnPoint = spawnPoints[randomSpawnPointIndex];
               Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
           }
       }
}
