using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class NothingTile : TileBase
{
    public Sprite m_Sprite;
    public GameObject m_Prefab;
    


    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        if (m_Sprite && !Application.isPlaying)
        {
            tileData.sprite = m_Sprite;
        }
        else
        {
            tileData.sprite = null;
        }

        tileData.gameObject = m_Prefab;
        
    }
}
