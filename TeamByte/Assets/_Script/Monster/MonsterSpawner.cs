using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] m_Monster;
    public GameObject[] m_spawnPos;
    private int count =0;
    void Start()
    {
        count = m_Monster.Length;
        gameObject.SetActive(true);

    }

    void Spawn(int c)
    {
        for(int i = 0; i<c;i++)
        {
            GameObject clone = Instantiate(m_Monster[i], m_spawnPos[i].transform.position, Quaternion.identity);
            MonsterManager.Instance.MonsterInit(clone.GetComponent<Monster>());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Spawn(count);
            gameObject.SetActive(false);
        }
    }

}
