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
   float timeLeft = 30.0f;
   public Text startText;
   public Text money;
   public Text location;

   public HashSet<string> player1_permit = new HashSet<string>();
   public static List<GameObject> Alleyway_building = new List<GameObject>();
   public static List<GameObject> Luxury_building = new List<GameObject>();
   public static List<GameObject> Street_building = new List<GameObject>();

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
        // Debug.Log("hi");  
        timeLeft -= Time.deltaTime;
        startText.text = timeLeft.ToString("0");
        // Debug.Log("Countdown: " + timeLeft)
        Vector2 raycastposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(raycastposition,Vector2.zero);
        if(hit.collider!=null){
            // Debug.Log(hit.collider.transform.parent.name);
            location.gameObject.SetActive(true);
            location.text = hit.collider.transform.parent.name;
        }

        if (timeLeft < 0.0f)
        {
            enabled = false;
            //Call the consumer phase code here and change the value he recieved in money.
            // Debug.Log("Countdown: " + timeLeft);
        }


          if(Input.GetMouseButtonDown(0)){
               
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
            
            
            if(hit.collider!=null && player1_permit.Contains(hit.collider.gameObject.name)){

                hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.green;

                 if(hit.collider.transform.parent.gameObject.name=="Luxury"){
                     money.text = (int.Parse(money.text)-100).ToString();
                 }
                 else if(hit.collider.transform.parent.gameObject.name=="Alleyway"){
                     money.text = (int.Parse(money.text)-70).ToString();
                 }
                 else{
                    money.text = (int.Parse(money.text)-50).ToString();
                 }
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
                    
                    if(hit.collider.transform.parent.gameObject.name=="Luxury"){
                        Luxury_building.Add(hit.collider.gameObject);
                        Debug.Log(money.text);
                        money.text = (int.Parse(money.text)-50).ToString();
                    }
                    else if(hit.collider.transform.parent.gameObject.name=="Alleyway"){
                        Alleyway_building.Add(hit.collider.gameObject);
                        money.text = (int.Parse(money.text)-30).ToString();
                    }
                    else{
                        Street_building.Add(hit.collider.gameObject);
                        money.text = (int.Parse(money.text)-25).ToString();
                    }

                    // foreach(GameObject l in Luxury_building){
                    //     Debug.Log(l.name);
                    // }

                    hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_f";
                
                 }
                 else{
                        GameObject building=Instantiate(prefab_buildingG,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;

                        building_g = false;
                        hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_g";
                        
                        if(hit.collider.transform.parent.gameObject.name=="Luxury"){
                            Luxury_building.Add(hit.collider.gameObject);
                            money.text = (int.Parse(money.text)-80).ToString();
                        }
                        else if(hit.collider.transform.parent.gameObject.name=="Alleyway"){
                            Alleyway_building.Add(hit.collider.gameObject);
                            money.text = (int.Parse(money.text)-60).ToString();
                        }
                        else{
                            Street_building.Add(hit.collider.gameObject);
                            money.text = (int.Parse(money.text)-55).ToString();
                        }
                }


                
            }

            // button_g.gameObject.SetActive(false);
            // button_f.gameObject.SetActive(false);
            // tile.gameObject.SetActive(true);
            
    }

    public void start_next_round(){

        enabled = true;
        timeLeft = 30.0f;
        Debug.Log("Enabled");
    }

   


}
