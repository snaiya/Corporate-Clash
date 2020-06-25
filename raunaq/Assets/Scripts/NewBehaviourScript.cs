using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // private Vector3 screenBounds;
    public GameObject consumer;
    public float time=3.0f;
    // Start is called before the first frame update
    void Start()
    {
        // GameObject board = GameObject.Find("Tiles");
        for(int i =0 ; i<15;i++){
             GameObject c = Instantiate(consumer) as GameObject;
             c.transform.position = new Vector2(Random.Range(-45.0f,40.0f),Random.Range(-39.0f,33.0f));
        }
		clusters c1 = new clusters();
		c1.assign_bots_to_area();
		variable.updateBuildingCount();
		salesreport.countBuildingTypes();
        

    }
    private void spawnConsumer(){
       

    }
    // Update is called once per frame
    void Update()
    {
         
        }
}

