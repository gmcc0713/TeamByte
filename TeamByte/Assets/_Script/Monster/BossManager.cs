using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager Instance { get; private set; }
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
    [SerializeField] private GameObject[] m_aMovingRoot;
    public GameObject[] GetMovingRoot()
    {
        return m_aMovingRoot;
    }

}
