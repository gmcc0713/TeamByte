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
        IState idle = (IState)Resources.Load("ScriptableObject/MonsterState/IdleState");
        IState move = (IState)Resources.Load("ScriptableObject/MonsterState/MoveState");
        IState attack = (IState)Resources.Load("ScriptableObject/MonsterState/AttackState");
        IState die = (IState)Resources.Load("ScriptableObject/MonsterState/DieState");

        IState bossJumpAttack = (IState)Resources.Load("ScriptableObject/MonsterState/Boss/BossJumpState");
        IState bossCircleShot = (IState)Resources.Load("ScriptableObject/MonsterState/Boss/BossCircleShot");
        IState bossSectorShot = (IState)Resources.Load("ScriptableObject/MonsterState/Boss/BossSectorShot");
        IState bossWait = (IState)Resources.Load("ScriptableObject/MonsterState/Boss/BossWaitState");
        StateData data = ScriptableObject.CreateInstance<StateData>();
        data.SetData(idle, move, attack, die, bossJumpAttack, bossCircleShot, bossSectorShot,bossWait);
        monster.SetData(data);
    }
}
