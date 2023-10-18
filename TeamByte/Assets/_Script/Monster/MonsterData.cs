using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster Data", menuName = "ScriptableObject/Monster Data Asset", order = 2)]
public class MonsterData : ScriptableObject
{
    public int m_iAttackDamage;
    public int m_iHP;
    public float m_iSpeed;
    public float m_iAttackRange;
    public MonsterData()
    {
        m_iAttackDamage = 1;
        m_iHP = 1;
        m_iSpeed = 1;
    }

}
