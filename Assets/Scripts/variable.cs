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
    public static Dictionary<string, List<string>> Mapping = new Dictionary<string, List<string>>();

    //Mapping of list of tiles allocated in which area for Player1
    public static Dictionary<string, List<string>> Player1 = new Dictionary<string, List<string>>();
    //Mapping of list of tiles allocated in which area for Player2
    public static Dictionary<string, List<string>> Player2 = new Dictionary<string, List<string>>();    

    //List of tile GameObjects in a particular area
    public static List<string> tiles_in_area = new List<string>();

    //A global list which contains the tiles that have been assigned
    public static List<string> tile_assign = new List<string>();
    

    /* gets populated in clusters.cs */
    //Mapping of area with list of bot_ids belonging to that area
    public static Dictionary<string, List<int>> Land = new Dictionary<string, List<int>>();

    //Mapping of how many bots belongs to which cluster in Luxury
    public static Dictionary<int, int> Luxury_cluster = new Dictionary<int, int>();
    //Mapping of how many bots belongs to which cluster in Alleyway
    public static Dictionary<int, int> Alleyway_cluster = new Dictionary<int, int>();
    //Mapping of how many bots belongs to which cluster in Street
    public static Dictionary<int, int> Street_cluster = new Dictionary<int, int>();


    /* gets populated in BuildingCreate.cs */
    //Check for location
    public static HashSet<string> location_check = new HashSet<string>();
    //list of tiles player bought before new tiles allocation round
    public static Dictionary<string, List<string>> tiles_bought = new Dictionary<string, List<string>>();

    /* gets populated in salesreport.cs */
    public static Dictionary<string, List<string>> Alleyway_building = new Dictionary<string, List<string>>();
    public static Dictionary<string, List<string>> Luxury_building = new Dictionary<string, List<string>>();
    public static Dictionary<string, List<string>> Street_building = new Dictionary<string, List<string>>();
    

    public static Dictionary<string, Dictionary<string, List<string>>> BuildingDict= new  Dictionary<string, Dictionary<string, List<string>>>()
    {
        {"Luxury", Luxury_building}, 
        {"Alleyway", Alleyway_building},
        {"Street", Street_building}
    };


    public static int money = 1000;

    public static int round = 0;

    public static void updateBuildingCount()
    {
        BuildingDict["Luxury"] = Luxury_building;
        BuildingDict["Alleyway"] = Alleyway_building;
        BuildingDict["Street"] = Street_building;
        
    }
    
}