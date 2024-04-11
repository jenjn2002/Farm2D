using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="Data/Tool action/Plow")]
public class PlowTile : ToolAction
{
    [SerializeField] List<TileBase> canPlow;
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController, Item item)
    {
        TileBase tilePlow = tileMapReadController.GetTileBase(gridPosition);
        if (canPlow.Contains(tilePlow) == false)
        {
            return false;
        }

        tileMapReadController.cropsManager.Plow(gridPosition);

        return true;
    }
}
