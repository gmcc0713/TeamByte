using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class NextStage : MonoBehaviour
{
    public int currentScene; // Scene �̸� ����
    public GameObject Player;
    public GameObject SummonPositionLeft;
    public GameObject SummonPositionRight;

    public void Start()
    {
        
    }

    // �浹 �߻� �� ȣ��� �Լ�
    void OnTriggerEnter2D(Collider2D collision)
    {


		if (collision.gameObject.CompareTag("Player"))
        {
          /*  if(currentScene == (int)Save_Data.Stage_4_1)

			SaveLoadManager.Instance.SetNextScene(currentScene + 1);
			SaveLoadManager.Instance.NextSceneStart();
			if (currentScene == "Stage4-1")
            {
                if(this.gameObject.name == "LastBossPortal")
                {
                    SceneManager.LoadScene("Stage4-3");
                }
                else
                {
                    SceneManager.LoadScene("Stage4-2");
                }
                    
            }

            if (currentScene == "Stage4-2")
            {
                Debug.Log("���� 4-2 stage");
                if (this.gameObject.name == "OtherRoomLeft")
                {
                    Player.transform.position = SummonPositionRight.transform.position;
                    Debug.Log("���� �� �浹");
                }
                    
                if (this.gameObject.name == "OtherRoomRight")
                {
                    Player.transform.position = SummonPositionLeft.transform.position;
                    Debug.Log("������ �� �浹");
                }

                if (this.gameObject.name == "To4-1Portal")
                {
                    SceneManager.LoadScene("Stage4-1");
                    Debug.Log("4-1 ���ư�");
                    PlayerPosition position = new PlayerPosition();
                    SceneData.stage4Position = true;
                }

            }

            if (currentScene == "Stage4-3")
                SceneManager.LoadScene("EndingScene");



        }*/
    }
}
