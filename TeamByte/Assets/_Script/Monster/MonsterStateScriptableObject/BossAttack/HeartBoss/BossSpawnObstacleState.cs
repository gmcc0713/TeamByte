using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossWaitState", menuName = "ScriptableObject/FSM State/BossSpawnObstacle", order = 3)]

public class BossSpawnObstacleState : ScriptableObject, IState
{

	public void Enter(Monster owner)
	{

		owner.GetComponent<HeartQueenBossMonster>().SpawnObstacle();
	}
	public void Excute(Monster owner)
	{
	}
	public void Exit(Monster owner)
	{

	}
}
