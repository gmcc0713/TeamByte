using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> nameimageData;

    public GameManager gameManager;
    public Sprite[] nameimageArr;
    public string currentScene;
    public GameObject CutSceneObject;//Destory


    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
        talkData = new Dictionary<int, string[]>();
        nameimageData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    private void Start()
    {
        StartCoroutine(stage1Start());

    }

    void GenerateData()
    {
        // id : 500~1000 = �Ϲ� ��ȭ ������Ʈ
        // id : 1000 = NPC, ǥ���� �� ���� ��ȭ ������Ʈ
        // id : 0~500 = ����, �ƾ��� ��ȭ

        //Tutorial Scene

        talkData.Add(0, new string[] { "������ �⺻���� ���� ����� �˷��帮�ڽ��ϴ�!",
            "��ȣ�ۿ� ��ư : Space Bar, ���� �ý��� ���� : F ",
            "���� �̵� : W, �Ʒ��� �̵� S \n �������� �̵� : A, ���������� �̵� : D",
            "���� ���� �ٷ� �տ� �ִ� ǥ������ Ȯ���غ�����!",});

    
        talkData.Add(1, new string[] { "�켱 �� ��Ȳ�� �ذ��ϱ� ���ؼ��� � �ͺ��� �ؾ��ұ�...?",
            "�׷�! ���� �̾߱��� ���ΰ��� �ٸ����� �����°ž�! ",
            "������ �̾߱��ζ�� �ٸ����� �̰� ��򰡿� �����ž�.."});


        // ���콺 ��Ŭ�� : ���� [���콺 Ŀ���� ����Ű�� �������� ����]

        // id = 1001 : Tutorial sign2
        talkData.Add(1000, new string[] { "���ڱ� �䳢�� �Ǿ�����ż� ��Ȳ�ϼ���? \n�����ƿ�! �ٽ� ���ư� �� �ִ� ����� �ִ�ϴ�!",
            "���� ��Ű�� ����θ� �ϽŴٸ� ������� �����帱�״ϱ��!",
            "�̰��� �̻��� ������ �ٸ��� ��ȭ ���̶��ϴ�! \n��ȭ�� ���� ��������������... �̰� �ذ����ֽô� �� ����� �� ���̶��ϴ�~",
            "��ó�� ǥ������ �ִٸ� �� �о����! \n ���� �������� ���� ����ξ����ϱ��!", 
            "����... �ϴ°� ����� ��������!"});

        // id = 1001 : Tutorial sign2
        talkData.Add(1001, new string[] { "������ ù ����! �Ƚ��ϼ���. �׷��� ������ �ƴ϶��ϴ�?",
            "���콺 ��Ŭ�� : ���� [���콺 Ŀ���� ����Ű�� �������� ����] \n���� ����ġ�� Ʃ�丮���� ����������!",
            "���� ���� ���Ŀ��� ������ ��Ż�� �����ø� �˴ϴ�!"});

        // id = 500 : Tutorial Obstacle
        talkData.Add(500, new string[] { "�ܼ��� �׷��ͱ��̴�." });

    }

    public string GetTalk(int id, int talkIndex)  // obj id, string[] index
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }


    IEnumerator stage1Start()
    {
        yield return new WaitForSeconds(1.0f);

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
