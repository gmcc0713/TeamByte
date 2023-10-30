using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_Monster;
    void Start()
    {
        GameObject clone = Instantiate(m_Monster,transform.position, Quaternion.identity);
        Debug.Log(clone);
        MonsterManager.Instance.MonsterInit(clone.GetComponent<Monster>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
