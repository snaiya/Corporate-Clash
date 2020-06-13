using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public Grid grid;
    public Tilemap tilemap;

    void Start()
    {
  
        Debug.Log("Started");
   
    }

    void Update(){

        
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var noZ = new Vector3(pos.x, pos.y);
        Vector3Int mouseCell = grid.WorldToCell(noZ);
        //Debug.Log(mouseCell);
        //var color = tilemap.GetColor(mouseCell);
        //Debug.Log(color);
        

         if (Input.GetMouseButtonDown(0))
        {
         tilemap.SetTileFlags(mouseCell, TileFlags.None);
         tilemap.SetColor(mouseCell,Color.red);
         Debug.Log(mouseCell);
            placeBuilding();



        }


    // Update is called once per frame
}

    private void placeBuilding()
    {
        
    }

}
