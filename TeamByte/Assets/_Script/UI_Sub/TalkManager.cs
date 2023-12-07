using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> nameimageData;
    Dictionary<int, Sprite> cutSceneImage;

    public GameManager gameManager;
    public Sprite[] nameimageArr;
    public Sprite[] cutSceneimageArr;
    public string currentScene;
    public GameObject CutSceneObject;//Destory

    public PotionFind PotionTalk;

    public GameObject PotionObject;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
        talkData = new Dictionary<int, string[]>();
        nameimageData = new Dictionary<int, Sprite>();
        cutSceneImage = new Dictionary<int, Sprite>();
        GenerateData();

        PotionTalk = PotionObject.GetComponent<PotionFind>();
    }

    private void Start()
    {
        StartCoroutine(CutSceneTalk());

    }

    void GenerateData()
    {
        // id : 1500~1699 = �̹��� ����

        // �̸� �̹��� ����
        //nameimageData.Add(1500, nameimageArr[0]);

        // id : 1700~1999 = �ƾ� �̹��� ����
        //cutSceneImage.Add(1700, cutSceneImage[0]);

        // id : 0~499 = ����, �ƾ��� ��ȭ
        // id : 500~999 = �Ϲ� ��ȭ ������Ʈ
        // id : 1000~1499 = NPC, ǥ���� �� ���� ��ȭ ������Ʈ


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

        //id = 1004 : Stage1 Alice
        talkData.Add(1004, new string[] { "��? �䳢 ģ������, �ȳ�?", "��? �ʸ� ����� �����?",
            "��.. ��ħ �ɽ��ϱ⵵ �߰�... ����־�̴ϱ� �ѹ� ���󰡺���!", "���� ���� ������ ���� ���� �ִٰ� ���󰥰�!" });

        //id = 1005 : Stage1 sign3
        talkData.Add(1005, new string[] { "�ٸ����� �ʸ� ã�ƾ� �Ұ� �־�!", "�װ� ���ĸ�... \n �ð� �����̾�.",
            "���� �� ��ȭ���� �䳢�� ȸ�߽ð踦 ������ �ִ°� ����? ", "������� �ʰ� ������ �־���ϴµ�, \n��ȭ�� ������ �������� �������� ��������Ⱦ�.",
            "���������� �������� �뷫���� ��ġ�� �� �� �ִ°Ŷ���?", "���� ��ġ�ϰ� �ִ� �� ������ �� �� ���� �����ž�.", "�װ� ã�Ƽ� ���� ���� ���� ������ ���ָ� �� �� ����!"});


        // Stage2

        //id = 1006 : Stage2 sign1
        talkData.Add(1006, new string[] { "������ �ܼ��� �������µ�...?", "������ �˾ƺ��� ���������� �������Ⱦ��...", 
            "������ �˷��ֱ� ���� �� ���ƿ�.. \n��� �ٷ� �տ� ��� �ִ��� ������ �� �� ���� �� ���ƿ�!",
            "�ϴ� ���������� ���� ������ �� �� ���ƿ�!"});


        //id = 1007 : Stage2 sign2
        talkData.Add(1007, new string[] { "�������� ����.. \n������ ������ ������ ���� �� ���� �� ���ƿ�!", 
            "���������� ����.. �ٸ����� �ִ°� ���ƿ�. \n ����´ٴ��� ���� ������ ���� �־��׿�." });

        //id = 1008 : Stage2 Alice
        talkData.Add(1008, new string[] { "������� �ͼ� ���� �����տ� ������ �־��µ�..\n �ñ��ؼ� ���� ���� ���Ⱦ�!",
            "�¾� ���� ���� ���ƴٴϴ� ���ϱ� ���� ������ ������ �ִ���?", "������.. �Ķ���.. �� ���� ���� �ִ���? \n��� ���°ɱ�?" });

        //id = 1009 : Stage2 sign3
        talkData.Add(1009, new string[] { "�ٷ� �տ� ������ �ִ� �� ���ƿ�! ", "Ȥ�� �Ȱ��� ���� �ֵ��� ������ �͵� ������ ���� �� ���ƿ�!"});


        //id = 501 : Stage2 Red Potion
        talkData.Add(501, new string[] { "������ ������ ȹ���ߴ�!" });

        //id = 502 : Stage2 Green Potion
        talkData.Add(502, new string[] { "�ʷϻ� ������ ȹ���ߴ�!" });

        //id = 503 : Stage2 Blue Potion
        talkData.Add(503, new string[] { "�Ķ��� ������ ȹ���ߴ�!" });

        //id = 504 : Stage2 Yellow Potion
        talkData.Add(504, new string[] { "����� ������ ȹ���ߴ�!" });

        //id = 505 : Stage2 Red Potion Bundle
        talkData.Add(505, new string[] { "������ ���� ���̸� ȹ���ߴ�!" });

        //id = 506 : Stage2 Green Potion Bundle
        talkData.Add(506, new string[] { "�ʷϻ� ���� ���̸� ȹ���ߴ�!" });

        //id = 507 : Stage2 Blue Potion Bundle
        talkData.Add(507, new string[] { "�Ķ��� ���� ���̸� ȹ���ߴ�!" });

        //id = 508 : Stage2 Yellow Potion Bundle
        talkData.Add(508, new string[] { "����� ���� ���̸� ȹ���ߴ�!" });


    }

    public string GetTalk(int id, int talkIndex)  // obj id, string[] index
    {
        if (talkIndex == talkData[id].Length)
            return null;
        if (id >= 501 && id <= 508)
        {
            Debug.Log(id);
            switch (id)
            {
                case 501:
                    PotionTalk.potionCount[0]++;
                    break;
                case 502:
                    PotionTalk.potionCount[1]++;
                    break;
                case 503:
                    PotionTalk.potionCount[2]++;
                    break;
                case 504:
                    PotionTalk.potionCount[3]++;
                    break;
                case 505:
                    PotionTalk.potionCount[0] += 5;
                    break;
                case 506:
                    PotionTalk.potionCount[1] += 5;
                    break;
                case 507:
                    PotionTalk.potionCount[2] += 5;
                    break;
                case 508:
                    PotionTalk.potionCount[3] += 5;
                    break;
                default:
                    break;
            }
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
        Destroy(CutSceneObject);
    }
}