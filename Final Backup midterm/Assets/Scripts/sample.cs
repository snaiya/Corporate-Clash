/* LAND ALLOCATION SCRIPT */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample : MonoBehaviour
{
    //declare a Gameobject area
    public GameObject area;

    System.Random r = new System.Random();
    
    //called from BuildingCreate.cs
    public void New()
    {
        //array fo strings containing primary areas
        string[] areaType = new string[] {"Luxury", "Alleyway", "Street"};

        //array storing total number of area in each areaType
        int[] total_tiles_in_areaType = new int[] {24, 44, 72};

        //array storing total number of tiles to be allocated in each area cumulatively for all the players 
        int[] total_tiles_to_assign = new int[] {4, 6, 8};
 
        //loop for each areaType
        for (int i = 0; i < 3; i++)
        {
            //fetch the GameObject with name areaType[i]
            area = GameObject.Find(areaType[i]);

            //loop for the total tiles belonging to areaType[i]
            for (int x = 0; x < total_tiles_in_areaType[i]; x++)
            {
                //get all the tiles in area and add it to the list
                variable.tiles_in_area.Add(area.transform.GetChild(x).gameObject);
            }

            //randomly allocate tiles according to the number of tiles to be assigned from the list of tile Gameobjects in an area
            randomizeTile(total_tiles_to_assign[i]);
            
            //map all the tiles with the area they belong to
            // variable.Mapping.Add(areaType[i], variable.tiles_in_area);
            if(variable.Mapping.ContainsKey(areaType[i]))        
            {            
                variable.Mapping[areaType[i]].AddRange(variable.tiles_in_area);       
                }else{
                               variable.Mapping.Add(areaType[i], variable.tiles_in_area);       
                               }             
            
            variable.tiles_in_area.Clear();
        }
    }

    public void randomizeTile(int total_tiles)
    {
        //declare a temporary list of GameObject temp_tile
        List<GameObject> temp_tile = new List<GameObject>();

        //loop while the list doesnot contain required number of tiles
        while (temp_tile.Count < total_tiles)
        {
            //randomly find a tile
            int index = r.Next(0, variable.tiles_in_area.Count);

            //if it is not already allocated 
            if (!variable.tile_assign.Contains(variable.tiles_in_area[index]))
            {
                //add the tile to both global and local lists
                variable.tile_assign.Add(variable.tiles_in_area[index]);
                variable.tile_assign_2.Add(variable.tiles_in_area[index].name);
                temp_tile.Add(variable.tiles_in_area[index]);
            }
        }

        //color the allocated tile according to the player id
        colorTile(total_tiles);

        //clear the local list
        temp_tile.Clear();
    }
        
    public void colorTile(int x)
    {
        string s = "";

        for (int i = 0; i < variable.tile_assign.Count; i++)
        {
            if(x == 4)
            {
                s = "Luxury";
            }
            else if(x == 6)
            {    
                s = "Alleyway";
            }
            else
            {
                s = "Street";
            }
            
            GameObject temp = variable.tile_assign[i];
            
            if (i % 2 == 0)
            {
                //add the assigned tiles to player 1 list and color it red
                variable.p1.Add(temp);
                //Debug.Log("Yess");
                temp.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else 
            {
                //add the assigned tiles to player 2 list and color it red
                variable.p2.Add(temp);
                //Debug.Log("Yess");
                //temp.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
        
        //map tiles with area for player1
        if(variable.Player1.ContainsKey(s))
        {
            variable.Player1[s].AddRange(variable.p1);
        }
        else
        {
            variable.Player1.Add(s,variable.p1);
        }
        
        //map tiles with area for player2
        if(variable.Player2.ContainsKey(s))
        {
            variable.Player2[s].AddRange(variable.p2);
        }
        else
        {
            variable.Player2[s] = variable.p2;
        }
    }
}