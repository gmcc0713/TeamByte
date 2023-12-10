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
        talkData.Add(1004, new string[] { "찾아야 할게 있어요!", "그게 뭐냐면... \n회중시계 조각이에요.",
            "원래 이 동화에서 토끼가 회중시계를 가지고 있는건 아시죠? ", "원래라면 가지고 있으셔야하는데, \n동화가 망가진 여파인지 조각나서 흩어져버렸어요.",
            "다행인점은 조각들이 그렇게 멀리 흩어진게 아니라는 거에요.", "아마 지금 위치하고 있는 이 지역에 전부 있을거에요. \n그걸 찾아서 길을 따라서 동굴로 가시면 될 것 같아요!",
             "바로 앞에 보이는 것부터 가져가죠!"});

        //id = 1005 : Stage1 sign4
        talkData.Add(1005, new string[] { "시계조각은 대략 7개 인것 같아요! ",
            "잡다한게 많아서 어떤게 시계조각인지는.. \n잘 모르겠네요", "아마 이 시계조각을 다 모으셔서 합치셔야 \n동굴로 들어갈 수 있을 것 같아요!."});

        //id = 1006 : Stage1 sign5
        talkData.Add(1006, new string[] { "가면 갈수록 적들이 자주 나오는 것만 같아요.... \n조심하세요!"});

        //id = 1007 : Stage1 sign6
        talkData.Add(1007, new string[] { "시계가 있어야지 동굴에 들어갈 수 있다고 말씀드렸는데..\n앨리스는 어떡하냐구요?",
            "그건 괜찮아요! \n원래 이 세계의 주민들이라면 큰 제약을 받거나 하는건 아니에요. ", "다만...\n당신께서는 끌려오신것이라 그런지 이곳에서는 불순물 취급을 하는 것 같더라구요",
            "그런 걸 막아줄 역할을 해주는 것이 회중시계에요.", "그래서 제가 필요하다고 이야기 드렸던 것이기도 하구요."});

        //id = 501 : Stage1 ClockPiece
        talkData.Add(501, new string[] { "1번 시계조각을 획득했다!" });

        //id = 502 : Stage1 ClockPiece
        talkData.Add(502, new string[] { "2번 시계조각을 획득했다!" });

        //id = 503 : Stage1 ClockPiece
        talkData.Add(503, new string[] { "3번 시계조각을 획득했다!" });

        //id = 504 : Stage1 ClockPiece
        talkData.Add(504, new string[] { "4번 시계조각을 획득했다!" });

        //id = 505 : Stage1 ClockPiece
        talkData.Add(505, new string[] { "5번 시계조각을 획득했다!" });

        //id = 506 : Stage1 ClockPiece
        talkData.Add(506, new string[] { "6번 시계조각을 획득했다!" });

        //id = 507 : Stage1 ClockPiece
        talkData.Add(507, new string[] { "7번 시계조각을 획득했다!" });

        //id = 508 : Stage1 ClockPiece
        talkData.Add(508, new string[] { "단순한 고철인 것 같다..." });

        //id = 509 : Stage1 ClockPiece
        talkData.Add(509, new string[] { "돌멩이를 착각한 듯 하다..." });

        //id = 510 : Stage1 ClockPiece
        talkData.Add(510, new string[] { "알수없는 파편이다.. 내가 찾는건 아닌듯 하다." });



        // Stage2

        //id = 1008 : Stage2 sign1
        talkData.Add(1008, new string[] { "원래는 단순한 동굴었는데...?", "구조가 알아보기 힘들정도로 꼬여버렸어요...", 
            "방향은 알려주기 힘들 것 같아요.. \n대신 바로 앞에 어떤게 있는지 정도는 알 수 있을 것 같아요!",
            "일단 오른쪽으로 먼저 가봐야 할 것 같아요!"});


        //id = 1009 : Stage2 sign2
        talkData.Add(1009, new string[] { "왼쪽으로 가면.. \n적들이 있지만 뭔가를 얻을 수 있을 것 같아요!", 
            "오른쪽으로 가면.. 앨리스가 있는것 같아요. \n 따라온다더니 벌써 동굴로 들어와 있었네요." });

        //id = 1201 : Stage2 Alice
        talkData.Add(1201, new string[] { "지름길로 와서 먼저 동굴앞에 도착해 있었는데..\n 궁금해서 먼저 들어와 버렸어!",
            "맞아 동굴 안을 돌아다니다 보니까 여러 색깔의 물약이 있더라?", "빨간색.. 파란색.. 또 무슨 색이 있더라? \n어디에 쓰는걸까?" });

        //id = 1010 : Stage2 sign3
        talkData.Add(1010, new string[] { "바로 앞에 적들이 있는 것 같아요! ", "혹시 안가본 곳이 있따면 가보는 것도 나쁘지 않을 것 같아요!"});

        //id = 1011 : Stage2 sign4
        talkData.Add(1011, new string[] { "여태껏 모아오신 물약들..", "몸의 크기를 조절하는 물약의 재료인 것 같아요!",
            "그냥 먹었을 때에는 특별한 변화는 없는 것 같아요."});

        //id = 1012 : Stage2 sign5
        talkData.Add(1012, new string[] { "이제보니 빨간색 물약에는 3이라는 숫자가 적혀있어요.", "초록색 물약에는 7, 파란색 물약에는 13, 노란색 물약에는 -1이 적혀있어요!",
            "이 숫자들이 물약을 만드는 힌트가 아닐까요?"});

        //id = 1013 : Stage2 sign6
        talkData.Add(1013, new string[] { "일지는 제가 읽어드릴 수 있어요!", "한 번 확인해보니 저희가 필요했던 물약에 대한 정보가 적혀있어요!",
            "어디보자...\n물약의 완성품에 대한 정보가...", "아! 여기있네요!", " '나는 기억력이 좋지 않아서 재료들에다가 여러 정보를 적어두곤 했다. ", 
            "\n그 덕분에 여러 물약을 만들때 일일이 적어둔 것들을 찾지 않아도 되게 되었다.' ", "몸이 작아지는 물약 : 50 \n몸이 커지는 물약 : ....",
              "알아두면 써먹을 수 있지 않을까요...?"});

        //id = 1014 : Stage2 sign7
        talkData.Add(1014, new string[] { "출구로 나가기에는 출구의 크기가 많이 작아요...", "아! 아까 전 찾았던 재료물약들을 조합하면 물약을 만들 수 있지 않나요?\n" +
            "일지에 레시피도 적혀 있었잖아요!", "얼른 해볼까요!", "아래쪽에 위치한 테이블에서 물약을 조합할 수 있습니다.\n테이블 앞에서 상호작용 버튼 : F를 눌러보세요."});



        //id = 511 : Stage2 Red Potion
        talkData.Add(511, new string[] { "빨간색 재료물약을 획득했다!" });

        //id = 512 : Stage2 Green Potion
        talkData.Add(512, new string[] { "초록색 재료물약을 획득했다!" });

        //id = 513 : Stage2 Blue Potion
        talkData.Add(513, new string[] { "파란색 재료물약을 획득했다!" });

        //id = 514 : Stage2 Yellow Potion
        talkData.Add(514, new string[] { "노란색 재료물약을 획득했다!" });

        //id = 515 : Stage2 Red Potion Bundle
        talkData.Add(515, new string[] { "빨간색 재료물약 더미를 획득했다!" });

        //id = 516 : Stage2 Green Potion Bundle
        talkData.Add(516, new string[] { "초록색 재료물약 더미를 획득했다!" });

        //id = 517 : Stage2 Blue Potion Bundle
        talkData.Add(517, new string[] { "파란색 재료물약 더미를 획득했다!" });

        //id = 518 : Stage2 Yellow Potion Bundle
        talkData.Add(518, new string[] { "노란색 재료물약 더미를 획득했다!" });

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