using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterSpawnPattern : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] monsters;
<<<<<<< Updated upstream

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player") )
=======
    bool isSpawned = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")|| !isSpawned)
>>>>>>> Stashed changes
        {
            Debug.Log("플레이어와 충돌");
            foreach(GameObject point in spawnPoints) 
            {
                int rand = Random.Range(0, monsters.Length);
                GameObject clone = Instantiate(monsters[rand], point.transform.position, Quaternion.identity);
                MonsterManager.Instance.MonsterInit(clone.GetComponent<Monster>());
            }
<<<<<<< Updated upstream
        }

    }
=======
            isSpawned = true;
        }

    }
    private void OnDisable()
    {
        isSpawned = false;
    }
>>>>>>> Stashed changes
}
