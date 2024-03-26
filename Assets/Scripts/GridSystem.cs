using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField]
    private int width;

    [SerializeField]
    private int height;


    Tile[,] tiles;

    public Tile[,] Tiles => tiles;

    public event Action Changed;
    public event Action Created;

    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        tiles = new Tile[width, height];
        for (int i = 0; i < Tiles.GetLength(0); i++)
        {
            for (int j = 0; j < Tiles.GetLength(1); j++)
            {
                tiles[i, j] = new Tile() { x = i, y = j, tileType = TileType.None };
            }
        }
                Created?.Invoke();
    }
}

public class Tile
{
    public int x;
    public int y;
    public TileType tileType = TileType.None;
}

public enum TileType
{
    None,
    Occupied
}
