using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
	[SerializeField]BoxCollider2D rangeCollider;
	private void Start()
	{
		rangeCollider = GetComponent<BoxCollider2D>();
	}
	// Start is called before the first frame update
	public Vector3 ReturnRandomPosition()
	{
		Vector3 originPosition = transform.position;
		// 콜라이더의 사이즈를 가져오는 bound.size 사용
		Debug.Log(rangeCollider);
		float range_X = rangeCollider.bounds.size.x;
		float range_Z = rangeCollider.bounds.size.z;

		range_X = Random.Range((range_X / 2) * -1, range_X / 2);
		range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
		Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

		Vector3 respawnPosition = originPosition + RandomPostion;
		return respawnPosition;
	}
}
