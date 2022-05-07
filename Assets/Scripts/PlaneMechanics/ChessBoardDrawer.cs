using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardDrawer : MonoBehaviour
{
    [SerializeField] private Material _whiteMaterial;
    [SerializeField] private Material _blackMaterial;
    [SerializeField] private GameObject _tile; 
    void Start()
    {
        DrawTiles(_whiteMaterial, _blackMaterial, CreateBoard());
    }

    private GameObject[,] CreateBoard()
    {
        int horizontalLenght = 8;
        int verticalLength = 8;
        GameObject[,] board = new GameObject[verticalLength, horizontalLenght];
        
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                GameObject tile = Instantiate(_tile, new Vector3(i, 0, j), Quaternion.identity, transform);
                board[i, j] = tile;
            }
        }

        return board;
    }

    private void DrawTiles(Material white, Material black, GameObject[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if ((i + j) % 2 == 0)
                {
                    board[i, j].GetComponent<Renderer>().material = white;
                }
                else
                {
                    board[i, j].GetComponent<Renderer>().material = black;
                }
            }
        }
    }
}
