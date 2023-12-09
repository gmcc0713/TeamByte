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

    public PotionFind potionTalk;
    public GameObject potionObject;

    public Image nameImage;
    public Sprite[] imageSprite;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
        talkData = new Dictionary<int, string[]>();
        GenerateData();

        potionTalk = potionObject.GetComponent<PotionFind>();
        if (potionTalk == null)
            return;

    }

    private void Start()
    {
        StartCoroutine(CutSceneTalk());

    }

    void GenerateData()
    {
        // id : 1500~1699 = 이미지 설정


        // id : 0~499 = 독백, 컷씬용 대화
        // id : 500~999 = 일반 대화 오브젝트
        // id : 1000~1199 = 표지판 등 많은 대화 오브젝트
        // id : 1200~1499 = 앨리스 등 많은 대화 오브젝트


        //Tutorial Scene

        // id = 0 : 독백
        talkData.Add(0, new string[] { "게임의 기본적인 조작 방법을 알려드리겠습니다!",
            "상호작용 버튼 : Space Bar, 퀴즈 시스템 동작 : F ",
            "위로 이동 : W, 아래로 이동 S \n 왼쪽으로 이동 : A, 오른쪽으로 이동 : D",
            "제일 먼저 바로 앞에 있는 표지판을 확인해보세요!",});

        // id = 1001 : Tutorial sign1
        talkData.Add(1000, new string[] { "정말 죄송해요! \n제 실수로 당신이 이곳으로 끌려오게 되었어요...",
            "그래도 제 실수인 만큼 해결하기 위해서 당신을 돕는 것에는 최선을 다할게요!",
            "이곳은 이상한 나라의 앨리스 동화 속 이에요. \n동화가 많이 망가져버린지라... 이대로는 빠져나갈 수 없을거에요.",
            "제가 직접적으로 말을 거는건 여러 제약 때문에 힘들 것 같아요. \n대신 이곳 저곳에 표지판을 통해서 도움을 드릴게요.",
            "그럼 잘 부탁드려요."});

        // id = 1001 : Tutorial sign2
        talkData.Add(1001, new string[] { "이곳에서 자주 보게될 적들이에요. \n원래 트럼프 병사들이었지만 동화가 망가지면서 저들도 망가져버렸어요.",
            "마우스 좌클릭 : 공격 [마우스 커서가 가리키는 방향으로 공격] \n상대하기 어렵지는 않을 거에요. 힘내세요!",
            "적을 잡고 난 뒤에는 맞은편의 포탈로 넘어가시면 될거에요."});

        // id = 500 : Tutorial Obstacle
        talkData.Add(500, new string[] { "단순한 그루터기이다." });


        // Stage1

        // id = 1 : 독백
        talkData.Add(1, new string[] { "우선 이 상황을 해결하기 위해서는 어떤 것부터 해야할까...?",
            "아까 표지판을 통해서 도움을 준다고 했지..? ",
            "표지판을 한번 읽어보자."});

        //id = 1002 : Stage1 sign1
        talkData.Add(1002, new string[] { "제일 먼저 찾아야 할 사람이 있어요. \n이 동화 속의 주인공이자 제일 중요한 인물인 엘리스에요.",
            "제일 먼저 그녀를 만나고, 그녀를 데리고 동화를 진행시켜야해요.",
            "이미 망가져버린 동화이기 때문에 제대로 이야기가 진행될지는 모르겠지만..\n일단 길을 따라가봐요!"});

        //id = 1003 : Stage1 sign2
        talkData.Add(1003, new string[] { "저기 다리 건너편에 앨리스가 있어요!", "얼른 가봐요!" });

        //id = 1200 : Stage1 Alice
        talkData.Add(1200, new string[] { "어? 토끼 친구구나, 안녕?", "뭐? 너를 따라와 보라고?",
            "음.. 마침 심심하기도 했고... 재미있어보이니까 한번 따라가볼게!", "먼저 가고 있으면 내가 조금 있다가 따라갈게!" });

        //id = 1004 : Stage1 sign3
        talkData.Add(1004, new string[] { "앨리스가 너를 찾아야 할게 있어!", "그게 뭐냐면... \n 시계 조각이야.",
            "원래 이 동화에서 토끼가 회중시계를 가지고 있는건 알지? ", "원래라면 너가 가지고 있어야하는데, \n동화가 망가진 여파인지 조각나서 흩어져버렸어.",
            "다행인점은 조각들의 대략적인 위치는 알 쉬 있는거랄까?", "지금 위치하고 있는 이 지역에 몇 개 정도 있을거야.", "그걸 찾아서 길을 따라서 동굴 앞으로 와주면 될 것 같아!"});


        // Stage2

        //id = 1005 : Stage2 sign1
        talkData.Add(1005, new string[] { "원래는 단순한 동굴었는데...?", "구조가 알아보기 힘들정도로 꼬여버렸어요...", 
            "방향은 알려주기 힘들 것 같아요.. \n대신 바로 앞에 어떤게 있는지 정도는 알 수 있을 것 같아요!",
            "일단 오른쪽으로 먼저 가봐야 할 것 같아요!"});


        //id = 1006 : Stage2 sign2
        talkData.Add(1006, new string[] { "왼쪽으로 가면.. \n적들이 있지만 뭔가를 얻을 수 있을 것 같아요!", 
            "오른쪽으로 가면.. 앨리스가 있는것 같아요. \n 따라온다더니 벌써 동굴로 들어와 있었네요." });

        //id = 1201 : Stage2 Alice
        talkData.Add(1201, new string[] { "지름길로 와서 먼저 동굴앞에 도착해 있었는데..\n 궁금해서 먼저 들어와 버렸어!",
            "맞아 동굴 안을 돌아다니다 보니까 여러 색깔의 물약이 있더라?", "빨간색.. 파란색.. 또 무슨 색이 있더라? \n어디에 쓰는걸까?" });

        //id = 1007 : Stage2 sign3
        talkData.Add(1007, new string[] { "바로 앞에 적들이 있는 것 같아요! ", "혹시 안가본 곳이 있따면 가보는 것도 나쁘지 않을 것 같아요!"});


        //id = 501 : Stage2 Red Potion
        talkData.Add(501, new string[] { "빨간색 물약을 획득했다!" });

        //id = 502 : Stage2 Green Potion
        talkData.Add(502, new string[] { "초록색 물약을 획득했다!" });

        //id = 503 : Stage2 Blue Potion
        talkData.Add(503, new string[] { "파란색 물약을 획득했다!" });

        //id = 504 : Stage2 Yellow Potion
        talkData.Add(504, new string[] { "노란색 물약을 획득했다!" });

        //id = 505 : Stage2 Red Potion Bundle
        talkData.Add(505, new string[] { "빨간색 물약 더미를 획득했다!" });

        //id = 506 : Stage2 Green Potion Bundle
        talkData.Add(506, new string[] { "초록색 물약 더미를 획득했다!" });

        //id = 507 : Stage2 Blue Potion Bundle
        talkData.Add(507, new string[] { "파란색 물약 더미를 획득했다!" });

        //id = 508 : Stage2 Yellow Potion Bundle
        talkData.Add(508, new string[] { "노란색 물약 더미를 획득했다!" });


    }

    public string GetTalk(int id, int talkIndex)  // obj id, string[] index
    {
        /*        // 독백 : 1~499
        if (id >= 1 || id <= 499)
            nameImage.sprite = imageSprite[0]; Debug.Log("0");

        // 표지판(요정) : 1000~1199 
        if (id >= 1000 || id <= 1199)
            nameImage.sprite = imageSprite[1]; Debug.Log("1");

        // 앨리스 : 1200~1499
        if (id >= 1200 || id <= 1499)
            nameImage.sprite = imageSprite[2]; Debug.Log("2");

        if (id >= 500 || id <= 999)
            nameImage.sprite = null;
*/

        if (talkIndex == talkData[id].Length)
            return null;
        if (id >= 501 && id <= 508)
        {
            Debug.Log(id);
            switch (id)
            {
                case 501:
                    potionTalk.potionCount[0]++;
                    break;
                case 502:
                    potionTalk.potionCount[1]++;
                    break;
                case 503:
                    potionTalk.potionCount[2]++;
                    break;
                case 504:
                    potionTalk.potionCount[3]++;
                    break;
                case 505:
                    potionTalk.potionCount[0] += 5;
                    break;
                case 506:
                    potionTalk.potionCount[1] += 5;
                    break;
                case 507:
                    potionTalk.potionCount[2] += 5;
                    break;
                case 508:
                    potionTalk.potionCount[3] += 5;
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
        Destroy(cutSceneObject);
    }
}