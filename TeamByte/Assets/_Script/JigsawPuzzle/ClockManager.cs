using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockManager : MonoBehaviour
{
    public List<Texture2D> imageTextures;
    public Transform levelSelectPanel;
    public Image levelSelectPrefab;
    public Transform gameHolder;

    public List<Transform> pieces;
    private Vector2Int dimensions;
    private int piecesNum = 9;
    private float width;
    private float height;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Texture2D texture in imageTextures) 
        {
            Image image = Instantiate(levelSelectPrefab, levelSelectPanel);
            image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            image.GetComponent<Button>().onClick.AddListener(delegate { StartGame(texture); });
        }
    }

    public void StartGame(Texture2D jigsawTex) 
    {
        levelSelectPanel.gameObject.SetActive(false);

        dimensions = GetDimensions(jigsawTex, piecesNum);

        CreatePieces(jigsawTex);
    }

    private void CreatePieces(Texture2D jigsawTex)
    {
        height = 1f / dimensions.y;
        float aspect = (float)jigsawTex.width / jigsawTex.height;
        width = aspect / dimensions.x;

        for (int row = 0; row < dimensions.y; row++)
        {
            for (int col = 0; col < dimensions.x; col++)
            {
                Transform piece = Instantiate(piecePrefab, gameHolder);
                piece.localPosition = new Vector3((-width * dimensions.x / 2) + (width * col) + (width / 2),
                (-height * dimensions.y / 2) + (height * row) + (height / 2), -1);

                piece.localScale = new Vector3(width, height, 1f);
                piece.name = $"Piece{(row * dimensions.x) + col}";
                pieces.Add( piece );
            }
        }

    }

    Vector2Int GetDimensions(Texture2D jigsawTex, int piecesNum)
    {
       Vector2Int dimensions = Vector2Int.zero;

        if(jigsawTex.width < jigsawTex.height) 
        {
            dimensions.x = piecesNum;
            dimensions.y = (piecesNum * jigsawTex.height) / jigsawTex.width;
        }
        else
        {
            dimensions.x = (piecesNum * jigsawTex.width) / jigsawTex.height;
            dimensions.y = piecesNum;
        }
        return dimensions;
    }
}
