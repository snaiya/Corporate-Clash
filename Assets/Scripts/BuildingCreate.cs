using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingCreate : MonoBehaviour
{
  
//    public RaycastHit2D hit =  Physics2D.Raycast(Vector2.zero,Vector2.zero);

   public bool building_f = false;
   public bool building_g = false;
   public bool is_tile = false;
   

   public GameObject prefab_buildingG;
   public GameObject prefab_buildingF;
   public Button tile;
   public Button button_f;
   public Button button_g;

   public string building_placed = null;

   public HashSet<string> player1_permit = new HashSet<string>();
   

    void Start(){
        //  tile.gameObject.SetActive(true);
        //  button_f.gameObject.SetActive(false);
        //  button_g.gameObject.SetActive(false);
            Debug.Log("Started");

            sample s1 = new sample();
            s1.New();

             foreach (KeyValuePair<string, List<GameObject>> kvp in variable.Player1)
                {
                    //Debug.Log(kvp.Key);

                    foreach (GameObject g in kvp.Value)
                    {
                        player1_permit.Add(g.name);
                        
                    }
                }
           
            
     }

    void Update()
    { 
            // tile_selected= false;
          //According to land permit set the conditons in if
           

          if(Input.GetMouseButtonDown(0) ){
                
        
             if(is_tile==true){ 
                tile_placement();
             }

            if(building_f==true || building_g==true){
                initiate_building();   
            }
            
        }
        

    }
        public void tile_placement(){
       
        
            // Touch touch = Input.touches[0];
            // Vector2 raycastposition = Camera.main.ScreenToWorldPoint(touch.position);
            // RaycastHit2D hit = Physics2D.Raycast(raycastposition,Vector2.zero);
            Debug.Log("Entered");
             Vector2 raycastposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             RaycastHit2D hit = Physics2D.Raycast(raycastposition,Vector2.zero);
            
            if(hit.collider!=null && player1_permit.Contains(hit.collider.name)){
                
                hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                // button_f.gameObject.gameObject.SetActive(true);
                // button_g.gameObject.SetActive(true);
                // tile.gameObject.SetActive(false);
                is_tile = false;
            } 
    
        }

    public void create_building_f(){
       
           building_f = true;
           building_g = false;
           is_tile = false;
    }

    public void create_building_g(){
       
           building_g = true;
           is_tile = false;
           building_f = false;
    }

    public void place_tile(){
        is_tile = true;
        building_f = false;
        building_g = false;
    }

    public void initiate_building(){
        //  Touch touch = Input.touches[0];
        //     Vector2 raycastposition = Camera.main.ScreenToWorldPoint(touch.position);
        //     RaycastHit2D hit = Physics2D.Raycast(raycastposition,Vector2.zero);

             Vector2 raycastposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             RaycastHit2D hit = Physics2D.Raycast(raycastposition,Vector2.zero);


             if(hit.collider!=null && hit.collider.gameObject.GetComponent<SpriteRenderer>().color==Color.green && hit.collider.gameObject.GetComponent<tile_individual>().building_placed.Equals("") ){
                 if(building_f==true){

                GameObject building=Instantiate(prefab_buildingF,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;
                building_f = false;
                Debug.Log(hit.collider.gameObject.name);
                hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_f";
                
                 }
                 else{
                     GameObject building=Instantiate(prefab_buildingG,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;
                    
                     building_g = false;
                     building_placed = "building_g";
                     hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_g";
                     
                 }


                
            }

            // button_g.gameObject.SetActive(false);
            // button_f.gameObject.SetActive(false);
            // tile.gameObject.SetActive(true);
            
    }


}
