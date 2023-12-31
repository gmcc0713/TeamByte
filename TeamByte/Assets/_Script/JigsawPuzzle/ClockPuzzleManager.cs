using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClockPuzzleManager : MonoBehaviour
{
    [SerializeField] GameObject clockPuzzlePanel;
    [SerializeField]  public bool isClear;
    [SerializeField] PiecesController[] ValueFromPiecesController;
    // Start is called before the first frame update
    public GameObject ActiveObject;
    public GameObject[] FalseObject; 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ValueFromPiecesController != null)
        {
            foreach(var piece in ValueFromPiecesController)
            { 
                if(piece.clearPuzzle == false)
                {
                    
                    return;
                }
            }
        }
        StartCoroutine(CloseQuiz());

    }

     IEnumerator CloseQuiz()
    {
        clockPuzzlePanel.SetActive(true);
        yield return new WaitForSeconds(3);
        clockPuzzlePanel.SetActive(false);
        //SceneManager.LoadScene("LoadingScene");
        ActiveObject.SetActive(true);
        Destroy(this);
        for (int i = 0; i < FalseObject.Length; i++)
            Destroy(FalseObject[i]);
    }
}
