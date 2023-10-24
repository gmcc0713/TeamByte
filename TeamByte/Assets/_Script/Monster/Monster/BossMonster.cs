using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class BossMonster : Monster
{
    // Start is called before the first frame update
    [SerializeField] private GameObject m_bullet;
    [SerializeField] private Vector3 m_spawnPos;
    [SerializeField] private Slider m_HPUI;
    private bool m_bIsAttacking = false;


    public override void Initialize()
    {
        base.Initialize();
        m_bIsAttacking = false;
        m_cFSM.ChangeState(m_cState.IdleState);
        transform.position = m_spawnPos;
        m_HPUI =GetComponentInChildren<Slider>();
    }
    public override void Idle()
    {
        m_bIsAttacking = false;
        if (!m_bIsAttacking)
        {
            Debug.Log("attack");
            StartCoroutine(AttackCoolDown());
        }
    }
    public override void Move()
    {
        //좌우로 움직임 처리
    }
    public void JumpAttack()
    {
        if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            CircleShot(10);

            m_cFSM.ChangeState(m_cState.IdleState);
            
        }


    }
    private IEnumerator ShotCircleBullets()
    {
        for (int i = 0; i < 3; i++)
        {
            float radius = 1f;
            Vector3 startPos = transform.position;
            for (int j = 0; j < 360; j += 360 / 10)      //0~360도 까지 각도 증가(생성할 총알 갯수만큼 나눠서 각도 설정)
            {
                Vector3 pos = startPos + new Vector3(Mathf.Cos(j * Mathf.Deg2Rad) * radius, Mathf.Sin(j * Mathf.Deg2Rad) * radius, 0);

                Vector2 normalVec = (m_target.transform.position - startPos).normalized;
                float z = Mathf.Atan2(normalVec.y, normalVec.x) * Mathf.Rad2Deg;
                Quaternion rot = Quaternion.Euler(0, 0, z);

                Instantiate(m_bullet, pos, rot);
            }
            m_bIsAttacking = true;
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator SectorShot()
    {
        for (int j = 0; j < 3; j++)
        {
            SectorFormShot(10, 90);
            yield return new WaitForSeconds(0.5f);
        }

    }
    public void ShootBulletCircle()  
    {
        ShotCircleBullets();
    }
    public void BossSectorShot()
    {
        StartCoroutine(SectorShot());
    }
    public void SectorFormShot(int count,float central)
    {
        Vector3 startPos = transform.position;
        Vector2 nor = (m_target.transform.position - startPos);
        float tarZ = Mathf.Atan2(nor.y, nor.x) * Mathf.Rad2Deg;

        float amount = central / (count - 1);
        float z = central / -2f + (int)tarZ;

        for (int i =0; i<count; i++)
        {
            Quaternion rot = Quaternion.Euler(0, 0, z);
            Instantiate(m_bullet, startPos, rot);
            z += amount;
        }
        m_bIsAttacking = true;
    }
    public override void GetDamage(int damage)
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
    void CircleShot(int count)
    {
        for (int i = 0; i < 360; i += 360 / count)      //0~360도 까지 각도 증가(생성할 총알 갯수만큼 나눠서 각도 설정)
        {

            Instantiate(m_bullet, transform.position, Quaternion.Euler(0,0,i));
        }
        m_bIsAttacking = true;
    }
    private IEnumerator AttackCoolDown()
    {
        Debug.Log("Wait 5sec");
        m_bIsAttacking = false;
        yield return new WaitForSeconds(1.0f);
        switch (RandomAttackType())
        {
            case 0:
                Debug.Log("0");
                m_cFSM.ChangeState(m_cState.BossCircleShotState);
                break;
            case 1:
                Debug.Log("2");
                m_cFSM.ChangeState(m_cState.BossSectorShotState);
                break;
            case 2:
                Debug.Log("1");
                m_cFSM.ChangeState(m_cState.BossJumpState);
                break;
        }
    }
    private int RandomAttackType()
    {
        int ran = Random.Range(0, 3);
        Debug.Log("rac" + ran);
        return ran;
    }
}
