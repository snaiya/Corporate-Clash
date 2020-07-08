using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Globalization;

public class BuildingCreate : MonoBehaviour
{

    public bool building_f = false;
    public bool building_g = false;
    public bool is_tile = false;
    public GameObject Panel;
    public GameObject BldgPanel;
    public GameObject ConfirmPanel;
    public Text moneyone_go_txt;

    
    public GameObject Img;
    public GameObject prefab_buildingG;
    public GameObject prefab_buildingF;
    public Button tile;
    public Button button_f;
    public Button button_g;
    float timeLeft = 30;
    public Text startText;
    public Text money;
    public Text location;
    public Text money_individual;

    GameObject tile_color;
    public GameObject Insufficient_balance;

    public HashSet<string> player1_permit = new HashSet<string>();
    public HashSet<GameObject> player_tiles_onego = new HashSet<GameObject>();
    // public HashSet<GameObject> player_bui_onego = new HashSet<GameObject>();
    public void Start()
    {
        money.text = variable.money.ToString();
        Insufficient_balance.SetActive(false);
        Img.SetActive(true);
        for (int i = 0; i <= 23; i++)
        {
            tile_color = GameObject.Find("LuxuryTile" + i.ToString());
            tile_color.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }

        for (int i = 0; i <= 43; i++)
        {
            tile_color = GameObject.Find("Alleyway" + i.ToString());
            tile_color.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        }

        for (int i = 0; i <= 71; i++)
        {
            tile_color = GameObject.Find("Street" + i.ToString());
            tile_color.gameObject.GetComponent<SpriteRenderer>().color = new Color(76.5f, 69f, 56.90f);
        }

        if (variable.round % 3 == 0)
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

        foreach (KeyValuePair<string, List<string>> kvp in variable.tiles_bought)
        {
            foreach (string s in kvp.Value)
            {
                GameObject pqr = GameObject.Find(s);
                pqr.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }

    private int i = 0;
    private int money_onego = 0;

    void Update()
    {

        if (money_individual.text != "")
            i++;

        if (money_individual.text != "" && i >= 40)
            money_individual.text = "";

        timeLeft -= Time.deltaTime;
        startText.text = timeLeft.ToString("0");

        Vector2 raycastposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(raycastposition, Vector2.zero);

        if (hit.collider != null)
        {
            location.gameObject.SetActive(true);
            location.text = hit.collider.transform.parent.name;
        }

        if (timeLeft <0)
        {
            enabled = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene("New Consumption Phase");
        }


        if (Input.GetMouseButtonDown(0))
        {

            if (is_tile == true)
            {
                tile_placement();
            }

            if (building_f == true || building_g == true)
            {
                initiate_building();
            }
        }
        moneyone_go_txt.text = money_onego.ToString();

    }

    public void tile_placement()
    {
        Vector2 raycastposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(raycastposition, Vector2.zero);


        if (hit.collider != null && player1_permit.Contains(hit.collider.gameObject.name) && !variable.location_check.Contains(hit.collider.gameObject.name))
        {
            if (hit.collider.transform.parent.gameObject.name == "Luxury")
            {
                i = 0;

                money_individual.text = "- $100";

                int temp = variable.money - 100;

                if (temp >= 0)
                {
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    player_tiles_onego.Add(hit.collider.gameObject);
                    //adding the tiles to the list that player purchased


                    // variable.money -= 100;
                    money_onego += 100;
                    // money.text = variable.money.ToString();
                }
                else
                {
                    // Debug.Log("Insufficient balance");
                    Insufficient_balance.SetActive(true);
                }
            }
            else if (hit.collider.transform.parent.gameObject.name == "Alleyway")
            {
                i = 0;
                //money.text = (int.Parse(money.text)-70).ToString();
                money_individual.text = "- $70";

                int temp = variable.money - 70;

                if (temp >= 0)
                {
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    player_tiles_onego.Add(hit.collider.gameObject);

                    //variable.money -= 70;
                    money_onego += 70;
                    // money.text = variable.money.ToString();
                }
                else
                {
                    // Debug.Log("Insufficient balance");
                    Insufficient_balance.SetActive(true);
                }
            }
            else
            {
                i = 0;
                //money.text = (int.Parse(money.text)-50).ToString();
                money_individual.text = "- $50";

                int temp = variable.money - 50;

                if (temp >= 0)
                {
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    player_tiles_onego.Add(hit.collider.gameObject);

                    //variable.money -= 50;
                    money_onego += 50;
                    // money.text = variable.money.ToString();                
                }
                else
                {
                    // Debug.Log("Insufficient balance");
                    Insufficient_balance.SetActive(true);
                }
            }

        }
    }

    public void create_building_f()
    {
        if (BldgPanel != null)
        {
            BldgPanel.SetActive(false);
        }
        if (ConfirmPanel != null)
        {
            ConfirmPanel.SetActive(true);
        }
        building_f = true;
        building_g = false;
        is_tile = false;
    }

    public void create_building_g()
    {
        if (BldgPanel != null)
        {
            BldgPanel.SetActive(false);
        }
        if (ConfirmPanel != null)
        {
            ConfirmPanel.SetActive(true);
        }
        building_g = true;
        is_tile = false;
        building_f = false;
    }

    public void place_tile()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
        if (ConfirmPanel != null)
        {
            ConfirmPanel.SetActive(true);
        }
        is_tile = true;
        building_f = false;
        building_g = false;
    }

    public void initiate_building()
    {

        Vector2 raycastposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(raycastposition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject.GetComponent<SpriteRenderer>().color == Color.green && hit.collider.gameObject.GetComponent<tile_individual>().building_placed.Equals("") && !variable.location_check.Contains(hit.collider.gameObject.name))
        {
            if (building_f == true)
            {
                if (hit.collider.transform.parent.gameObject.name == "Luxury")
                {
                    i = 0;

                    money_individual.text = "- $50";

                    int temp = variable.money - 50;

                    if (temp >= 0)
                    {
                        hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                        // GameObject building=Instantiate(prefab_buildingF,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;
                        // building_f = false;
                        // building.tag = "Building";
                        // GameObject.DontDestroyOnLoad(building);
                        // hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_f";
                        money_onego += 50;
                        // variable.money -= 50;
                        // money.text = variable.money.ToString();
                        player_tiles_onego.Add(hit.collider.gameObject);


                    }
                    else
                    {
                        // Debug.Log("Insufficient balance to place building");
                        Insufficient_balance.SetActive(true);
                    }
                }
                else if (hit.collider.transform.parent.gameObject.name == "Alleyway")
                {
                    i = 0;

                    money_individual.text = "- $50";

                    int temp = variable.money - 50;

                    if (temp >= 0)
                    {
                        // GameObject building=Instantiate(prefab_buildingF,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;
                        // building_f = false;
                        hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                        // building.tag = "Building";
                        // GameObject.DontDestroyOnLoad(building);

                        // hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_f";
                        player_tiles_onego.Add(hit.collider.gameObject);
                        // variable.money -= 50;
                        money_onego += 50;
                        // money.text = variable.money.ToString();

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
                        hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                        // GameObject building=Instantiate(prefab_buildingF,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;
                        // building_f = false;
                        // building.tag = "Building";
                        // GameObject.DontDestroyOnLoad(building);
                        player_tiles_onego.Add(hit.collider.gameObject);
                        // hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_f";
                        money_onego += 50;
                        // variable.money -= 50;
                        // money.text = variable.money.ToString();

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
                if (hit.collider.transform.parent.gameObject.name == "Luxury")
                {
                    i = 0;

                    money_individual.text = "- $70";

                    int temp = variable.money - 70;

                    if (temp >= 0)
                    {
                        hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                        // GameObject building=Instantiate(prefab_buildingG,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;
                        // GameObject.DontDestroyOnLoad(building);
                        // building_g = false;

                        // hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_g";

                        // variable.money -= 70;
                        money_onego += 70;
                        // money.text = variable.money.ToString();
                        player_tiles_onego.Add(hit.collider.gameObject);


                    }
                    else
                    {
                        // Debug.Log("Insufficient balance to place building");
                        Insufficient_balance.SetActive(true);
                    }
                }
                else if (hit.collider.transform.parent.gameObject.name == "Alleyway")
                {

                    i = 0;

                    money_individual.text = "- $70";

                    int temp = variable.money - 70;

                    if (temp >= 0)
                    {
                        hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                        // GameObject building=Instantiate(prefab_buildingG,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;
                        // GameObject.DontDestroyOnLoad(building);
                        // building_g = false;

                        // hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_g";
                        player_tiles_onego.Add(hit.collider.gameObject);
                        // variable.money -= 70;
                        money_onego += 70;
                        // money.text = variable.money.ToString();

                        player_tiles_onego.Add(hit.collider.gameObject);
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
                        hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                        // GameObject building=Instantiate(prefab_buildingG,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;
                        // GameObject.DontDestroyOnLoad(building);
                        // building_g = false;

                        // hit.collider.gameObject.GetComponent<tile_individual>().building_placed = "building_g";

                        // variable.money -= 70;
                        money_onego += 70;
                        // money.text = variable.money.ToString();
                        player_tiles_onego.Add(hit.collider.gameObject);

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

    public void confirm_tile()
    {
        if(money_onego > variable.money)
        {
            cancel_tile();
            Insufficient_balance.SetActive(true);
        }
        if (is_tile == true)
        {
            is_tile = false;
            foreach (GameObject g in player_tiles_onego)
            {
                g.GetComponent<SpriteRenderer>().color = Color.green;

                if (g.transform.parent.gameObject.name == "Luxury")
                {

                    if (variable.tiles_bought.ContainsKey("Luxury"))
                    {
                        variable.tiles_bought["Luxury"].Add(g.name);
                    }
                    else
                    {
                        variable.tiles_bought.Add("Luxury", new List<string> { g.name });
                    }
                }
                else if (g.transform.parent.gameObject.name == "Alleyway")
                {
                    if (variable.tiles_bought.ContainsKey("Alleyway"))
                    {
                        variable.tiles_bought["Alleyway"].Add(g.name);
                    }
                    else
                    {
                        variable.tiles_bought.Add("Alleyway", new List<string> { g.name });
                    }
                }
                else if (g.transform.parent.gameObject.name == "Street")
                {
                    if (variable.tiles_bought.ContainsKey("Street"))
                    {
                        variable.tiles_bought["Street"].Add(g.name);
                    }
                    else
                    {
                        variable.tiles_bought.Add("Street", new List<string> { g.name });
                    }
                }
            }
            variable.money -= money_onego;
            money.text = variable.money.ToString();
            money_onego = 0;
            building_f = false;
            building_g = false;
            player_tiles_onego.Clear();
        }
        else if (building_f == true)
        {

            foreach (GameObject g in player_tiles_onego)
            {
                g.GetComponent<SpriteRenderer>().color = Color.green;
                GameObject building = Instantiate(prefab_buildingF, new Vector2(g.transform.position.x, g.transform.position.y), Quaternion.identity) as GameObject;
                GameObject.DontDestroyOnLoad(building);
                g.GetComponent<tile_individual>().building_placed = "building_f";
                if (g.transform.parent.gameObject.name == "Luxury")
                {

                    if (!variable.location_check.Contains(g.name))
                    {
                        variable.location_check.Add(g.name);
                    }

                    if (variable.Luxury_building.ContainsKey("f"))
                    {
                        variable.Luxury_building["f"].Add(g.name);
                    }
                    else
                    {
                        variable.Luxury_building.Add("f", new List<string> { g.name });
                    }
                }
                else if (g.transform.parent.gameObject.name == "Alleyway")
                {
                    if (!variable.location_check.Contains(g.name))
                    {
                        variable.location_check.Add(g.name);
                    }

                    if (variable.Alleyway_building.ContainsKey("f"))
                    {
                        variable.Alleyway_building["f"].Add(g.name);
                    }
                    else
                    {
                        variable.Alleyway_building.Add("f", new List<string> { g.name });
                    }

                }
                else if (g.transform.parent.gameObject.name == "Street")
                {
                    if (!variable.location_check.Contains(g.name))
                    {
                        variable.location_check.Add(g.name);
                    }

                    if (variable.Street_building.ContainsKey("f"))
                    {
                        variable.Street_building["f"].Add(g.name);
                    }
                    else
                    {
                        variable.Street_building.Add("f", new List<string> { g.name });
                    }
                }

            }
            variable.money -= money_onego;
            money.text = variable.money.ToString();
            player_tiles_onego.Clear();
            money_onego = 0;
            building_f = false;
            building_g = false;
            is_tile = false;
        }
        else if (building_g == true)
        {
            foreach (GameObject g in player_tiles_onego)
            {
                g.GetComponent<SpriteRenderer>().color = Color.green;
                g.GetComponent<tile_individual>().building_placed = "building_g";
                GameObject building = Instantiate(prefab_buildingG, new Vector2(g.transform.position.x, g.transform.position.y), Quaternion.identity) as GameObject;
                GameObject.DontDestroyOnLoad(building);
                if (g.transform.parent.gameObject.name == "Luxury")
                {

                    if (!variable.location_check.Contains(g.name))
                    {
                        variable.location_check.Add(g.name);
                    }

                    if (variable.Luxury_building.ContainsKey("g"))
                    {
                        variable.Luxury_building["g"].Add(g.name);
                    }
                    else
                    {
                        variable.Luxury_building.Add("g", new List<string> { g.name });
                    }
                }
                else if (g.transform.parent.gameObject.name == "Alleyway")
                {
                    if (!variable.location_check.Contains(g.name))
                    {
                        variable.location_check.Add(g.name);
                    }

                    if (variable.Alleyway_building.ContainsKey("g"))
                    {
                        variable.Alleyway_building["g"].Add(g.name);
                    }
                    else
                    {
                        variable.Alleyway_building.Add("g", new List<string> { g.name });
                    }

                }
                else if (g.transform.parent.gameObject.name == "Street")
                {
                    if (!variable.location_check.Contains(g.name))
                    {
                        variable.location_check.Add(g.name);
                    }

                    if (variable.Street_building.ContainsKey("g"))
                    {
                        variable.Street_building["g"].Add(g.name);
                    }
                    else
                    {
                        variable.Street_building.Add("g", new List<string> { g.name });
                    }
                }

            }
            variable.money -= money_onego;
            money.text = variable.money.ToString();
            player_tiles_onego.Clear();
            money_onego = 0;
            building_g = false;
            is_tile = false;
            building_f = false;
        }
        if (ConfirmPanel != null)
        {
            ConfirmPanel.SetActive(false);
        }
    }
    public void cancel_tile()
    {
        if (is_tile == true)
        {
            if (player_tiles_onego.Count != 0)
            {
                foreach (GameObject g in player_tiles_onego)
                {
                    g.GetComponent<SpriteRenderer>().color = Color.red;
                }
                player_tiles_onego.Clear();
            }
            is_tile = false;
            building_g = false;
            building_f = false;
            player_tiles_onego.Clear();
            money.text = variable.money.ToString();
            money_onego = 0;
        }
        else if (building_f == true)
        {
            if (player_tiles_onego.Count != 0)
            {
                foreach (GameObject g in player_tiles_onego)
                {
                    g.GetComponent<SpriteRenderer>().color = Color.green;
                }
                // variable.money += money_onego;
                player_tiles_onego.Clear();
                money_onego = 0;
                money.text = variable.money.ToString();
                building_f = false;

            }
        }
        else if (building_g == true)
        {
            if (player_tiles_onego.Count != 0)
            {
                foreach (GameObject g in player_tiles_onego)
                {
                    g.GetComponent<SpriteRenderer>().color = Color.green;
                }
                // variable.money += money_onego;
                player_tiles_onego.Clear();
                money_onego = 0;
                building_g = false;
                money.text = variable.money.ToString();
            }
        }
        if (ConfirmPanel != null)
        {
            ConfirmPanel.SetActive(false);
        }
    }
}
