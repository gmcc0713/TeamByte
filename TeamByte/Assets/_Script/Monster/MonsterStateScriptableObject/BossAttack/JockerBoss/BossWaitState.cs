using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "BossWaitState", menuName = "ScriptableObject/FSM State/BossWait", order = 3)]

public class BossWaitState : ScriptableObject, IState
{

    public void Enter(Monster owner)
    {
        owner.GetComponent<BossMonster>().StartAttackCoolTime();
    }
    public void Excute(Monster owner)
    {
    }
    public void Exit(Monster owner)
    {

    }
}
