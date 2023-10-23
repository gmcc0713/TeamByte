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
    private bool m_bIsAttacking;


    public override void Initialize()
    {
        base.Initialize();
        
        m_cFSM.ChangeState(m_cState.IdleState);
        transform.position = m_spawnPos;
        m_HPUI =GetComponentInChildren<Slider>();

        StartCoroutine(AttackAndCooldown());
        //ShootBulletCircle(10);
        SectorFormShot(10,90);
    }
    public override void Move()
    {
        //좌우로 움직임 처리
    }
    public void JumpAttack()
    {

    }
    
    public void ShootBulletCircle(int count)    // 방향 오류 확인필요
    {
        float radius = 1f;
        Vector3 startPos = transform.position;
        for (int i =0;i<360;i+= 360/count)      //0~360도 까지 각도 증가(생성할 총알 갯수만큼 나눠서 각도 설정)
        {
            Vector3 pos = startPos + new Vector3(Mathf.Cos(i * Mathf.Deg2Rad) * radius, Mathf.Sin(i * Mathf.Deg2Rad) * radius, 0);

            Vector2 normalVec = (m_target.transform.position - startPos).normalized;
            float z = Mathf.Atan2(normalVec.y, normalVec.x) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, 0, z);

            Instantiate(m_bullet, pos, rot);
        }
        m_bIsAttacking = true;
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
    void SectorFromDelayShot(int bulletCount,int cventral,int rotate,int rotateCount,int entireCount)
    {
        StartCoroutine(ShotRoutine());
        IEnumerator ShotRoutine()
        {
            m_bIsAttacking = false;

            float z = -rotate;
            float amount = (rotate * 2f) / rotateCount;

            yield break;
        }
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
    private IEnumerator AttackAndCooldown()
    {

        yield return new WaitForSeconds(5.0f);
        m_bIsAttacking = false;
    }
}
