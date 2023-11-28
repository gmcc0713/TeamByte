using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance { get; private set; }
    [SerializeField] private List<Monster> m_lMonsterList;
    void Awake()
    {
        if (null == Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);


    }
    public void MonsterInit(Monster monster)
    {
        //Monster
        IState idle = (IState)Resources.Load("ScriptableObject/MonsterState/IdleState");
        IState move = (IState)Resources.Load("ScriptableObject/MonsterState/MoveState");
        IState attack = (IState)Resources.Load("ScriptableObject/MonsterState/AttackState");
        IState die = (IState)Resources.Load("ScriptableObject/MonsterState/DieState");
        //jocker Boss
        IState bossJumpAttack = (IState)Resources.Load("ScriptableObject/MonsterState/Boss/Jocker/BossJumpState");
        IState bossCircleShot = (IState)Resources.Load("ScriptableObject/MonsterState/Boss/Jocker/BossCircleShot");
        IState bossSectorShot = (IState)Resources.Load("ScriptableObject/MonsterState/Boss/Jocker/BossSectorShot");
        IState bossWait = (IState)Resources.Load("ScriptableObject/MonsterState/Boss/Jocker/BossWaitState");
        IState bossDashAttack = (IState)Resources.Load("ScriptableObject/MonsterState/Boss/Jocker/BossDashAttack");
        //HeartQueen Boss
        IState bossSpawnObstacle = (IState)Resources.Load("ScriptableObject/MonsterState/Boss/HeartQueen/BossSpawnObstacle");
        IState bossSpinSquare = (IState)Resources.Load("ScriptableObject/MonsterState/Boss/HeartQueen/BossSpinSquareState");
        IState bossSpawnDamagePlane = (IState)Resources.Load("ScriptableObject/MonsterState/Boss/HeartQueen/BossSpawnDamagePlane");
        StateData data = ScriptableObject.CreateInstance<StateData>();
        data.SetData(idle, move, attack, die, bossJumpAttack, bossCircleShot, bossSectorShot,bossWait, bossDashAttack, bossSpawnObstacle, bossSpinSquare, bossSpawnDamagePlane);
        monster.SetData(data);
    }
}
