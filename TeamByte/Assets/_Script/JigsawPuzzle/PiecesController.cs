using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiecesController : MonoBehaviour
{ 
    public string curPieceStatus = "idle";
    public bool isClicked = false;
    private Vector3 initialPosition;
    private float puzzlePanelSize = 5.0f;
    public int progressCount = 0;
    private int numOfPuzzle = 8;
    public bool clearPuzzle = false;

    public GameObject PuzzlePosition;

    void Start()
    {
        initialPosition = GetRandomPosition();
        transform.position = initialPosition;
    }

    void Update()
    {
        if(curPieceStatus == "dragging") 
        {
             Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }

    void OnMouseDown()
    {
        curPieceStatus = "dragging";
        isClicked = true;
    }
    private void OnMouseUp()
    {
        isClicked= false;
    }
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(PuzzlePosition.gameObject.transform.position.x +5.0f, PuzzlePosition.gameObject.transform.position.x -5.0f);
        float y = Random.Range(PuzzlePosition.gameObject.transform.position.y +5.0f, PuzzlePosition.gameObject.transform.position.y - 5.0f);     
        //float x = Random.Range(-puzzlePanelSize * 0.9f, puzzlePanelSize *0.9f);
        //float y = Random.Range(-puzzlePanelSize * 0.9f, puzzlePanelSize * 0.9f);
        return new Vector3(x, y, 0f);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if ((curPieceStatus != "locked" && collision.gameObject.name == gameObject.name) && (isClicked == true))
        {
            clearPuzzle = true;
            transform.position = collision.transform.position;
            curPieceStatus = "locked";
            isClicked = false;
            progressCount++;
        }
    }
    void ClearPuzzle()
    {
        if (progressCount == numOfPuzzle)
        {
            clearPuzzle = true;
        }
    }
}
