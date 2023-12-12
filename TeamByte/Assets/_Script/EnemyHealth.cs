using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public void GetDamage()
	{
		this.gameObject.SetActive(false);
		BossHealthManager.Instance.HealthCountUP();
	}
}
