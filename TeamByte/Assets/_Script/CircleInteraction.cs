using UnityEngine;

public class CircleInteraction : MonoBehaviour
{
    public GameObject circleObj; // Circle ������Ʈ�� Transform ����
    public float interactDistance = 20f; // ��� �Ÿ�
    public GameObject quizUI; // ���� UI ���� ������Ʈ
    public GameObject playerObj;
    public GameObject PressUI;

    void Update()
    {
        // Circle ������Ʈ���� �Ÿ��� ���
        float distance = Vector3.Distance(playerObj.transform.position, circleObj.transform.position);

        if (distance < interactDistance)
        {
            Debug.Log("Press");
            PressUI.SetActive(true);
        }
        else
        {
            PressUI.SetActive(false);
        }

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
