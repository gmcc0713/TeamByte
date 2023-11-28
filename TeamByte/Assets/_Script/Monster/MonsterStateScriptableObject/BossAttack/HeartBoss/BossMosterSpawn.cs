using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BossWaitState", menuName = "ScriptableObject/FSM State/BossMonsterSpawn", order = 3)]
public class BossMosterSpawn : ScriptableObject, IState
{
    public void Enter(Monster owner)
    {
        Debug.Log("BossMonsterSpawn");
        owner.GetComponent<HeartQueenBossMonster>().SpawnMonster();
    }
    public void Excute(Monster owner)
    {

    }
    public void Exit(Monster owner)
    {

    }
}
