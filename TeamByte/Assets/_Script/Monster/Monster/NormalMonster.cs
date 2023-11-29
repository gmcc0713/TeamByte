using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalMonster : Monster
{
    public override void Initialize()
    {
        base.Initialize();
        if(m_cFSM==null)
		    MonsterManager.Instance.MonsterInit(this.GetComponent<Monster>());
		m_cFSM.ChangeState(m_cState.MoveState);
       
    }
    private void OnEnable()
    {
        Initialize();
    }
    public override void Move()
    {
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
