using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossWaitState", menuName = "ScriptableObject/FSM State/BossSpinSquare", order = 3)]
public class BossSpinSquareState : ScriptableObject, IState
{
    // Start is called before the first frame update
    public void Enter(Monster owner)
    {
        owner.GetComponent<HeartQueenBossMonster>().StartSpin();
    }
    public void Excute(Monster owner)
    {
        owner.GetComponent<HeartQueenBossMonster>().SpinSqureUpdate();
    }
    public void Exit(Monster owner)
    {

    }
}
