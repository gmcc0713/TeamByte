using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BossSectorShot", menuName = "ScriptableObject/FSM State/BossSectorShot", order = 3)]

public class BossSectorShot : ScriptableObject, IState
{

    public void Enter(Monster owner)
    {
        
        owner.GetComponent<JockerBossMonster>().BossSectorShot();
    }
    public void Excute(Monster owner)
    {
    }
    public void Exit(Monster owner)
    {

    }
}
