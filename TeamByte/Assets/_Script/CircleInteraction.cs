using UnityEngine;

public class CircleInteraction : MonoBehaviour
{
    public GameObject circleObj; // Circle ������Ʈ�� Transform ����
    public float interactDistance = 20f; // ��� �Ÿ�
    public GameObject quizUI; // ���� UI ���� ������Ʈ
    public GameObject playerObj;

    void Update()
    {
        // Circle ������Ʈ���� �Ÿ��� ���
        float distance = Vector3.Distance(playerObj.transform.position, circleObj.transform.position);

        // �Ÿ��� 20 �����̰� F Ű�� ������ ���� UI�� ���ϴ�.
        if (distance <= interactDistance && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("����");
            OpenQuizUI();
        }
    }

    void OpenQuizUI()
    {
        // ���� UI�� Ȱ��ȭ
        quizUI.SetActive(true);
    }
}
