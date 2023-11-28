using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BossWaitState", menuName = "ScriptableObject/FSM State/BossSpawnDamagePlane")]
public class BossSpawnDamagePlane : ScriptableObject, IState
{
	// Start is called before the first frame update
	public void Enter(Monster owner)
	{
		owner.GetComponent<HeartQueenBossMonster>().SpawnDamagePlane();
	}
	public void Excute(Monster owner)
	{

	}
	public void Exit(Monster owner)
	{

	}
}
