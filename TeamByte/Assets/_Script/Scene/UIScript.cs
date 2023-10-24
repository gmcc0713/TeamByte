using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    public void GameStartBtn()
    {
        SceneManager.LoadScene("KJHTest");
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        // ������ �󿡼��� Play ��带 ����
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ����� ��Ÿ�ӿ����� ���ø����̼��� �����մϴ�.
        Application.Quit();
#endif
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}