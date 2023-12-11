using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockPuzzleManager : MonoBehaviour
{
    public GameObject Canvas;
    public Text successText;
    public int progressCount;
    private int numOfPuzzle = 8;
    // Start is called before the first frame update
    void Start()
    {
        PiecesController ValueFromPiecesController = FindObjectOfType<PiecesController>();
        if (ValueFromPiecesController != null)
        {
            progressCount = ValueFromPiecesController.progressCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        FinishedPuzzle();
    }
    private void FinishedPuzzle()
    {
        if (progressCount == numOfPuzzle)
        {
            Debug.Log("ddddd");
            successText.gameObject.SetActive(true);
            StartCoroutine(CloseQuiz());
        }
    }
    private IEnumerator CloseQuiz()
    {
        yield return new WaitForSeconds(3);
        Canvas.SetActive(false);
    }
}
