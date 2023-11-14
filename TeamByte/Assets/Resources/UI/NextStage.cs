using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class NextStage : MonoBehaviour
{
    public string currentScene; // Scene �̸� ����
    public GameObject Player;
    public GameObject SummonPositionLeft;
    public GameObject SummonPositionRight;

    public void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(currentScene);
    }

    // �浹 �߻� �� ȣ��� �Լ�
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("�浹");
            string currentScene = transform.parent.name;
            if (currentScene == "Tutorial")
                SceneManager.LoadScene("Stage1");
            if (currentScene == "Stage1")
                SceneManager.LoadScene("Stage2");
            if (currentScene == "Stage2")
                SceneManager.LoadScene("Stage3");
            if (currentScene == "Stage3")
                SceneManager.LoadScene("Stage4-1");
            if (currentScene == "Stage4-1")
                SceneManager.LoadScene("Stage4-2");
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




        }
    }
}
