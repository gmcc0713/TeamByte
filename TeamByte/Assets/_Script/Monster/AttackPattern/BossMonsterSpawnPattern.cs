using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterSpawnPattern : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] monsters;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject point in spawnPoints)
            {
                int rand = Random.Range(0, monsters.Length);

                GameObject clone = Instantiate(monsters[rand], point.transform.position, Quaternion.identity);


            }
        }

    }
}
