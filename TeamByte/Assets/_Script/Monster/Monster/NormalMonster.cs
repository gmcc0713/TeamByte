using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalMonster : Monster
{

    public override void Initialize()
    {
        base.Initialize();
        m_cFSM.ChangeState(m_cState.MoveState);

    }
    public override void Move()
    {
        if(!m_target)
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
