using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{
    [SerializeField] Button[] m_SaveStageBtn;
    // Start is called before the first frame update
    public void SetNextScene(int data)
    {
        SaveLoadManager.Instance.SetNextScene(data);
    }
    public void NextSceneStart()
    {
        SaveLoadManager.Instance.NextSceneStart();
    }
    public void SaveData()
    {
        for (int i = 0; i < 4; i++)
        {
            m_SaveStageBtn[i].interactable = false;
        }
        for (int i = 0; i <= (int)SaveLoadManager.Instance.GetSaveData(); i++)
        {
            m_SaveStageBtn[i].interactable = true;
        }
        SaveLoadManager.Instance.SettingSaveDatas();
    }
}
