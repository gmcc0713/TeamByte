using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartQueenBossMonster : BossMonster
{
	[SerializeField] BossMonsterSpawnPattern spawnPattern;
	[SerializeField] GameObject spinSquare;
	[SerializeField] GameObject damagePlane;
	[SerializeField] GameObject enemyObstacle;
	[SerializeField] GameObject m_gWarning;
	[SerializeField] GameObject[] enemySpawnPoints;

	private void Start()
	{
        Initialize();
        enemySpawnPoints = BossManager.Instance.GetSpawnPoints();
		m_ipatternCount = 4;
		MonsterManager.Instance.AddBossMon(this);
	}
	public void SpawnMonster()
	{

		StartCoroutine(WaitSpawnMonster(1.0f));
        m_cFSM.ChangeState(m_cState.BossWaitState);
    }
    public IEnumerator WaitSpawnMonster(float time)
	{
        foreach (var point in enemySpawnPoints)
		{
			Debug.Log("스폰포인트" + point);
            point.SetActive(true);
        }
        yield return new WaitForSeconds(time);
        foreach (var point in enemySpawnPoints)
		{
            point.SetActive(false);
        }
	}

    public void SpawnObstacle()
	{
		Debug.Log("장애물 소환");
		GameObject clone = Instantiate(enemyObstacle);
		clone.transform.position = m_target.transform.position;
		m_cFSM.ChangeState(m_cState.BossWaitState);
    }
	public IEnumerator SpawnDamagePlanes(int a)
	{
		for(int i =0;i<a;i++)
		{
			yield return new WaitForSeconds(1.0f);
			SpawnDamagePlane();
		}
		m_cFSM.ChangeState(m_cState.BossWaitState);
	}
	public void SpawnDamagePlaneState()
	{
		StartCoroutine(SpawnDamagePlanes(3));
	}
	public void SpawnDamagePlane()
	{
		Debug.Log("장애물 소환");
		GameObject clone = Instantiate(damagePlane);
		clone.transform.position = m_target.transform.position;
	}
	public IEnumerator WarningSpin()
	{
		int rand = Random.RandomRange(0,180);
		m_gWarning.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rand));
		SpriteRenderer waringPatternRenderer = m_gWarning.GetComponent<SpriteRenderer>();
		for (int i = 0; i < 20; i++)
		{
			waringPatternRenderer.color = new Color(1, 0, 0, 0.05f * i);
			yield return new WaitForSeconds(0.1f);
		}
		waringPatternRenderer.color = new Color(1, 0, 0, 0);
		Debug.Log("Spin");
		spinSquare.SetActive(true);
		spinSquare.GetComponent<SpinSquareBullet>().SetRotateStartPoint(rand);
		StartCoroutine(TimerCheck(10.0f));
	}
	public void StartSpin()
	{
		m_gWarning.SetActive(true);
		StartCoroutine(WarningSpin());
    }
	public IEnumerator TimerCheck(float time)
	{
        Debug.Log("TimeCheck");
        yield return new WaitForSeconds(time);
		spinSquare.GetComponent<SpinSquareBullet>().ResetSpeed();
        spinSquare.SetActive(false);
        m_cFSM.ChangeState(m_cState.BossWaitState);
	}
	public void SpinSqureUpdate()
	{
		if(spinSquare.activeSelf)
		{
			spinSquare.GetComponent<SpinSquareBullet>().AddSpeed(0.1f);
		}
	}
	protected override void ChangeStateBossPattern(int idx)
	{
		switch (idx)
		{
			case 0:
				Debug.Log("Change Spawn Obstacle");
                m_cFSM.ChangeState(m_cState.BossSpawnObstacle);
                break;
			case 1:
				Debug.Log("Change Spin Square");
				m_cFSM.ChangeState(m_cState.BossSpinSquare);
				break;
			case 2:
				Debug.Log("Change Spawn DamagePlane");
				m_cFSM.ChangeState(m_cState.BossSpawnDamagePlane);
				break;
			case 3:
				Debug.Log("Change Spin Square1");
				m_cFSM.ChangeState(m_cState.BossSpawnMonster);
				break;
		}
	}
	public void canDamaged() 
	{ 
		m_bCanDamaged = true; 
	}
}
