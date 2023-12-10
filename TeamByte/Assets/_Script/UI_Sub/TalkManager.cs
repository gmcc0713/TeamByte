using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    public GameManager gameManager;
    public Sprite[] nameimageArr;
    public Sprite[] cutSceneimageArr;
    public string currentScene;
    public GameObject cutSceneObject;//Destory

    private PotionFind potionTalk;
    public GameObject potionObject;

    private ClockFind clockTalk;
    public GameObject clockObject;

    //public GameObject[] nameImage;
    
    public GameObject ActiveUI;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
        talkData = new Dictionary<int, string[]>();
        GenerateData();

        if(potionObject != null)
        {
            potionTalk = potionObject.GetComponent<PotionFind>();
            Debug.Log("potion");
        }
            
        if (clockObject != null)
        {
            clockTalk = clockObject.GetComponent<ClockFind>();
            Debug.Log("clock");
        }


        if (potionTalk == null && clockTalk == null)
            return;
    }

    private void Start()
    {
        StartCoroutine(CutSceneTalk());

    }

    void GenerateData()
    {
        // id : 1500~1699 = �̹��� ����


        // id : 0~499 = ����, �ƾ��� ��ȭ
        // id : 500~999 = �Ϲ� ��ȭ ������Ʈ
        // id : 1000~1199 = ǥ���� �� ���� ��ȭ ������Ʈ
        // id : 1200~1499 = �ٸ��� �� ���� ��ȭ ������Ʈ


        //Tutorial Scene

        // id = 0 : ����
        talkData.Add(0, new string[] { "������ �⺻���� ���� ����� �˷��帮�ڽ��ϴ�!",
            "��ȣ�ۿ� ��ư : Space Bar, ���� �ý��� ���� : F ",
            "���� �̵� : W, �Ʒ��� �̵� S \n �������� �̵� : A, ���������� �̵� : D",
            "���� ���� �ٷ� �տ� �ִ� ǥ������ Ȯ���غ�����!",});

        // id = 1001 : Tutorial sign1
        talkData.Add(1000, new string[] { "���� �˼��ؿ�! \n�� �Ǽ��� ����� �̰����� �������� �Ǿ����...",
            "�׷��� �� �Ǽ��� ��ŭ �ذ��ϱ� ���ؼ� ����� ���� �Ϳ��� �ּ��� ���ҰԿ�!",
            "�̰��� �̻��� ������ �ٸ��� ��ȭ �� �̿���. \n��ȭ�� ���� ��������������... �̴�δ� �������� �� �����ſ���.",
            "���� ���������� ���� �Ŵ°� ���� ���� ������ ���� �� ���ƿ�. \n��� �̰� ������ ǥ������ ���ؼ� ������ �帱�Կ�.",
            "�׷� �� ��Ź�����."});

        // id = 1001 : Tutorial sign2
        talkData.Add(1001, new string[] { "�̰����� ���� ���Ե� �����̿���. \n���� Ʈ���� ������̾����� ��ȭ�� �������鼭 ���鵵 ���������Ⱦ��.",
            "���콺 ��Ŭ�� : ���� [���콺 Ŀ���� ����Ű�� �������� ����] \n����ϱ� ������� ���� �ſ���. ��������!",
            "���� ��� �� �ڿ��� �������� ��Ż�� �Ѿ�ø� �ɰſ���."});

        // id = 500 : Tutorial Obstacle
        talkData.Add(500, new string[] { "�ܼ��� �׷��ͱ��̴�." });


        // Stage1

        // id = 1 : ����
        talkData.Add(1, new string[] { "�켱 �� ��Ȳ�� �ذ��ϱ� ���ؼ��� � �ͺ��� �ؾ��ұ�...?",
            "�Ʊ� ǥ������ ���ؼ� ������ �شٰ� ����..? ",
            "ǥ������ �ѹ� �о��."});

        //id = 1002 : Stage1 sign1
        talkData.Add(1002, new string[] { "���� ���� ã�ƾ� �� ����� �־��. \n�� ��ȭ ���� ���ΰ����� ���� �߿��� �ι��� ����������.",
            "���� ���� �׳ฦ ������, �׳ฦ ������ ��ȭ�� ������Ѿ��ؿ�.",
            "�̹� ���������� ��ȭ�̱� ������ ����� �̾߱Ⱑ ��������� �𸣰�����..\n�ϴ� ���� ���󰡺���!"});

        //id = 1003 : Stage1 sign2
        talkData.Add(1003, new string[] { "���� �ٸ� �ǳ��� �ٸ����� �־��!", "�� ������!" });

        //id = 1200 : Stage1 Alice
        talkData.Add(1200, new string[] { "��? �䳢 ģ������, �ȳ�?", "��? �ʸ� ����� �����?",
            "��.. ��ħ �ɽ��ϱ⵵ �߰�... ����־�̴ϱ� �ѹ� ���󰡺���!", "���� ���� ������ ���� ���� �ִٰ� ���󰥰�!" });

        //id = 1004 : Stage1 sign3
        talkData.Add(1004, new string[] { "ã�ƾ� �Ұ� �־��!", "�װ� ���ĸ�... \nȸ�߽ð� �����̿���.",
            "���� �� ��ȭ���� �䳢�� ȸ�߽ð踦 ������ �ִ°� �ƽ���? ", "������� ������ �����ž��ϴµ�, \n��ȭ�� ������ �������� �������� ��������Ⱦ��.",
            "���������� �������� �׷��� �ָ� ������� �ƴ϶�� �ſ���.", "�Ƹ� ���� ��ġ�ϰ� �ִ� �� ������ ���� �����ſ���. \n�װ� ã�Ƽ� ���� ���� ������ ���ø� �� �� ���ƿ�!",
             "�ٷ� �տ� ���̴� �ͺ��� ��������!"});

        //id = 1005 : Stage1 sign4
        talkData.Add(1005, new string[] { "�ð������� �뷫 7�� �ΰ� ���ƿ�! ",
            "����Ѱ� ���Ƽ� ��� �ð�����������.. \n�� �𸣰ڳ׿�", "�Ƹ� �� �ð������� �� �����ż� ��ġ�ž� \n������ �� �� ���� �� ���ƿ�!."});

        //id = 1006 : Stage1 sign5
        talkData.Add(1006, new string[] { "���� ������ ������ ���� ������ �͸� ���ƿ�.... \n�����ϼ���!"});

        //id = 1007 : Stage1 sign6
        talkData.Add(1007, new string[] { "�ð谡 �־���� ������ �� �� �ִٰ� ������ȴµ�..\n�ٸ����� ��ϳı���?",
            "�װ� �����ƿ�! \n���� �� ������ �ֹε��̶�� ū ������ �ްų� �ϴ°� �ƴϿ���. ", "�ٸ�...\n��Ų����� �������Ű��̶� �׷��� �̰������� �Ҽ��� ����� �ϴ� �� �����󱸿�",
            "�׷� �� ������ ������ ���ִ� ���� ȸ�߽ð迡��.", "�׷��� ���� �ʿ��ϴٰ� �̾߱� ��ȴ� ���̱⵵ �ϱ���."});

        //id = 501 : Stage1 ClockPiece
        talkData.Add(501, new string[] { "1�� �ð������� ȹ���ߴ�!" });

        //id = 502 : Stage1 ClockPiece
        talkData.Add(502, new string[] { "2�� �ð������� ȹ���ߴ�!" });

        //id = 503 : Stage1 ClockPiece
        talkData.Add(503, new string[] { "3�� �ð������� ȹ���ߴ�!" });

        //id = 504 : Stage1 ClockPiece
        talkData.Add(504, new string[] { "4�� �ð������� ȹ���ߴ�!" });

        //id = 505 : Stage1 ClockPiece
        talkData.Add(505, new string[] { "5�� �ð������� ȹ���ߴ�!" });

        //id = 506 : Stage1 ClockPiece
        talkData.Add(506, new string[] { "6�� �ð������� ȹ���ߴ�!" });

        //id = 507 : Stage1 ClockPiece
        talkData.Add(507, new string[] { "7�� �ð������� ȹ���ߴ�!" });

        //id = 508 : Stage1 ClockPiece
        talkData.Add(508, new string[] { "�ܼ��� ��ö�� �� ����..." });

        //id = 509 : Stage1 ClockPiece
        talkData.Add(509, new string[] { "�����̸� ������ �� �ϴ�..." });

        //id = 510 : Stage1 ClockPiece
        talkData.Add(510, new string[] { "�˼����� �����̴�.. ���� ã�°� �ƴѵ� �ϴ�." });



        // Stage2

        //id = 1008 : Stage2 sign1
        talkData.Add(1008, new string[] { "������ �ܼ��� �������µ�...?", "������ �˾ƺ��� ���������� �������Ⱦ��...", 
            "������ �˷��ֱ� ���� �� ���ƿ�.. \n��� �ٷ� �տ� ��� �ִ��� ������ �� �� ���� �� ���ƿ�!",
            "�ϴ� ���������� ���� ������ �� �� ���ƿ�!"});


        //id = 1009 : Stage2 sign2
        talkData.Add(1009, new string[] { "�������� ����.. \n������ ������ ������ ���� �� ���� �� ���ƿ�!", 
            "���������� ����.. �ٸ����� �ִ°� ���ƿ�. \n ����´ٴ��� ���� ������ ���� �־��׿�." });

        //id = 1201 : Stage2 Alice
        talkData.Add(1201, new string[] { "������� �ͼ� ���� �����տ� ������ �־��µ�..\n �ñ��ؼ� ���� ���� ���Ⱦ�!",
            "�¾� ���� ���� ���ƴٴϴ� ���ϱ� ���� ������ ������ �ִ���?", "������.. �Ķ���.. �� ���� ���� �ִ���? \n��� ���°ɱ�?" });

        //id = 1010 : Stage2 sign3
        talkData.Add(1010, new string[] { "�ٷ� �տ� ������ �ִ� �� ���ƿ�! ", "Ȥ�� �Ȱ��� ���� �ֵ��� ������ �͵� ������ ���� �� ���ƿ�!"});

        //id = 1011 : Stage2 sign4
        talkData.Add(1011, new string[] { "���²� ��ƿ��� �����..", "���� ũ�⸦ �����ϴ� ������ ����� �� ���ƿ�!",
            "�׳� �Ծ��� ������ Ư���� ��ȭ�� ���� �� ���ƿ�."});

        //id = 1012 : Stage2 sign5
        talkData.Add(1012, new string[] { "�������� ������ ���࿡�� 3�̶�� ���ڰ� �����־��.", "�ʷϻ� ���࿡�� 7, �Ķ��� ���࿡�� 13, ����� ���࿡�� -1�� �����־��!",
            "�� ���ڵ��� ������ ����� ��Ʈ�� �ƴұ��?"});

        //id = 1013 : Stage2 sign6
        talkData.Add(1013, new string[] { "������ ���� �о�帱 �� �־��!", "�� �� Ȯ���غ��� ���� �ʿ��ߴ� ���࿡ ���� ������ �����־��!",
            "�����...\n������ �ϼ�ǰ�� ���� ������...", "��! �����ֳ׿�!", " '���� ������ ���� �ʾƼ� ���鿡�ٰ� ���� ������ ����ΰ� �ߴ�. ", 
            "\n�� ���п� ���� ������ ���鶧 ������ ����� �͵��� ã�� �ʾƵ� �ǰ� �Ǿ���.' ", "���� �۾����� ���� : 50 \n���� Ŀ���� ���� : ....",
              "�˾Ƶθ� ����� �� ���� �������...?"});

        //id = 1014 : Stage2 sign7
        talkData.Add(1014, new string[] { "�ⱸ�� �����⿡�� �ⱸ�� ũ�Ⱑ ���� �۾ƿ�...", "��! �Ʊ� �� ã�Ҵ� ��Ṱ����� �����ϸ� ������ ���� �� ���� �ʳ���?\n" +
            "������ �����ǵ� ���� �־��ݾƿ�!", "�� �غ����!", "�Ʒ��ʿ� ��ġ�� ���̺��� ������ ������ �� �ֽ��ϴ�.\n���̺� �տ��� ��ȣ�ۿ� ��ư : F�� ����������."});



        //id = 511 : Stage2 Red Potion
        talkData.Add(511, new string[] { "������ ��Ṱ���� ȹ���ߴ�!" });

        //id = 512 : Stage2 Green Potion
        talkData.Add(512, new string[] { "�ʷϻ� ��Ṱ���� ȹ���ߴ�!" });

        //id = 513 : Stage2 Blue Potion
        talkData.Add(513, new string[] { "�Ķ��� ��Ṱ���� ȹ���ߴ�!" });

        //id = 514 : Stage2 Yellow Potion
        talkData.Add(514, new string[] { "����� ��Ṱ���� ȹ���ߴ�!" });

        //id = 515 : Stage2 Red Potion Bundle
        talkData.Add(515, new string[] { "������ ��Ṱ�� ���̸� ȹ���ߴ�!" });

        //id = 516 : Stage2 Green Potion Bundle
        talkData.Add(516, new string[] { "�ʷϻ� ��Ṱ�� ���̸� ȹ���ߴ�!" });

        //id = 517 : Stage2 Blue Potion Bundle
        talkData.Add(517, new string[] { "�Ķ��� ��Ṱ�� ���̸� ȹ���ߴ�!" });

        //id = 518 : Stage2 Yellow Potion Bundle
        talkData.Add(518, new string[] { "����� ��Ṱ�� ���̸� ȹ���ߴ�!" });

    }

    public string GetTalk(int id, int talkIndex)  // obj id, string[] index
    {

        if (talkIndex == talkData[id].Length)
            return null;
        if (id >= 501 && id <= 518)
        {
            Debug.Log(id);
            switch (id)
            {
                case 501:
                    clockTalk.clockCount++;
                    break;
                case 502:
                    clockTalk.clockCount++;
                    break;
                case 503:
                    clockTalk.clockCount++;
                    break;
                case 504:
                    clockTalk.clockCount++;
                    break;
                case 505:
                    clockTalk.clockCount++;
                    break;
                case 506:
                    clockTalk.clockCount++;
                    break;
                case 507:
                    clockTalk.clockCount++;
                    break;

                case 511:
                    potionTalk.potionCount[0]++;
                    break;
                case 512:
                    potionTalk.potionCount[1]++;
                    break;
                case 513:
                    potionTalk.potionCount[2]++;
                    break;
                case 514:
                    potionTalk.potionCount[3]++;
                    break;
                case 515:
                    potionTalk.potionCount[0] += 5;
                    break;
                case 516:
                    potionTalk.potionCount[1] += 5;
                    break;
                case 517:
                    potionTalk.potionCount[2] += 5;
                    break;
                case 518:
                    potionTalk.potionCount[3] += 5;
                    break;
                default:
                    break;
            }
            return talkData[id][talkIndex];
        }

        if (id == 1201 || id == 1004) // stage2 Alice Talk
        {
           ActiveUI.SetActive(true);
           return talkData[id][talkIndex];
        }

        else
            return talkData[id][talkIndex];
    }


    IEnumerator CutSceneTalk()
    {
        yield return new WaitForSeconds(0.5f);

        if (currentScene == "Tutorial")
            gameManager.CutSceneAction(0);


        if (currentScene == "Stage1")
            gameManager.CutSceneAction(1);


        StartCoroutine(CutSceneObjectDestroy());

    }

    IEnumerator CutSceneObjectDestroy()
    {

        yield return new WaitForSecondsRealtime(10.0f);
        Destroy(cutSceneObject);
    }
}