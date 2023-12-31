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
    Stage_4_1_1,
    Stage_4_3,
	Stage_EndingScene,
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
	[SerializeField] public Button[] m_SaveStageBtn;
    [SerializeField] Save_Data m_eNextScene;
	public bool m_bIsFirst;
	public int health = 3; 
	public bool _bIsFirst => m_bIsFirst;
	public void NextSceneStart()
	{
        SceneManager.LoadScene("LoadingScene");
	}
    void Start()
    {
		m_eSaveData = Save_Data.Tutorial;
		m_bIsFirst = true;
		m_eNextScene = Save_Data.Tutorial;

    }

	public Save_Data GetNextSceneData()
	{
		Debug.Log(m_eNextScene);
		return m_eNextScene;
	}
    public Save_Data GetSaveData()
    {
        return m_eSaveData;
    }
    public void SetNextScene(int data)
	{
		m_eNextScene =(Save_Data)data;
	}
    public void SetSaveData(int i)
    {
        m_eSaveData = (Save_Data)i;
    }
    public void SettingSaveDatas()
	{
		if (m_bIsFirst)
		{
			m_eNextScene = Save_Data.Tutorial;
			Debug.Log(m_eNextScene);
			NextSceneStart();
			m_bIsFirst = false;
            return;
		}
		for (int i = 0; i < 4; i++)
		{
			m_SaveStageBtn[i].interactable = false;
		}
		for (int i =0;i<= (int)m_eSaveData; i++)
		{
			m_SaveStageBtn[i].interactable = true;
		}

	}
	public void btnset()
	{

	}
}
