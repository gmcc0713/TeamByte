using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public TextMeshProUGUI talkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;
    public GameObject activeImageUI;
    public Image nameImage;
    public Sprite[] imageSprite;
    

    public void Action(GameObject scanObj)
    {
        Debug.Log(scanObject);
        isAction = true;
        scanObject = scanObj;
        Debug.Log(scanObject.GetComponent<ObjData>());
        ObjData objData = scanObject.GetComponent<ObjData>();
        Debug.Log(objData);
        Talk(objData.id, objData.isNPC);
        Debug.Log(objData.id);
        Debug.Log(objData.isNPC);


        if (objData.id >= 501 && objData.id <= 510)
            scanObj.transform.Find("Image").gameObject.SetActive(false);

        if (objData.id >= 511 && objData.id <= 518)
            scanObj.transform.Find("PotionImage").gameObject.SetActive(false);


        talkPanel.SetActive(isAction);

        // 독백 : 1~499
        if (objData.id >= 1 && objData.id <= 499)
            nameImage.sprite = imageSprite[0];

        // 표지판(요정) : 1000~1199 
        if (objData.id >= 1000 && objData.id <= 1199)
            nameImage.sprite = imageSprite[1];

        // 앨리스 : 1200~1499
        if (objData.id >= 1200 && objData.id <= 1499)
            nameImage.sprite = imageSprite[2];

        if ((objData.id >= 500 && objData.id <= 999) || objData.id >=1500 || objData.id == 0)
        {
            activeImageUI.SetActive(!isAction);
            return;
        }

        activeImageUI.SetActive(isAction);
   

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