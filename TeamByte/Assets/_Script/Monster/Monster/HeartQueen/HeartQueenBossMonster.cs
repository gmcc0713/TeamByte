using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartQueenBossMonster : BossMonster
{
	[SerializeField] RandomSpawner randomSpawner;
	[SerializeField] GameObject spinSquare;
	[SerializeField] GameObject damagePlane;

	private void Start()
	{
        Initialize();
	}

	public void SpawnObstacle()
	{
		Debug.Log("장애물 소환");
		Instantiate(damagePlane,m_target.transform);
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
