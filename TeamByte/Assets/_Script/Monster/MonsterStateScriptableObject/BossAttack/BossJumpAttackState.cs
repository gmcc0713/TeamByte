using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BossJumpState", menuName = "ScriptableObject/FSM State/BossJump", order = 3)]

public class BossJumpAttackState : ScriptableObject, IState
{

    public void Enter(Monster owner)
    {
        Debug.Log("BosssSjump");
        owner._animator.SetTrigger("IsJump");
        owner.GetComponent<BossMonster>().BossJumpShot();
    }
    public void Excute(Monster owner)
    {

    }
    public void Exit(Monster owner)
    {

    }
}
