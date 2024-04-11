using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MarkerManager : MonoBehaviour
{
    [SerializeField] Tilemap targetTileMap;
    [SerializeField] TileBase tile;

    public Vector3Int markedCellPosition;
    Vector3Int oldCellPosition;
    bool show;

    private void Update()
    {
        if (show == false)
        {
            return;
        }
        targetTileMap.SetTile(oldCellPosition, null);
        targetTileMap.SetTile(markedCellPosition, tile);
        oldCellPosition = markedCellPosition;
    }

    internal void Show(bool selectable)
    {
        show = selectable;
        targetTileMap.gameObject.SetActive(show);
    }
}
