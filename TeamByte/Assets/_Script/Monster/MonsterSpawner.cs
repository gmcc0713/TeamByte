using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] m_Monster;
    public Vector3[] m_spawnPos;
    private int count =0;
    void Start()
    {
        count = m_Monster.Length;
    }

    void Spawn(int c)
    {
        for(int i = 0; i<c;i++)
        {
            GameObject clone = Instantiate(m_Monster[i], m_spawnPos[i], Quaternion.identity);
            Debug.Log(clone);
            MonsterManager.Instance.MonsterInit(clone.GetComponent<Monster>());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Spawn(count);
        }
    }

}
