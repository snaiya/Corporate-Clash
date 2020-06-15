using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Playermovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Grid grid;
    public Tilemap myTileMap;

    void start(){
        Debug.Log("Stsrted");
    }

    void update()
    {
        if (Input.GetMouseButtonDown(0))
     {
         //Get position of the mouseclick
         Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         //Convert position of the mouseclick to the position of the tile located at the mouseclick
         Vector3Int coordinate = grid.WorldToCell(mouseWorldPos);
         //Display tile position in log
         Debug.Log(coordinate);
         //Display the sprite value of the tile in log *SUCCESS*
         Debug.Log(myTileMap.GetSprite(coordinate));
     }
    }
}
