using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public class Puzzle
    {
        public int width;
        public int height;
        public piece[,] pieces;
    }


    public Puzzle puzzle;


    void Start()
    {

        Vector2 dimensions = CheckDimensions();

        puzzle.width = (int)dimensions.x;
        puzzle.height = (int)dimensions.y;

        puzzle.pieces = new piece[puzzle.width, puzzle.height];

        foreach (var piece in GameObject.FindGameObjectsWithTag("Piece"))
        {

            puzzle.pieces[(int)piece.transform.position.x, (int)piece.transform.position.y] = piece.GetComponent<piece>();
        }

        foreach (var item in puzzle.pieces)
        {

            Debug.Log(item.gameObject.name);
        }


        Shuffle();
    }


    void Shuffle()
    {
        foreach (var piece in puzzle.pieces)
        {
            int k = Random.Range(0, 4);
            for (int i = 0; i < k; i++)
            {
                piece.RotatePiece(); // Assuming RotatePiece is a public method of the piece class.
            }
        }
    }


    Vector2 CheckDimensions()
    {
        Vector2 aux = Vector2.zero;

        GameObject[] pieces = GameObject.FindGameObjectsWithTag("Piece");

        foreach (var p in pieces)
        {
            if (p.transform.position.x > aux.x)
                aux.x = p.transform.position.x;

            if (p.transform.position.y > aux.y)
                aux.y = p.transform.position.y;
        }

        aux.x++;
        aux.y++;

        return aux;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
