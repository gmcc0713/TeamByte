using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObject : MonoBehaviour
{
    [SerializeField] GameObject m_activeObj;

    public GameObject GetActiveObj()
    {
        return m_activeObj;
    }

}
