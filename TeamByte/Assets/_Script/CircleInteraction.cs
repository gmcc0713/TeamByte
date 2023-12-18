using UnityEngine;

public class CircleInteraction : MonoBehaviour
{
    public GameObject circleObj; // Circle 오브젝트의 Transform 참조
    public float interactDistance = 20f; // 허용 거리
    public GameObject quizUI; // 퀴즈 UI 게임 오브젝트
    public GameObject playerObj;

    void Update()
    {
        // Circle 오브젝트와의 거리를 계산
        float distance = Vector3.Distance(playerObj.transform.position, circleObj.transform.position);

        // 거리가 20 이하이고 F 키를 누르면 퀴즈 UI를 엽니다.
        if (distance <= interactDistance && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("ㅎㅇ");
            OpenQuizUI();
        }
    }

    void OpenQuizUI()
    {
        // 퀴즈 UI를 활성화
        quizUI.SetActive(true);
    }
}
