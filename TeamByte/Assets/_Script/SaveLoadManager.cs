using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[Serializable]
public enum Save_Data
{
	Tutorial = -1,
    Stage_1 = 0,
    Stage_2,
    Stage_3,
    Stage_4_1,
    Stage_4_2,
    Stage_4_3,
	Count,
}
public class SaveLoadManager : MonoBehaviour
{
	public static SaveLoadManager Instance { get; private set; }
	void Awake()
	{
		if (null == Instance)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
			return;
		}
		Destroy(gameObject);
	}

	[SerializeField] Save_Data m_eSaveData; //1,2,3,4-1,4-2,4-3
	[SerializeField] Button[] m_SaveStageBtn;
	Save_Data m_eNextScene;
	bool m_bIsFirst;
	public void NextSceneStart()
	{
		SceneManager.LoadScene("LoadingScene");
	}
    void Start()
    {
		m_eSaveData = Save_Data.Stage_1;
		m_bIsFirst = true;
		m_eNextScene = Save_Data.Tutorial;
	}

	public Save_Data GetNextSceneData()
	{
		return m_eNextScene;
	}
	public void SetNextScene(int data)
	{
		m_eNextScene =(Save_Data)data;
	}
	public void SettingSaveDatas()
	{

		for (int i = 0; i < (int)Save_Data.Count; i++)
		{
			m_SaveStageBtn[i].interactable = false;
		}
		Debug.Log((int)m_eSaveData);
		for (int i =0;i<= (int)m_eSaveData; i++)
		{
			m_SaveStageBtn[i].interactable = true;
		}

	}
}
