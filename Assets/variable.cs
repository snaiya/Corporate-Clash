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

    void Start()
    {
        // sample s1 = new sample();
        // s1.New();

        foreach (KeyValuePair<string, List<GameObject>> kvp in Player2){
            // Debug.Log(kvp.Key);

            foreach (GameObject g in kvp.Value) {
                // Debug.Log(g.name);
                
            }
            
        }
        //Debug.Log(Mapping);

    }

    // Update is called once per frame
    void Update()
    {

    }
}