using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockPuzzleManager : MonoBehaviour
{
    GameObject clockPuzzlePanel;
    public bool isClear;
    // Start is called before the first frame update
    void Start()
    {
        PiecesController ValueFromPiecesController = FindObjectOfType<PiecesController>();
        if (ValueFromPiecesController != null)
        {
            isClear = ValueFromPiecesController.clearPuzzle;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isClear) { StartCoroutine(CloseQuiz()); }
    }

     IEnumerator CloseQuiz()
    {
        yield return new WaitForSeconds(3);
        clockPuzzlePanel.SetActive(false);
    }
}
