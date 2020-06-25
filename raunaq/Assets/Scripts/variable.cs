/*
 * THIS IS A MASTER VARIABLES SCRIPT. ONLY FETCH DATA FROM THESE
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variable : MonoBehaviour
{
    // Main mapping of which tiles belong to which area
    public static Dictionary<string, List<GameObject>> Mapping = new Dictionary<string, List<GameObject>>();

    //Mapping of which tile belong to which player in which area
    public static Dictionary<string, List<GameObject>> Player1 = new Dictionary<string, List<GameObject>>();
    public static Dictionary<string, List<GameObject>> Player2 = new Dictionary<string, List<GameObject>>();
    //public static Dictionary<string, List<GameObject>> Assigned_Street = new Dictionary<string, List<GameObject>>();
    // Start is called before the first frame update

    public static Dictionary<string, List<int>> Land = new Dictionary<string, List<int>>();

    public static Dictionary<int, int> Luxury_cluster = new Dictionary<int, int>();
    public static Dictionary<int, int> Alleyway_cluster = new Dictionary<int, int>();
    public static Dictionary<int, int> Street_cluster = new Dictionary<int, int>();

    public static Dictionary<string, List<GameObject>> Alleyway_building = new Dictionary<string, List<GameObject>>();
    public static Dictionary<string, List<GameObject>> Luxury_building = new Dictionary<string, List<GameObject>>();
    public static Dictionary<string, List<GameObject>> Street_building = new Dictionary<string, List<GameObject>>();
	
	public static Dictionary<string, Dictionary<string, List<GameObject>>> BuildingDict= new  Dictionary<string, Dictionary<string, List<GameObject>>>(){{"Luxury", Luxury_building}, {"Alleyway", Alleyway_building}
	,{"Street", Street_building}};


    

    public static void updateBuildingCount()
	{
		BuildingDict["Luxury"] = Luxury_building;
		BuildingDict["Alleyway"] = Alleyway_building;
		BuildingDict["Street"] = Street_building;
		
	}
	void Start()
    {
        // sample s1 = new sample();
        // s1.New();

	
        //foreach (KeyValuePair<int, int> kvp in Alleyway_cluster){
             //Debug.Log(kvp.Key);
	//Debug.Log(kvp.Value);
             //foreach (GameObject g in kvp.Value) {
                 //Debug.Log(g.name);
                
             //}
            
        }
        //Debug.Log(Mapping);

    

    // Update is called once per frame
    void Update()
    {

    }
}