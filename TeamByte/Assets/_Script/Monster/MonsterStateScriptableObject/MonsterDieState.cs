using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Die State", menuName = "ScriptableObject/FSM State/Die", order = 3)]
public class MonsterDieState : ScriptableObject, IState
{
    public void Enter(Monster owner)
    {
        owner.StartDie();
    }
    public void Excute(Monster owner)
    {
        
        
    }
    public void Exit(Monster owner)
    {

    }
}
