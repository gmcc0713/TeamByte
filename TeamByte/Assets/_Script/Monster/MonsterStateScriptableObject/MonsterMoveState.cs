using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Move State", menuName = "ScriptableObject/FSM State/Move", order = 2)]
public class MonsterMoveState : ScriptableObject, IState
{
    public void Enter(Monster owner)
    {
        Debug.Log("Move State Enter");
    }
    public void Excute(Monster owner)
    {
        owner.Move();
    }
    public void Exit(Monster owner)
    {

    }
}

