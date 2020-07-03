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
                variable.tiles_in_area_name.Add(area.transform.GetChild(x).gameObject.name);
            }
            //UnityEngine.Debug.Log("DHARMIN");
            foreach (string s in variable.tiles_in_area_name)
            {
                //UnityEngine.Debug.Log(s);
            }
            //randomly allocate tiles according to the number of tiles to be assigned from the list of tile Gameobjects in an area
            randomizeTile(total_tiles_to_assign[i]);
            
            //map all the tiles with the area they belong to
            //variable.Mapping_name.Add(areaType[i], variable.tiles_in_area_name);
            if (variable.Mapping_name.ContainsKey(areaType[i]))
            {
                variable.Mapping_name[areaType[i]].AddRange(variable.tiles_in_area_name);
            }
            else
            {
                variable.Mapping_name.Add(areaType[i], variable.tiles_in_area_name);
            }

            

        //clear the list for next area
        variable.tiles_in_area_name.Clear();
        }
    }

    public void randomizeTile(int total_tiles)
    {
        //declare a temporary list of GameObject temp_tile
        List<GameObject> temp_tile = new List<GameObject>();

        //loop while the list doesnot contain required number of tiles
        while (temp_tile.Count < total_tiles)
        {
           // UnityEngine.Debug.Log("DHARMIN");
            //randomly find a tile
            int c = 0;
            foreach (string s in variable.tiles_in_area_name)
            {
                c += 1;
                //UnityEngine.Debug.Log("The options are ");
                //UnityEngine.Debug.Log(s);

            }
            int index = r.Next(0, c);

            //if it is not already allocated 
            if (!variable.tile_assign_name.Contains(variable.tiles_in_area_name[index]))
            {
                //add the tile to both global and local lists
                variable.tile_assign_name.Add(variable.tiles_in_area_name[index]);
                //UnityEngine.Debug.Log("The tiles assigned are " + variable.tiles_in_area_name[index]);
                temp_tile.Add(GameObject.Find(variable.tiles_in_area_name[index]));
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

        for (int i = 0; i < variable.tile_assign_name.Count; i++)
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
            foreach (string var in variable.tile_assign_name)
            {
               // UnityEngine.Debug.Log(var);
            }
            GameObject temp = GameObject.Find(variable.tile_assign_name[i]);
            
            if (i % 2 == 0)
            {
                //add the assigned tiles to player 1 list and color it red
                variable.p1_name.Add(temp.name);
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
        if(variable.Player1_name.ContainsKey(s))
        {
            variable.Player1_name[s].AddRange(variable.p1_name);
        }
        else
        {
            variable.Player1_name.Add(s,variable.p1_name);
        }
        
        //map tiles with area for player2
        /*if(variable.Player2_name.ContainsKey(s))
        {
            variable.Player2_name[s].AddRange(variable.p2_name);
        }
        else
        {
            variable.Player2_name[s] = variable.p2_name;
        }*/
    }
}