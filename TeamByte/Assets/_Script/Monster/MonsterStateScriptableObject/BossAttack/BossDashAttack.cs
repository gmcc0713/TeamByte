using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BossDashAttack", menuName = "ScriptableObject/FSM State/BossDashAttack", order = 3)]
public class BossDashAttack : ScriptableObject, IState
{
    public void Enter(Monster owner)
    {
        owner._animator.SetTrigger("IsWalk");
        owner.GetComponent<BossMonster>().MoveAttack();
    }
    public void Excute(Monster owner)
    {
    }
    public void Exit(Monster owner)
    {

    }
}
