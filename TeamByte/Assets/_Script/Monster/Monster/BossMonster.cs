using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : Monster
{
    // Start is called before the first frame update
    [SerializeField] private GameObject m_bullet;
    [SerializeField] private Vector3 m_spawnPos;
    private bool m_bIsAttacking;
    public override void Initialize()
    {
        base.Initialize();
        m_cFSM.ChangeState(m_cState.IdleState);
        transform.position = m_spawnPos;
        SectorFormShot(10,90);
    }
    public override void Move()
    {
        //谅快肺 框流烙 贸府
    }
    public void JumpAttack()
    {

    }
    public void ShootBulletCircle(int count)
    {
        float radius = 1f;
        Vector3 startPos = transform.position;
        for (int i =0;i<360;i+= 360/count)
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
        float amount = central / (count - 1);
        float z = central / -2f;
        Vector3 startPos = transform.position;
        for (int i =0; i<count; i++)
        {
            Quaternion rot = Quaternion.Euler(0, 0, z);
            Instantiate(m_bullet, startPos, rot);
            z += amount;
        }
        m_bIsAttacking = true;
    }
    private IEnumerator AttackAndCooldown()
    {

        yield return new WaitForSeconds(5.0f);

        m_bIsAttacking = false;
    }
}
