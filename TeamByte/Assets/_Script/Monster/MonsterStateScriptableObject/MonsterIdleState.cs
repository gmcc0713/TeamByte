using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle State", menuName = "ScriptableObject/FSM State/Idle", order = 4)]
public class MonsterIdleState : ScriptableObject, IState
{
    public void Enter(Monster owner)
    {
        owner.Idle();
    }
    public void Excute(Monster owner)
    {
        owner.Idle();
    }
    public void Exit(Monster owner)
    {

    }

}
