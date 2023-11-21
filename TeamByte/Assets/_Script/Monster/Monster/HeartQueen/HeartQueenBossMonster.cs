using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartQueenBossMonster : BossMonster
{
	[SerializeField] GameObject warningPattern;
	[SerializeField] RandomSpawner randomSpawner;
	[SerializeField] GameObject spinSquare;

	private void Start()
	{
        Initialize();
	}

	public void BossSpawnObstacle()
	{
		StartCoroutine(WarningLineSpawn(randomSpawner.ReturnRandomPosition()));
	}
	public void SpawnObstacle()
	{
		Debug.Log("장애물 소환");
        m_cFSM.ChangeState(m_cState.BossWaitState);
    }
	public void StartSpin()
	{
		Debug.Log("Spin");
        spinSquare.SetActive(true);
		StartCoroutine(TimerCheck(10.0f));
    }
	public IEnumerator TimerCheck(float time)
	{
        Debug.Log("TimeCheck");
        yield return new WaitForSeconds(time);
		Debug.Log("End");
		spinSquare.GetComponent<SpinSquareBullet>().ResetSpeed();
        spinSquare.SetActive(false);
        m_cFSM.ChangeState(m_cState.BossWaitState);
	}
	public void SpinSqureUpdate()
	{
        spinSquare.GetComponent<SpinSquareBullet>().AddSpeed(0.3f);
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
		Debug.Log(idx);
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
		}
	}
}
