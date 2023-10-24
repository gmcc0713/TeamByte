using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterFSM : MonoBehaviour
{
    Monster owner;
    IState currState;
    MonsterFSM() { }
    public MonsterFSM(Monster owner)
    {
        this.owner = owner;
    }
    public void Update()
    {
        currState.Excute(owner);
    }
    public bool SetCurrState(IState state)
    {
        if (null == state) return false;
        currState = state;
        return true;
    }
    public bool ChangeState(IState state)
    {

        if (null == state) return false;
        currState.Exit(owner);
        currState = state;
        currState.Enter(owner);
        return true;
    }
}
