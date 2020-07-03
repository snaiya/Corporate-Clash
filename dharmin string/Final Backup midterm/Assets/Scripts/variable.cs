 /*
 * THIS IS A MASTER VARIABLES SCRIPT. ONLY FETCH DATA FROM THESE
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variable : MonoBehaviour
{
    /* gets populated in sample.cs */ 
    // Main mapping of which tiles belong to which area
    public static Dictionary<string, List<GameObject>> Mapping = new Dictionary<string, List<GameObject>>();

    public static Dictionary<string, List<string>> Mapping_name = new Dictionary<string, List<string>>();


    //Mapping of list of tiles allocated in which area for Player1
    public static Dictionary<string, List<GameObject>> Player1 = new Dictionary<string, List<GameObject>>();
    public static Dictionary<string, List<string>> Player1_name = new Dictionary<string, List<string>>();
    //Mapping of list of tiles allocated in which area for Player2
    public static Dictionary<string, List<GameObject>> Player2 = new Dictionary<string, List<GameObject>>();

    //List of tile GameObjects in a particular area
    public static List<GameObject> tiles_in_area = new List<GameObject>();
    public static List<string> tiles_in_area_name = new List<string>();

    //A global list which contains the tiles that have been assigned
    public static List<GameObject> tile_assign = new List<GameObject>();
    public static List<string> tile_assign_name = new List<string>();


    //temporary list of tiles for each round belonging to player1
    public static List<GameObject> p1 = new List<GameObject>();
    public static List<string> p1_name = new List<string>();


    //temporary list of tiles for each round belonging to player2
    public static List<GameObject> p2 = new List<GameObject>();



    /* gets populated in clusters.cs */
    //Mapping of area with list of bot_ids belonging to that area
    public static Dictionary<string, List<int>> Land = new Dictionary<string, List<int>>();

    //Mapping of how many bots belongs to which cluster in Luxury
    public static Dictionary<int, int> Luxury_cluster = new Dictionary<int, int>();
    //Mapping of how many bots belongs to which cluster in Alleyway
    public static Dictionary<int, int> Alleyway_cluster = new Dictionary<int, int>();
    //Mapping of how many bots belongs to which cluster in Street
    public static Dictionary<int, int> Street_cluster = new Dictionary<int, int>();



    /* gets populated in salesreport.cs */
    public static Dictionary<string, List<GameObject>> Alleyway_building = new Dictionary<string, List<GameObject>>();
    public static Dictionary<string, List<GameObject>> Luxury_building = new Dictionary<string, List<GameObject>>();
    public static Dictionary<string, List<GameObject>> Street_building = new Dictionary<string, List<GameObject>>();
    
    public static Dictionary<string, Dictionary<string, List<GameObject>>> BuildingDict= new  Dictionary<string, Dictionary<string, List<GameObject>>>()
    {
        {"Luxury", Luxury_building}, 
        {"Alleyway", Alleyway_building},
        {"Street", Street_building}
    };



    public static int money = 1000;

    public static bool created = false;

    public static void updateBuildingCount()
    {
        BuildingDict["Luxury"] = Luxury_building;
        BuildingDict["Alleyway"] = Alleyway_building;
        BuildingDict["Street"] = Street_building;
        
    }
}