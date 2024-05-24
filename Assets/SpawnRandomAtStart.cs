using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnRandomAtStart : MonoBehaviour
{
    [SerializeField] Tilemap tileMap;
    // Start is called before the first frame update
    void Start()
    {
        BoundsInt bounds = tileMap.cellBounds;
        Vector3Int randomPos = new Vector3Int(
            Random.Range(bounds.xMin, bounds.xMax),
            Random.Range(bounds.yMin, bounds.yMax), 0);

        Vector3 worldPos = tileMap.CellToWorld(randomPos);

        gameObject.transform.position = worldPos;
    }


    
}
