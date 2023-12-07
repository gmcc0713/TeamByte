using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public Image nameImage;
    public TextMeshProUGUI talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;


    public void Action(GameObject scanObj)
    {
        isAction = true;
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNPC);

        if (objData.id >= 501 && objData.id <= 508)
            scanObj.transform.Find("PotionImage").gameObject.SetActive(false);



        talkPanel.SetActive(isAction);

    }

    public void CutSceneAction(int id)
    {
        isAction = true;
        Talk(id, true);
        talkPanel.SetActive(isAction);
    }

    public void Talk(int id, bool isNPC)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }
        if (isNPC)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }


        isAction = true;
        talkIndex++;
    }
}