using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JockerBossMonster : BossMonster
{
	private int m_curPathIndex;
    private void Start()
    {
		Debug.Log("Start");
        Initialize();
    }
    public void MoveAttack()
	{
		StartCoroutine(BossWalk());
	}
	public void ShootBulletCircle()
	{
		StartCoroutine(SectorShotPattern());
	}
	public void BossSectorShot()
	{
		StartCoroutine(CircleShotPattern());
	}
	public void BossJumpShot()
	{
		StartCoroutine(JumpAttackPattern());
	}
	public IEnumerator JumpAttackPattern()
	{
		int count;
		yield return new WaitForSeconds(0.2f);
		for (int i = 0; i < 3; i++)
		{
			count = Random.Range(15, 25);
			CircleShot(count);
			yield return new WaitForSeconds(0.5f);
		}
		m_cFSM.ChangeState(m_cState.BossWaitState);
	}
	IEnumerator CircleShotPattern()
	{

		for (int j = 0; j < 10; j++)
		{
			ShotCircleBullets(10);
			yield return new WaitForSeconds(0.5f);
		}
		m_cFSM.ChangeState(m_cState.BossWaitState);
	}
	IEnumerator SectorShotPattern()
	{
		for (int j = 0; j < 5; j++)
		{
			SectorFormShot(10, 90);
			yield return new WaitForSeconds(0.5f);
		}
		m_cFSM.ChangeState(m_cState.BossWaitState);
	}
	IEnumerator BossWalkAndAttack()
	{
		for (int j = 0; j < 5; j++)
		{
			SectorFormShot(10, 90);
			yield return new WaitForSeconds(0.5f);
		}
		m_cFSM.ChangeState(m_cState.BossWaitState);
	}
	private IEnumerator BossWalk()
	{
		Vector2[] path = RandomPathGet();
		while (m_curPathIndex < path.Length)
		{
			Debug.Log("Walk " + m_curPathIndex);
			transform.position = Vector2.MoveTowards(transform.position, path[m_curPathIndex], 10 * Time.deltaTime);
			yield return new WaitForSeconds(0.001f);
			if (Vector2.Distance(transform.position, path[m_curPathIndex]) < 0.3f)
			{
				Debug.Log("Arrive");
				m_curPathIndex++;
			}
			Debug.Log("Arrive");
		}
		yield return null;
		_animator.SetBool("IsWalk", false);
		m_cFSM.ChangeState(m_cState.BossWaitState);


	}
	Vector2[] RandomPathGet()
	{
		Vector2[] path = new Vector2[6];
		int rand = 0;
		int previousRand = -1;
		for (int i = 0; i < 5;) // 조건부 확인에 문제가 있을 수 있습니다.
		{
			rand = Random.Range(0, m_aMovingRoot.Length);
			if (rand != previousRand)
			{
				path[i] = m_aMovingRoot[rand].transform.position;
				i++; // 이 부분을 수정하여 항상 i를 증가시킵니다.
			}
			previousRand = rand;
		}
		path[5] = m_aMovingRoot[0].transform.position;
		return path;
	}

	void CircleDelayShot(int count)
	{
		StartCoroutine(shotCor());

		IEnumerator shotCor()
		{
			for (int j = 0; j < 5; j++)
			{
				for (int i = 0; i < 360; i += 360 / count)
				{
					Instantiate(m_bullet, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, i));
					yield return new WaitForSeconds(0.1f);
				}
			}
			yield break;
		}

	}
	private void ShotCircleBullets(int count)
	{
		float radius = 1f;
		Vector3 startPos = transform.position;
		for (int j = 0; j < 360; j += 360 / count)      //0~360도 까지 각도 증가(생성할 총알 갯수만큼 나눠서 각도 설정)
		{
			Vector3 pos = startPos + new Vector3(Mathf.Cos(j * Mathf.Deg2Rad) * radius, Mathf.Sin(j * Mathf.Deg2Rad) * radius, 0);

			Vector2 normalVec = (m_target.transform.position - startPos).normalized;
			float z = Mathf.Atan2(normalVec.y, normalVec.x) * Mathf.Rad2Deg;
			Quaternion rot = Quaternion.Euler(0, 0, z);

			Instantiate(m_bullet, pos, rot);
		}
		m_bIsAttacking = true;
	}
	public void SectorFormShot(int count, float central)
	{
		Vector3 startPos = transform.position;
		Vector2 nor = (m_target.transform.position - startPos);
		float tarZ = Mathf.Atan2(nor.y, nor.x) * Mathf.Rad2Deg;

		float amount = central / (count - 1);
		float z = central / -2f + (int)tarZ;

		for (int i = 0; i < count; i++)
		{
			Quaternion rot = Quaternion.Euler(0, 0, z);
			Instantiate(m_bullet, startPos, rot);
			z += amount;
		}
		m_bIsAttacking = true;
	}
	void CircleShot(int count)
	{

		for (int i = 0; i < 360; i += 360 / count)      //0~360도 까지 각도 증가(생성할 총알 갯수만큼 나눠서 각도 설정)
		{
			Instantiate(m_bullet, transform.position, Quaternion.Euler(0, 0, i));
		}
		m_bIsAttacking = true;
	}

	protected override void ChangeStateBossPattern(int idx) 
	{
		switch (idx)
		{
			case 0:
				Debug.Log("Change Circle");
				m_cFSM.ChangeState(m_cState.BossCircleShotState);
				break;
			case 1:
				Debug.Log("Change Sector");
				m_cFSM.ChangeState(m_cState.BossSectorShotState);
				break;
			case 2:
				Debug.Log("Change Jump");
				m_cFSM.ChangeState(m_cState.BossJumpState);
				break;
			case 3:
				Debug.Log("Change Walk");
				m_cFSM.ChangeState(m_cState.BossDashAttack);
				break;
		}
	}
}
