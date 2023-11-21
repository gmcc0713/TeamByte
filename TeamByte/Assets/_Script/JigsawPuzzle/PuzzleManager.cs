using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private GameObject[,] puzzlePieces;
    private Vector3[,] initialPositions;
    private GameObject selectedPiece;
    private Vector3 lastMousePosition;

    void Start()
    {
        InitializePuzzle();
    }

    void InitializePuzzle()
    {
        puzzlePieces = new GameObject[3, 3];
        initialPositions = new Vector3[500, 500];

        // Instantiate puzzle pieces and store initial positions
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                GameObject puzzlePiece = InstantiatePuzzlePiece();
                puzzlePiece.transform.position = new Vector3(col, -row, 0); // Adjust positions as needed
                puzzlePieces[row, col] = puzzlePiece;
                initialPositions[row, col] = puzzlePiece.transform.position;
            }
        }
    }

    GameObject InstantiatePuzzlePiece()
    {
        // Instantiate and return your puzzle piece GameObject
        // You can load a sprite, model, or any other representation of your puzzle piece here
        GameObject puzzlePiece = new GameObject("PuzzlePiece");
        puzzlePiece.AddComponent<SpriteRenderer>().color = Color.white; // Add a sprite renderer or mesh renderer as needed
        puzzlePiece.AddComponent<BoxCollider2D>(); // Add a collider for interactions

        return puzzlePiece;
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectPiece();
        }
        else if (Input.GetMouseButton(0))
        {
            if (selectedPiece != null)
            {
                DragPiece();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            DeselectPiece();
        }
    }

    void SelectPiece()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.CompareTag("PuzzlePiece"))
        {
            selectedPiece = hit.collider.gameObject;
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void DragPiece()
    {
        Vector3 mouseDelta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
        selectedPiece.transform.position += mouseDelta;
        lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void DeselectPiece()
    {
        if (selectedPiece != null)
        {
            SnapToGrid();
            selectedPiece = null;
        }
    }

    void SnapToGrid()
    {
        float snapDistance = 0.5f; // Adjust as needed

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (Vector3.Distance(selectedPiece.transform.position, initialPositions[row, col]) < snapDistance)
                {
                    selectedPiece.transform.position = initialPositions[row, col];
                    // Check if the piece is in the correct position and perform any additional actions
                    // For example, you can check if all pieces are in the correct position to consider the puzzle solved
                    return;
                }
            }
        }

        // If the piece is not in a correct position, return it to its initial position
        selectedPiece.transform.position = initialPositions[Mathf.FloorToInt(selectedPiece.transform.position.y),
                                                            Mathf.FloorToInt(selectedPiece.transform.position.x)];
    }
}