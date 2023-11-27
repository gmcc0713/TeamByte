using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> nameimageData;

    public Sprite[] nameimageArr;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        nameimageData = new Dictionary<int, Sprite>();  
        GenerateData();
    }

    void GenerateData()
    {
        // id = 1000 : Tutorial sign1
        talkData.Add(1000, new string[] { "�ȳ��ϼ���", "���� ǥ�����Դϴ�." });

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
}
