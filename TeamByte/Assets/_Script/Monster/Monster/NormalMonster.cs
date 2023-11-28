using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalMonster : Monster
{
    public override void Initialize()
    {
        base.Initialize();
        Debug.Log(m_cState);
        Debug.Log(m_cFSM);
        m_cFSM.ChangeState(m_cState.MoveState);
       
    }
    private void OnEnable()
    {
        Initialize();
    }
    public override void Move()
    {
        Debug.Log("M" + transform.position);
        if (!m_target)
        {
            return;
        }
        agent.SetDestination(m_target.transform.position);
        if (transform.position.x > m_target.transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
