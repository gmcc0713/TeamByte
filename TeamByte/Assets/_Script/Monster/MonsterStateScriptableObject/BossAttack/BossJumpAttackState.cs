using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BossJumpState", menuName = "ScriptableObject/FSM State/BossJump", order = 3)]

public class BossJumpAttackState : ScriptableObject, IState
{

    public void Enter(Monster owner)
    {
        owner._animator.SetTrigger("JumpAttack");
    }
    public void Excute(Monster owner)
    {
        owner.GetComponent<BossMonster>().JumpAttack();
    }
    public void Exit(Monster owner)
    {

    }
}
