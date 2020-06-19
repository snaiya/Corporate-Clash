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
    

    void Start()
    {
        // sample s1 = new sample();
        // s1.New();

clusters c1 = new clusters();
c1.assign_bots_to_area();
        foreach (KeyValuePair<int, int> kvp in Alleyway_cluster){
             Debug.Log(kvp.Key);
Debug.Log(kvp.Value);
            // foreach (GameObject g in kvp.Value) {
            //     // Debug.Log(g.name);
                
            // }
            
        }
        //Debug.Log(Mapping);

    }

    // Update is called once per frame
    void Update()
    {

    }
}