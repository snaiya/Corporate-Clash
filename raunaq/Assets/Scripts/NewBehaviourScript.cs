using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NewBehaviourScript : MonoBehaviour
{
    // private Vector3 screenBounds;
    public GameObject consumer;
    public float time =10.0f;
    // Start is called before the first frame update
	
    void Start()
    {
         GameObject board = GameObject.Find("Tiles");
        for(int i =0 ; i<15;i++){
             GameObject c = Instantiate(consumer) as GameObject;
             c.transform.position = new Vector2(Random.Range(-45.0f,40.0f),Random.Range(-39.0f,33.0f));
        }
		
		//clusters c1 = new clusters();
		//c1.assign_bots_to_area();
		//variable.updateBuildingCount();
		//salesreport.countBuildingTypes();
		//popualteSalesReport();
		
        

    }
	public static void popualteSalesReport()
	{
		GameObject luxury_f = GameObject.Find("Luxury_F");
		luxury_f.GetComponent<TextMeshProUGUI>().text = salesreport.NetProfit["Luxury_F"].ToString();
		
		GameObject luxury_g = GameObject.Find("Luxury_G");
		luxury_g.GetComponent<TextMeshProUGUI>().text = salesreport.NetProfit["Luxury_G"].ToString();
		
		GameObject alleyway_f = GameObject.Find("Alleyway_F");
		alleyway_f.GetComponent<TextMeshProUGUI>().text = salesreport.NetProfit["Alleyway_F"].ToString();
		
		GameObject alleyway_g = GameObject.Find("Alleyway_G");
		alleyway_g.GetComponent<TextMeshProUGUI>().text = salesreport.NetProfit["Alleyway_G"].ToString();
		
		GameObject street_f = GameObject.Find("Street_F");
		street_f.GetComponent<TextMeshProUGUI>().text = salesreport.NetProfit["Street_F"].ToString();
		
		GameObject street_g = GameObject.Find("Street_G");
		street_g.GetComponent<TextMeshProUGUI>().text = salesreport.NetProfit["Street_G"].ToString();
		
		GameObject netprofit = GameObject.Find("Netprofit");
		netprofit.GetComponent<TextMeshProUGUI>().text = salesreport.total_profit.ToString();
		
		GameObject balance = GameObject.Find("Totalbalance");
		int temp = salesreport.total_profit + variable.money;
		balance.GetComponent<TextMeshProUGUI>().text = temp.ToString();
		
	}
	
   
   
    // Update is called once per frame
    void Update()
    {
        
        }
}

