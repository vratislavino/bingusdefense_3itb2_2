using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDisplay : MonoBehaviour
{
    [SerializeField]
    private GridSystem gridSystem;

    [SerializeField] private TileDisplay TilePrefab;

    [SerializeField]
    private float tileSize;

    TileDisplay[,] TileViews;

    private void Awake()
    {
        gridSystem.Changed += OnGridChanged;
        gridSystem.Created += OnGridCreated;
    }

    private void OnGridCreated()
    {
        TileViews = new TileDisplay[gridSystem.Tiles.GetLength(0), gridSystem.Tiles.GetLength(1)];
        for(int i = 0; i < TileViews.GetLength(0); i++)
        {
            for(int j = 0; j < TileViews.GetLength(1); j++)
            {
                TileViews[i, j] = Instantiate(TilePrefab, transform);
                TileViews[i, j].transform.localPosition = new Vector3(i * tileSize, 0, -j * tileSize);
                TileViews[i, j].tileData = gridSystem.Tiles[i, j];
            }
        }
    }

    public void OnGridChanged() {
        
    }
}
