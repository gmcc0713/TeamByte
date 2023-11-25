using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public interface IState
{
    public void Enter(Monster owner);
    public void Excute(Monster owner);
    public void Exit(Monster owner);
}
public class StateData : ScriptableObject
{
    //NormalMonster
    public IState IdleState { get; private set; }
    public IState MoveState { get; private set; }
    public IState AttackState { get; private set; }
    public IState DieState { get; private set; }
    //JockerBoss
    public IState BossJumpState { get; private set; }
    public IState BossCircleShotState { get; private set; }
    public IState BossSectorShotState { get; private set; }
    public IState BossWaitState { get; private set; }
    public IState BossDashAttack { get; private set; }
    //HeartQueenBoss
    
    public IState BossSpawnObstacle { get; private set; }
    public IState BossSpinSquare { get; private set; }
    public IState BossSpawnDamagePlane { get; private set; }

    public void SetData(IState idle, IState move, IState attack, IState die, 
                        IState bossJump, IState bossCircleShot, IState bossSectorShot,IState bossWait, IState bossDash,
                        IState bossSpawnObstacle, IState bossSpinSqure,IState bossDamagePlane)
    {
        IdleState = idle;
        MoveState = move;
        AttackState = attack;
        DieState = die;
        BossJumpState = bossCircleShot;
        BossCircleShotState = bossJump;
        BossSectorShotState = bossSectorShot;
        BossWaitState = bossWait;
        BossDashAttack = bossDash;
        BossSpawnObstacle = bossSpawnObstacle;
        BossSpinSquare = bossSpinSqure;
        BossSpawnDamagePlane = bossDamagePlane;

	}

}
