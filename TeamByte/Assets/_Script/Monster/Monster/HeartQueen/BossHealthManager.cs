using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossHealthManager : MonoBehaviour
{
	public static BossHealthManager Instance { get; private set; }
	void Awake()
	{
		if (null == Instance)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
			return;
		}
		Destroy(gameObject);
	}
	[SerializeField]GameObject[] m_healths;
    [SerializeField]int m_healthCount;
    void Start()
    {
        m_healthCount = 0;

		for (int i =0;i<m_healths.Length;i++)
        {
            m_healths[i].SetActive(true);
        }
    }
    public void HealthCountUP()
    {
        m_healthCount++;
        if(m_healthCount>=4)
        {
            Debug.Log("111");
            MonsterManager.Instance.bossMon.GetComponent<HeartQueenBossMonster>().canDamaged();
        }
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
