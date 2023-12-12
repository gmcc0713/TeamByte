using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Monster : MonoBehaviour
{
    [SerializeField] protected MonsterData m_sData;
    protected MonsterFSM m_cFSM;
    protected StateData m_cState;
    [SerializeField] protected GameObject m_target;
    protected Animator m_animator;
    public Animator _animator => m_animator;
    public GameObject _target => m_target;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] private bool m_bIsDie;

    public bool _IsDie => m_bIsDie;

    [SerializeField] protected int m_iHP;
    [SerializeField] protected int m_iMaxHP;
    [SerializeField] protected int m_iattackDamage;
    [SerializeField] protected GameObject m_activeObject;
    [SerializeField] protected bool m_activeGameObject;
	[SerializeField] public bool m_bCanDamaged;
	void Start()
    {
        Initialize();
    }
    public virtual void Initialize()
    {
        m_target = GameObject.Find("Player");
        m_iMaxHP = m_sData.m_iHP;
        m_iHP = m_iMaxHP;
        m_iattackDamage = m_sData.m_iAttackDamage;
        m_animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
		m_bIsDie = false;
	}
    public virtual void Idle() { }
    public virtual void Move() { }

    private IEnumerator OnUpdate()
    {
        while (true)
        {
            if (!m_cFSM)
            {
                m_cFSM.Update();
            }
            yield return new WaitForSeconds(0.04f);
        }
    }
    public bool SetData(StateData _data)            //제일 초기에 한번 데이터 세팅
    {
        m_cState = _data;
        if (null == m_cFSM)
        {
            m_cFSM = new MonsterFSM(this);
        }

        if (!m_cFSM.SetCurrState(m_cState.IdleState))
        {
            Debug.Log("stateData 가 null");
            return false;
        }
        gameObject.SetActive(true);

        StartCoroutine(OnUpdate());
        return true;

    }

    public void StartDie()
    {
        m_bIsDie = true;
        ActiveObjectByDie();

		StartCoroutine(Die());
    }
    IEnumerator Die()
    {
        m_animator.SetTrigger("IsDie");
        yield return new WaitForSeconds(0.7f);
        gameObject.SetActive(false);
    }

    public virtual void GetDamage(int damage)
    {

			m_iHP -= damage;
			if (m_iHP <= 0)
			{
				m_cFSM.ChangeState(m_cState.DieState);
				agent.isStopped = true;
				agent.velocity = Vector3.zero;
			}


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("attack");
        }
    }
    private void ActiveObjectByDie()
    {
        if(m_activeGameObject)
        {

            m_activeObject.SetActive(true);
        }
    }
}
