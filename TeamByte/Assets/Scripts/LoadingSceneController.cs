using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    [SerializeField] Slider loadingBar;

    void Start()
    {
        StartCoroutine(LoadingSceneProgress());
    }


    IEnumerator LoadingSceneProgress()
    {
        AsyncOperation op =   SceneManager.LoadSceneAsync("Stage1");       //�񵿱� ���(���� �ҷ����� ���� �ٸ��۾��� ������)
        op.allowSceneActivation = false;    //���� �񵿱�� �ҷ����϶� ���� �ε��� ������ �ڵ����� �ҷ��� ������ �̵��Ұ��� ����(�ε��ð��� �ʹ� ª������ ���)

        float timer = 0;
        while(!op.isDone)   //bar�� �������� �ϱ����� op�� ������ �ʾ����� ��� ����
        {
            yield return null;
            if (op.progress < 0.9f)     //���� �ε��� 90�� ���� �ε� �ٸ� ä���
            {
                loadingBar.value = op.progress;
            }
            else                        //������ 10�۴� 1�ʵ��� ä��� ���� �ҷ��´�
            {
                timer += Time.unscaledDeltaTime;
                loadingBar.value = Mathf.Lerp(0.9f, 1f, timer);
                if(loadingBar.value >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield return null;
                }
            }

        }
    }
}
