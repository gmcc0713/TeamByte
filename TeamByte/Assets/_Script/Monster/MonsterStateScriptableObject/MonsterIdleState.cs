using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle State", menuName = "ScriptableObject/FSM State/Idle", order = 4)]
public class MonsterIdleState : ScriptableObject, IState
{
    public void Enter(Monster owner)
    {
        Debug.Log("BossIdle");
        owner.Idle();
    }
    public void Excute(Monster owner)
    {
    }
    public void Exit(Monster owner)
    {

    }

}
