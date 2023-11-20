using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartQueenBossMonster : BossMonster
{
	[SerializeField] GameObject warningPattern;
	[SerializeField] RandomSpawner randomSpawner;

	private void Start()
	{
		BossSpawnObstacle();
	}
	public void BossSpawnObstacle()
	{
		StartCoroutine(WarningLineSpawn(randomSpawner.ReturnRandomPosition()));
	}
	public void SpawnObstacle()
	{
		Debug.Log("장애물 소환");
	}
	public IEnumerator WarningLineSpawn(Vector3 spawnPos)
	{
		warningPattern.transform.position = spawnPos;
		SpriteRenderer waringPatternRenderer = warningPattern.GetComponent<SpriteRenderer>();
		for (int i =0;i<10; i++)
		{
			waringPatternRenderer.color = new Color(1,0,0,0.1f*i);
			yield return new WaitForSeconds(0.1f);
		}
		SpawnObstacle();
	}
	
	protected override void ChangeStateBossPattern(int idx)
	{
		switch (idx)
		{
			case 0:
				Debug.Log("Change Spawn Obstacle");
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
