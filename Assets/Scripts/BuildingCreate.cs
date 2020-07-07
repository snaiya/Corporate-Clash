using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;


public class BuildingCreate : MonoBehaviour
{
  
    public bool building_f = false;
    public bool building_g = false;
    public bool is_tile = false;


    public GameObject prefab_buildingG;
    public GameObject prefab_buildingF;
    public Button tile;
    public Button button_f;
    public Button button_g;
    float timeLeft = 10.0f;
    public Text startText;
    public Text money;
    public Text location;
    public Text money_individual;

    GameObject tile_color;

    public GameObject Insufficient_balance;
    
    public HashSet<string> player1_permit = new HashSet<string>();

    public void Start()
    {
        money.text = variable.money.ToString();
        Insufficient_balance.SetActive(false);
        for (int i = 0; i <=23; i++) 
        {
            tile_color = GameObject.Find("LuxuryTile"+i.ToString());
            tile_color.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
       
       for (int i = 0; i <=43; i++) 
        {
            tile_color = GameObject.Find("Alleyway"+i.ToString());
            tile_color.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        }

       for (int i = 0; i <=71; i++) 
        {
            tile_color = GameObject.Find("Street"+i.ToString());
            tile_color.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        if (variable.round%3 == 0) 
        {
            sample s1 = new sample();
            s1.clearPlayer();
            s1.New();
        }
        
        foreach (KeyValuePair<string, List<string>> kvp in variable.Player1)
        {
            foreach (string g in kvp.Value)
            {
                GameObject obj = GameObject.Find(g);
                obj.GetComponent<SpriteRenderer>().color = Color.red;
                player1_permit.Add(g);
                
            }
        }

        foreach(KeyValuePair<string, List<string>> kvp in variable.tiles_bought)
        {
            foreach(string s in kvp.Value)
            {
                GameObject pqr = GameObject.Find(s);
                pqr.GetComponent<SpriteRenderer>().color = Color.green;
            }    
        }
    }
    
    private int i=0;

    void Update()
    { 
        
        if(money_individual.text != "") 
            i++;

        if(money_individual.text != "" && i>=40) 
            money_individual.text = "";

        timeLeft -= Time.deltaTime;
        startText.text = timeLeft.ToString("0");
        
        Vector2 raycastposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(raycastposition,Vector2.zero);
        
        if(hit.collider!=null)
        {
            location.gameObject.SetActive(true);
            location.text = hit.collider.transform.parent.name;
        }

        if (timeLeft <= 0)
        {
            enabled = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene("New Consumption Phase");
        }


        if(Input.GetMouseButtonDown(0))
        {

            if(is_tile==true)
            { 
                tile_placement();
            }

            if(building_f==true || building_g==true)
            {
                initiate_building();   
            }    
        }
    }
    
    public void tile_placement()
    {
        Vector2 raycastposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(raycastposition,Vector2.zero);
               
        if(hit.collider!=null && player1_permit.Contains(hit.collider.gameObject.name) && !variable.location_check.Contains(hit.collider.gameObject.name))
        {
            if(hit.collider.transform.parent.gameObject.name=="Luxury")
            {
                i = 0;
            
                money_individual.text = "- $100";

                int temp = variable.money - 100;

                add_to_variableTilesBought(hit, "Luxury", temp, 100);
            }
            else if(hit.collider.transform.parent.gameObject.name=="Alleyway")
            {
                i = 0;
                
                money_individual.text = "- $70";
                
                int temp = variable.money - 70;

                add_to_variableTilesBought(hit, "Alleyway", temp, 70);
            }
            else
            {
                i = 0;
                
                money_individual.text = "- $50";
                
                int temp = variable.money - 50;
                
                add_to_variableTilesBought(hit, "Street", temp, 50);
            } 
            
            is_tile = false;
        } 
    }

    public void add_to_variableTilesBought(RaycastHit2D hit, string s, int temp, int tile_cost)
    {
        if (temp >= 0)
        {
            hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.green;

            //adding the tiles to the list that player purchased
            if (variable.tiles_bought.ContainsKey(s))
            {
                variable.tiles_bought[s].Add(hit.collider.gameObject.name);
            }
            else 
            {
                variable.tiles_bought.Add(s, new List<string> {hit.collider.gameObject.name});
            }
        
            variable.money -= tile_cost;
            money.text = variable.money.ToString();                
        }
        else
        {
            Insufficient_balance.SetActive(true);
        }
    }

    public void create_building_f()
    {
       building_f = true;
       building_g = false;
       is_tile = false;
    }

    public void create_building_g()
    {   
       building_g = true;
       is_tile = false;
       building_f = false;
    }

    public void place_tile()
    {
        is_tile = true;
        building_f = false;
        building_g = false;
    }

    void add_to_variableBuilding(RaycastHit2D hit, int temp, string sbuilding, string btype, int bcost)
    {
        
    }

    public void initiate_building()
    {
        
        Vector2 raycastposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(raycastposition,Vector2.zero);

        if(hit.collider!=null && hit.collider.gameObject.GetComponent<SpriteRenderer>().color==Color.green && hit.collider.gameObject.GetComponent<tile_individual>().building_placed.Equals("") && !variable.location_check.Contains(hit.collider.gameObject.name) )
        {
            if(building_f==true)
            {   
                if(hit.collider.transform.parent.gameObject.name=="Luxury")
                {
                    i = 0;
                    
                    money_individual.text = "- $50";

                    int temp = variable.money - 50;

                    if (temp >= 0)
                    {
                        GameObject building=Instantiate(prefab_buildingF,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;
                        building_f = false;
                        building.tag = "Building";
                        GameObject.DontDestroyOnLoad(building);
                
                        hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_f";
                        
                        variable.money -= 50;
                        money.text = variable.money.ToString();

                        if(!variable.location_check.Contains(hit.collider.gameObject.name))
                        {
                            variable.location_check.Add(hit.collider.gameObject.name);
                        }

                        if (variable.Luxury_building.ContainsKey("f"))
                        {
                            variable.Luxury_building["f"].Add(hit.collider.gameObject.name);
                        }
                        else
                        {
                            variable.Luxury_building.Add("f", new List<string> {hit.collider.gameObject.name});
                        }  
                    }
                    else
                    {
                        // Debug.Log("Insufficient balance to place building");
                        Insufficient_balance.SetActive(true);
                    }
                }
                else if(hit.collider.transform.parent.gameObject.name=="Alleyway")
                {
                    i = 0;
                    
                    money_individual.text = "- $50";

                    int temp = variable.money - 50;
                
                    if (temp >= 0)
                    {
                        GameObject building=Instantiate(prefab_buildingF,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;
                        building_f = false;
                        building.tag = "Building";
                        GameObject.DontDestroyOnLoad(building);
                
                        hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_f";
                        
                        variable.money -= 50;
                        money.text = variable.money.ToString();

                        if(!variable.location_check.Contains(hit.collider.gameObject.name))
                        {
                            variable.location_check.Add(hit.collider.gameObject.name);
                        }
                        
                        if (variable.Alleyway_building.ContainsKey("f"))
                        {
                            variable.Alleyway_building["f"].Add(hit.collider.gameObject.name);
                        }
                        else
                        {
                            variable.Alleyway_building.Add("f", new List<string> {hit.collider.gameObject.name});
                        }
                    }
                    else
                    {
                        // Debug.Log("Insufficient balance to place building");
                        Insufficient_balance.SetActive(true);
                    }
                }
                else
                {
                    i = 0;
                    
                    money_individual.text = "- $50";

                    int temp = variable.money - 50;
                
                    if (temp >= 0)
                    {
                        GameObject building=Instantiate(prefab_buildingF,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;
                        building_f = false;
                        building.tag = "Building";
                        GameObject.DontDestroyOnLoad(building);
                
                        hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_f";
                        
                        variable.money -= 50;
                        money.text = variable.money.ToString();

                        if(!variable.location_check.Contains(hit.collider.gameObject.name))
                        {
                            variable.location_check.Add(hit.collider.gameObject.name);
                        }

                        if (variable.Street_building.ContainsKey("f"))
                        {
                            variable.Street_building["f"].Add(hit.collider.gameObject.name);
                        }
                        else
                        {
                            variable.Street_building.Add("f", new List<string> {hit.collider.gameObject.name});
                        }
                    }
                    else
                    {
                        // Debug.Log("Insufficient balance to place building");
                        Insufficient_balance.SetActive(true);
                    }
                }
            }
            else
            {
                if(hit.collider.transform.parent.gameObject.name=="Luxury")
                {
                    i = 0;
                    
                    money_individual.text = "- $70";

                    int temp = variable.money - 70;
                
                    if (temp >= 0)
                    {
                        GameObject building=Instantiate(prefab_buildingG,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;
                        GameObject.DontDestroyOnLoad(building);
                        building_g = false;

                        hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_g";
                        
                        variable.money -= 70;
                        money.text = variable.money.ToString();

                        if(!variable.location_check.Contains(hit.collider.gameObject.name))
                        {
                            variable.location_check.Add(hit.collider.gameObject.name);
                        }

                        if (variable.Luxury_building.ContainsKey("g"))
                        {
                            variable.Luxury_building["g"].Add(hit.collider.gameObject.name);
                        }
                        else
                        {
                            variable.Luxury_building.Add("g", new List<string> {hit.collider.gameObject.name});
                        }
                    }
                    else
                    {
                        // Debug.Log("Insufficient balance to place building");
                        Insufficient_balance.SetActive(true);
                    }
                }
                else if(hit.collider.transform.parent.gameObject.name=="Alleyway")
                {
                    i = 0;
                    
                    money_individual.text = "- $70";

                    int temp = variable.money - 70;
                
                    if (temp >= 0)
                    {
                        GameObject building=Instantiate(prefab_buildingG,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;
                        GameObject.DontDestroyOnLoad(building);
                        building_g = false;

                        hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_g";
                        
                        variable.money -= 70;
                        money.text = variable.money.ToString();

                        if(!variable.location_check.Contains(hit.collider.gameObject.name))
                        {
                            variable.location_check.Add(hit.collider.gameObject.name);
                        }

                        if (variable.Alleyway_building.ContainsKey("g"))
                        {
                            variable.Alleyway_building["g"].Add(hit.collider.gameObject.name);
                        }
                        else
                        {
                            variable.Alleyway_building.Add("g", new List<string> {hit.collider.gameObject.name});
                        }
                    }
                    else
                    {
                        // Debug.Log("Insufficient balance to place building");
                        Insufficient_balance.SetActive(true);
                    }
                }
                else
                {
                    i = 0;
                    
                    money_individual.text = "- $70";

                    int temp = variable.money - 70;
                
                    if (temp >= 0)
                    {
                        GameObject building=Instantiate(prefab_buildingG,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;
                        GameObject.DontDestroyOnLoad(building);
                        building_g = false;

                        hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_g";
                        
                        variable.money -= 70;
                        money.text = variable.money.ToString();

                        if(!variable.location_check.Contains(hit.collider.gameObject.name))
                        {
                            variable.location_check.Add(hit.collider.gameObject.name);
                        }

                        if (variable.Street_building.ContainsKey("g"))
                        {
                            variable.Street_building["g"].Add(hit.collider.gameObject.name);
                        }
                        else
                        {
                            variable.Street_building.Add("g", new List<string> {hit.collider.gameObject.name});
                        }
                    }
                    else
                    {
                        // Debug.Log("Insufficient balance to place building");
                        Insufficient_balance.SetActive(true);
                    }
                }
            }   
        }    
    }

    public void start_next_round()
    {
        enabled = true;
        timeLeft = 30.0f;
        Debug.Log("Enabled");
    }
}
