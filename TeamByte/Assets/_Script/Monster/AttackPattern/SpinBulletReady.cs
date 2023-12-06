using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpinBulletReady : MonoBehaviour
{
	[SerializeField] private GameObject m_gWarning;
    [SerializeField] private GameObject m_gObstaccle;
	void Start()
    {
		SpriteRenderer waringPatternRenderer = m_gWarning.GetComponent<SpriteRenderer>();
		for (int i = 0; i < 20; i++)
		{
				waringPatternRenderer.color = new Color(1, 0, 0, 0.05f * i);
		}
		m_gObstaccle.SetActive(true);
		waringPatternRenderer.color = new Color(1, 0, 0, 0);
	}

	public void AddSpeed(float add)
	{
		m_gObstaccle.GetComponent<SpinSquareBullet>().AddSpeed(add);
	}
}
