using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Tilemaps;

public class MapEditor : MonoBehaviour
{

    public Sprite test123;

    // Detta script gör inget i dagens läge
    public static MapEditor instance;


    public TileBase nothing;
    public Grid grid;
    public Tilemap currentTilemap;

    float pitch = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        GetCurrentTile(new Vector2(1, 1));
    }

    public Vector2 GetCurrentTile(Vector2 posToCheck)
    {
        float x = currentTilemap.tileAnchor.x;
        float y = currentTilemap.tileAnchor.y;

        Vector3Int vectorInt = currentTilemap.WorldToCell(new Vector2(posToCheck.x, posToCheck.y));

        Vector2 vector = currentTilemap.CellToWorld(vectorInt);
        vector = new Vector2(vector.x + x, vector.y + y);

        return vector;
    }

    public Vector3Int GetCurrentTileInt(Vector2 posToCheck)
    {


        Vector3Int vectorInt = currentTilemap.WorldToCell(new Vector2(posToCheck.x, posToCheck.y));

        return vectorInt;
    }

    public void DestroyTile(Vector2 posToCheck)
    {

        Vector3Int vectorInt = currentTilemap.WorldToCell(new Vector3(posToCheck.x, posToCheck.y, 0));

        currentTilemap.SetTile(vectorInt, null);

    }

    public void PlaySound(AudioClip sound, float clipVolume)
    {
        AudioSource audioS = transform.gameObject.AddComponent<AudioSource>();
        audioS.clip = sound;
        audioS.pitch = pitch;
        audioS.volume = clipVolume;
        pitch += 0.1f;
        audioS.Play();


        Destroy(audioS, audioS.clip.length);
    }
}
