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
        // id : 500~1000 = 일반 대화 오브젝트
        // id : 1000 = NPC, 표지판 등 많은 대화 오브젝트
        // id : 0~500 = 독백, 컷씬용 대화

        //Tutorial Scene

        talkData.Add(0, new string[] { "게임의 기본적인 조작 방법을 알려드리겠습니다!",
            "상호작용 버튼 : Space Bar, 퀴즈 시스템 동작 : F ",
            "위로 이동 : W, 아래로 이동 S \n 왼쪽으로 이동 : A, 오른쪽으로 이동 : D",
            "제일 먼저 바로 앞에 있는 표지판을 확인해보세요!",});

    
        talkData.Add(1, new string[] { "우선 이 상황을 해결하기 위해서는 어떤 것부터 해야할까...?",
            "그래! 원래 이야기의 주인공인 앨리스를 만나는거야! ",
            "원래의 이야기대로라면 앨리스가 이곳 어딘가에 있을거야.."});


        // 마우스 좌클릭 : 공격 [마우스 커서가 가리키는 방향으로 공격]

        // id = 1001 : Tutorial sign2
        talkData.Add(1000, new string[] { "갑자기 토끼가 되어버리셔서 당황하셨죠? \n괜찮아요! 다시 돌아갈 수 있는 방법이 있답니다!",
            "제가 시키는 말대로만 하신다면 원래대로 돌려드릴테니까요!",
            "이곳은 이상한 나라의 앨리스 동화 속이랍니다! \n동화가 많이 망가져버린지라... 이걸 해결해주시는 게 당신의 할 일이랍니다~",
            "근처에 표지판이 있다면 꼭 읽어보세요! \n 제가 여러가지 팁을 적어두었으니까요!", 
            "물론... 믿는건 당신의 자유지만!"});

        // id = 1001 : Tutorial sign2
        talkData.Add(1001, new string[] { "적과의 첫 전투! 안심하세요. 그렇게 어려운건 아니랍니다?",
            "마우스 좌클릭 : 공격 [마우스 커서가 가리키는 방향으로 공격] \n적을 물리치고 튜토리얼을 끝내보세요!",
            "적을 잡은 이후에는 위쪽의 포탈로 나가시면 됩니다!"});

        // id = 500 : Tutorial Obstacle
        talkData.Add(500, new string[] { "단순한 그루터기이다." });

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
