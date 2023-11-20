using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BossCircleShot", menuName = "ScriptableObject/FSM State/BossCircleShot", order = 3)]

public class BossCircleShot : ScriptableObject, IState
{

    public void Enter(Monster owner)
    {
        
        owner.GetComponent<JockerBossMonster>().ShootBulletCircle();
    }
    public void Excute(Monster owner)
    {
    }
    public void Exit(Monster owner)
    {

    }
}
