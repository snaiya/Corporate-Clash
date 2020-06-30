using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    // private Vector3 screenBounds;
    
    public GameObject consumer;
    public GameObject[] animation_consumer = new GameObject[15];

    public Vector3[] position_of_consumer = new Vector3[6];
    public float time=3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        //Leftmost horizontal
        position_of_consumer[0] = new Vector3(-54.40446f,3.530338f,-1.22861f);
        //Rightmost horizontal
        position_of_consumer[1] = new Vector3(21.0f,2f,-1.22861f);
        //Below of top Alleyway horizontal
        position_of_consumer[2] = new Vector3(-23.60f,15.9303f,-1.22861f);
        //Above ,bottom Alleyway horizontal
        position_of_consumer[3] = new Vector3(-23.60f,-15.9303f,-1.22861f);

        // position_of_consumer[4] = new Vector3(0.5955334f,3.530338f,-1.22861f);
        // position_of_consumer[5] = new Vector3(0.5955334f,3.530338f,-1.22861f);

        clusters c1 = new clusters();
        c1.assign_bots_to_area();

        variable.updateBuildingCount();

        salesreport.countBuildingTypes();

        popualteSalesReport();

        for(int i =0 ;i<4;i++)
        {
            GameObject c = Instantiate(consumer) as GameObject;
            c.transform.position = position_of_consumer[i];
            animation_consumer[i]=c;
        }
        

        


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
        
        variable.money = variable.money + salesreport.total_profit;
        GameObject balance = GameObject.Find("Totalbalance");
        balance.GetComponent<TextMeshProUGUI>().text = (variable.money).ToString();
        
    }

   
    // Update is called once per frame
    void Update()
    {
        
                Vector3 p = new Vector3();
                p = animation_consumer[0].GetComponent<Transform>().position;
              
                //Left to right (leftmost )

                p =Horizontal_animation(p,-41.00447f,-54.40446f);
                animation_consumer[0].GetComponent<Transform>().position=p;
                
                
         
    }
    int flag =0;
    public Vector3 Horizontal_animation(Vector3 v,float xmax,float xmin)
    {
                
                float temp = v.x;
                
                if(v.x<=xmax && flag==0 )
                    v.x ++;
                if((temp-v.x)==0)
                {
                    //Debug.Log("Flag switched");
                    flag = 1;
                    v.x--;
                }
                if(v.x>=xmin && flag ==1)
                {
                    v.x--;
                }
                if(v.x == xmin)
                {
                    flag = 0;
                    v.x++;
                }
                return v;
    }

    public void MoveX_Right()
    {
        
    }
}

