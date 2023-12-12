using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class BossMonster : Monster
{

    // Start is called before the first frame update
    [SerializeField] protected GameObject m_bullet;
    [SerializeField] protected Slider m_HPUI;
    [SerializeField] protected GameObject[] m_aMovingRoot;
	protected bool m_bIsAttacking = false;
	protected int m_iPriviousAttackType;
    [SerializeField] protected int m_ipatternCount;

    public override void Initialize()
    {
        base.Initialize();
        m_bIsAttacking = false;
        m_cFSM.ChangeState(m_cState.IdleState);
        m_HPUI =GetComponentInChildren<Slider>();
        m_aMovingRoot = BossManager.Instance.GetMovingRoot();
		m_target = GameObject.Find("Player");
		m_ipatternCount = 4;
    }
    public override void Idle()
    {
        m_bIsAttacking = false;
        if (!m_bIsAttacking)
        {
            StartCoroutine(AttackCoolDown());
        }
    }
    public override void GetDamage(int damage)
    {

		if (m_bCanDamaged)
		{
			m_iHP -= damage;

			if (m_iHP <= 0)
			{
				m_cFSM.ChangeState(m_cState.DieState);
				agent.isStopped = true;
				agent.velocity = Vector3.zero;
			}

			m_HPUI.value = (float)m_iHP / m_iMaxHP;
		}

		
    }
    public void StartAttackCoolTime()
    {
        StartCoroutine(AttackCoolDown());
    }
    protected virtual void ChangeStateBossPattern(int idx) { }
	public IEnumerator AttackCoolDown()
    {
        Debug.Log("Wait 3sec");
        m_bIsAttacking = false;
        yield return new WaitForSeconds(3.0f);
        int t = RandomAttackType();
		Debug.Log("Wait 5sec");
		ChangeStateBossPattern(t);
    }
	public int RandomAttackType()
    {
        int ran = Random.Range(0, m_ipatternCount);
        if(m_iPriviousAttackType == ran)
            ran = Random.Range(0, m_ipatternCount);
        m_iPriviousAttackType = ran;
        Debug.Log(ran);
        return ran;
    }
}
